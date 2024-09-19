namespace FSH.WebApi.Application.Catalog.OpportunitySources;
public class SearchOpportunitySourceRequest : PaginationFilter, IRequest<PaginationResponse<OpportunitySourceDto>>
{

}

public class OpportunitySourceBySearchRequestSpec : EntitiesByPaginationFilterSpec<OpportunitySource, OpportunitySourceDto>
{
    public OpportunitySourceBySearchRequestSpec(SearchOpportunitySourceRequest request)
        : base(request)
    {
        Query.OrderBy(c => c.SourceName, !request.HasOrderBy());
    }
}

public class SearchOpportunitySourceRequestHandler : IRequestHandler<SearchOpportunitySourceRequest, PaginationResponse<OpportunitySourceDto>>
{
    private readonly IReadRepository<OpportunitySource> _repository;

    public SearchOpportunitySourceRequestHandler(IReadRepository<OpportunitySource> repository)
    {
        _repository = repository;
    }

    public async Task<PaginationResponse<OpportunitySourceDto>> Handle(SearchOpportunitySourceRequest request, CancellationToken cancellationToken)
    {
        var spec = new OpportunitySourceBySearchRequestSpec(request);

        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken); 
    }
}
