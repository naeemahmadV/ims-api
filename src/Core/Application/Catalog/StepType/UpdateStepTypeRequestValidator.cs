namespace FSH.WebApi.Application.Catalog.StepType;

public class UpdateStepTypeRequestValidator : CustomValidator<UpdateStepTypeRequest>
{
    public UpdateStepTypeRequestValidator(IReadRepository<FSH.WebApi.Domain.Catalog.StepTypes> stepTypeRepo, IStringLocalizer<UpdateStepTypeRequestValidator> T)
    {
        RuleFor(p => p.StepName)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (stepType, name, ct) =>
                    await stepTypeRepo.FirstOrDefaultAsync(new StepTypeByNameSpec(name), ct)
                        is not FSH.WebApi.Domain.Catalog.StepTypes existingStepType || existingStepType.Id == stepType.Id)
                .WithMessage((_, name) => T["StepType {0} already Exists.", name]);
    }
}