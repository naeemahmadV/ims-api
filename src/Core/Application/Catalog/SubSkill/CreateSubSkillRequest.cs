using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application;
public class CreateSubSkillRequest : IRequest<Guid>
{
    public string? SubSkillName { get; set; }
    public Guid? SkillId { get; set; }
}

public class CreateSubSkillRequestHandler : IRequestHandler<CreateSubSkillRequest, Guid>
{
    private readonly IRepository<SubSkill> _repository;
    private readonly IUploadService _file;

    public CreateSubSkillRequestHandler(IRepository<SubSkill> repository, IUploadService file) =>
        (_repository, _file) = (repository, file);

    public async Task<Guid> Handle(CreateSubSkillRequest request, CancellationToken cancellationToken)
    {
        var leadSubSkill = new SubSkill(request.SubSkillName, request.SkillId);

        // Add Domain Events to be raised after the commit
        leadSubSkill.DomainEvents.Add(EntityCreatedEvent.WithEntity(leadSubSkill));
        await _repository.AddAsync(leadSubSkill, cancellationToken);
        return leadSubSkill.Id;
    }
}