using FSH.WebApi.Application;
using FSH.WebApi.Application.Catalog.Lead;
using FSH.WebApi.Application.Catalog.LeadStatus;

namespace FSH.WebApi.Host.Controllers.Catalog;
public class LeadController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.Lead)]
    [OpenApiOperation("Search leads using available filters.", "")]
    public Task<PaginationResponse<LeadDto>> SearchAsync(SearchLeadRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.Lead)]
    [OpenApiOperation("Get lead details.", "")]
    public Task<LeadDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetLeadRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Lead)]
    [OpenApiOperation("Create a new lead.", "")]
    public Task<Guid> CreateAsync(CreateLeadRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Lead)]
    [OpenApiOperation("Update a lead.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateLeadRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Lead)]
    [OpenApiOperation("Delete a lead.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteLeadRequest(id));
    }

    [HttpGet("leadstatus")]
    [MustHavePermission(FSHAction.View, FSHResource.Lead)]
    [OpenApiOperation("Get lead status.", "")]
    public Task<List<LeadStatusDto>> GetLeadStatusAsync()
    {
        return Mediator.Send(new GetLeadStatusRequest());
    }

    [HttpGet("PreferredShiftTiming")]
    [MustHavePermission(FSHAction.View, FSHResource.Lead)]
    [OpenApiOperation("Get lead Preferred Shift Timing.", "")]
    public Task<List<PreferredShiftTimingRequestDto>> GetPreferredShiftTimingAsync()
    {
        return Mediator.Send(new GetPreferredShiftTimingRequest());
    }

    [HttpGet("leadtype")]
    [MustHavePermission(FSHAction.View, FSHResource.Lead)]
    [OpenApiOperation("Get lead type.", "")]
    public Task<List<LeadTypeDto>> GetLeadTypeAsync()
    {
        return Mediator.Send(new GetLeadTypeRequest());
    }

    [HttpGet("yearstats")]
    [MustHavePermission(FSHAction.View, FSHResource.Lead)]
    [OpenApiOperation("Get lead year stats.", "")]
    public Task<IList<LeadYearDto>> GetLeadYearsAsync()
    {
        return Mediator.Send(new GetLeadYearsRequest());
    }

    [HttpGet("monthsstatsbyyear")]
    [MustHavePermission(FSHAction.View, FSHResource.Lead)]
    [OpenApiOperation("Get lead month stats by year.", "")]
    public Task<IList<LeadMonthDto>> GetLeadCountMonthWiseAsync(int year)
    {
        return Mediator.Send(new GetLeadCountMonthWiseRequest(year));
    }

    [HttpGet("daystatsbymonth")]
    [MustHavePermission(FSHAction.View, FSHResource.Lead)]
    [OpenApiOperation("Get lead day stats by month.", "")]
    public Task<IList<LeadDayDto>> GetLeadCountDayWiseAsync(int year, int month)
    {
        return Mediator.Send(new GetLeadCountDayWiseRequest(year, month));
    }
}
