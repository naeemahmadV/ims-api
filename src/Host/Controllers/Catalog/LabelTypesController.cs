using FSH.WebApi.Application.Catalog.LabelTypes;
using FSH.WebApi.Application.Catalog.Products;

namespace FSH.WebApi.Host.Controllers.Catalog;

public class LabelTypesController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.LabelTypes)]
    [OpenApiOperation("Search label types using available filters.", "")]
    public Task<PaginationResponse<LabelTypesDto>> SearchAsync(SearchLabelTypesRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.LabelTypes)]
    [OpenApiOperation("Get label types details.", "")]
    public Task<LabelTypesDetailsDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetLabelTypesRequest(id));
    }

    [HttpGet("dapper")]
    [MustHavePermission(FSHAction.View, FSHResource.LabelTypes)]
    [OpenApiOperation("Get label types details via dapper.", "")]
    public Task<LabelTypesDto> GetDapperAsync(Guid id)
    {
        return Mediator.Send(new GetLabelTypesViaDapperRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.LabelTypes)]
    [OpenApiOperation("Create a new LabelTypes.", "")]
    public Task<Guid> CreateAsync(CreateLabelTypesRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.LabelTypes)]
    [OpenApiOperation("Update a LabelTypes.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateLabelTypesRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.LabelTypes)]
    [OpenApiOperation("Delete a LabelTypes.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteLabelTypesRequest(id));
    }

    [HttpPost("export")]
    [MustHavePermission(FSHAction.Export, FSHResource.LabelTypes)]
    [OpenApiOperation("Export a LabelTypes.", "")]
    public async Task<FileResult> ExportAsync(ExportLabelTypesRequest filter)
    {
        var result = await Mediator.Send(filter);
        return File(result, "application/octet-stream", "LabelTypesExports");
    }
}