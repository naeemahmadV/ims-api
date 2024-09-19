using Microsoft.AspNetCore.Mvc;
using FSH.WebApi.Application.Catalog.PickListDetails;
using FSH.WebApi.Application.Catalog.Products;
using FSH.WebApi.Application.Catalog.SalesOrders;

namespace FSH.WebApi.Host.Controllers.Catalog;
public class PickListController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.PickList)]
    [OpenApiOperation("Search PickList using available filters.", "")]
    public async Task<PaginationResponse<PickListDto>> SearchAsync(SearchPickListRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.PickList)]
    [OpenApiOperation("Get PickList details.", "")]
    public Task<PickListDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetPickListRequest(id));
    }

    [HttpGet("dapper")]
    [MustHavePermission(FSHAction.View, FSHResource.PickList)]
    [OpenApiOperation("Get pickList details via dapper.", "")]
    public Task<PickListDto> GetDapperAsync(Guid id)
    {
        return Mediator.Send(new GetPickListViaDapperRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.PickList)]
    [OpenApiOperation("Create a new PickList.", "")]
    public Task<Guid> CreateAsync(CreatePickListRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.PickList)]
    [OpenApiOperation("Update A PickList.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdatePickListRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.PickList)]
    [OpenApiOperation("Delete a PickList.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeletePickListRequest(id));
    }

    [HttpPost("export")]
    [MustHavePermission(FSHAction.Export, FSHResource.PickList)]
    [OpenApiOperation("Export A PickList.", "")]
    public async Task<FileResult> ExportAsync(ExportPickListRequest filter)
    {
        var result = await Mediator.Send(filter);
        return File(result, "application/octet-stream", "PickListxports");
    }
}
