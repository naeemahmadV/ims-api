using Microsoft.AspNetCore.Mvc;
using FSH.WebApi.Application.Catalog.AccountSource;
using FSH.WebApi.Application.Catalog.LeadSources;

namespace FSH.WebApi.Host.Controllers.Catalog;
[Route("api/[controller]")]
[ApiController]
public class AccountSourceController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.AccountSource)]
    [OpenApiOperation("Search AccountSource using available filters.", "")]
    public Task<PaginationResponse<AccountSourceDto>> SearchAsync(SearchAccountSourceRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.AccountSource)]
    [OpenApiOperation("Get AccountSource details.", "")]
    public Task<AccountSourceDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetAccountSourceRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.AccountSource)]
    [OpenApiOperation("Create a new AccountSource.", "")]
    public Task<Guid> CreateAsync(CreateAccountSourceRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.AccountSource)]
    [OpenApiOperation("Update a AccountSource.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateAccountSourceRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.AccountSource)]
    [OpenApiOperation("Delete a AccountSource.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteAccountSourceRequest(id));
    }
}
