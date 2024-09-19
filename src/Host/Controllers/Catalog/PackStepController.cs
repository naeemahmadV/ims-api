using FSH.WebApi.Application.Catalog.PackStep;
using FSH.WebApi.Application.Catalog.StepType;

namespace FSH.WebApi.Host.Controllers.Catalog;

public class PackStepController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.PackStep)]
    [OpenApiOperation("Search PackStep using available filters.", "")]
    public async Task<PaginationResponse<PackStepDto>> SearchAsync(SearchPackStepRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.PackStep)]
    [OpenApiOperation("Get PackStep details.", "")]
    public Task<PackStepDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetPackStepRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.PackStep)]
    [OpenApiOperation("Create a new PackStep.", "")]
    public Task<Guid> CreateAsync(CreatePackStepRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.PackStep)]
    [OpenApiOperation("Update a PackStep.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdatePackStepRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.PackStep)]
    [OpenApiOperation("Delete a PackStep.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeletePackStepRequest(id));
    }

    [HttpPost("export")]
    [MustHavePermission(FSHAction.Export, FSHResource.PackStep)]
    [OpenApiOperation("Export A PackStep.", "")]
    public async Task<FileResult> ExportAsync(ExportPackStepRequest filter)
    {
        var result = await Mediator.Send(filter);
        return File(result, "application/octet-stream", "PickListxports");
    }
}
