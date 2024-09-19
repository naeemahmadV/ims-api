using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application;
public class CreateLeadRequest : IRequest<Guid>
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

public class CreateLeadRequestHandler : IRequestHandler<CreateLeadRequest, Guid>
{
    private readonly IRepository<Lead> _repository;
    private readonly IRepository<LeadSkill> _skillrepository;
    private readonly IRepository<LeadSubSkill> _subskillrepository;
    private readonly IRepository<SalesCoordinator> _salesCoordinator;
    private readonly IRepository<TechnicalCoordinator> _techCoordinator;
    private readonly IRepository<LeadMedia> _leadMedia;
    private readonly IUploadService _file;

    public CreateLeadRequestHandler(IRepository<Lead> repository, IUploadService file, IRepository<LeadSkill> skillrepository, IRepository<LeadSubSkill> subskillrepository, IRepository<SalesCoordinator> salesCoordinator, IRepository<TechnicalCoordinator> techCoordinator, IRepository<LeadMedia> leadMedia) =>
        (_repository, _file, _skillrepository, _subskillrepository, _salesCoordinator, _techCoordinator, _leadMedia) = (repository, file, skillrepository, subskillrepository, salesCoordinator, techCoordinator, leadMedia);

    public async Task<Guid> Handle(CreateLeadRequest request, CancellationToken cancellationToken)
    {
        var lead = new Lead(request.Topic, request.FirstName, request.LastName, request.Email, request.BusinessPhone, request.MobilePhone, request.JobDescription, request.CountryId, request.StateId, request.CityId, request.TimeZone, request.LeadSourceId, request.LeadStatus, request.FreeTrialOffered, request.PrefferedShift, request.NumberOfResources, request.ExpectedStartDate, request.DomainORIndustry, request.Budget, request.Rating, request.LeadType, request.NDAShared, request.NDASharedOn, request.TechnicalCoordinatorStatus, request.Website, request.Designation, request.Company, request.CompanyAddress1, request.CompanyAddress2, request.CompanyPostalCode, request.CompanyAnnualRevenue, request.CompanyNumberofEmployees, request.PreferredContactMethod, request.FollowEmail, request.DoNotEmail, request.DoNotBulkEmail, request.DoNotPhone , request.MarkAsQualified,request.QualifiedOn,request.QualifiedBy);

        // Add Domain Events to be raised after the commit
        lead.DomainEvents.Add(EntityCreatedEvent.WithEntity(lead));
        await _repository.AddAsync(lead, cancellationToken);

        if (request.SkillsIds is not null && request.SkillsIds.Length > 0)
        {
            foreach (var skill in request.SkillsIds)
            {
                await _skillrepository.AddAsync(new LeadSkill()
                {
                    LeadId = lead.Id,
                    SkillId = skill
                });
            }
        }

        if (request.SubSkillsIds is not null && request.SubSkillsIds.Length > 0)
        {
            foreach (var subskill in request.SubSkillsIds)
            {
                await _subskillrepository.AddAsync(new LeadSubSkill()
                {
                    LeadId = lead.Id,
                    SubSkillId = subskill
                });
            }
        }

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

        return lead.Id;
    }

}
