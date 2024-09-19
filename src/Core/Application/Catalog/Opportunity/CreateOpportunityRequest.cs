using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.Catalog.Opportunity;
public class CreateOpportunityRequest : IRequest<Guid>
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

    public Guid? LeadId { get; set; }

    public string? TimeZone { get; set; }

    public Guid? OpportunitySourceId { get; set; }

    public string? OpportunityStatus { get; set; }

    public bool FreeTrialOffered { get; set; }

    public string? PrefferedShift { get; set; }

    public int NumberOfResources { get; set; }

    public DateTime? ExpectedStartDate { get; set; }

    public string? DomainORIndustry { get; set; }
    public Guid[]? SkillsIds { get; set; }
    public Guid[]? SubSkillsIds { get; set; }
    public Guid[]? SalesCoordinaotrs { get; set; }
    public Guid[]? TechCoordinaotrs { get; set; }
    public Guid[]? OpportunityMedia { get; set; }

    public int Budget { get; set; }

    public int Rating { get; set; }

    public string? OpportunityType { get; set; }

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

    public bool? OpportunityWon { get; set; }
    public bool? OpportunityLost { get; set; }
}

public class CreateOpportunityRequestHandler : IRequestHandler<CreateOpportunityRequest, Guid>
{
    private readonly IRepository<Domain.Catalog.Opportunity> _repository;
    private readonly IRepository<OpportunitySkill> _skillRepository;
    private readonly IRepository<OpportunitySubSkill> _subskillRepository;
    private readonly IRepository<OpportunitySalesCoordinator> _salesCoordinator;
    private readonly IRepository<OpportunityTechnicalCoordinator> _technicalCoordinator;
    private readonly IRepository<OpportunityMedia> _mediaRepository;
    private readonly IUploadService _uploadService;

    public CreateOpportunityRequestHandler(IRepository<Domain.Catalog.Opportunity> repository, IRepository<OpportunitySkill> skillRepository, IRepository<OpportunitySubSkill> subskillRepository, IRepository<OpportunitySalesCoordinator> salesCoordinator, IRepository<OpportunityTechnicalCoordinator> technicalCoordinator, IRepository<OpportunityMedia> mediaRepository, IUploadService uploadService)
    {
        _repository = repository;
        _skillRepository = skillRepository;
        _subskillRepository = subskillRepository;
        _salesCoordinator = salesCoordinator;
        _technicalCoordinator = technicalCoordinator;
        _mediaRepository = mediaRepository;
        _uploadService = uploadService;
    }

    public async Task<DefaultIdType> Handle(CreateOpportunityRequest request, CancellationToken cancellationToken)
    {
        var opportunity = new Domain.Catalog.Opportunity(request.Topic, request.FirstName, request.LastName, request.Email, request.BusinessPhone, request.MobilePhone, request.JobDescription, request.CountryId, request.StateId, request.CityId, request.LeadId, request.TimeZone, request.OpportunitySourceId, request.OpportunityStatus, request.FreeTrialOffered, request.PrefferedShift, request.NumberOfResources, request.ExpectedStartDate, request.DomainORIndustry, request.Budget, request.Rating, request.OpportunityType, request.NDAShared, request.NDASharedOn, request.TechnicalCoordinatorStatus, request.Website, request.Designation, request.Company, request.CompanyAddress1, request.CompanyAddress2, request.CompanyPostalCode, request.CompanyAnnualRevenue, request.CompanyNumberofEmployees, request.PreferredContactMethod, request.FollowEmail, request.DoNotEmail, request.DoNotBulkEmail, request.DoNotPhone, request.OpportunityWon, request.OpportunityLost);

        opportunity.DomainEvents.Add(EntityCreatedEvent.WithEntity(opportunity));

        await _repository.AddAsync(opportunity, cancellationToken);

        if(request.SkillsIds is not null & request.SkillsIds.Length > 0)
        {
            foreach(var skill in request.SkillsIds)
            {
                await _skillRepository.AddAsync(new OpportunitySkill
                {
                    SkillId = skill,
                    OpportunityId = opportunity.Id
                });
            }
        }

        if(request.SubSkillsIds is not null && request.SubSkillsIds.Length > 0)
        {
            foreach(var subSkill in request.SubSkillsIds)
            {
                await _subskillRepository.AddAsync(new OpportunitySubSkill
                {
                    SubSkillId = subSkill,
                    OpportunityId = opportunity.Id
                });
            }
        }

        if(request.SalesCoordinaotrs is not null && request.SalesCoordinaotrs.Length > 0)
        {
            foreach(var salesCoordinator in request.SalesCoordinaotrs)
            {
                await _salesCoordinator.AddAsync(new OpportunitySalesCoordinator
                {
                    OpportunityId = opportunity.Id,
                    UserId = salesCoordinator
                });
            }
        }

        if(request.TechCoordinaotrs is not null && request.TechCoordinaotrs.Length > 0)
        {
            foreach(var technicalCoordinator in request.TechCoordinaotrs)
            {
                await _technicalCoordinator.AddAsync(new OpportunityTechnicalCoordinator
                {
                    OpportunityId = opportunity.Id,
                    UserId = technicalCoordinator
                });
            }
        }

        if(request.OpportunityMedia is not null && request.OpportunityMedia.Length > 0)
        {
            foreach(var media in request.OpportunityMedia)
            {
                await _mediaRepository.AddAsync(new OpportunityMedia
                {
                    OpportunityId = opportunity.Id,
                    MediaId = media
                });
            }
        }

        return opportunity.Id;
    }
}
