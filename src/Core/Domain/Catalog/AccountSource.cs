namespace FSH.WebApi.Domain.Catalog;
public class AccountSource : AuditableEntity, IAggregateRoot
{
    public string SourceName { get; set; }

    public AccountSource(string sourceName)
    {
        SourceName = sourceName;
    }

    public AccountSource Update(string?sourceName)
    {
        if (sourceName is not null && SourceName?.Equals(sourceName) is not true) SourceName = sourceName;
        return this;
    }
}
