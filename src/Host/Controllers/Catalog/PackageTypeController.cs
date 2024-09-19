using FSH.WebApi.Application.Catalog.PackageType;

namespace FSH.WebApi.Host.Controllers.Catalog;

public class PackageTypeController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.PackageType)]
    [OpenApiOperation("Search PackageType using available filters.", "")]
    public async Task<PaginationResponse<PackageTypeDto>> SearchAsync(SearchPackageTypeRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.PackageType)]
    [OpenApiOperation("Get PackageType details.", "")]
    public Task<PackageTypeDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetPackageTypeRequest(id));
    }

    [HttpGet("dapper")]
    [MustHavePermission(FSHAction.View, FSHResource.PackageType)]
    [OpenApiOperation("Get PackageType details via dapper.", "")]
    public Task<PackageTypeDto> GetDapperAsync(Guid id)
    {
        return Mediator.Send(new GetPackageTypeViaDapperRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.PackageType)]
    [OpenApiOperation("Create a new PackageType.", "")]
    public Task<Guid> CreateAsync(CreatePackageTypeRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.PackageType)]
    [OpenApiOperation("Update a PackageType.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdatePackageTypeRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.PackageType)]
    [OpenApiOperation("Delete a PackageType.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeletePackageTypeRequest(id));
    }

    [HttpPost("export")]
    [MustHavePermission(FSHAction.Export, FSHResource.PackageType)]
    [OpenApiOperation("Export A PackageType.", "")]
    public async Task<FileResult> ExportAsync(ExportPackageTypeRequest filter)
    {
        var result = await Mediator.Send(filter);
        return File(result, "application/octet-stream", "PackageTypexports");
    }
}
