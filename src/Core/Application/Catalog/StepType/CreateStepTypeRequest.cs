namespace FSH.WebApi.Application.Catalog.StepType;
public class CreateStepTypeRequest : IRequest<Guid>
{
    public string StepType { get; set; }
    public string StepName { get; set; }
    public string Details { get; set; }
    public string BPCode { get; set; }
}

public class CreateStepTypeRequestValidator : CustomValidator<CreateStepTypeRequest>
{
    public CreateStepTypeRequestValidator(IReadRepository<FSH.WebApi.Domain.Catalog.StepTypes> repository, IStringLocalizer<CreateStepTypeRequestValidator> T) =>
        RuleFor(p => p.StepName)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (steptype, ct) => await repository.FirstOrDefaultAsync(new StepTypeByNameSpec(steptype), ct) is null)
                .WithMessage((_, name) => T["StepType {0} already Exists.", name]);
}

public class CreateStepTypeRequestHandler : IRequestHandler<CreateStepTypeRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<FSH.WebApi.Domain.Catalog.StepTypes> _repository;

    public CreateStepTypeRequestHandler(IRepositoryWithEvents<FSH.WebApi.Domain.Catalog.StepTypes> repository) => _repository = repository;

    public async Task<Guid> Handle(CreateStepTypeRequest request, CancellationToken cancellationToken)
    {
        var stepType = new FSH.WebApi.Domain.Catalog.StepTypes(request.StepType, request.StepName, request.Details, request.BPCode);

        await _repository.AddAsync(stepType, cancellationToken);

        return stepType.Id;
    }
}
