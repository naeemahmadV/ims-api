using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application;
public class UpdateSubSkillRequest : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string? SubSkillName { get; set; }
    public Guid? SkillId { get; set; }
}

public class UpdateSubSkillRequestHandler : IRequestHandler<UpdateSubSkillRequest, Guid>
{
    private readonly IRepository<SubSkill> _repository;
    private readonly IStringLocalizer<UpdateSubSkillRequestHandler> _localizer;
    private readonly IUploadService _file;

    public UpdateSubSkillRequestHandler(IRepository<SubSkill> repository, IStringLocalizer<UpdateSubSkillRequestHandler> localizer, IUploadService file) =>
        (_repository, _localizer, _file) = (repository, localizer, file);

    public async Task<Guid> Handle(UpdateSubSkillRequest request, CancellationToken cancellationToken)
    {
        var Subskill = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = Subskill ?? throw new NotFoundException(string.Format(_localizer["Skill.notfound"], request.Id));

        var updatedSubSkill = Subskill.Update(request.SubSkillName, request.SkillId);

        // Add Domain Events to be raised after the commit
        Subskill.DomainEvents.Add(EntityUpdatedEvent.WithEntity(Subskill));

        await _repository.UpdateAsync(updatedSubSkill, cancellationToken);

        return request.Id;
    }
}