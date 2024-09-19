using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.Catalog.LeadAcitvity;
public class CreateLeadActivityRequest : IRequest<Guid>
{
    public Guid? LeadId { get; set; }
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

public class CreateLeadActivityRequestHandler : IRequestHandler<CreateLeadActivityRequest, Guid>
{
    private readonly IRepository<LeadActivities> _repository;
    private readonly IRepository<ActivityMedia> _activityMedia;
    public CreateLeadActivityRequestHandler(IRepository<LeadActivities> repository, IRepository<ActivityMedia> activityMedia) =>
        (_repository, _activityMedia) = (repository, activityMedia);

    public async Task<Guid> Handle(CreateLeadActivityRequest request, CancellationToken cancellationToken)
    {
        var leadActivities = new LeadActivities(request.LeadId, request.ActivityType, request.Title, request.Description, request.MarkAsTask, request.TaskStartDate, request.TaskDueDate, request.TaskStatus, request.TaskCompletedOn,request.AssignTo);

        // Add Domain Events to be raised after the commit
        leadActivities.DomainEvents.Add(EntityCreatedEvent.WithEntity(leadActivities));

        await _repository.AddAsync(leadActivities, cancellationToken);

        if (request.ActivityMedia is not null && request.ActivityMedia.Length > 0)
        {
            foreach (var media in request.ActivityMedia)
            {
                await _activityMedia.AddAsync(new ActivityMedia()
                {
                    LeadActivitiesId = leadActivities.Id,
                    MediaId = media
                });
            }
        }

        return leadActivities.Id;
    }
}