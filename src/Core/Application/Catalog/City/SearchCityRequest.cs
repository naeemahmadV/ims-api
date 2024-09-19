
namespace FSH.WebApi.Application.Catalog.City;
public class SearchCityRequest : PaginationFilter, IRequest<PaginationResponse<CityDto>>
{

}

public class CityBySearchRequestSpec : EntitiesByPaginationFilterSpec<Domain.Catalog.City, CityDto>
{
    public CityBySearchRequestSpec(SearchCityRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchCityRequestHandler : IRequestHandler<SearchCityRequest, PaginationResponse<CityDto>>
{
    private readonly IReadRepository<Domain.Catalog.City> _repository;

    public SearchCityRequestHandler(IReadRepository<Domain.Catalog.City> repository) => _repository = repository;

    public async Task<PaginationResponse<CityDto>> Handle(SearchCityRequest request, CancellationToken cancellationToken)
    {
        var spec = new CityBySearchRequestSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken);
    }
}