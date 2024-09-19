using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Domain.Common;
public enum AccountType
{
    [Description("New")]
    New = 1,
    [Description("Existing")]
    Existing = 2,
    [Description("Old")]
    Old = 3
}
