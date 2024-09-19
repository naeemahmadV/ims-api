using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Domain.Catalog;
public class AccountSkill : AuditableEntity, IAggregateRoot
{
    [Column("AccountId")]
    public Guid AccountId { get; set; }
    public Account Account { get; set; }
    [Column("SkillId")]
    public Guid SkillId { get; set; }
    public virtual Skill Skill { get; set; }
}
