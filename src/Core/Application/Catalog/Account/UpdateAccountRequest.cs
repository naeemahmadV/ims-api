using FSH.WebApi.Domain.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application;
public class UpdateAccountRequest : IRequest<Guid>
{

    public Guid Id { get; set; }
    public string? Topic { get; set; }
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }
    public string? Designation { get; set; }
    public string? BusinessPhone { get; set; }

    public string? MobilePhone { get; set; }
    public string? Website { get; set; }
    public string? JobDescription { get; set; }

    public Guid? CountryId { get; set; }

    public Guid? StateId { get; set; }

    public Guid? CityId { get; set; }

    public string? TimeZone { get; set; }

    public Guid? AccountSourceId { get; set; }

    public string? AccountStatus { get; set; }

    public bool FreeTrialOffered { get; set; }

    public string? PrefferedShift { get; set; }

    public int NumberOfResources { get; set; }

    public DateTime? ExpectedStartDate { get; set; }

    public string? DomainORIndustry { get; set; }
    public Guid[]? SkillsIds { get; set; }
    public Guid[]? SubSkillsIds { get; set; }
    public Guid[]? SalesCoordinaotrs { get; set; }
    public Guid[]? TechCoordinaotrs { get; set; }
    public Guid[]? AccountMedia { get; set; }

    public int Budget { get; set; }

    public int Rating { get; set; }

    public string? AccountType { get; set; }

    public bool NDAShared { get; set; }

    public DateTime? NDASharedOn { get; set; }

    public string? TechnicalCoordinatorStatus { get; set; }
    public string? Company { get; set; }
    public string? CompanyAddress1 { get; set; }
    public string? CompanyAddress2 { get; set; }
    public string? CompanyPostalCode { get; set; }
    public string? CompanyAnnualRevenue { get; set; }
    public int? CompanyNumberofEmployees { get; set; }
    public int? PreferredContactMethod { get; set; }
    public bool? FollowEmail { get; set; }
    public bool? DoNotEmail { get; set; }
    public bool? DoNotBulkEmail { get; set; }
    public bool? DoNotPhone { get; set; }
    //public bool? MarkAsQualified { get; set; }

    //public DateTime? QualifiedOn { get; set; }

    //public Guid QualifiedBy { get; set; }
}

public class UpdateAccountRequestHandler : IRequestHandler<UpdateAccountRequest, Guid>
{
    private readonly IRepository<Account> _repository;
    private readonly IStringLocalizer<UpdateAccountRequestHandler> _localizer;
    private readonly IUploadService _file;
    private readonly IRepository<AccountSkill> _skillrepository;
    private readonly IRepository<AccountSubSkill> _subskillrepository;
    private readonly IRepository<AccountSalesCoordinator> _accountsalesCoordinator;
    private readonly IRepository<AccountTechnicalCoordinator> _accounttechCoordinator;
    private readonly IRepository<AccountMedia> _accountMedia;
    public UpdateAccountRequestHandler(IRepository<Account> repository, IStringLocalizer<UpdateAccountRequestHandler> localizer, IUploadService file, IRepository<AccountSkill> skillrepository, IRepository<AccountSubSkill> subskillrepository, IRepository<AccountSalesCoordinator> accountsalesCoordinator, IRepository<AccountTechnicalCoordinator> accounttechCoordinator, IRepository<AccountMedia> accountMedia) =>
        (_repository, _localizer, _file, _skillrepository, _subskillrepository, _accountsalesCoordinator, _accounttechCoordinator, _accountMedia) = (repository, localizer, file, skillrepository, subskillrepository, accountsalesCoordinator, accounttechCoordinator, accountMedia);

