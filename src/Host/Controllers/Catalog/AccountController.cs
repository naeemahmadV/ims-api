using Microsoft.AspNetCore.Mvc;
using FSH.WebApi.Application.Catalog.Account;
using FSH.WebApi.Application.Catalog.LeadStatus;
using FSH.WebApi.Application;
using FSH.WebApi.Application.Catalog.AccountStatus;
using FSH.WebApi.Application.Catalog;

namespace FSH.WebApi.Host.Controllers.Catalog;
public class AccountController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.Account)]
    [OpenApiOperation("Search accounts using available filters.", "")]
    public Task<PaginationResponse<AccountDto>> SearchAsync(SearchAccountRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.Account)]
    [OpenApiOperation("Get account details.", "")]
    public Task<AccountDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetAccountRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Account)]
    [OpenApiOperation("Create a new account.", "")]
    public Task<Guid> CreateAsync(CreateAccountRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Account)]
    [OpenApiOperation("Update a account.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateAccountRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Account)]
    [OpenApiOperation("Delete a account.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteLeadRequest(id));
    }

    [HttpGet("accountstatus")]
    [MustHavePermission(FSHAction.View, FSHResource.Account)]
    [OpenApiOperation("Get account status.", "")]
    public Task<List<AccountStatusDto>> GetAccountStatusAsync()
    {
        return Mediator.Send(new GetAccountStatusRequest());
    }

    [HttpGet("PreferredShiftTiming")]
    [MustHavePermission(FSHAction.View, FSHResource.Account)]
    [OpenApiOperation("Get account Preferred Shift Timing.", "")]
    public Task<List<PreferredShiftTimingRequestDto>> GetPreferredShiftTimingAsync()
    {
        return Mediator.Send(new GetPreferredShiftTimingRequest());
    }

    [HttpGet("accounttype")]
    [MustHavePermission(FSHAction.View, FSHResource.Account)]
    [OpenApiOperation("Get account type.", "")]
    public Task<List<AccountTypeDto>> GetAccountTypeAsync()
    {
        return Mediator.Send(new GetAccountTypeRequest());
    }

    [HttpGet("yearstats")]
    [MustHavePermission(FSHAction.View, FSHResource.Account)]
    [OpenApiOperation("Get account year stats.", "")]
    public Task<IList<AccountYearDto>> GetAccountYearsAsync()
    {
        return Mediator.Send(new GetAccountYearsRequest());
    }

    [HttpGet("monthsstatsbyyear")]
    [MustHavePermission(FSHAction.View, FSHResource.Account)]
    [OpenApiOperation("Get accont month stats by year.", "")]
    public Task<IList<AccountMonthDto>> GetAccountCountMonthWiseAsync(int year)
    {
        return Mediator.Send(new GetAccountCountMonthWiseRequest(year));
    }

    [HttpGet("daystatsbymonth")]
    [MustHavePermission(FSHAction.View, FSHResource.Account)]
    [OpenApiOperation("Get account day stats by month.", "")]
    public Task<IList<AccountDayDto>> GetAccountCountDayWiseAsync(int year, int month)
    {
        return Mediator.Send(new GetAccountCountDayWiseRequest(year, month));
    }
}
