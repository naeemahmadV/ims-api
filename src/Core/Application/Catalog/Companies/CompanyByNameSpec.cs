
namespace FSH.WebApi.Application.Catalog.Companies;

public class CompanyByNameSpec : Specification<Company>, ISingleResultSpecification
{
    public CompanyByNameSpec(string name) => Query.Where(p => p.Name == name);
}