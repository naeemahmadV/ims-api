namespace FSH.WebApi.Application.Catalog.StepType;
public class SearchStepTypeRequest : PaginationFilter, IRequest<PaginationResponse<StepTypeDto>>
{
}

public class StepTypeBySearchRequestSpec : EntitiesByPaginationFilterSpec<FSH.WebApi.Domain.Catalog.StepTypes, StepTypeDto>
{
    public StepTypeBySearchRequestSpec(SearchStepTypeRequest request)
        : base(request) =>
        Query.OrderBy(c => c.StepName, !request.HasOrderBy());
}

public class SearchStepTypeRequestHandler : IRequestHandler<SearchStepTypeRequest, PaginationResponse<StepTypeDto>>
{
    private readonly IReadRepository<FSH.WebApi.Domain.Catalog.StepTypes> _repository;

    public SearchStepTypeRequestHandler(IReadRepository<FSH.WebApi.Domain.Catalog.StepTypes> repository) => _repository = repository;

    public async Task<PaginationResponse<StepTypeDto>> Handle(SearchStepTypeRequest request, CancellationToken cancellationToken)
    {
        var spec = new StepTypeBySearchRequestSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken);
    }
}
