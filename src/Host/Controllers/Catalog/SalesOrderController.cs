using FSH.WebApi.Application.Catalog.SalesOrders;

namespace FSH.WebApi.Host.Controllers.Catalog;

public class SalesOrderController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.SalesOrders)]
    [OpenApiOperation("Search SalesOrders using available filters.", "")]
    public async Task<PaginationResponse<SalesOrderDto>> SearchAsync(SearchSalesOrderRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.SalesOrders)]
    [OpenApiOperation("Get SalesOrders details.", "")]
    public Task<SalesOrderDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetSalesOrderRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.SalesOrders)]
    [OpenApiOperation("Create a new SalesOrder.", "")]
    public Task<Guid> CreateAsync(CreateSalesOrderRequest request)
    {
        return Mediator.Send(request);
    }
}
