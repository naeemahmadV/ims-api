using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.PickListDetails;
public class PickListByNameSpec : Specification<PickList>, ISingleResultSpecification
{
    public PickListByNameSpec(string custpartnum) =>
    Query.Where(b => b.CustPartNum == custpartnum);
}
