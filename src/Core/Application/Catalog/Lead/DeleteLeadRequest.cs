using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application;
public class DeleteLeadRequest : IRequest<Guid>
{
    public Guid Id { get; set; }

    public DeleteLeadRequest(Guid id) => Id = id;
}

public class DeleteLeadRequestHandler : IRequestHandler<DeleteLeadRequest, Guid>
{
    private readonly IRepository<Lead> _repository;
    private readonly IStringLocalizer<DeleteLeadRequestHandler> _localizer;

    public DeleteLeadRequestHandler(IRepository<Lead> repository, IStringLocalizer<DeleteLeadRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Guid> Handle(DeleteLeadRequest request, CancellationToken cancellationToken)
    {
        var lead = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = lead ?? throw new NotFoundException(_localizer["Lead.notfound"]);

        // Add Domain Events to be raised after the commit
        lead.DomainEvents.Add(EntityDeletedEvent.WithEntity(lead));

        await _repository.DeleteAsync(lead, cancellationToken);

        return request.Id;
    }
}
