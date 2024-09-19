using FSH.WebApi.Application.Catalog.StepType;

namespace FSH.WebApi.Host.Controllers.Catalog;

public class StepTypeController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.StepType)]
    [OpenApiOperation("Search StepType using available filters.", "")]
    public async Task<PaginationResponse<StepTypeDto>> SearchAsync(SearchStepTypeRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.StepType)]
    [OpenApiOperation("Get StepType details.", "")]
    public Task<StepTypeDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetStepTypeRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.StepType)]
    [OpenApiOperation("Create a new StepType.", "")]
    public Task<Guid> CreateAsync(CreateStepTypeRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.StepType)]
    [OpenApiOperation("Update a StepType.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateStepTypeRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.StepType)]
    [OpenApiOperation("Delete a StepType.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteStepTypeRequest(id));
    }

    [HttpPost("export")]
    [MustHavePermission(FSHAction.Export, FSHResource.StepType)]
    [OpenApiOperation("Export A StepType.", "")]
    public async Task<FileResult> ExportAsync(ExportStepTypeRequest filter)
    {
        var result = await Mediator.Send(filter);
        return File(result, "application/octet-stream", "PickListxports");
    }
}
