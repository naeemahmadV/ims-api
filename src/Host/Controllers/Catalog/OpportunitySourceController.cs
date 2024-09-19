using FSH.WebApi.Application.Catalog.OpportunitySources;

namespace FSH.WebApi.Host.Controllers.Catalog;

[Route("api/[controller]")]
[ApiController]
public class OpportunitySourceController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.OpportunitySource)]
    [OpenApiOperation("Search Opportunity Source using available filters.", "")]
    public Task<PaginationResponse<OpportunitySourceDto>> SearchAsync(SearchOpportunitySourceRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.OpportunitySource)]
    [OpenApiOperation("Get details of Opportunity Source.", "")]
    public Task<OpportunitySourceDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetOpportunitySourceRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.OpportunitySource)]
    [OpenApiOperation("Create a new Opportunity Source.", "")]
    public Task<Guid> CreateAsync(CreateOpportunitySourceRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.OpportunitySource)]
    [OpenApiOperation("Update an Opportunity Source.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateOpportunitySourceRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.OpportunitySource)]
    [OpenApiOperation("Delete an Opportunity Source.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteOpportunitySourceRequest(id));
    }
}
