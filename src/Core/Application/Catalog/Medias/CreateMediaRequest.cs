using FSH.WebApi.Application.Models;
using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.Catalog.Medias;
public class CreateMediaRequest : IRequest<Guid>
{
    public string MediaName { get; set; }
    public Guid MediaGuid { get; set; }
    public string? MimeType { get; set; }
    public string? AltAttribute { get; set; }
    public string? TitleAttribute { get; set; }
    public string PathURL { get; set; }
    public bool Active { get; set; }
    public bool Deleted { get; set; }
    public UploadRequest? Image { get; set; }
}

public class CreateMediaRequestHandler : IRequestHandler<CreateMediaRequest, Guid>
{
    private readonly IRepository<Media> _repository;
    private readonly IUploadService _file;

    public CreateMediaRequestHandler(IRepository<Media> repository, IUploadService file) =>
        (_repository, _file) = (repository, file);

    public async Task<Guid> Handle(CreateMediaRequest request, CancellationToken cancellationToken)
    {
        var url = _file.UploadAsync(request.Image);

        var media = new Media(request.MediaName, request.MediaGuid, request.MimeType, request.AltAttribute, request.TitleAttribute, url, request.Active, request.Deleted);

        // Add Domain Events to be raised after the commit
        media.DomainEvents.Add(EntityCreatedEvent.WithEntity(media));

        await _repository.AddAsync(media, cancellationToken);

        return media.Id;
    }
}