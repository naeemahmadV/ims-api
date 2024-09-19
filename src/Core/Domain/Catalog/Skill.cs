using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Domain.Catalog;
public class Skill : AuditableEntity, IAggregateRoot
{

    public string Name { get; set; } = default!;
    public IList<LeadSkill>? LeadSkills { get; set; }

    public Skill(string name)
    {
        Name = name;
    }
    public Skill Update(string? name)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        return this;
    }
}
