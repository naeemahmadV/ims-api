
namespace FSH.WebApi.Application;
public class CountryByNameSpec : Specification<Country>, ISingleResultSpecification
{
    public CountryByNameSpec(string name) => Query.Where(p => p.Name == name);
}
