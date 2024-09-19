using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.Catalog.LeadAcitvity;
public class UpdateLeadActivityRequest : IRequest<Guid>
{
    public Guid Id { get; set; }
    public Guid? LeadId { get; set; }
    public int? ActivityType { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public bool? MarkAsTask { get; set; }
    public DateTime? TaskStartDate { get; set; }
    public DateTime? TaskDueDate { get; set; }
    public int TaskStatus { get; set; }
    public DateTime? TaskCompletedOn { get; set; }
    public Guid[]? ActivityMedia { get; set; }
    public Guid? AssignTo { get; set; }
}

public class UpdateLeadActivityRequestHandler : IRequestHandler<UpdateLeadActivityRequest, Guid>
{
    private readonly IRepository<LeadActivities> _repository;
    private readonly IRepository<ActivityMedia> _activityMedia;
    private readonly IStringLocalizer<UpdateLeadActivityRequestHandler> _localizer;
    public UpdateLeadActivityRequestHandler(IRepository<LeadActivities> repository, IRepository<ActivityMedia> activityMedia, IStringLocalizer<UpdateLeadActivityRequestHandler> localizer) =>
        (_repository, _activityMedia, _localizer) = (repository, activityMedia, localizer);

    public async Task<Guid> Handle(UpdateLeadActivityRequest request, CancellationToken cancellationToken)
    {
        var leadActivity = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = leadActivity ?? throw new NotFoundException(string.Format(_localizer["Lead Activity.notfound"], request.Id));

        var updateLeadActivities = leadActivity.Update(request.LeadId, request.ActivityType, request.Title, request.Description, request.MarkAsTask, request.TaskStartDate, request.TaskDueDate, request.TaskStatus, request.TaskCompletedOn,request.AssignTo);

        // Add Domain Events to be raised after the commit
        leadActivity.DomainEvents.Add(EntityUpdatedEvent.WithEntity(leadActivity));

        await _repository.UpdateAsync(updateLeadActivities, cancellationToken);

        var activityMediaspec = new ActivityMediaSpecification(new ActivityMediaRequest()
        {
            LeadActivitiesId = leadActivity.Id
        });

        var activityMedias = await _activityMedia.ListAsync(activityMediaspec, cancellationToken);

        if (activityMedias.Count() > 0)
            await _activityMedia.DeleteRangeAsync(activityMedias);

        if (request.ActivityMedia is not null && request.ActivityMedia.Length > 0)
        {
            foreach (var media in request.ActivityMedia)
            {
                await _activityMedia.AddAsync(new ActivityMedia()
                {
                    LeadActivitiesId = request.Id,
                    MediaId = media
                });
            }
        }

        return request.Id;
    }
}

public class ActivityMediaSpecification : EntitiesByBaseFilterSpec<ActivityMedia, ActivityMedia>
{
    public ActivityMediaSpecification(ActivityMediaRequest request)
        : base(request) =>
        Query
            .Where(p => p.LeadActivitiesId == request.LeadActivitiesId);
}

public class ActivityMediaRequest : BaseFilter
{
    public Guid LeadActivitiesId { get; set; }
}
