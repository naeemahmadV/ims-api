
namespace FSH.WebApi.Application.Catalog.Medias;
public class MediaDto : IDto
{
    public Guid Id { get; set; }
    public string MediaName { get; set; } = default!;
    public Guid MediaGuid { get; set; }
    public string? MimeType { get; set; }
    public string? AltAttribute { get; set; }
    public string? TitleAttribute { get; set; }
    public string PathURL { get; set; } = default!;
    public bool Active { get; set; }
    public bool Deleted { get; set; }

}