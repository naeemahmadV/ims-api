
namespace FSH.WebApi.Application.Catalog.City;
public class GetCityRequest : IRequest<CityDto>
{
    public Guid Id { get; set; }

    public GetCityRequest(Guid id) => Id = id;
}

public class GetCityRequestHandler : IRequestHandler<GetCityRequest, CityDto>
{
    private readonly IRepository<Domain.Catalog.City> _repository;
    private readonly IStringLocalizer<GetCityRequestHandler> _localizer;

    public GetCityRequestHandler(IRepository<Domain.Catalog.City> repository, IStringLocalizer<GetCityRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<CityDto> Handle(GetCityRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<Domain.Catalog.City, CityDto>)new CityById(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["City.notfound"], request.Id));
}
