
namespace FSH.WebApi.Application.Catalog.LeadSources;
public class SearchLeadSourceRequest : PaginationFilter, IRequest<PaginationResponse<LeadSourceDto>>
{

}

public class LeadSourceBySearchRequestSpec : EntitiesByPaginationFilterSpec<Domain.Catalog.LeadSource, LeadSourceDto>
{
    public LeadSourceBySearchRequestSpec(SearchLeadSourceRequest request)
        : base(request) =>
        Query.OrderBy(c => c.SourceName, !request.HasOrderBy());
}

public class SearchLeadSourceRequestHandler : IRequestHandler<SearchLeadSourceRequest, PaginationResponse<LeadSourceDto>>
{
    private readonly IReadRepository<LeadSource> _repository;

    public SearchLeadSourceRequestHandler(IReadRepository<LeadSource> repository) => _repository = repository;

    public async Task<PaginationResponse<LeadSourceDto>> Handle(SearchLeadSourceRequest request, CancellationToken cancellationToken)
    {
        var spec = new LeadSourceBySearchRequestSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken);
    }
}