    public async Task<Guid> Handle(UpdateAccountRequest request, CancellationToken cancellationToken)
    {
        var account = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = account ?? throw new NotFoundException(string.Format(_localizer["account.notfound"], request.Id));

        var updatedSubSkill = account.Update(request.Topic, request.FirstName, request.LastName, request.Email, request.BusinessPhone, request.MobilePhone, request.JobDescription, request.CountryId, request.StateId, request.CityId, request.TimeZone, request.AccountSourceId, request.AccountStatus, request.FreeTrialOffered, request.PrefferedShift, request.NumberOfResources, request.ExpectedStartDate, request.DomainORIndustry, request.Budget, request.Rating, request.AccountType, request.NDAShared, request.NDASharedOn, request.TechnicalCoordinatorStatus, request.Website, request.Designation, request.Company, request.CompanyAddress1, request.CompanyAddress2, request.CompanyPostalCode, request.CompanyAnnualRevenue, request.CompanyNumberofEmployees, request.PreferredContactMethod, request.FollowEmail, request.DoNotEmail, request.DoNotBulkEmail, request.DoNotPhone);

        // Add Domain Events to be raised after the commit
        account.DomainEvents.Add(EntityUpdatedEvent.WithEntity(account));

        await _repository.UpdateAsync(updatedSubSkill, cancellationToken);

        if (request.SkillsIds is not null && request.SkillsIds.Length > 0)
        {
            var accountSkillsRequest = new AccountSkillsRequest()
            {
                AccountId = account.Id
            };

            var accountspec = new AccountSkillsSpecification(accountSkillsRequest);

            var accountSkills = await _skillrepository.ListAsync(accountspec, cancellationToken);

            if (accountSkills.Count > 0)
                await _skillrepository.DeleteRangeAsync(accountSkills);

            foreach (var skill in request.SkillsIds)
            {
                await _skillrepository.AddAsync(new AccountSkill()
                {
                    AccountId = account.Id,
                    SkillId = skill
                });
            }
        }

        var subSkillpec = new AccountSubSkillsSpecification(new AccountSubSkillsRequest()
        {
            AccountId = account.Id
        });

        var accountSubSkills = await _subskillrepository.ListAsync(subSkillpec, cancellationToken);

        if (accountSubSkills.Count() > 0)
            await _subskillrepository.DeleteRangeAsync(accountSubSkills);

        if (request.SubSkillsIds is not null && request.SubSkillsIds.Length > 0)
        {
            foreach (var subSkill in request.SubSkillsIds)
            {
                await _subskillrepository.AddAsync(new AccountSubSkill()
                {
                    AccountId = account.Id,
                    SubSkillId = subSkill
                });
            }
        }

        var salesCoordinaotrsspec = new AccountSalesCoordinaotrsSpecification(new AccountSalesCoordinaotrsRequest()
        {
            AccountId = account.Id
        });

        var salesCoordinaotrs = await _accountsalesCoordinator.ListAsync(salesCoordinaotrsspec, cancellationToken);

        if (salesCoordinaotrs.Count() > 0)
            await _accountsalesCoordinator.DeleteRangeAsync(salesCoordinaotrs);

        if (request.SalesCoordinaotrs is not null && request.SalesCoordinaotrs.Length > 0)
        {
            foreach (var coordinator in request.SalesCoordinaotrs)
            {
                await _accountsalesCoordinator.AddAsync(new AccountSalesCoordinator()
                {
                    AccountId = account.Id,
                    UserId = coordinator
                });
            }
        }

        if (request.TechCoordinaotrs is not null && request.TechCoordinaotrs.Length > 0)
        {
            foreach (var coordinator in request.TechCoordinaotrs)
            {
                await _accounttechCoordinator.AddAsync(new AccountTechnicalCoordinator()
                {
                    AccountId = account.Id,
                    UserId = coordinator
                });
            }
        }

        var accountMediasspec = new AccontMediaSpecification(new AccountMediaRequest()
        {
            AccountId = account.Id
        });

        var accountMedias = await _accountMedia.ListAsync(accountMediasspec, cancellationToken);

        if (accountMedias.Count() > 0)
            await _accountMedia.DeleteRangeAsync(accountMedias);

        if (request.AccountMedia is not null && request.AccountMedia.Length > 0)
        {
            foreach (var media in request.AccountMedia)
            {
                await _accountMedia.AddAsync(new AccountMedia()
                {
                    AccountId = account.Id,
                    MediaId = media
                });
            }
        }

        return request.Id;
    }

    public class AccountSkillsSpecification : EntitiesByBaseFilterSpec<AccountSkill, AccountSkill>
    {
        public AccountSkillsSpecification(AccountSkillsRequest request)
            : base(request) =>
            Query
                .Where(p => p.AccountId == request.AccountId);
    }

    public class AccountSkillsRequest : BaseFilter
    {
        public Guid AccountId { get; set; }
    }

    public class AccountSubSkillsSpecification : EntitiesByBaseFilterSpec<AccountSubSkill, AccountSubSkill>
    {
        public AccountSubSkillsSpecification(AccountSubSkillsRequest request)
            : base(request) =>
            Query
                .Where(p => p.AccountId == request.AccountId);
    }

    public class AccountSubSkillsRequest : BaseFilter
    {
        public Guid AccountId { get; set; }
    }

    public class AccountSalesCoordinaotrsSpecification : EntitiesByBaseFilterSpec<AccountSalesCoordinator, AccountSalesCoordinator>
    {
        public AccountSalesCoordinaotrsSpecification(AccountSalesCoordinaotrsRequest request)
            : base(request) =>
            Query
                .Where(p => p.AccountId == request.AccountId);
    }

    public class AccountSalesCoordinaotrsRequest : BaseFilter
    {
        public Guid AccountId { get; set; }
    }

    public class AccontMediaSpecification : EntitiesByBaseFilterSpec<AccountMedia, AccountMedia>
    {
        public AccontMediaSpecification(AccountMediaRequest request)
            : base(request) =>
            Query
                .Where(p => p.AccountId == request.AccountId);
    }

    public class AccountMediaRequest : BaseFilter
    {
        public Guid AccountId { get; set; }
    }
}
