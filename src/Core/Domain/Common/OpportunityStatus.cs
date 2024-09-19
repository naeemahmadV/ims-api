using System.ComponentModel;

namespace FSH.WebApi.Domain.Common;
public enum OpportunityStatus
{
    [Description("Open")]
    Open = 1,
    [Description("In Progress")]
    InProgress = 2,
    [Description("On Hold")]
    OnHold = 3,
    [Description("Won")]
    Won = 4,
    [Description("Lost")]
    Lost = 5
}
