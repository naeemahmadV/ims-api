using FSH.WebApi.Application;
using FSH.WebApi.Application.Catalog.City;

namespace FSH.WebApi.Host.Controllers.Catalog;

public class CityController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.City)]
    [OpenApiOperation("Search products using available filters.", "")]
    public Task<PaginationResponse<CityDto>> SearchAsync(SearchCityRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.City)]
    [OpenApiOperation("Get product details.", "")]
    public Task<CityDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetCityRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.City)]
    [OpenApiOperation("Create a new City.", "")]
    public Task<Guid> CreateAsync(CreateCityRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.City)]
    [OpenApiOperation("Update a City.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateCityRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.City)]
    [OpenApiOperation("Delete a City.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteCityRequest(id));
    }
}
