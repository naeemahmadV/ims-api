using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Domain.Catalog;
public class Country : AuditableEntity, IAggregateRoot
{

    public string? Name { get; set; }
    public string Code { get; set; }

    public Country(string name, string code)
    {
        Name = name;
        Code = code;
    }
    public Country Update(string? name, string? code)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (code is not null && Code?.Equals(code) is not true) Code = code;
        return this;
    }

}
