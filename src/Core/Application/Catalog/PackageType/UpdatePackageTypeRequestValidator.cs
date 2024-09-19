namespace FSH.WebApi.Application.Catalog.PackageType;

public class UpdatePackageTypeRequestValidator : CustomValidator<UpdatePackageTypeRequest>
{
    public UpdatePackageTypeRequestValidator(IReadRepository<FSH.WebApi.Domain.Catalog.PackageType> packageTypeRepo, IStringLocalizer<UpdatePackageTypeRequestValidator> T)
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (packageType, name, ct) =>
                    await packageTypeRepo.FirstOrDefaultAsync(new PackageTypeByNameSpec(name), ct)
                        is not FSH.WebApi.Domain.Catalog.PackageType existingPackageType || existingPackageType.Id == packageType.Id)
                .WithMessage((_, name) => T["PackageType {0} already Exists.", name]);
    }
}