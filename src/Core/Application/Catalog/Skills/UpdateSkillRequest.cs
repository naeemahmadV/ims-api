using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.Catalog.Skills;
public class UpdateSkillRequest : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}

public class UpdateSkillRequestHandler : IRequestHandler<UpdateSkillRequest, Guid>
{
    private readonly IRepository<Domain.Catalog.Skill> _repository;
    private readonly IStringLocalizer<UpdateSkillRequestHandler> _localizer;
    private readonly IUploadService _file;

    public UpdateSkillRequestHandler(IRepository<Domain.Catalog.Skill> repository, IStringLocalizer<UpdateSkillRequestHandler> localizer, IUploadService file) =>
        (_repository, _localizer, _file) = (repository, localizer, file);

    public async Task<Guid> Handle(UpdateSkillRequest request, CancellationToken cancellationToken)
    {
        var skill = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = skill ?? throw new NotFoundException(string.Format(_localizer["Skill.notfound"], request.Id));

        var updatedState = skill.Update(request.Name);

        // Add Domain Events to be raised after the commit
        skill.DomainEvents.Add(EntityUpdatedEvent.WithEntity(skill));

        await _repository.UpdateAsync(updatedState, cancellationToken);

        return request.Id;
    }
}