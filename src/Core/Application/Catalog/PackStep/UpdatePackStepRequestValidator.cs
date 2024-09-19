namespace FSH.WebApi.Application.Catalog.PackStep;

public class UpdatePackStepRequestValidator : CustomValidator<UpdatePackStepRequest>
{
    public UpdatePackStepRequestValidator(IReadRepository<FSH.WebApi.Domain.Catalog.PackStep> packStepRepo, IStringLocalizer<UpdatePackStepRequestValidator> T)
    {
        RuleFor(p => p.StepType)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (packStep, name, ct) =>
                    await packStepRepo.FirstOrDefaultAsync(new PackStepByNameSpec(name), ct)
                        is not FSH.WebApi.Domain.Catalog.PackStep existingPackStep || existingPackStep.Id == packStep.Id)
                .WithMessage((_, name) => T["PackStep {0} already Exists.", name]);
    }
}