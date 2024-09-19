using FSH.WebApi.Application.Catalog.ReportType;

namespace FSH.WebApi.Host.Controllers.Catalog;

public class ReportTypeController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.ReportType)]
    [OpenApiOperation("Search ReportType using available filters.", "")]
    public async Task<PaginationResponse<ReportTypeDto>> SearchAsync(SearchReportTypeRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.ReportType)]
    [OpenApiOperation("Get ReportType details.", "")]
    public Task<ReportTypeDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetReportTypeRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.ReportType)]
    [OpenApiOperation("Create a new ReportType.", "")]
    public Task<Guid> CreateAsync(CreateReportTypeRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.ReportType)]
    [OpenApiOperation("Update a ReportType.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateReportTypeRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.ReportType)]
    [OpenApiOperation("Delete a ReportType.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteReportTypeRequest(id));
    }
}
