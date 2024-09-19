using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.Catalog.StepType;

public class UpdateStepTypeRequest : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string StepType { get; set; }
    public string StepName { get; set; }
    public string Details { get; set; }
    public string BPCode { get; set; }
}

public class UpdateStepTypeRequestHandler : IRequestHandler<UpdateStepTypeRequest, Guid>
{
    private readonly IRepository<FSH.WebApi.Domain.Catalog.StepTypes> _repository;
    private readonly IStringLocalizer _t;
    private readonly IFileStorageService _file;

    public UpdateStepTypeRequestHandler(IRepository<FSH.WebApi.Domain.Catalog.StepTypes> repository, IStringLocalizer<UpdateStepTypeRequestHandler> localizer, IFileStorageService file) =>
        (_repository, _t, _file) = (repository, localizer, file);

    public async Task<Guid> Handle(UpdateStepTypeRequest request, CancellationToken cancellationToken)
    {
        var stepType = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = stepType ?? throw new NotFoundException(_t["StepType {0} Not Found.", request.Id]);

        var updatedstepType = stepType.Update(request.StepType, request.StepName, request.Details, request.BPCode);

        // Add Domain Events to be raised after the commit
        stepType.DomainEvents.Add(EntityUpdatedEvent.WithEntity(stepType));

        await _repository.UpdateAsync(updatedstepType, cancellationToken);

        return request.Id;
    }
}