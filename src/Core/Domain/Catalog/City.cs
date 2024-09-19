using System.ComponentModel.DataAnnotations.Schema;

namespace FSH.WebApi.Domain.Catalog;
public class City : AuditableEntity, IAggregateRoot
{
    public string? Name { get; set; }

    [Column("StateId")]
    public Guid StateId { get; set; }
    public State State { get; set; }

    public City(string name, Guid stateId)
    {
        Name = name;
        StateId = stateId;
    }

    public City Update(string? name, Guid? stateId)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        return this;
    }
}
