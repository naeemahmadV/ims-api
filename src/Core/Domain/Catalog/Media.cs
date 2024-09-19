using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Domain.Catalog;
public class Media : AuditableEntity, IAggregateRoot
{
    [StringLength(250)]
    public string MediaName { get; set; } = default!;

    public Guid MediaGuid { get; set; }

    [StringLength(50)]
    public string? MimeType { get; set; }

    [StringLength(250)]
    public string? AltAttribute { get; set; }

    [StringLength(250)]
    public string? TitleAttribute { get; set; }

    [StringLength(250)]
    public string PathURL { get; set; } = default!;
    public bool Active { get; set; }

    public bool Deleted { get; set; }

    public IList<LeadMedia> LeadMedia { get; set; }

    public Media(string mediaName, Guid mediaGuid, string? mimeType, string? altAttribute, string? titleAttribute, string pathURL, bool active, bool deleted)
    {
        MediaName = mediaName;
        MediaGuid = mediaGuid;
        MimeType = mimeType;
        AltAttribute = altAttribute;
        TitleAttribute = titleAttribute;
        PathURL = pathURL;
        Active = active;
        Deleted = deleted;
    }

    public Media Update(string? mediaName, Guid? mediaGuid, string? mimeType, string? altAttribute, string? titleAttribute, string? pathURL, bool? active, bool? deleted)
    {
        if (mediaName is not null && MediaName?.Equals(mediaName) is not true) MediaName = mediaName;
        if (mediaGuid.HasValue && mediaGuid.Value != Guid.Empty && !MediaGuid.Equals(mediaGuid.Value)) MediaGuid = mediaGuid.Value;
        if (mimeType is not null && MimeType?.Equals(mimeType) is not true) MimeType = mimeType;
        if (altAttribute is not null && AltAttribute?.Equals(altAttribute) is not true) AltAttribute = altAttribute;
        if (titleAttribute is not null && TitleAttribute?.Equals(titleAttribute) is not true) TitleAttribute = titleAttribute;
        if (pathURL is not null && PathURL?.Equals(pathURL) is not true) PathURL = pathURL;
        return this;
    }

}
