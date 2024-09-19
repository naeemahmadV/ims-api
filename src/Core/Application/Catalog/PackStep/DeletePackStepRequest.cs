using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.Catalog.PackStep;

public class DeletePackStepRequest : IRequest<Guid>
{
    public Guid Id { get; set; }

    public DeletePackStepRequest(Guid id) => Id = id;
}

public class DeletePackStepRequestHandler : IRequestHandler<DeletePackStepRequest, Guid>
{
    private readonly IRepository<FSH.WebApi.Domain.Catalog.PackStep> _repository;
    private readonly IStringLocalizer _t;

    public DeletePackStepRequestHandler(IRepository<FSH.WebApi.Domain.Catalog.PackStep> repository, IStringLocalizer<DeletePackStepRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<Guid> Handle(DeletePackStepRequest request, CancellationToken cancellationToken)
    {
        var packstep = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = packstep ?? throw new NotFoundException(_t["PackStep {0} Not Found."]);

        // Add Domain Events to be raised after the commit
        packstep.DomainEvents.Add(EntityDeletedEvent.WithEntity(packstep));

        await _repository.DeleteAsync(packstep, cancellationToken);

        return request.Id;
    }
}