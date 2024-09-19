using FSH.WebApi.Application;
using FSH.WebApi.Application.Catalog.SubSkill;

namespace FSH.WebApi.Host.Controllers.Catalog;
public class SubSkillController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.SubSkill)]
    [OpenApiOperation("Search sub skills using available filters.", "")]
    public Task<PaginationResponse<SubSkillDto>> SearchAsync(SearchSubSkillRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.SubSkill)]
    [OpenApiOperation("Get sub skill details.", "")]
    public Task<SubSkillDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetSubSkillRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.SubSkill)]
    [OpenApiOperation("Create a new Sub Skill.", "")]
    public Task<Guid> CreateAsync(CreateSubSkillRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.SubSkill)]
    [OpenApiOperation("Update a Sub Skill.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateSubSkillRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.SubSkill)]
    [OpenApiOperation("Delete a Sub Skill.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteSubSkillRequest(id));
    }
}
