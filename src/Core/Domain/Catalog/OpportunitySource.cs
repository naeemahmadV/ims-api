namespace FSH.WebApi.Domain.Catalog;
public class OpportunitySource : AuditableEntity, IAggregateRoot
{
    public string SourceName { get; set; }

    public OpportunitySource(string sourceName)
    {
        SourceName = sourceName;
    }

    public OpportunitySource Update(string? sourceName)
    {
        if (sourceName is not null && SourceName?.Equals(sourceName) is not true) SourceName = sourceName;
        return this;
    }
}
