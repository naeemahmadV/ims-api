using System.ComponentModel.DataAnnotations.Schema;

namespace FSH.WebApi.Domain.Catalog;
public class State : AuditableEntity, IAggregateRoot
{
    public string? Name { get; set; }
    public string? Code { get; set; }
    [Column("CountryId")]
    public Guid CountryId { get; set; }
    public Country Country { get; set; }

    public State(string name, string code, Guid countryId)
    {
        Name = name;
        Code = code;
        CountryId = countryId;
    }

    public State Update(string? name, string? code, Guid? countryId)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (code is not null && Code?.Equals(code) is not true) Code = code;
        return this;
    }
}
