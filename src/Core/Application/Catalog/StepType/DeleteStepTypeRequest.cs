using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.Catalog.StepType;

public class DeleteStepTypeRequest : IRequest<Guid>
{
    public Guid Id { get; set; }

    public DeleteStepTypeRequest(Guid id) => Id = id;
}

public class DeleteStepTypeRequestHandler : IRequestHandler<DeleteStepTypeRequest, Guid>
{
    private readonly IRepository<FSH.WebApi.Domain.Catalog.StepTypes> _repository;
    private readonly IStringLocalizer _t;

    public DeleteStepTypeRequestHandler(IRepository<FSH.WebApi.Domain.Catalog.StepTypes> repository, IStringLocalizer<DeleteStepTypeRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<Guid> Handle(DeleteStepTypeRequest request, CancellationToken cancellationToken)
    {
        var stepType = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = stepType ?? throw new NotFoundException(_t["StepType {0} Not Found."]);

        // Add Domain Events to be raised after the commit
        stepType.DomainEvents.Add(EntityDeletedEvent.WithEntity(stepType));

        await _repository.DeleteAsync(stepType, cancellationToken);

        return request.Id;
    }
}