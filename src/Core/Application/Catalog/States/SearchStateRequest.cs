
using FSH.WebApi.Application.Catalog.State;

namespace FSH.WebApi.Application;
public class SearchStateRequest : PaginationFilter, IRequest<PaginationResponse<StateDto>>
{

}

public class StateBySearchRequestSpec : EntitiesByPaginationFilterSpec<State, StateDto>
{
    public StateBySearchRequestSpec(SearchStateRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchStateRequestHandler : IRequestHandler<SearchStateRequest, PaginationResponse<StateDto>>
{
    private readonly IReadRepository<State> _repository;

    public SearchStateRequestHandler(IReadRepository<State> repository) => _repository = repository;

    public async Task<PaginationResponse<StateDto>> Handle(SearchStateRequest request, CancellationToken cancellationToken)
    {
        var spec = new StateBySearchRequestSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken);
    }
}
