using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.Catalog.PackStep;

public class UpdatePackStepRequest : IRequest<Guid>
{
    public Guid Id { get; set; }
    public int StepNo { get; set; }
    public string StepType { get; set; }
    public string LabelType { get; set; }
    public string ReportType { get; set; }
    public string PackageType { get; set; }
    public string BPCode { get; set; }
    public string Pallet { get; set; }
    public string Detail { get; set; }
}

public class UpdatePackStepRequestHandler : IRequestHandler<UpdatePackStepRequest, Guid>
{
    private readonly IRepository<FSH.WebApi.Domain.Catalog.PackStep> _repository;
    private readonly IStringLocalizer _t;
    private readonly IFileStorageService _file;

    public UpdatePackStepRequestHandler(IRepository<FSH.WebApi.Domain.Catalog.PackStep> repository, IStringLocalizer<UpdatePackStepRequestHandler> localizer, IFileStorageService file) =>
        (_repository, _t, _file) = (repository, localizer, file);

    public async Task<Guid> Handle(UpdatePackStepRequest request, CancellationToken cancellationToken)
    {
        var packStep = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = packStep ?? throw new NotFoundException(_t["PackStep {0} Not Found.", request.Id]);

        var updatedpackStep = packStep.Update(request.StepNo, request.StepType, request.LabelType, request.ReportType, request.PackageType, request.BPCode, request.Pallet, request.Detail);

        // Add Domain Events to be raised after the commit
        packStep.DomainEvents.Add(EntityUpdatedEvent.WithEntity(packStep));

        await _repository.UpdateAsync(updatedpackStep, cancellationToken);

        return request.Id;
    }
}