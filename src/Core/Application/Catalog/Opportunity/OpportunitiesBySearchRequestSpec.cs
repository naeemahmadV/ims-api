namespace FSH.WebApi.Application.Catalog.Opportunity;
public class OpportunitiesBySearchRequestSpec : EntitiesByPaginationFilterSpec<Domain.Catalog.Opportunity, OpportunityDto>
{
    public OpportunitiesBySearchRequestSpec(SearchOpportunityRequest request)
        : base(request)
    {
        Query
        .Include(p => p.City)
        .Include(p => p.Country)
        .Include(p => p.State)
        .Include(p => p.OpportunitySource)
        .Where(x => ((request.Year ?? 0) == 0 || x.CreatedOn.Year == request.Year) &&
        ((request.Month ?? 0) == 0 || x.CreatedOn.Month == request.Month) &&
        ((request.Day ?? 0) == 0 || x.CreatedOn.Day == request.Day) &&
        (request.OpportunityWon == null || x.OpportunityWon == request.OpportunityWon));

        if (request.CreatedOnOrder)
            Query.OrderBy(x => x.CreatedOn);
        else
            Query.OrderByDescending(x => x.CreatedOn);
    }
}

public class OpportunitiesBySearchSalesCoordinatorRequestSpec : EntitiesByPaginationFilterSpec<Domain.Catalog.Opportunity, OpportunityDto>
{
    public OpportunitiesBySearchSalesCoordinatorRequestSpec(SearchOpportunityRequest request)
        : base(request)
    {
        Query
        .Include(p => p.City)
        .Include(p => p.Country)
        .Include(p => p.State)
        .Include(p => p.OpportunitySource)
        //.Include(p => p.SalesCoordinators)
        //.Include(p => p.SalesCoordinators.Where(p => p.UserId == request.UserId))

        .Where(x => ((request.Year ?? 0) == 0 || x.CreatedOn.Year == request.Year) &&
        (x.SalesCoordinators.Any(a => a.UserId == request.UserId)) &&
        ((request.Month ?? 0) == 0 || x.CreatedOn.Month == request.Month) &&
        ((request.Day ?? 0) == 0 || x.CreatedOn.Day == request.Day) &&
        (request.OpportunityWon == null || x.OpportunityWon == request.OpportunityWon));
        if (request.CreatedOnOrder)
            Query.OrderBy(x => x.CreatedOn);
        else
            Query.OrderByDescending(x => x.CreatedOn);
    }

}

public class OpportunitiesBySearchTechnialCoordinatorRequestSpec : EntitiesByPaginationFilterSpec<Domain.Catalog.Opportunity, OpportunityDto>
{
    public OpportunitiesBySearchTechnialCoordinatorRequestSpec(SearchOpportunityRequest request)
        : base(request)
    {
        Query
        .Include(p => p.City)
        .Include(p => p.Country)
        .Include(p => p.State)
        .Include(p => p.OpportunitySource)

        .Where(x => ((request.Year ?? 0) == 0 || x.CreatedOn.Year == request.Year) &&
        (x.TechnicalCoordinators.Any(a => a.UserId == request.UserId)) &&
        ((request.Month ?? 0) == 0 || x.CreatedOn.Month == request.Month) &&
        ((request.Day ?? 0) == 0 || x.CreatedOn.Day == request.Day) &&
        (request.OpportunityWon == null || x.OpportunityWon == request.OpportunityWon));
        if (request.CreatedOnOrder)
            Query.OrderBy(x => x.CreatedOn);
        else
            Query.OrderByDescending(x => x.CreatedOn);
    }

}