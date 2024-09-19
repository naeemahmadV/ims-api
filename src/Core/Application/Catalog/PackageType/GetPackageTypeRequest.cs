namespace FSH.WebApi.Application.Catalog.PackageType;
public class GetPackageTypeRequest : IRequest<PackageTypeDto>
{
    public Guid Id { get; set; }

    public GetPackageTypeRequest(Guid id) => Id = id;
}

public class SalesOderByIdSpec : Specification<FSH.WebApi.Domain.Catalog.PackageType, PackageTypeDto>, ISingleResultSpecification
{
    public SalesOderByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetPackageTypeRequestHandler : IRequestHandler<GetPackageTypeRequest, PackageTypeDto>
{
    private readonly IRepository<FSH.WebApi.Domain.Catalog.PackageType> _repository;
    private readonly IStringLocalizer _t;

    public GetPackageTypeRequestHandler(IRepository<FSH.WebApi.Domain.Catalog.PackageType> repository, IStringLocalizer<GetPackageTypeRequestHandler> localizer) => (_repository, _t) = (repository, localizer);

    public async Task<PackageTypeDto> Handle(GetPackageTypeRequest request, CancellationToken cancellationToken) =>
        await _repository.FirstOrDefaultAsync(
            (ISpecification<FSH.WebApi.Domain.Catalog.PackageType, PackageTypeDto>)new SalesOderByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(_t["PackageType {0} Not Found.", request.Id]);
}
