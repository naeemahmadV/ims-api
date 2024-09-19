using FSH.WebApi.Application.Catalog.Products;

namespace FSH.WebApi.Application.Catalog.LeadAcitvity;
public class LeadActivityBySearchRequestSpec : EntitiesByPaginationFilterSpec<LeadActivities, LeadActivityDto>
{
    public LeadActivityBySearchRequestSpec(SearchLeadAcitivityRequest request)
     : base(request)
    {
        Query
            .Where(x => x.LeadId == request.LeadId)
            .OrderByDescending(x => x.CreatedOn);

        // .EnableCache("LeadActivityBySearchRequestSpec")
    }
}
public class LeadActivityByTaskAssignUserRequestSpec : EntitiesByPaginationFilterSpec<LeadActivities, LeadActivityTaskDto>
{
    public LeadActivityByTaskAssignUserRequestSpec(SearchLeadAcitivityTaskRequest request)
     : base(request)
    {
        Query
       .Include(p => p.Lead)
            .OrderByDescending(c => c.CreatedOn, !request.HasOrderBy())
            .Where(p => p.AssignTo == request.assignTo);


    }
}

