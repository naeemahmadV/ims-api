namespace FSH.WebApi.Application.Catalog.PackageType;
public class PackageTypeDto : IDto
{
    public Guid Id { get; set; }
    public string Type { get; set; }
    public string Name { get; set; }
    public string Length { get; set; }
    public string Width { get; set; }
    public string Height { get; set; }
    public string Weight { get; set; }
    public string Volume { get; set; }
    public string UOM { get; set; }
    public string SubType { get; set; }
}
