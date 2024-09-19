namespace FSH.WebApi.Application.Catalog.LabelTypes;

public class SearchLabelTypesRequest : PaginationFilter, IRequest<PaginationResponse<LabelTypesDto>>
{
}

public class LabelTypesBySearchRequestSpec : EntitiesByPaginationFilterSpec<FSH.WebApi.Domain.Catalog.LabelTypes, LabelTypesDto>
{
    public LabelTypesBySearchRequestSpec(SearchLabelTypesRequest request)
        : base(request) =>
        Query.OrderBy(c => c.LabelName, !request.HasOrderBy());
}
public class SearchLabelTypesRequestHandler : IRequestHandler<SearchLabelTypesRequest, PaginationResponse<LabelTypesDto>>
{
    private readonly IReadRepository<FSH.WebApi.Domain.Catalog.LabelTypes> _repository;

    public SearchLabelTypesRequestHandler(IReadRepository<FSH.WebApi.Domain.Catalog.LabelTypes> repository) => _repository = repository;

    public async Task<PaginationResponse<LabelTypesDto>> Handle(SearchLabelTypesRequest request, CancellationToken cancellationToken)
    {
        var spec = new LabelTypesBySearchRequestSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken);
    }
}
