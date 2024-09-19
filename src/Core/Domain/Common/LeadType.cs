using System.ComponentModel;

namespace FSH.WebApi.Domain.Common;
public enum LeadType
{
    [Description("New")]
    New = 1,
    [Description("Existing")]
    Existing = 2,
    [Description("Old")]
    Old = 3
}
