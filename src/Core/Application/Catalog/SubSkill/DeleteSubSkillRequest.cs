using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application;
public class DeleteSubSkillRequest : IRequest<Guid>
{
    public Guid Id { get; set; }

    public DeleteSubSkillRequest(Guid id) => Id = id;
}

public class DeleteSubSkillRequestHandler : IRequestHandler<DeleteSubSkillRequest, Guid>
{
    private readonly IRepository<SubSkill> _repository;
    private readonly IStringLocalizer<DeleteSubSkillRequestHandler> _localizer;

    public DeleteSubSkillRequestHandler(IRepository<SubSkill> repository, IStringLocalizer<DeleteSubSkillRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Guid> Handle(DeleteSubSkillRequest request, CancellationToken cancellationToken)
    {
        var skill = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = skill ?? throw new NotFoundException(_localizer["State.notfound"]);

        // Add Domain Events to be raised after the commit
        skill.DomainEvents.Add(EntityDeletedEvent.WithEntity(skill));

        await _repository.DeleteAsync(skill, cancellationToken);

        return request.Id;
    }
}