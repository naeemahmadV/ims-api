using FSH.WebApi.Application.Catalog.Medias;

namespace FSH.WebApi.Host.Controllers.Catalog;
[Route("api/[controller]")]
[ApiController]
public class MediaController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.Media)]
    [OpenApiOperation("Search Media using available filters.", "")]
    public Task<PaginationResponse<MediaDto>> SearchAsync(SearchMediaRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.Media)]
    [OpenApiOperation("Get Media details.", "")]
    public Task<MediaDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetMediaRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Media)]
    [OpenApiOperation("Create a new Media.", "")]
    public Task<Guid> CreateAsync(CreateMediaRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Media)]
    [OpenApiOperation("Update a Media.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateMediaRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Media)]
    [OpenApiOperation("Delete a Media.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteMediaRequest(id));
    }
}
