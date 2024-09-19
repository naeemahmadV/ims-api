
namespace FSH.WebApi.Application.Catalog.City;
public class CityById : Specification<Domain.Catalog.City, CityDto>, ISingleResultSpecification
{
    public CityById(Guid id) => Query.Where(p => p.Id == id);
}
