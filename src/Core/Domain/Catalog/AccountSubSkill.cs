using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Domain.Catalog;
public class AccountSubSkill : AuditableEntity, IAggregateRoot
{
    [Column("AccountId")]
    public Guid AccountId { get; set; }
    public Account Account { get; set; }
    [Column("SubSkillId")]
    public Guid SubSkillId { get; set; }
    public SubSkill SubSkill { get; set; }
}
