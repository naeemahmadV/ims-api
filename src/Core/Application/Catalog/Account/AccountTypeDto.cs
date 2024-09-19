using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.Account;
public class AccountTypeDto 
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}
