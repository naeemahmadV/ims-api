using FSH.WebApi.Application;
using FSH.WebApi.Application.Catalog.Country;

namespace FSH.WebApi.Host.Controllers.Catalog;

public class CountryController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.Country)]
    [OpenApiOperation("Search countries using available filters.", "")]
    public Task<PaginationResponse<CountryDto>> SearchAsync(SearchCountryRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.Country)]
    [OpenApiOperation("Get country details.", "")]
    public Task<CountryDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetCountryRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Country)]
    [OpenApiOperation("Create a new Country.", "")]
    public Task<Guid> CreateAsync(CreateCountryRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Country)]
    [OpenApiOperation("Update a Country.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateCountryRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Country)]
    [OpenApiOperation("Delete a Country.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteCountryRequest(id));
    }
}
