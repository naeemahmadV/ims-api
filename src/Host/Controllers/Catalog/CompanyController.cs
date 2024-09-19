using FSH.WebApi.Application.Catalog.Companies;

namespace FSH.WebApi.Host.Controllers.Catalog;

public class CompanyController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.Company)]
    [OpenApiOperation("Search company using available filters.", "")]
    public Task<PaginationResponse<CompanyDto>> SearchAsync(SearchCompanyRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.Company)]
    [OpenApiOperation("Get Company details.", "")]
    public Task<CompanyDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetCompanyRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Company)]
    [OpenApiOperation("Create a new Company.", "")]
    public Task<Guid> CreateAsync(CreateCompanyRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Company)]
    [OpenApiOperation("Update a Company.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateCompanyRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Company)]
    [OpenApiOperation("Delete a Company.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteCompanyRequest(id));
    }
}