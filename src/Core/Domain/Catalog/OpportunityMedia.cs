using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Domain.Catalog;
public class OpportunityMedia : AuditableEntity, IAggregateRoot
{
    [Column("OpportunityId")]
    public Guid OpportunityId { get; set; }
    public Opportunity? Opportunity { get; set; }
    [Column("MediaId")]
    public Guid MediaId { get; set; }
    public virtual Media? Media { get; set; }
}
