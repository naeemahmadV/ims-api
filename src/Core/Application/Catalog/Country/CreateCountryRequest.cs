using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application;
public class CreateCountryRequest : IRequest<Guid>
{
    public string? Name { get; set; }
    public string Code { get; set; }
}

public class CreateCountryRequestHandler : IRequestHandler<CreateCountryRequest, Guid>
{
    private readonly IRepository<Country> _repository;
    private readonly IUploadService _file;

    public CreateCountryRequestHandler(IRepository<Country> repository, IUploadService file) =>
        (_repository, _file) = (repository, file);

    public async Task<Guid> Handle(CreateCountryRequest request, CancellationToken cancellationToken)
    {
        var leadSource = new Country(request.Name, request.Code);
        //Add Domain Events to be raised after the commit
        leadSource.DomainEvents.Add(EntityCreatedEvent.WithEntity(leadSource));
        await _repository.AddAsync(leadSource, cancellationToken);
        return leadSource.Id;
    }
}
