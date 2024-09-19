namespace FSH.WebApi.Application.Catalog.SalesOrders;
public class GetSalesOrderRequest : IRequest<SalesOrderDto>
{
    public Guid Id { get; set; }

    public GetSalesOrderRequest(Guid id) => Id = id;
}

public class SalesOderByIdSpec : Specification<SalesOrder, SalesOrderDto>, ISingleResultSpecification
{
    public SalesOderByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetSalesOrderRequestHandler : IRequestHandler<GetSalesOrderRequest, SalesOrderDto>
{
    private readonly IRepository<SalesOrder> _repository;
    private readonly IStringLocalizer _t;

    public GetSalesOrderRequestHandler(IRepository<SalesOrder> repository, IStringLocalizer<GetSalesOrderRequestHandler> localizer) => (_repository, _t) = (repository, localizer);

    public async Task<SalesOrderDto> Handle(GetSalesOrderRequest request, CancellationToken cancellationToken) =>
        await _repository.FirstOrDefaultAsync(
            (ISpecification<SalesOrder, SalesOrderDto>)new SalesOderByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(_t["SalesOrder {0} Not Found.", request.Id]);
}
