using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application;
public class CreateCityRequest : IRequest<Guid>
{
    public string? Name { get; set; }
    public Guid StateId { get; set; }
}

public class CreateCityRequestHandler : IRequestHandler<CreateCityRequest, Guid>
{
    private readonly IRepository<Domain.Catalog.City> _repository;
    private readonly IUploadService _file;

    public CreateCityRequestHandler(IRepository<Domain.Catalog.City> repository, IUploadService file) =>
        (_repository, _file) = (repository, file);

    public async Task<Guid> Handle(CreateCityRequest request, CancellationToken cancellationToken)
    {
        var leadcity = new City(request.Name, request.StateId);
        // Add Domain Events to be raised after the commit
        leadcity.DomainEvents.Add(EntityCreatedEvent.WithEntity(leadcity));
        await _repository.AddAsync(leadcity, cancellationToken);
        return leadcity.Id;
    }
}