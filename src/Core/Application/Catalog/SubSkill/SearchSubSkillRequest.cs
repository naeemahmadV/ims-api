using FSH.WebApi.Application.Catalog.SubSkill;

namespace FSH.WebApi.Application;
public class SearchSubSkillRequest : PaginationFilter, IRequest<PaginationResponse<SubSkillDto>>
{

}

public class SubSkillBySearchRequestSpec : EntitiesByPaginationFilterSpec<SubSkill, SubSkillDto>
{
    public SubSkillBySearchRequestSpec(SearchSubSkillRequest request)
        : base(request) =>
        Query.OrderBy(c => c.SubSkillName, !request.HasOrderBy());
}

public class SearchSubSkillRequestHandler : IRequestHandler<SearchSubSkillRequest, PaginationResponse<SubSkillDto>>
{
    private readonly IReadRepository<SubSkill> _repository;

    public SearchSubSkillRequestHandler(IReadRepository<SubSkill> repository) => _repository = repository;

    public async Task<PaginationResponse<SubSkillDto>> Handle(SearchSubSkillRequest request, CancellationToken cancellationToken)
    {
        var spec = new SubSkillBySearchRequestSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken);
    }
}
