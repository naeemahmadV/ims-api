
namespace FSH.WebApi.Application.Catalog.City;
public class CityByNameSpec : Specification<Domain.Catalog.City>, ISingleResultSpecification
{
    public CityByNameSpec(string name) => Query.Where(p => p.Name == name);
}
