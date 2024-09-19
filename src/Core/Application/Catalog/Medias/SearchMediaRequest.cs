namespace FSH.WebApi.Application.Catalog.Medias;
public class SearchMediaRequest : PaginationFilter, IRequest<PaginationResponse<MediaDto>>
{
}

public class MediaBySearchRequestSpec : EntitiesByPaginationFilterSpec<Media, MediaDto>
{
    public MediaBySearchRequestSpec(SearchMediaRequest request)
        : base(request) => Query.OrderBy(c => c.MediaName, !request.HasOrderBy());
}

public class SearchMediaRequestHandler : IRequestHandler<SearchMediaRequest, PaginationResponse<MediaDto>>
{
    private readonly IReadRepository<Media> _repository;

    public SearchMediaRequestHandler(IReadRepository<Media> repository) => _repository = repository;

    public async Task<PaginationResponse<MediaDto>> Handle(SearchMediaRequest request, CancellationToken cancellationToken)
    {
        var spec = new MediaBySearchRequestSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken);
    }
}