using System.ComponentModel;

namespace FSH.WebApi.Domain.Common;
public enum PreferredShiftTiming
{
    [Description("Exactly the same hours as client's")]
    Exactlythesamehoursasclients = 1,
    [Description("Overlapping Shift")]
    OverlappingShift = 2,
    [Description("Any Shift")]
    AnyShift = 3,
    [Description("Not Sure")]
    NotSure = 4

}
