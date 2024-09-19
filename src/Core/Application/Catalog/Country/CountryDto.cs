
namespace FSH.WebApi.Application.Catalog.Country;
public class CountryDto : IDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string Code { get; set; }
}
