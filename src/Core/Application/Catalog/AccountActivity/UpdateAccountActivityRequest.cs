using FSH.WebApi.Application.Catalog.LeadAcitvity;
using FSH.WebApi.Domain.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.AccountActivity;
public class UpdateAccountActivityRequest : IRequest<Guid>
{
    public Guid Id { get; set; }
    public Guid? AccountId { get; set; }
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

public class UpdateAccountActivityRequestHandler : IRequestHandler<UpdateAccountActivityRequest, Guid>
{
    private readonly IRepository<AccountActivities> _repository;
    private readonly IRepository<ActivityMedia> _activityMedia;
    private readonly IStringLocalizer<UpdateAccountActivityRequestHandler> _localizer;
    public UpdateAccountActivityRequestHandler(IRepository<AccountActivities> repository, IRepository<ActivityMedia> activityMedia, IStringLocalizer<UpdateAccountActivityRequestHandler> localizer) =>
        (_repository, _activityMedia, _localizer) = (repository, activityMedia, localizer);

    public async Task<Guid> Handle(UpdateAccountActivityRequest request, CancellationToken cancellationToken)
    {
        var accountActivity = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = accountActivity ?? throw new NotFoundException(string.Format(_localizer["Account Activity.notfound"], request.Id));

        var updateAccountActivities = accountActivity.Update(request.AccountId, request.ActivityType, request.Title, request.Description, request.MarkAsTask, request.TaskStartDate, request.TaskDueDate, request.TaskStatus, request.TaskCompletedOn, request.AssignTo);

        // Add Domain Events to be raised after the commit
        accountActivity.DomainEvents.Add(EntityUpdatedEvent.WithEntity(accountActivity));

        await _repository.UpdateAsync(updateAccountActivities, cancellationToken);

        var activityMediaspec = new ActivityMediaSpecification(new ActivityMediaRequest()
        {
            AccountActivitiesId = accountActivity.Id
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
                    AccountActivitiesId = request.Id,
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
            .Where(p => p.AccountActivitiesId == request.AccountActivitiesId);
}

public class ActivityMediaRequest : BaseFilter
{
    public Guid AccountActivitiesId { get; set; }

}
