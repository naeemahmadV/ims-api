﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.AccountStatus;
public class AccountStatusDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}
