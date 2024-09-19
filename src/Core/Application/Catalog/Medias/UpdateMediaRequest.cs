using FSH.WebApi.Application.Models;
using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.Catalog.Medias;
public class UpdateMediaRequest : IRequest<Guid>
{
    public string MediaName { get; set; } = default!;
    public Guid MediaGuid { get; set; }
    public string? MimeType { get; set; }
    public string? AltAttribute { get; set; }
    public string? TitleAttribute { get; set; }
    public string PathURL { get; set; } = default!;
    public bool Active { get; set; }
    public bool Deleted { get; set; }
    public Guid Id { get; set; }
    public UploadRequest? Image { get; set; }
}

public class UpdateMediaRequestHandler : IRequestHandler<UpdateMediaRequest, Guid>
{
    private readonly IRepository<Media> _repository;
    private readonly IStringLocalizer<UpdateMediaRequestHandler> _localizer;
    private readonly IUploadService _file;

    public UpdateMediaRequestHandler(IRepository<Media> repository, IStringLocalizer<UpdateMediaRequestHandler> localizer, IUploadService file) =>
        (_repository, _localizer, _file) = (repository, localizer, file);

    public async Task<Guid> Handle(UpdateMediaRequest request, CancellationToken cancellationToken)
    {
        var media = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = media ?? throw new NotFoundException(string.Format(_localizer["Media.notfound"], request.Id));
        var url = _file.UploadAsync(request.Image);

        // Remove old image if flag is set
        var updatedMedia = media.Update(request.MediaName, request.MediaGuid, request.MimeType, request.AltAttribute, request.TitleAttribute, url, request.Active, request.Deleted);

        // Add Domain Events to be raised after the commit
        media.DomainEvents.Add(EntityUpdatedEvent.WithEntity(media));

        await _repository.UpdateAsync(updatedMedia, cancellationToken);

        return request.Id;
    }
}
