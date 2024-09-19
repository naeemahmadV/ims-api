namespace FSH.WebApi.Domain.Catalog;
public class ActivityMedia : AuditableEntity, IAggregateRoot
{
    public Guid LeadActivitiesId { get; set; }
    public virtual LeadActivities LeadActivities { get; set; } = null!;

    public Guid AccountActivitiesId { get; set; }
    public virtual AccountActivities AccountActivities { get; set; } = null!;

    public Guid OpportunityActivitiesId { get; set; }
    public virtual OpportunityActivities OpportunityActivities { get; set; } = null!;

    public Guid MediaId { get; set; }
    public virtual Media Media { get; set; } = null!;
}
