using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.Catalog.Opportunity;
public class UpdateOpportunityRequest : IRequest<Guid>
{
    public Guid Id { get; set; }
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

public class UpdateOpportunityRequestHandler : IRequestHandler<UpdateOpportunityRequest, Guid>
{
    private readonly IRepository<Domain.Catalog.Opportunity> _repository;
    private readonly IRepository<OpportunitySkill> _skillrepository;
    private readonly IRepository<OpportunitySubSkill> _subskillrepository;
    private readonly IRepository<OpportunitySalesCoordinator> _salesCoordinatorrepository;
    private readonly IRepository<OpportunityTechnicalCoordinator> _technicalCoordinatorrepository;
    private readonly IRepository<OpportunityMedia> _mediarepository;
    private readonly IUploadService _file;
    private readonly IStringLocalizer<UpdateOpportunityRequestHandler> _stringLocalizer;

    public UpdateOpportunityRequestHandler(IRepository<Domain.Catalog.Opportunity> repository, IRepository<OpportunitySkill> skillrepository, IStringLocalizer<UpdateOpportunityRequestHandler> stringLocalizer, IRepository<OpportunitySubSkill> subskillrepository, IRepository<OpportunitySalesCoordinator> salesCoordinatorrepository, IRepository<OpportunityTechnicalCoordinator> technicalCoordinatorrepository, IRepository<OpportunityMedia> mediarepository, IUploadService file)
    {
        _repository = repository;
        _stringLocalizer = stringLocalizer;
        _skillrepository = skillrepository;
        _subskillrepository = subskillrepository;
        _salesCoordinatorrepository = salesCoordinatorrepository;
        _technicalCoordinatorrepository = technicalCoordinatorrepository;
        _mediarepository = mediarepository;
        _file = file;
    }

    public async Task<DefaultIdType> Handle(UpdateOpportunityRequest request, CancellationToken cancellationToken)
    {
        var opportunity = await _repository.GetByIdAsync(request.Id, cancellationToken);

        if (opportunity == null)
        {
            throw new NotFoundException(string.Format(_stringLocalizer["Opportunity.NotFound"]));
        }

        var updateOpportunity = opportunity.Update(request.Topic, request.FirstName, request.LastName, request.Email, request.BusinessPhone, request.MobilePhone, request.JobDescription, request.CountryId, request.StateId, request.CityId, request.LeadId, request.TimeZone, request.OpportunitySourceId, request.OpportunityStatus, request.FreeTrialOffered, request.PrefferedShift, request.NumberOfResources, request.ExpectedStartDate, request.DomainORIndustry, request.Budget, request.Rating, request.OpportunityType, request.NDAShared, request.NDASharedOn, request.TechnicalCoordinatorStatus, request.Website, request.Designation, request.Company, request.CompanyAddress1, request.CompanyAddress2, request.CompanyPostalCode, request.CompanyAnnualRevenue, request.CompanyNumberofEmployees, request.PreferredContactMethod, request.FollowEmail, request.DoNotEmail, request.DoNotBulkEmail, request.DoNotPhone, request.OpportunityWon, request.OpportunityLost);

        opportunity.DomainEvents.Add(EntityUpdatedEvent.WithEntity(opportunity));

        await _repository.UpdateAsync(updateOpportunity);

        //Updating all related Tables

        var opportunitySkillsRequest = new OpportunitySkillsRequest
        {
            OpportunityId = opportunity.Id
        };

        var skillSpec = new OpportunitySkillsSpecification(opportunitySkillsRequest);

        var skills = await _skillrepository.ListAsync(skillSpec, cancellationToken);

        if (skills.Count > 0)
            await _skillrepository.DeleteRangeAsync(skills);

        if(request.SkillsIds is not null && request.SkillsIds.Length > 0)
        {
            foreach(var skill in request.SkillsIds)
            {
                await _skillrepository.AddAsync(new OpportunitySkill
                {
                    OpportunityId = opportunity.Id,
                    SkillId = skill
                });
            }
        }

        var subSkillSpec = new OpportunitySubSkillsSpecification(new OpportunitySubSkillsRequest
        {
            OpportunityId = opportunity.Id
        });

        var subSkills = await _subskillrepository.ListAsync(subSkillSpec, cancellationToken);

        if(subSkills.Count > 0)
            await _subskillrepository.DeleteRangeAsync(subSkills);

        if(request.SubSkillsIds is not null && request.SubSkillsIds.Length > 0)
        {
            foreach(var subSkill in request.SubSkillsIds)
            {
                await _subskillrepository.AddAsync(new OpportunitySubSkill
                {
                    OpportunityId = opportunity.Id,
                    SubSkillId = subSkill
                });
            }
        }

        var salesCoordinatorSpec = new OpportunitySalesCoordinaotrsSpecification(new OpportunitySalesCoordinaotrsRequest
        {
            OpportunityId = opportunity.Id
        });

        var salesCoordinators = await _salesCoordinatorrepository.ListAsync(salesCoordinatorSpec, cancellationToken);

        if(salesCoordinators.Count > 0)
            await _salesCoordinatorrepository.DeleteRangeAsync(salesCoordinators);

        if(request.SalesCoordinaotrs is not null && request.SalesCoordinaotrs.Length > 0)
        {
            foreach(var salesCoordinator in request.SalesCoordinaotrs)
            {
                await _salesCoordinatorrepository.AddAsync(new OpportunitySalesCoordinator
                {
                    OpportunityId = opportunity.Id,
                    UserId = salesCoordinator
                });
            }
        }

        var technicalCoordinatorSpec = new OpportunityTechnicalCoordinaotrsSpecification(new OpportunityTechnicalCoordinaotrsRequest
        {
            OpportunityId = opportunity.Id
        });

        var technicalCoordinators = await _technicalCoordinatorrepository.ListAsync(technicalCoordinatorSpec, cancellationToken);

        if (technicalCoordinators.Count > 0)
            await _technicalCoordinatorrepository.DeleteRangeAsync(technicalCoordinators);

        if (request.TechCoordinaotrs is not null && request.TechCoordinaotrs.Length > 0)
        {
            foreach (var technicalCoordinator in request.TechCoordinaotrs)
            {
                await _technicalCoordinatorrepository.AddAsync(new OpportunityTechnicalCoordinator
                {
                    OpportunityId = opportunity.Id,
                    UserId = technicalCoordinator
                });
            }
        }

        var opportunityMediasspec = new OpportunityMediaSpecification(new OpportunityMediaRequest()
        {
            OpportunityId = opportunity.Id
        });

        var opportunityMedias = await _mediarepository.ListAsync(opportunityMediasspec, cancellationToken);

        if (opportunityMedias.Count() > 0)
            await _mediarepository.DeleteRangeAsync(opportunityMedias);

        if (request.OpportunityMedia is not null && request.OpportunityMedia.Length > 0)
        {
            foreach (var media in request.OpportunityMedia)
            {
                await _mediarepository.AddAsync(new OpportunityMedia()
                {
                    OpportunityId = opportunity.Id,
                    MediaId = media
                });
            }
        }

        return request.Id;
    }

