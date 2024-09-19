using FSH.WebApi.Application;
using FSH.WebApi.Application.Catalog.State;

namespace FSH.WebApi.Host.Controllers.Catalog;
public class StateController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.State)]
    [OpenApiOperation("Search states using available filters.", "")]
    public Task<PaginationResponse<StateDto>> SearchAsync(SearchStateRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.State)]
    [OpenApiOperation("Get state details.", "")]
    public Task<StateDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetStateRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.State)]
    [OpenApiOperation("Create a new State.", "")]
    public Task<Guid> CreateAsync(CreateStateRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.State)]
    [OpenApiOperation("Update a State.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateStateRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.State)]
    [OpenApiOperation("Delete a State.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteStateRequest(id));
    }
}
