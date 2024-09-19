using FSH.WebApi.Application.Catalog.LeadAcitvity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.AccountActivity;
public class AccountActivityBySearchRequestSpec : EntitiesByPaginationFilterSpec<AccountActivities, AccountActivityDto>
{
    public AccountActivityBySearchRequestSpec(SearchAccountActivityRequest request)
    : base(request)
    {
        Query
            .Where(x => x.AccountId == request.AccountId)
            .OrderByDescending(x => x.CreatedOn);

        // .EnableCache("LeadActivityBySearchRequestSpec")
    }
}

public class AccountActivityByTaskAssignUserRequestSpec : EntitiesByPaginationFilterSpec<AccountActivities, AccountActivityTaskDto>
{
    public AccountActivityByTaskAssignUserRequestSpec(SearchAccountAcitivityTaskRequest request)
     : base(request)
    {
        Query
       .Include(p => p.Account)
            .OrderByDescending(c => c.CreatedOn, !request.HasOrderBy())
            .Where(p => p.AssignTo == request.assignTo);


    }
}
