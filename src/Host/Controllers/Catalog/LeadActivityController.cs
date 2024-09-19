using FSH.WebApi.Application.Catalog.LeadAcitvity;

namespace FSH.WebApi.Host.Controllers.Catalog;
public class LeadActivityController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.Lead)]
    [OpenApiOperation("Search lead activity using available filters.", "")]
    public Task<PaginationResponse<LeadActivityDto>> SearchAsync(SearchLeadAcitivityRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.Lead)]
    [OpenApiOperation("Get lead activity details.", "")]
    public Task<LeadActivityDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetLeadActivityRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Lead)]
    [OpenApiOperation("Create a new lead activity.", "")]
    public Task<Guid> CreateAsync(CreateLeadActivityRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Lead)]
    [OpenApiOperation("Update a lead activity.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateLeadActivityRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Lead)]
    [OpenApiOperation("Delete a lead activity.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteLeadActivityRequest(id));
    }


  

    [HttpPost("assignTask")]
    [MustHavePermission(FSHAction.Search, FSHResource.Lead)]
    [OpenApiOperation("Search lead activity using available filters.", "")]
    public Task<PaginationResponse<LeadActivityTaskDto>> GetAsyncUserTask(SearchLeadAcitivityTaskRequest request)
    {
        return Mediator.Send(request);
    }
}
