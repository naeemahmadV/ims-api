using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Domain.Catalog;
public class AccountActivities : AuditableEntity, IAggregateRoot
{
    [ForeignKey("Account")]
    public Guid? AccountId { get; set; }
    public virtual Account Account { get; set; }
    public int? ActivityType { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public bool? MarkAsTask { get; set; }
    public DateTime? TaskStartDate { get; set; }
    public DateTime? TaskDueDate { get; set; }
    public int? TaskStatus { get; set; }
    public DateTime? TaskCompletedOn { get; set; }
    public Guid? AssignTo { get; set; }
    public virtual IList<ActivityMedia>? ActivityMedias { get; set; }

    public AccountActivities(Guid? accountId, int? activityType, string? title, string? description, bool? markAsTask, DateTime? taskStartDate, DateTime? taskDueDate, int? taskStatus, DateTime? taskCompletedOn, Guid? assignTo)
    {
        AccountId = accountId;
        ActivityType = activityType;
        Title = title;
        Description = description;
        MarkAsTask = markAsTask;
        TaskStartDate = taskStartDate;
        TaskDueDate = taskDueDate;
        TaskStatus = taskStatus;
        TaskCompletedOn = taskCompletedOn;
        AssignTo = assignTo;
    }

    public AccountActivities Update(Guid? accountId, int? activityType, string? title, string? description, bool? markAsTask, DateTime? taskStartDate, DateTime? taskDueDate, int? taskStatus, DateTime? taskCompletedOn, Guid? assignTo)
    {
        if (accountId is not null && AccountId?.Equals(accountId) is not true) AccountId = accountId;
        if (ActivityType.Equals(activityType) is not true) ActivityType = activityType;
        if (title is not null && Title?.Equals(title) is not true) Title = title;
        if (description is not null && Description?.Equals(description) is not true) Description = description;
        if (markAsTask is not null && MarkAsTask?.Equals(markAsTask) is not true) MarkAsTask = markAsTask;
        if (taskStartDate is not null && TaskStartDate?.Equals(taskStartDate) is not true) TaskStartDate = taskStartDate;
        if (taskDueDate is not null && TaskDueDate?.Equals(taskDueDate) is not true) TaskDueDate = taskDueDate;
        if (TaskStatus.Equals(taskStatus) is not true) TaskStatus = taskStatus;
        if (taskCompletedOn is not null && TaskCompletedOn?.Equals(taskCompletedOn) is not true) TaskCompletedOn = taskCompletedOn;
        if (assignTo is not null && AssignTo?.Equals(assignTo) is not true) AssignTo = assignTo;

        return this;

    }

}
