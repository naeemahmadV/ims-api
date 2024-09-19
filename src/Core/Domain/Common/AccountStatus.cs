using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Domain.Common;
public enum AccountStatus
{
    [Description("New")]
    New = 1,
    [Description("Contacted")]
    Contacted = 2,
    [Description("Response Required")]
    ResponseRequired = 3,
    [Description("Live")]
    Live = 4,
    [Description("Follow up")]
    Followup = 5,
    [Description("Analysis")]
    Analysis = 6,
    [Description("On Hold")]
    OnHold = 7,
    [Description("Qualified")]
    Qualified = 8,
    [Description("Dead")]
    Dead = 9,
    [Description("Junk")]
    Junk = 10
}
