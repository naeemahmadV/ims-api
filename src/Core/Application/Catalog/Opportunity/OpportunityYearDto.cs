using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FSH.WebApi.Application.Catalog.Opportunity;
public class OpportunityYearDto : IAggregateRoot
{
    [JsonIgnore]
    [NotMapped]
    public List<DomainEvent> DomainEvents => new();
    public int Year { get; set; }
    public int? Count { get; set; }
}
