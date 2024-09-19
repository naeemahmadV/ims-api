
namespace FSH.WebApi.Application.Catalog.Medias;
public class GetMediaRequest : IRequest<MediaDto>
{
    public Guid Id { get; set; }

    public GetMediaRequest(Guid id) => Id = id;
}

public class GetMediaRequestHandler : IRequestHandler<GetMediaRequest, MediaDto>
{
    private readonly IRepository<Media> _repository;
    private readonly IStringLocalizer<GetMediaRequestHandler> _localizer;

    public GetMediaRequestHandler(IRepository<Media> repository, IStringLocalizer<GetMediaRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<MediaDto> Handle(GetMediaRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<Media, MediaDto>)new MediaById(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["Media.notfound"], request.Id));
}