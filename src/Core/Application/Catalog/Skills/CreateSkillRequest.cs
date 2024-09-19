using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.Catalog.Skills;
public class CreateSkillRequest : IRequest<Guid>
{
    public string Name { get; set; }
}

public class CreateSkillRequestHandler : IRequestHandler<CreateSkillRequest, Guid>
{
    private readonly IRepository<Skill> _repository;
    private readonly IUploadService _file;

    public CreateSkillRequestHandler(IRepository<Skill> repository, IUploadService file) =>
        (_repository, _file) = (repository, file);

    public async Task<Guid> Handle(CreateSkillRequest request, CancellationToken cancellationToken)
    {
        var leadSkill = new Skill(request.Name);

        // Add Domain Events to be raised after the commit
        leadSkill.DomainEvents.Add(EntityCreatedEvent.WithEntity(leadSkill));
        await _repository.AddAsync(leadSkill, cancellationToken);
        return leadSkill.Id;
    }
}