using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FSH.WebApi.Domain.Catalog;
public class Company : AuditableEntity, IAggregateRoot
{
    public string Name { get; private set; }

public Company(string name)
{
    Name = name;
}

public Company Update(string? name)
{
    if (name is not null && Name?.Equals(name) is not true) Name = name;
    return this;
}
}