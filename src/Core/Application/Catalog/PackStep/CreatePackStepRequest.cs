namespace FSH.WebApi.Application.Catalog.PackStep;
public class CreatePackStepRequest : IRequest<Guid>
{
    public int StepNo { get; set; }
    public string StepType { get; set; }
    public string LabelType { get; set; }
    public string ReportType { get; set; }
    public string PackageType { get; set; }
    public string BPCode { get; set; }
    public string Pallet { get; set; }
    public string Detail { get; set; }
}

public class CreatePackStepRequestValidator : CustomValidator<CreatePackStepRequest>
{
    public CreatePackStepRequestValidator(IReadRepository<FSH.WebApi.Domain.Catalog.PackStep> repository, IStringLocalizer<CreatePackStepRequestValidator> T) =>
        RuleFor(p => p.StepType)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (steptype, ct) => await repository.FirstOrDefaultAsync(new PackStepByNameSpec(steptype), ct) is null)
                .WithMessage((_, name) => T["PackStep {0} already Exists.", name]);
}

public class CreatePackStepRequestHandler : IRequestHandler<CreatePackStepRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<FSH.WebApi.Domain.Catalog.PackStep> _repository;

    public CreatePackStepRequestHandler(IRepositoryWithEvents<FSH.WebApi.Domain.Catalog.PackStep> repository) => _repository = repository;

    public async Task<Guid> Handle(CreatePackStepRequest request, CancellationToken cancellationToken)
    {
        var packStep = new FSH.WebApi.Domain.Catalog.PackStep(request.StepNo, request.StepType, request.LabelType, request.ReportType, request.PackageType, request.BPCode, request.Pallet, request.Detail);

        await _repository.AddAsync(packStep, cancellationToken);

        return packStep.Id;
    }
}
