using FSH.WebApi.Application.Catalog.Products;
using FSH.WebApi.Domain.Catalog;
using FSH.WebApi.Domain.Common.Events;
using static FSH.WebApi.Application.CreateLeadRequestHandler;
using static FSH.WebApi.Application.UpdateLeadRequestHandler;

namespace FSH.WebApi.Application;

public class UpdateLeadRequest : IRequest<Guid>
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

    public Guid? LeadSourceId { get; set; }

    public string? LeadStatus { get; set; }

    public bool FreeTrialOffered { get; set; }

    public string? PrefferedShift { get; set; }

    public int NumberOfResources { get; set; }

    public DateTime? ExpectedStartDate { get; set; }

    public string? DomainORIndustry { get; set; }
    public Guid[]? SkillsIds { get; set; }
    public Guid[]? SubSkillsIds { get; set; }
    public Guid[]? SalesCoordinaotrs { get; set; }
    public Guid[]? TechCoordinaotrs { get; set; }
    public Guid[]? LeadMedia { get; set; }

    public int Budget { get; set; }

    public int Rating { get; set; }

    public string? LeadType { get; set; }

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
    public bool? MarkAsQualified { get; set; }

    public DateTime? QualifiedOn { get; set; }

    public Guid QualifiedBy { get; set; }

}

public class UpdateLeadRequestHandler : IRequestHandler<UpdateLeadRequest, Guid>
{
    private readonly IRepository<Lead> _repository;
    private readonly IStringLocalizer<UpdateLeadRequestHandler> _localizer;
    private readonly IUploadService _file;
    private readonly IRepository<LeadSkill> _skillrepository;
    private readonly IRepository<LeadSubSkill> _subskillrepository;
    private readonly IRepository<SalesCoordinator> _salesCoordinator;
    private readonly IRepository<TechnicalCoordinator> _techCoordinator;
    private readonly IRepository<LeadMedia> _leadMedia;
    public UpdateLeadRequestHandler(IRepository<Lead> repository, IStringLocalizer<UpdateLeadRequestHandler> localizer, IUploadService file, IRepository<LeadSkill> skillrepository, IRepository<LeadSubSkill> subskillrepository, IRepository<SalesCoordinator> salesCoordinator, IRepository<TechnicalCoordinator> techCoordinator, IRepository<LeadMedia> leadMedia) =>
        (_repository, _localizer, _file, _skillrepository, _subskillrepository, _salesCoordinator, _techCoordinator, _leadMedia) = (repository, localizer, file, skillrepository, subskillrepository, salesCoordinator, techCoordinator, leadMedia);