    public class OpportunitySkillsSpecification : EntitiesByBaseFilterSpec<OpportunitySkill, OpportunitySkill>
    {
        public OpportunitySkillsSpecification(OpportunitySkillsRequest request)
            : base(request) =>
            Query
                .Where(p => p.OpportunityId == request.OpportunityId);
    }

    public class OpportunitySkillsRequest : BaseFilter
    {
        public Guid OpportunityId { get; set; }
    }

    public class OpportunitySubSkillsSpecification : EntitiesByBaseFilterSpec<OpportunitySubSkill, OpportunitySubSkill>
    {
        public OpportunitySubSkillsSpecification(OpportunitySubSkillsRequest request)
            : base(request) =>
            Query
                .Where(p => p.OpportunityId == request.OpportunityId);
    }

    public class OpportunitySubSkillsRequest : BaseFilter
    {
        public Guid OpportunityId { get; set; }
    }

    public class OpportunitySalesCoordinaotrsSpecification : EntitiesByBaseFilterSpec<OpportunitySalesCoordinator, OpportunitySalesCoordinator>
    {
        public OpportunitySalesCoordinaotrsSpecification(OpportunitySalesCoordinaotrsRequest request)
            : base(request) =>
            Query
                .Where(p => p.OpportunityId == request.OpportunityId);
    }

    public class OpportunitySalesCoordinaotrsRequest : BaseFilter
    {
        public Guid OpportunityId { get; set; }
    }

    public class OpportunityTechnicalCoordinaotrsSpecification : EntitiesByBaseFilterSpec<OpportunityTechnicalCoordinator, OpportunityTechnicalCoordinator>
    {
        public OpportunityTechnicalCoordinaotrsSpecification(OpportunityTechnicalCoordinaotrsRequest request)
            : base(request) =>
            Query
                .Where(p => p.OpportunityId == request.OpportunityId);
    }

    public class OpportunityTechnicalCoordinaotrsRequest : BaseFilter
    {
        public Guid OpportunityId { get; set; }
    }

    public class OpportunityMediaSpecification : EntitiesByBaseFilterSpec<OpportunityMedia, OpportunityMedia>
    {
        public OpportunityMediaSpecification(OpportunityMediaRequest request)
            : base(request) =>
            Query
                .Where(p => p.OpportunityId == request.OpportunityId);
    }

    public class OpportunityMediaRequest : BaseFilter
    {
        public Guid OpportunityId { get; set; }
    }
}
