using FSH.WebApi.Application.Catalog.Opportunity;
using FSH.WebApi.Application.Catalog.OpportunityStatus;

namespace FSH.WebApi.Host.Controllers.Catalog;

public class OpportunityController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.Opportunity)]
    [OpenApiOperation("Search Opportunity using available filters.", "")]
    public Task<PaginationResponse<OpportunityDto>> SearchAsync(SearchOpportunityRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.Opportunity)]
    [OpenApiOperation("Get Details of an Opportunity.", "")]
    public Task<OpportunityDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetOpportunityRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Opportunity)]
    [OpenApiOperation("Create a new Opportunity.", "")]
    public Task<Guid> CreateAsync(CreateOpportunityRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Opportunity)]
    [OpenApiOperation("Update a Opportunity.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateOpportunityRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Opportunity)]
    [OpenApiOperation("Delete an Opportunity.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteOpportunityRequest(id));
    }

    [HttpGet("opportunitystatus")]
    [MustHavePermission(FSHAction.View, FSHResource.Opportunity)]
    [OpenApiOperation("Get Opportunity status.", "")]
    public Task<List<OpportunityStatusDto>> GetOpportunityStatusAsync()
    {
        return Mediator.Send(new GetOpportunityStatusRequest());
    }

    [HttpGet("PreferredShiftTiming")]
    [MustHavePermission(FSHAction.View, FSHResource.Opportunity)]
    [OpenApiOperation("Get opportunity Preferred Shift Timing.", "")]
    public Task<List<PreferredShiftTimingRequestDto>> GetPreferredShiftTimingAsync()
    {
        return Mediator.Send(new GetPreferredShiftTimingRequest());
    }

    [HttpGet("opportunitytype")]
    [MustHavePermission(FSHAction.View, FSHResource.Opportunity)]
    [OpenApiOperation("Get opportunity type.", "")]
    public Task<List<OpportunityTypeDto>> GetOpportunityTypeAsync()
    {
        return Mediator.Send(new GetOpportunityTypeRequest());
    }

    [HttpGet("yearstats")]
    [MustHavePermission(FSHAction.View, FSHResource.Opportunity)]
    [OpenApiOperation("Get opportunity year stats.", "")]
    public Task<IList<OpportunityYearDto>> GetOpportunityYearsAsync()
    {
        return Mediator.Send(new GetOpportunityYearsRequest());
    }

    [HttpGet("monthsstatsbyyear")]
    [MustHavePermission(FSHAction.View, FSHResource.Opportunity)]
    [OpenApiOperation("Get opportunity month stats by year.", "")]
    public Task<IList<OpportunityMonthDto>> GetOpportunityCountMonthWiseAsync(int year)
    {
        return Mediator.Send(new GetOpportunityCountMonthWiseRequest(year));
    }

    [HttpGet("daystatsbymonth")]
    [MustHavePermission(FSHAction.View, FSHResource.Opportunity)]
    [OpenApiOperation("Get Opportunity day stats by month.", "")]
    public Task<IList<OpportunityDayDto>> GetOpportunityCountDayWiseAsync(int year, int month)
    {
        return Mediator.Send(new GetOpportunityCountDayWiseRequest(year, month));
    }
}
