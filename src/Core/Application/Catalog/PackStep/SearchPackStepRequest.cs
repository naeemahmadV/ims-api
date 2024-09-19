namespace FSH.WebApi.Application.Catalog.PackStep;
public class SearchPackStepRequest : PaginationFilter, IRequest<PaginationResponse<PackStepDto>>
{
}

public class PackStepBySearchRequestSpec : EntitiesByPaginationFilterSpec<FSH.WebApi.Domain.Catalog.PackStep, PackStepDto>
{
    public PackStepBySearchRequestSpec(SearchPackStepRequest request)
        : base(request) =>
        Query.OrderBy(c => c.StepType, !request.HasOrderBy());
}
public class SearchPackStepRequestHandler : IRequestHandler<SearchPackStepRequest, PaginationResponse<PackStepDto>>
{
    private readonly IReadRepository<FSH.WebApi.Domain.Catalog.PackStep> _repository;

    public SearchPackStepRequestHandler(IReadRepository<FSH.WebApi.Domain.Catalog.PackStep> repository) => _repository = repository;

    public async Task<PaginationResponse<PackStepDto>> Handle(SearchPackStepRequest request, CancellationToken cancellationToken)
    {
        var spec = new PackStepBySearchRequestSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken);
    }
}
