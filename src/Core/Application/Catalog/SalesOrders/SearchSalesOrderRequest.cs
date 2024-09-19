namespace FSH.WebApi.Application.Catalog.SalesOrders;
public class SearchSalesOrderRequest : PaginationFilter, IRequest<PaginationResponse<SalesOrderDto>>
{
}

public class SalesOrderBySearchRequestSpec : EntitiesByPaginationFilterSpec<FSH.WebApi.Domain.Catalog.SalesOrder, SalesOrderDto>
{
    public SalesOrderBySearchRequestSpec(SearchSalesOrderRequest request)
        : base(request) =>
        Query.OrderBy(c => c.CustomerName, !request.HasOrderBy());
}
public class SearchSalesOrderRequestHandler : IRequestHandler<SearchSalesOrderRequest, PaginationResponse<SalesOrderDto>>
{
    private readonly IReadRepository<FSH.WebApi.Domain.Catalog.SalesOrder> _repository;

    public SearchSalesOrderRequestHandler(IReadRepository<FSH.WebApi.Domain.Catalog.SalesOrder> repository) => _repository = repository;

    public async Task<PaginationResponse<SalesOrderDto>> Handle(SearchSalesOrderRequest request, CancellationToken cancellationToken)
    {
        var spec = new SalesOrderBySearchRequestSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken);
    }
}
