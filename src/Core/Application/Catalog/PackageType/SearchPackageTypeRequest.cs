namespace FSH.WebApi.Application.Catalog.PackageType;
public class SearchPackageTypeRequest : PaginationFilter, IRequest<PaginationResponse<PackageTypeDto>>
{
}

public class PackageTypeBySearchRequestSpec : EntitiesByPaginationFilterSpec<FSH.WebApi.Domain.Catalog.PackageType, PackageTypeDto>
{
    public PackageTypeBySearchRequestSpec(SearchPackageTypeRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchPackageTypeRequestHandler : IRequestHandler<SearchPackageTypeRequest, PaginationResponse<PackageTypeDto>>
{
    private readonly IReadRepository<FSH.WebApi.Domain.Catalog.PackageType> _repository;

    public SearchPackageTypeRequestHandler(IReadRepository<FSH.WebApi.Domain.Catalog.PackageType> repository) => _repository = repository;

    public async Task<PaginationResponse<PackageTypeDto>> Handle(SearchPackageTypeRequest request, CancellationToken cancellationToken)
    {
        var spec = new PackageTypeBySearchRequestSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken);
    }
}
