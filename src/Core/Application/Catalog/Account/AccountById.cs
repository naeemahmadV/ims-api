using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.Account;
public class AccountById : Specification<FSH.WebApi.Domain.Catalog.Account, AccountDto>, ISingleResultSpecification
{
    public AccountById(Guid id) => Query.Where(p => p.Id == id);
}
