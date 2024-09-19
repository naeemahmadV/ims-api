namespace FSH.WebApi.Application.Catalog.OpportunityActivity;
public class OpportunityActivityBySearchRequestSpec : EntitiesByPaginationFilterSpec<OpportunityActivities, OpportunityActivityDto>
{
    public OpportunityActivityBySearchRequestSpec(SearchOpportunityAcitivityRequest request)
     : base(request)
    {
        Query
            .Where(x => x.OpportunityId == request.OpportunityId)
            .OrderByDescending(x => x.CreatedOn);

        // .EnableCache("LeadActivityBySearchRequestSpec")
    }
}

public class OpportunityActivityByTaskAssignUserRequestSpec : EntitiesByPaginationFilterSpec<OpportunityActivities, OpportunityActivityTaskDto>
{
    public OpportunityActivityByTaskAssignUserRequestSpec(SearchOpportunityAcitivityTaskRequest request)
     : base(request)
    {
        Query
       .Include(p => p.Opportunity)
            .OrderByDescending(c => c.CreatedOn, !request.HasOrderBy())
            .Where(p => p.AssignTo == request.assignTo);


    }
}
