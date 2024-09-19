namespace FSH.WebApi.Application.Catalog.PackageType;
public class GetPackageTypeViaDapperRequest : IRequest<PackageTypeDto>
{
    public Guid Id { get; set; }

    public GetPackageTypeViaDapperRequest(Guid id) => Id = id;
}

public class GetPackageTypeViaDapperRequestHandler : IRequestHandler<GetPackageTypeViaDapperRequest, PackageTypeDto>
{
    private readonly IDapperRepository _repository;
    private readonly IStringLocalizer _t;

    public GetPackageTypeViaDapperRequestHandler(IDapperRepository repository, IStringLocalizer<GetPackageTypeViaDapperRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<PackageTypeDto> Handle(GetPackageTypeViaDapperRequest request, CancellationToken cancellationToken)
    {
        var packageType = await _repository.QueryFirstOrDefaultAsync<FSH.WebApi.Domain.Catalog.PackageType>(
            $"SELECT * FROM Catalog.\"PackageType\" WHERE \"Id\"  = '{request.Id}'", cancellationToken: cancellationToken);

        _ = packageType ?? throw new NotFoundException(_t["PackageType {0} Not Found.", request.Id]);

        // Using mapster here throws a nullreference exception because of the "BrandName" property
        // in ProductDto and the product not having a Brand assigned.
        return new PackageTypeDto
        {
            Id = packageType.Id,
            Type = packageType.Type,
            Name = packageType.Name,
            Length = packageType.Length,
            Width = packageType.Width,
            Height = packageType.Height,
            Weight = packageType.Weight,
            Volume = packageType.Volume,
            UOM = packageType.UOM,
            SubType = packageType.SubType,
        };
    }
}