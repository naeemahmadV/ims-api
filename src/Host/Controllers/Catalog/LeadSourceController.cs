using FSH.WebApi.Application.Catalog.LeadSources;

namespace FSH.WebApi.Host.Controllers.Catalog;
[Route("api/[controller]")]
[ApiController]
public class LeadSourceController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.LeadSource)]
    [OpenApiOperation("Search LeadSource using available filters.", "")]
    public Task<PaginationResponse<LeadSourceDto>> SearchAsync(SearchLeadSourceRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.LeadSource)]
    [OpenApiOperation("Get LeadSource details.", "")]
    public Task<LeadSourceDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetLeadSourceRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.LeadSource)]
    [OpenApiOperation("Create a new LeadSource.", "")]
    public Task<Guid> CreateAsync(CreateLeadSourceRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.LeadSource)]
    [OpenApiOperation("Update a LeadSource.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateLeadSourceRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.LeadSource)]
    [OpenApiOperation("Delete a LeadSource.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteLeadSourceRequest(id));
    }
}
