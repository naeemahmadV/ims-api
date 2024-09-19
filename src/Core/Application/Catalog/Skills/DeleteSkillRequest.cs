using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.Catalog.Skills;
public class DeleteSkillRequest : IRequest<Guid>
{
    public Guid Id { get; set; }

    public DeleteSkillRequest(Guid id) => Id = id;
}

public class DeleteSkillRequestHandler : IRequestHandler<DeleteSkillRequest, Guid>
{
    private readonly IRepository<Skill> _repository;
    private readonly IStringLocalizer<DeleteSkillRequestHandler> _localizer;

    public DeleteSkillRequestHandler(IRepository<Skill> repository, IStringLocalizer<DeleteSkillRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Guid> Handle(DeleteSkillRequest request, CancellationToken cancellationToken)
    {
        var skill = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = skill ?? throw new NotFoundException(_localizer["State.notfound"]);

        // Add Domain Events to be raised after the commit
        skill.DomainEvents.Add(EntityDeletedEvent.WithEntity(skill));

        await _repository.DeleteAsync(skill, cancellationToken);

        return request.Id;
    }
}