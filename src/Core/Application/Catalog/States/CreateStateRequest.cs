using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application;
public class CreateStateRequest : IRequest<Guid>
{
    public string? Name { get; set; }
    public string? Code { get; set; }
    public Guid CountryId { get; set; }
}

public class CreateStateRequestHandler : IRequestHandler<CreateStateRequest, Guid>
{
    private readonly IRepository<State> _repository;
    private readonly IUploadService _file;

    public CreateStateRequestHandler(IRepository<State> repository, IUploadService file) =>
        (_repository, _file) = (repository, file);

    public async Task<Guid> Handle(CreateStateRequest request, CancellationToken cancellationToken)
    {
        var leadState = new State(request.Name, request.Code, request.CountryId);
        ///Add Domain Events to be raised after the commit
        leadState.DomainEvents.Add(EntityCreatedEvent.WithEntity(leadState));
        await _repository.AddAsync(leadState, cancellationToken);
        return leadState.Id;
    }
}