using FSH.WebApi.Application.Catalog.Products;

namespace FSH.WebApi.Application;
public class LeadsBySearchRequestSpec : EntitiesByPaginationFilterSpec<Lead, LeadDto>
{
    public LeadsBySearchRequestSpec(SearchLeadRequest request)
        : base(request)
    {
        Query
        .Include(p => p.City)
        .Include(p => p.Country)
        .Include(p => p.State)
        .Include(p => p.LeadSource)
        .Where(x => ((request.Year ?? 0) == 0 || x.CreatedOn.Year == request.Year) &&
        ((request.Month ?? 0) == 0 || x.CreatedOn.Month == request.Month) &&
        ((request.Day ?? 0) == 0 || x.CreatedOn.Day == request.Day) &&
        (request.MarkAsQualified == null || x.MarkAsQualified == request.MarkAsQualified));

        if (request.CreatedOnOrder)
            Query.OrderBy(x => x.CreatedOn);
        else
            Query.OrderByDescending(x => x.CreatedOn);
    }

}


public class LeadsBySearchSalesCoordinatorRequestSpec : EntitiesByPaginationFilterSpec<Lead, LeadDto>
{
    public LeadsBySearchSalesCoordinatorRequestSpec(SearchLeadRequest request)
        : base(request)
    {
        Query
        .Include(p => p.City)
        .Include(p => p.Country)
        .Include(p => p.State)
        .Include(p => p.LeadSource)
        //.Include(p => p.SalesCoordinators)
        //.Include(p => p.SalesCoordinators.Where(p => p.UserId == request.UserId))

        .Where(x => ((request.Year ?? 0) == 0 || x.CreatedOn.Year == request.Year) &&
        ( x.SalesCoordinators.Any(a=>a.UserId==request.UserId)) &&
        ((request.Month ?? 0) == 0 || x.CreatedOn.Month == request.Month) &&
        ((request.Day ?? 0) == 0 || x.CreatedOn.Day == request.Day) &&
        (request.MarkAsQualified == null || x.MarkAsQualified == request.MarkAsQualified) );
        if (request.CreatedOnOrder)
            Query.OrderBy(x => x.CreatedOn);
        else
            Query.OrderByDescending(x => x.CreatedOn);
    }

}

public class LeadsBySearchTechnialCoordinatorRequestSpec : EntitiesByPaginationFilterSpec<Lead, LeadDto>
{
    public LeadsBySearchTechnialCoordinatorRequestSpec(SearchLeadRequest request)
        : base(request)
    {
        Query
        .Include(p => p.City)
        .Include(p => p.Country)
        .Include(p => p.State)
        .Include(p => p.LeadSource)

        .Where(x => ((request.Year ?? 0) == 0 || x.CreatedOn.Year == request.Year) &&
        (x.TechnicalCoordinators.Any(a => a.UserId == request.UserId)) &&
        ((request.Month ?? 0) == 0 || x.CreatedOn.Month == request.Month) &&
        ((request.Day ?? 0) == 0 || x.CreatedOn.Day == request.Day) &&
        (request.MarkAsQualified == null || x.MarkAsQualified == request.MarkAsQualified));
        if (request.CreatedOnOrder)
            Query.OrderBy(x => x.CreatedOn);
        else
            Query.OrderByDescending(x => x.CreatedOn);
    }

}