    public async Task<Guid> Handle(UpdateLeadRequest request, CancellationToken cancellationToken)
    {
        var lead = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = lead ?? throw new NotFoundException(string.Format(_localizer["lead.notfound"], request.Id));

        var updatedSubSkill = lead.Update(request.Topic, request.FirstName, request.LastName, request.Email, request.BusinessPhone, request.MobilePhone, request.JobDescription, request.CountryId, request.StateId, request.CityId, request.TimeZone, request.LeadSourceId, request.LeadStatus, request.FreeTrialOffered, request.PrefferedShift, request.NumberOfResources, request.ExpectedStartDate, request.DomainORIndustry, request.Budget, request.Rating, request.LeadType, request.NDAShared, request.NDASharedOn, request.TechnicalCoordinatorStatus, request.Website, request.Designation, request.Company, request.CompanyAddress1, request.CompanyAddress2, request.CompanyPostalCode, request.CompanyAnnualRevenue, request.CompanyNumberofEmployees, request.PreferredContactMethod, request.FollowEmail, request.DoNotEmail, request.DoNotBulkEmail, request.DoNotPhone,request.MarkAsQualified,request.QualifiedOn,request.QualifiedBy);

        // Add Domain Events to be raised after the commit
        lead.DomainEvents.Add(EntityUpdatedEvent.WithEntity(lead));

        await _repository.UpdateAsync(updatedSubSkill, cancellationToken);

        if (request.SkillsIds is not null && request.SkillsIds.Length > 0)
        {
            var leadSkillsRequest = new LeadSkillsRequest()
            {
                LeadId = lead.Id
            };

            var leadspec = new LeadSkillsSpecification(leadSkillsRequest);

            var leadSkills = await _skillrepository.ListAsync(leadspec, cancellationToken);

            if (leadSkills.Count > 0)
                    await _skillrepository.DeleteRangeAsync(leadSkills);

            foreach (var skill in request.SkillsIds)
            {
                    await _skillrepository.AddAsync(new LeadSkill()
                    {
                        LeadId = lead.Id,
                        SkillId = skill
                    });
            }
        }

        var subSkillpec = new LeadSubSkillsSpecification(new LeadSubSkillsRequest()
        {
            LeadId = lead.Id
        });

        var leadSubSkills = await _subskillrepository.ListAsync(subSkillpec, cancellationToken);

        if (leadSubSkills.Count() > 0)
                await _subskillrepository.DeleteRangeAsync(leadSubSkills);

        if (request.SubSkillsIds is not null && request.SubSkillsIds.Length > 0)
        {
            foreach (var subSkill in request.SubSkillsIds)
            {
                await _subskillrepository.AddAsync(new LeadSubSkill()
                {
                    LeadId = lead.Id,
                    SubSkillId = subSkill
                });
            }
        }

        var salesCoordinaotrsspec = new LeadSalesCoordinaotrsSpecification(new LeadSalesCoordinaotrsRequest()
        {
            LeadId = lead.Id
        });

        var salesCoordinaotrs = await _salesCoordinator.ListAsync(salesCoordinaotrsspec, cancellationToken);

        if (salesCoordinaotrs.Count() > 0)
            await _salesCoordinator.DeleteRangeAsync(salesCoordinaotrs);

        if (request.SalesCoordinaotrs is not null && request.SalesCoordinaotrs.Length > 0)
        {
            foreach (var coordinator in request.SalesCoordinaotrs)
            {
                await _salesCoordinator.AddAsync(new SalesCoordinator()
                {
                    LeadId = lead.Id,
                    UserId = coordinator
                });
            }
        }

        if (request.TechCoordinaotrs is not null && request.TechCoordinaotrs.Length > 0)
        {
            foreach (var coordinator in request.TechCoordinaotrs)
            {
                await _techCoordinator.AddAsync(new TechnicalCoordinator()
                {
                    LeadId = lead.Id,
                    UserId = coordinator
                });
            }
        }

        var leadMediasspec = new LeadMediaSpecification(new LeadMediaRequest()
        {
            LeadId = lead.Id
        });

        var leadMedias = await _leadMedia.ListAsync(leadMediasspec, cancellationToken);

        if (leadMedias.Count() > 0)
            await _leadMedia.DeleteRangeAsync(leadMedias);

        if (request.LeadMedia is not null && request.LeadMedia.Length > 0)
        {
            foreach (var media in request.LeadMedia)
            {
                await _leadMedia.AddAsync(new LeadMedia()
                {
                    LeadId = lead.Id,
                    MediaId = media
                });
            }
        }

        return request.Id;
    }

    public class LeadSkillsSpecification : EntitiesByBaseFilterSpec<LeadSkill, LeadSkill>
    {
        public LeadSkillsSpecification(LeadSkillsRequest request)
            : base(request) =>
            Query
                .Where(p => p.LeadId == request.LeadId);
    }

    public class LeadSkillsRequest : BaseFilter
    {
        public Guid LeadId { get; set; }
    }

    public class LeadSubSkillsSpecification : EntitiesByBaseFilterSpec<LeadSubSkill, LeadSubSkill>
    {
        public LeadSubSkillsSpecification(LeadSubSkillsRequest request)
            : base(request) =>
            Query
                .Where(p => p.LeadId == request.LeadId);
    }

    public class LeadSubSkillsRequest : BaseFilter
    {
        public Guid LeadId { get; set; }
    }

    public class LeadSalesCoordinaotrsSpecification : EntitiesByBaseFilterSpec<SalesCoordinator, SalesCoordinator>
    {
        public LeadSalesCoordinaotrsSpecification(LeadSalesCoordinaotrsRequest request)
            : base(request) =>
            Query
                .Where(p => p.LeadId == request.LeadId);
    }

    public class LeadSalesCoordinaotrsRequest : BaseFilter
    {
        public Guid LeadId { get; set; }
    }

    public class LeadMediaSpecification : EntitiesByBaseFilterSpec<LeadMedia, LeadMedia>
    {
        public LeadMediaSpecification(LeadMediaRequest request)
            : base(request) =>
            Query
                .Where(p => p.LeadId == request.LeadId);
    }

    public class LeadMediaRequest : BaseFilter
    {
        public Guid LeadId { get; set; }
    }
}
