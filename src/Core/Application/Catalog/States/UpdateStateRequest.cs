using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application;
public class UpdateStateRequest : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string Code { get; set; }
    public Guid CountryId { get; set; }
}

public class UpdateStateRequestHandler : IRequestHandler<UpdateStateRequest, Guid>
{
    private readonly IRepository<State> _repository;
    private readonly IStringLocalizer<UpdateStateRequestHandler> _localizer;
    private readonly IUploadService _file;

    public UpdateStateRequestHandler(IRepository<State> repository, IStringLocalizer<UpdateStateRequestHandler> localizer, IUploadService file) =>
        (_repository, _localizer, _file) = (repository, localizer, file);

    public async Task<Guid> Handle(UpdateStateRequest request, CancellationToken cancellationToken)
    {
        var state = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = state ?? throw new NotFoundException(string.Format(_localizer["State.notfound"], request.Id));

        var updatedState = state.Update(request.Name, request.Code, request.CountryId);

        // Add Domain Events to be raised after the commit
        state.DomainEvents.Add(EntityUpdatedEvent.WithEntity(state));

        await _repository.UpdateAsync(updatedState, cancellationToken);

        return request.Id;
    }
}