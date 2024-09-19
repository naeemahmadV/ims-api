using FSH.WebApi.Application.Catalog.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application;
public class AccountBySearchRequestSpec : EntitiesByPaginationFilterSpec<Account, AccountDto>
{

    public AccountBySearchRequestSpec(SearchAccountRequest request)
       : base(request)
    {
        Query
        .Include(p => p.City)
        .Include(p => p.Country)
        .Include(p => p.State)
        .Include(p => p.AccountSource)
        .Where(x => ((request.Year ?? 0) == 0 || x.CreatedOn.Year == request.Year) &&
        ((request.Month ?? 0) == 0 || x.CreatedOn.Month == request.Month) &&
        ((request.Day ?? 0) == 0 || x.CreatedOn.Day == request.Day));
        if (request.CreatedOnOrder)
            Query.OrderBy(x => x.CreatedOn);
        else
            Query.OrderByDescending(x => x.CreatedOn);
    }
}

public class AccountBySearchSalesCoordinatorRequestSpec : EntitiesByPaginationFilterSpec<Account, AccountDto>
{
    public AccountBySearchSalesCoordinatorRequestSpec(SearchAccountRequest request)
        : base(request)
    {
        Query
        .Include(p => p.City)
        .Include(p => p.Country)
        .Include(p => p.State)
        .Include(p => p.AccountSource)
        //.Include(p => p.SalesCoordinators)
        //.Include(p => p.SalesCoordinators.Where(p => p.UserId == request.UserId))

        .Where(x => ((request.Year ?? 0) == 0 || x.CreatedOn.Year == request.Year) &&
        (x.AccountSalesCoordinators.Any(a => a.UserId == request.UserId)) &&
        ((request.Month ?? 0) == 0 || x.CreatedOn.Month == request.Month) &&
        ((request.Day ?? 0) == 0 || x.CreatedOn.Day == request.Day));
        if (request.CreatedOnOrder)
            Query.OrderBy(x => x.CreatedOn);
        else
            Query.OrderByDescending(x => x.CreatedOn);
    }

}

public class AccountBySearchTechnialCoordinatorRequestSpec : EntitiesByPaginationFilterSpec<Account, AccountDto>
{
    public AccountBySearchTechnialCoordinatorRequestSpec(SearchAccountRequest request)
        : base(request)
    {
        Query
        .Include(p => p.City)
        .Include(p => p.Country)
        .Include(p => p.State)
        .Include(p => p.AccountSource)

        .Where(x => ((request.Year ?? 0) == 0 || x.CreatedOn.Year == request.Year) &&
        (x.AccountTechnicalCoordinators.Any(a => a.UserId == request.UserId)) &&
        ((request.Month ?? 0) == 0 || x.CreatedOn.Month == request.Month) &&
        ((request.Day ?? 0) == 0 || x.CreatedOn.Day == request.Day));

        if (request.CreatedOnOrder)
            Query.OrderBy(x => x.CreatedOn);
        else
            Query.OrderByDescending(x => x.CreatedOn);
    }

}
