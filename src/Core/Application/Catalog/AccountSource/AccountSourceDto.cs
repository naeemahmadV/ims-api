using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.AccountSource;
public class AccountSourceDto : IDto
{
    public Guid Id { get; set; }
    public string SourceName { get; set; }
}
