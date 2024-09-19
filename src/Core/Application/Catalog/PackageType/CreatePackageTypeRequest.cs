namespace FSH.WebApi.Application.Catalog.PackageType;
public class CreatePackageTypeRequest : IRequest<Guid>
{
    public string Type { get; set; }
    public string Name { get; set; }
    public string Length { get; set; }
    public string Width { get; set; }
    public string Height { get; set; }
    public string Weight { get; set; }
    public string Volume { get; set; }
    public string UOM { get; set; }
    public string SubType { get; set; }
}

public class CreatePackageTypeRequestValidator : CustomValidator<CreatePackageTypeRequest>
{
    public CreatePackageTypeRequestValidator(IReadRepository<FSH.WebApi.Domain.Catalog.PackageType> repository, IStringLocalizer<CreatePackageTypeRequestValidator> T) =>
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (name, ct) => await repository.FirstOrDefaultAsync(new PackageTypeByNameSpec(name), ct) is null)
                .WithMessage((_, name) => T["PackageName {0} already Exists.", name]);
}

public class CreatePackageTypeRequestHandler : IRequestHandler<CreatePackageTypeRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<FSH.WebApi.Domain.Catalog.PackageType> _repository;

    public CreatePackageTypeRequestHandler(IRepositoryWithEvents<FSH.WebApi.Domain.Catalog.PackageType> repository) => _repository = repository;

    public async Task<Guid> Handle(CreatePackageTypeRequest request, CancellationToken cancellationToken)
    {
        var packageType = new FSH.WebApi.Domain.Catalog.PackageType(request.Type, request.Name, request.Length, request.Width, request.Height, request.Weight, request.Volume, request.UOM, request.SubType);

        await _repository.AddAsync(packageType, cancellationToken);

        return packageType.Id;
    }
}
