using FSH.WebApi.Application.Catalog.AccountActivity;

namespace FSH.WebApi.Host.Controllers.Catalog;
public class AccountActivityController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.Account)]
    [OpenApiOperation("Search account activity using available filters.", "")]
    public Task<PaginationResponse<AccountActivityDto>> SearchAsync(SearchAccountActivityRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.Account)]
    [OpenApiOperation("Get account activity details.", "")]
    public Task<AccountActivityDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetAccountActivityRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Account)]
    [OpenApiOperation("Create a new account activity.", "")]
    public Task<Guid> CreateAsync(CreateAccountActivityRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Account)]
    [OpenApiOperation("Update a account activity.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateAccountActivityRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Account)]
    [OpenApiOperation("Delete a account activity.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteAccountActivityRequest(id));
    }

    [HttpPost("assignTask")]
    [MustHavePermission(FSHAction.Search, FSHResource.Account)]
    [OpenApiOperation("Search account activity using available filters.", "")]
    public Task<PaginationResponse<AccountActivityTaskDto>> GetAsyncUserTask(SearchAccountAcitivityTaskRequest request)
    {
        return Mediator.Send(request);
    }
}
