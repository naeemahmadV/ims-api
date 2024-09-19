using FSH.WebApi.Application.Catalog.Account;
using FSH.WebApi.Application.Catalog.LeadAcitvity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.AccountActivity;
public class AccountActivityDto : IDto
{
    public Guid Id { get; set; }
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
    public IList<ActivityMediaDto>? ActivityMedias { get; set; }
    public Guid LastModifiedBy { get; set; }
    public DateTime? LastModifiedOn { get; set; }
    public Guid? AssignTo { get; set; }
}

public class ActivityMediaDto : IDto
{
    public Guid AccountId { get; set; }
    public Guid MediaId { get; set; }
    public MediaDto? Media { get; set; }
}

public class AccountActivityTaskDto : IDto
{
    public Guid Id { get; set; }
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
    public IList<ActivityMediaDto>? ActivityMedias { get; set; }
    public Guid LastModifiedBy { get; set; }
    public DateTime? LastModifiedOn { get; set; }
    public Guid? AssignTo { get; set; }

    public AccountDto Account { get; set; }
}
