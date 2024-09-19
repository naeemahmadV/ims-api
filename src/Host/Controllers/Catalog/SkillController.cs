using FSH.WebApi.Application.Catalog.Skills;

namespace FSH.WebApi.Host.Controllers.Catalog;

public class SkillController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.Skill)]
    [OpenApiOperation("Search skills using available filters.", "")]
    public Task<PaginationResponse<SkillDto>> SearchAsync(SearchSkillRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.Skill)]
    [OpenApiOperation("Get skill details.", "")]
    public Task<SkillDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetSkillRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Skill)]
    [OpenApiOperation("Create a new Skill.", "")]
    public Task<Guid> CreateAsync(CreateSkillRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Skill)]
    [OpenApiOperation("Update a Skill.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateSkillRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Skill)]
    [OpenApiOperation("Delete a Skill.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteSkillRequest(id));
    }
}