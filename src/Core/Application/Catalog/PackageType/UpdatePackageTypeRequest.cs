using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.Catalog.PackageType;

public class UpdatePackageTypeRequest : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string Type { get; set; }
    public string Name { get; set; }
    public string Length { get; set; }
    public string Width { get; set; }
    public string Height { get; set; }
    public string Weight { get; set; }
    public string Volume { get; set; }
    public string UOM { get; set; }
    public string SubType { get; set; }
}

public class UpdatePackageTypeRequestHandler : IRequestHandler<UpdatePackageTypeRequest, Guid>
{
    private readonly IRepository<FSH.WebApi.Domain.Catalog.PackageType> _repository;
    private readonly IStringLocalizer _t;
    private readonly IFileStorageService _file;

    public UpdatePackageTypeRequestHandler(IRepository<FSH.WebApi.Domain.Catalog.PackageType> repository, IStringLocalizer<UpdatePackageTypeRequestHandler> localizer, IFileStorageService file) =>
        (_repository, _t, _file) = (repository, localizer, file);

    public async Task<Guid> Handle(UpdatePackageTypeRequest request, CancellationToken cancellationToken)
    {
        var packagetype = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = packagetype ?? throw new NotFoundException(_t["PackageType {0} Not Found.", request.Id]);

        var updatedpackagetype = packagetype.Update(request.Type, request.Name, request.Length, request.Width, request.Height, request.Weight, request.Volume, request.UOM, request.SubType);

        // Add Domain Events to be raised after the commit
        packagetype.DomainEvents.Add(EntityUpdatedEvent.WithEntity(packagetype));

        await _repository.UpdateAsync(updatedpackagetype, cancellationToken);

        return request.Id;
    }
}