using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application;
public class DeleteCountryRequest : IRequest<Guid>
{
    public Guid Id { get; set; }

    public DeleteCountryRequest(Guid id) => Id = id;
}

public class DeleteCountryRequestHandler : IRequestHandler<DeleteCountryRequest, Guid>
{
    private readonly IRepository<Country> _repository;
    private readonly IStringLocalizer<DeleteCountryRequestHandler> _localizer;

    public DeleteCountryRequestHandler(IRepository<Country> repository, IStringLocalizer<DeleteCountryRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Guid> Handle(DeleteCountryRequest request, CancellationToken cancellationToken)
    {
        var country = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = country ?? throw new NotFoundException(_localizer["Country.notfound"]);

        // Add Domain Events to be raised after the commit
        country.DomainEvents.Add(EntityDeletedEvent.WithEntity(country));

        await _repository.DeleteAsync(country, cancellationToken);

        return request.Id;
    }
}
