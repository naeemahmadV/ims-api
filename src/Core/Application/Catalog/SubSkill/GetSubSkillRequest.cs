using FSH.WebApi.Application.Catalog.SubSkill;

namespace FSH.WebApi.Application;
public class GetSubSkillRequest : IRequest<SubSkillDto>
{
    public Guid Id { get; set; }

    public GetSubSkillRequest(Guid id) => Id = id;
}

public class GetSubSkillRequestHandler : IRequestHandler<GetSubSkillRequest, SubSkillDto>
{
    private readonly IRepository<SubSkill> _repository;
    private readonly IStringLocalizer<GetSubSkillRequestHandler> _localizer;

    public GetSubSkillRequestHandler(IRepository<SubSkill> repository, IStringLocalizer<GetSubSkillRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<SubSkillDto> Handle(GetSubSkillRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<SubSkill, SubSkillDto>)new SubSkillById(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["State.notfound"], request.Id));
}