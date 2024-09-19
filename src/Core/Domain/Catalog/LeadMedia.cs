using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Domain.Catalog;
public class LeadMedia : AuditableEntity, IAggregateRoot
{
    [Column("LeadId")]
    public Guid LeadId { get; set; }
    public Lead Lead { get; set; }
    [Column("MediaId")]
    public Guid MediaId { get; set; }
    public virtual Media Media { get; set; }
}
