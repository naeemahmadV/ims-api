
namespace FSH.WebApi.Application.Catalog.State;
public class StateByNameSpec : Specification<Domain.Catalog.State>, ISingleResultSpecification
{
    public StateByNameSpec(string name) => Query.Where(p => p.Name == name);
}
