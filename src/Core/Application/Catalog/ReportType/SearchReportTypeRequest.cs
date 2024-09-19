namespace FSH.WebApi.Application.Catalog.ReportType;
public class SearchReportTypeRequest : PaginationFilter, IRequest<PaginationResponse<ReportTypeDto>>
{
}

public class ReportTypeBySearchRequestSpec : EntitiesByPaginationFilterSpec<FSH.WebApi.Domain.Catalog.ReportTypes, ReportTypeDto>
{
    public ReportTypeBySearchRequestSpec(SearchReportTypeRequest request)
        : base(request) =>
        Query.OrderBy(c => c.ReportName, !request.HasOrderBy());
}
public class SearchReportTypeRequestHandler : IRequestHandler<SearchReportTypeRequest, PaginationResponse<ReportTypeDto>>
{
    private readonly IReadRepository<FSH.WebApi.Domain.Catalog.ReportTypes> _repository;

    public SearchReportTypeRequestHandler(IReadRepository<FSH.WebApi.Domain.Catalog.ReportTypes> repository) => _repository = repository;

    public async Task<PaginationResponse<ReportTypeDto>> Handle(SearchReportTypeRequest request, CancellationToken cancellationToken)
    {
        var spec = new ReportTypeBySearchRequestSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken);
    }
}
