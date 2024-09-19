
namespace FSH.WebApi.Application.Catalog.State;
public class StateById : Specification<Domain.Catalog.State, StateDto>, ISingleResultSpecification
{
    public StateById(Guid id) => Query.Where(p => p.Id == id);
}
