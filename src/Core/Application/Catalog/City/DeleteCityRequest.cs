using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.Catalog.City;
public class DeleteCityRequest : IRequest<Guid>
{
    public Guid Id { get; set; }

    public DeleteCityRequest(Guid id) => Id = id;
}

public class DeleteCityRequestHandler : IRequestHandler<DeleteCityRequest, Guid>
{
    private readonly IRepository<Domain.Catalog.City> _repository;
    private readonly IStringLocalizer<DeleteCityRequestHandler> _localizer;

    public DeleteCityRequestHandler(IRepository<Domain.Catalog.City> repository, IStringLocalizer<DeleteCityRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Guid> Handle(DeleteCityRequest request, CancellationToken cancellationToken)
    {
        var city = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = city ?? throw new NotFoundException(_localizer["City.notfound"]);

        // Add Domain Events to be raised after the commit
        city.DomainEvents.Add(EntityDeletedEvent.WithEntity(city));

        await _repository.DeleteAsync(city, cancellationToken);

        return request.Id;
    }
}