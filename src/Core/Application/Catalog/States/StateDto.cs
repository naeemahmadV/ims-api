
namespace FSH.WebApi.Application.Catalog.State;
public class StateDto : IDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Code { get; set; }
    public Guid CountryId { get; set; }

}
