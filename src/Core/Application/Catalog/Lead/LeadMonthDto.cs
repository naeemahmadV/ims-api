using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FSH.WebApi.Application.Catalog.Lead;
public class LeadMonthDto : IAggregateRoot
{
    [JsonIgnore]
    [NotMapped]
    public List<DomainEvent> DomainEvents => new();
    public int Month { get; set; }
    public int Count { get; set; }
}
