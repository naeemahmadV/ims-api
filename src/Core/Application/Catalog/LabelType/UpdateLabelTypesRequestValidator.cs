namespace FSH.WebApi.Application.Catalog.LabelTypes;

public class UpdateLabelTypesRequestValidator : CustomValidator<UpdateLabelTypesRequest>
{
    public UpdateLabelTypesRequestValidator(IReadRepository<FSH.WebApi.Domain.Catalog.LabelTypes> labelTypeRepo, IStringLocalizer<UpdateLabelTypesRequestValidator> T)
    {
        RuleFor(p => p.LabelName)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (labeltype, name, ct) =>
                    await labelTypeRepo.FirstOrDefaultAsync(new LabelTypesByNameSpec(name), ct)
                        is not FSH.WebApi.Domain.Catalog.LabelTypes existinglabeltypes || existinglabeltypes.Id == labeltype.Id)
                .WithMessage((_, name) => T["LabelTypes {0} already Exists.", name]);
    }
}