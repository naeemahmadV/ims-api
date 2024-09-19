
namespace FSH.WebApi.Application.Catalog.Skills;
public class GetSkillRequest : IRequest<SkillDto>
{
    public Guid Id { get; set; }

    public GetSkillRequest(Guid id) => Id = id;
}

public class GetSkillRequestHandler : IRequestHandler<GetSkillRequest, SkillDto>
{
    private readonly IRepository<Skill> _repository;
    private readonly IStringLocalizer<GetSkillRequestHandler> _localizer;

    public GetSkillRequestHandler(IRepository<Skill> repository, IStringLocalizer<GetSkillRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<SkillDto> Handle(GetSkillRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<Domain.Catalog.Skill, SkillDto>)new SkillById(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["State.notfound"], request.Id));
}