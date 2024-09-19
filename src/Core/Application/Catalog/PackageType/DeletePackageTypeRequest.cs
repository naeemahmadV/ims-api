using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.Catalog.PackageType;

public class DeletePackageTypeRequest : IRequest<Guid>
{
    public Guid Id { get; set; }

    public DeletePackageTypeRequest(Guid id) => Id = id;
}

public class DeletePackageTypeRequestHandler : IRequestHandler<DeletePackageTypeRequest, Guid>
{
    private readonly IRepository<FSH.WebApi.Domain.Catalog.PackageType> _repository;
    private readonly IStringLocalizer _t;

    public DeletePackageTypeRequestHandler(IRepository<FSH.WebApi.Domain.Catalog.PackageType> repository, IStringLocalizer<DeletePackageTypeRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<Guid> Handle(DeletePackageTypeRequest request, CancellationToken cancellationToken)
    {
        var packagetype = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = packagetype ?? throw new NotFoundException(_t["PackageType {0} Not Found."]);

        // Add Domain Events to be raised after the commit
        packagetype.DomainEvents.Add(EntityDeletedEvent.WithEntity(packagetype));

        await _repository.DeleteAsync(packagetype, cancellationToken);

        return request.Id;
    }
}