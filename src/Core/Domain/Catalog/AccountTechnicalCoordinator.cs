using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Domain.Catalog;
public class AccountTechnicalCoordinator : AuditableEntity, IAggregateRoot
{
    [Column("AccountId")]
    public Guid AccountId { get; set; }
    public Account Account { get; set; }

    [Column("UserId")]
    public Guid? UserId { get; set; }
}
