namespace FSH.WebApi.Application.Catalog.Skills;
public class SearchSkillRequest : PaginationFilter, IRequest<PaginationResponse<SkillDto>>
{

}

public class SkillBySearchRequestSpec : EntitiesByPaginationFilterSpec<Skill, SkillDto>
{
    public SkillBySearchRequestSpec(SearchSkillRequest request)
        : base(request) => Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchSkillRequestHandler : IRequestHandler<SearchSkillRequest, PaginationResponse<SkillDto>>
{
    private readonly IReadRepository<Skill> _repository;

    public SearchSkillRequestHandler(IReadRepository<Skill> repository) => _repository = repository;

    public async Task<PaginationResponse<SkillDto>> Handle(SearchSkillRequest request, CancellationToken cancellationToken)
    {
        var spec = new SkillBySearchRequestSpec(request);
        var result = await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken);
        return result;
    }
}
