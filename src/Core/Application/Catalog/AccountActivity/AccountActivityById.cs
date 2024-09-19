using FSH.WebApi.Application.Catalog.LeadAcitvity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.AccountActivity;
public class AccountActivityById : Specification<AccountActivities, AccountActivityDto>, ISingleResultSpecification
{
    public AccountActivityById(Guid id) => Query.Where(p => p.Id == id);
}
