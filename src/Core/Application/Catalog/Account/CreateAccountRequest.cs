using FSH.WebApi.Domain.Catalog;
using FSH.WebApi.Domain.Common.Events;
using FSH.WebApi.Domain.Catalog;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application;
public class CreateAccountRequest : IRequest<Guid>
{
    public string? Topic { get; set; }
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }
    public string? Designation { get; set; }

    public string? BusinessPhone { get; set; }
    public string? Website { get; set; }
    public string? MobilePhone { get; set; }

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

}

public class CreateAccountRequestHandler : IRequestHandler<CreateAccountRequest, Guid>
{
    private readonly IRepository<Account> _repository;
    private readonly IRepository<AccountSkill> _skillrepository;
    private readonly IRepository<AccountSubSkill> _subskillrepository;
    private readonly IRepository<AccountSalesCoordinator> _accountsalesCoordinator;
    private readonly IRepository<AccountTechnicalCoordinator> _accounttechCoordinator;
    private readonly IRepository<AccountMedia> _accountMedia;
    private readonly IUploadService _file;

    public CreateAccountRequestHandler(IRepository<Account> repository, IUploadService file, IRepository<AccountSkill> skillrepository, IRepository<AccountSubSkill> subskillrepository, IRepository<AccountSalesCoordinator> accountsalesCoordinator, IRepository<AccountTechnicalCoordinator> accounttechCoordinator, IRepository<AccountMedia> accountMedia) =>
        (_repository, _file, _skillrepository, _subskillrepository, _accountsalesCoordinator, _accounttechCoordinator, _accountMedia) = (repository, file, skillrepository, subskillrepository, accountsalesCoordinator, accounttechCoordinator, accountMedia);

    public async Task<Guid> Handle(CreateAccountRequest request, CancellationToken cancellationToken)
    {
        var account = new Account(request.Topic, request.FirstName, request.LastName, request.Email, request.BusinessPhone, request.MobilePhone, request.JobDescription, request.CountryId, request.StateId, request.CityId, request.TimeZone, request.AccountSourceId, request.AccountStatus, request.FreeTrialOffered, request.PrefferedShift, request.NumberOfResources, request.ExpectedStartDate, request.DomainORIndustry, request.Budget, request.Rating, request.AccountType, request.NDAShared, request.NDASharedOn, request.TechnicalCoordinatorStatus, request.Website, request.Designation, request.Company, request.CompanyAddress1, request.CompanyAddress2, request.CompanyPostalCode, request.CompanyAnnualRevenue, request.CompanyNumberofEmployees, request.PreferredContactMethod, request.FollowEmail, request.DoNotEmail, request.DoNotBulkEmail, request.DoNotPhone);

        // Add Domain Events to be raised after the commit
        account.DomainEvents.Add(EntityCreatedEvent.WithEntity(account));
        await _repository.AddAsync(account, cancellationToken);

        if (request.SkillsIds is not null && request.SkillsIds.Length > 0)
        {
            foreach (var skill in request.SkillsIds)
            {
                await _skillrepository.AddAsync(new AccountSkill()
                {
                    AccountId = account.Id,
                    SkillId = skill
                });
            }
        }

        if (request.SubSkillsIds is not null && request.SubSkillsIds.Length > 0)
        {
            foreach (var subskill in request.SubSkillsIds)
            {
                await _subskillrepository.AddAsync(new AccountSubSkill()
                {
                    AccountId = account.Id,
                    SubSkillId = subskill
                });
            }
        }

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

        return account.Id;
    }

}