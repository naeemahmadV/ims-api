using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Domain.Catalog;
public class LeadSource : AuditableEntity, IAggregateRoot
{
    public string SourceName { get; set; }

    public LeadSource(string sourceName)
    {
        SourceName = sourceName;
    }

    public LeadSource Update(string? sourceName)
    {
        if (sourceName is not null && SourceName?.Equals(sourceName) is not true) SourceName = sourceName;
        return this;
    }

}
