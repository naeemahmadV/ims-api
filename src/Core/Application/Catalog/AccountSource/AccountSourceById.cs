
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.AccountSource;
public class AccountSourceById : Specification<FSH.WebApi.Domain.Catalog.AccountSource, AccountSourceDto>, ISingleResultSpecification
{
    public AccountSourceById(Guid id) =>
   Query.Where(p => p.Id == id);
}
