namespace FSH.WebApi.Application.Catalog.LabelTypes;

public class CreateLabelTypesRequestValidator : CustomValidator<CreateLabelTypesRequest>
{
    public CreateLabelTypesRequestValidator(IReadRepository<FSH.WebApi.Domain.Catalog.LabelTypes> labeltypeRepo, IStringLocalizer<CreateLabelTypesRequestValidator> T)
    {
        RuleFor(p => p.LabelName)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (name, ct) => await labeltypeRepo.FirstOrDefaultAsync(new LabelTypesByNameSpec(name), ct) is null)
                .WithMessage((_, name) => T["LabelTypes {0} already Exists.", name]);


    }
}