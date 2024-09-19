using FSH.WebApi.Application.Catalog.LeadAcitvity;
using FSH.WebApi.Domain.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.AccountActivity;
public class CreateAccountActivityRequest : IRequest<Guid>
{
    public Guid? AccountId { get; set; }
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

public class CreateAccountActivityRequestHandler : IRequestHandler<CreateAccountActivityRequest, Guid>
{
    private readonly IRepository<AccountActivities> _repository;
    private readonly IRepository<ActivityMedia> _activityMedia;
    public CreateAccountActivityRequestHandler(IRepository<AccountActivities> repository, IRepository<ActivityMedia> activityMedia) =>
        (_repository, _activityMedia) = (repository, activityMedia);

    public async Task<Guid> Handle(CreateAccountActivityRequest request, CancellationToken cancellationToken)
    {
        var accountActivities = new AccountActivities(request.AccountId, request.ActivityType, request.Title, request.Description, request.MarkAsTask, request.TaskStartDate, request.TaskDueDate, request.TaskStatus, request.TaskCompletedOn, request.AssignTo);

        // Add Domain Events to be raised after the commit
        accountActivities.DomainEvents.Add(EntityCreatedEvent.WithEntity(accountActivities));

        await _repository.AddAsync(accountActivities, cancellationToken);

        if (request.ActivityMedia is not null && request.ActivityMedia.Length > 0)
        {
            foreach (var media in request.ActivityMedia)
            {
                await _activityMedia.AddAsync(new ActivityMedia()
                {
                    AccountActivitiesId = accountActivities.Id,
                    MediaId = media
                });
            }
        }

        return accountActivities.Id;
    }
}
