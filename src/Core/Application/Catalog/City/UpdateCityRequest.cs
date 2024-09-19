using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.Catalog.City;
public class UpdateCityRequest : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public Guid StateId { get; set; }
}

public class UpdateCityRequestHandler : IRequestHandler<UpdateCityRequest, Guid>
{
    private readonly IRepository<Domain.Catalog.City> _repository;
    private readonly IStringLocalizer<UpdateCityRequestHandler> _localizer;
    private readonly IUploadService _file;

    public UpdateCityRequestHandler(IRepository<Domain.Catalog.City> repository, IStringLocalizer<UpdateCityRequestHandler> localizer, IUploadService file) =>
        (_repository, _localizer, _file) = (repository, localizer, file);

    public async Task<Guid> Handle(UpdateCityRequest request, CancellationToken cancellationToken)
    {
        var city = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = city ?? throw new NotFoundException(string.Format(_localizer["City.notfound"], request.Id));

        var updatedCity = city.Update(request.Name, request.StateId);

        // Add Domain Events to be raised after the commit
        city.DomainEvents.Add(EntityUpdatedEvent.WithEntity(city));

        await _repository.UpdateAsync(updatedCity, cancellationToken);

        return request.Id;
    }
}

