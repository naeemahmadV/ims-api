
namespace FSH.WebApi.Application.Catalog.City;
public class CityDto : IDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public Guid StateId { get; set; }

}
