using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.Catalog.OpportunityActivity;
public class CreateOpportunityActivityRequest : IRequest<Guid>
{
    public Guid? OpportunityId { get; set; }
    public int? ActivityType { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public bool? MarkAsTask { get; set; }
    public DateTime? TaskStartDate { get; set; }
    public DateTime? TaskDueDate { get; set; }
    public int? TaskStatus { get; set; }
    public DateTime? TaskCompletedOn { get; set; }
    public Guid[]? ActivityMedia { get; set; }
    public Guid? AssignTo { get; set; }
}

public class CreateOpportunityActivityRequestHandler : IRequestHandler<CreateOpportunityActivityRequest, Guid>
{
    private readonly IRepository<OpportunityActivities> _repository;
    private readonly IRepository<ActivityMedia> _activityMedia;
    public CreateOpportunityActivityRequestHandler(IRepository<OpportunityActivities> repository, IRepository<ActivityMedia> activityMedia)
    {
        _repository = repository;
        _activityMedia = activityMedia;
    }

    public async Task<DefaultIdType> Handle(CreateOpportunityActivityRequest request, CancellationToken cancellationToken)
    {
        var opportunityActivities = new OpportunityActivities(request.OpportunityId, request.ActivityType, request.Title, request.Description, request.MarkAsTask, request.TaskStartDate, request.TaskDueDate, request.TaskStatus, request.TaskCompletedOn, request.AssignTo);

        opportunityActivities.DomainEvents.Add(EntityCreatedEvent.WithEntity(opportunityActivities));

        await _repository.AddAsync(opportunityActivities, cancellationToken);

        if (request.ActivityMedia is not null && request.ActivityMedia.Length > 0)
        {
            foreach (var media in request.ActivityMedia)
            {
                await _activityMedia.AddAsync(new ActivityMedia()
                {
                    OpportunityActivitiesId = opportunityActivities.Id,
                    MediaId = media
                });
            }
        }

        return opportunityActivities.Id;
    }
}
