using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.Catalog.Medias;
public class DeleteMediaRequest : IRequest<Guid>
{
    public Guid Id { get; set; }

    public DeleteMediaRequest(Guid id) => Id = id;
}

public class DeleteMediaRequestHandler : IRequestHandler<DeleteMediaRequest, Guid>
{
    private readonly IRepository<Media> _repository;
    private readonly IStringLocalizer<DeleteMediaRequestHandler> _localizer;

    public DeleteMediaRequestHandler(IRepository<Media> repository, IStringLocalizer<DeleteMediaRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Guid> Handle(DeleteMediaRequest request, CancellationToken cancellationToken)
    {
        var media = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = media ?? throw new NotFoundException(_localizer["Media.notfound"]);

        // Add Domain Events to be raised after the commit
        media.DomainEvents.Add(EntityDeletedEvent.WithEntity(media));

        await _repository.DeleteAsync(media, cancellationToken);

        return request.Id;
    }
}