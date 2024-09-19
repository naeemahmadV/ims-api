using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.Catalog.OpportunityActivity;
public class UpdateOpportunityActivityRequest : IRequest<Guid>
{
    public Guid Id { get; set; }
    public Guid? OpportunityId { get; set; }
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

public class UpdateOpportunityActivityRequestHandler : IRequestHandler<UpdateOpportunityActivityRequest, Guid>
{
    private readonly IRepository<OpportunityActivities> _repository;
    private readonly IRepository<ActivityMedia> _activityMedia;
    private readonly IStringLocalizer<UpdateOpportunityActivityRequestHandler> _localizer;

    public UpdateOpportunityActivityRequestHandler(IRepository<OpportunityActivities> repository, IRepository<ActivityMedia> activityMedia, IStringLocalizer<UpdateOpportunityActivityRequestHandler> localizer) =>
        (_repository, _activityMedia, _localizer) = (repository, activityMedia, localizer);

    public async Task<Guid> Handle(UpdateOpportunityActivityRequest request, CancellationToken cancellationToken)
    {
        var opportunityActivity = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = opportunityActivity ?? throw new NotFoundException(string.Format(_localizer["Opportunity Activity.notfound"], request.Id));

        var updateopportunityActivities = opportunityActivity.Update(request.OpportunityId, request.ActivityType, request.Title, request.Description, request.MarkAsTask, request.TaskStartDate, request.TaskDueDate, request.TaskStatus, request.TaskCompletedOn, request.AssignTo);

        opportunityActivity.DomainEvents.Add(EntityUpdatedEvent.WithEntity(opportunityActivity));

        await _repository.UpdateAsync(updateopportunityActivities, cancellationToken);

        var activityMediaspec = new ActivityMediaSpecification(new ActivityMediaRequest()
        {
            OpportunityActivitiesId = opportunityActivity.Id
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
                    OpportunityActivitiesId = request.Id,
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
            .Where(p => p.OpportunityActivitiesId == request.OpportunityActivitiesId);
}

public class ActivityMediaRequest : BaseFilter
{
    public Guid OpportunityActivitiesId { get; set; }
}
