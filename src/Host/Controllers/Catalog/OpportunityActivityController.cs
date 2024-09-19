using FSH.WebApi.Application.Catalog.OpportunityActivity;

namespace FSH.WebApi.Host.Controllers.Catalog;

public class OpportunityActivityController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.Opportunity)]
    [OpenApiOperation("Search opportunity activity using available filters.", "")]
    public Task<PaginationResponse<OpportunityActivityDto>> SearchAsync(SearchOpportunityAcitivityRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.Opportunity)]
    [OpenApiOperation("Get an Opportunity Activity Details", "")]
    public Task<OpportunityActivityDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetOpportunityActivityRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Opportunity)]
    [OpenApiOperation("Create a new Opportunity Activity", "")]
    public Task<Guid> CreateAsync(CreateOpportunityActivityRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Opportunity)]
    [OpenApiOperation("Update an existing Opportunity Activity", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateOpportunityActivityRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Opportunity)]
    [OpenApiOperation("Delete an Opportunity Activity", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteOpportunityActivityRequest(id));
    }

    [HttpPost("assignTask")]
    [MustHavePermission(FSHAction.Search, FSHResource.Opportunity)]
    [OpenApiOperation("Search opportunity activity using available filters.", "")]
    public Task<PaginationResponse<OpportunityActivityTaskDto>> GetAsyncUserTask(SearchOpportunityAcitivityTaskRequest request)
    {
        return Mediator.Send(request);
    }
}
