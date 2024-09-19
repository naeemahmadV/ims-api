using FSH.WebApi.Application.Catalog.Country;

namespace FSH.WebApi.Application;
public class CountryById : Specification<Country, CountryDto>, ISingleResultSpecification
{
    public CountryById(Guid id) => Query.Where(p => p.Id == id);
}
