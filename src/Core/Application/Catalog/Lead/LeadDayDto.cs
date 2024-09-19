using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FSH.WebApi.Application.Catalog.Lead;
public class LeadDayDto : IAggregateRoot
{
    [JsonIgnore]
    [NotMapped]
    public List<DomainEvent> DomainEvents => new();
    public int Day { get; set; }
    public int? Count { get; set; }
}
