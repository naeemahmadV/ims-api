using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.Account;
public class AccountDto : IDto
{
    public Guid Id { get; set; }
    public string? Topic { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }
    public string? Designation { get; set; }

    public string? BusinessPhone { get; set; }

    public string? MobilePhone { get; set; }
    public string? Website { get; set; }

    public string? JobDescription { get; set; }

    public Guid? CountryId { get; set; }

    public string? CountryName { get; set; } = default!;

    public Guid? StateId { get; set; }

    public string? StateName { get; set; } = default!;

    public Guid? CityId { get; set; }

    public string? CityName { get; set; } = default!;

    public string? TimeZone { get; set; }

    public Guid? AccountSourceId { get; set; }

    public string? AccountSourceSourceName { get; set; } = default!;

    public string? AccountStatus { get; set; }

    public IList<AccountSkillDto>? AccountSkills { get; set; }
    public IList<AccountSubSkillDto>? AccountSubSkills { get; set; }
    public IList<AccountSalesCoordinatorDto>? AccountSalesCoordinators { get; set; }
    public IList<AccountTechnicalCoordinatorDto>? AccountTechnicalCoordinators { get; set; }
    public IList<AccountMediaDto>? AccountMedias { get; set; }

    public bool FreeTrialOffered { get; set; }

    public string? PrefferedShift { get; set; }

    public int NumberOfResources { get; set; }

    public DateTime? ExpectedStartDate { get; set; }

    public string? DomainORIndustry { get; set; }

    public Guid[]? SkillsIds { get; set; }
    public Guid[]? SubSkillsIds { get; set; }
    public Guid[]? AccountSalesCoordinaotrs { get; set; }
    public Guid[]? AccountTechCoordinaotrs { get; set; }
    public Guid[]? AccountMedia { get; set; }
    public int Budget { get; set; }

    public int Rating { get; set; }

    public string? AccountType { get; set; }

    public bool NDAShared { get; set; }
    public DateTime? NDASharedOn { get; set; }

    public string? TechnicalCoordinatorStatus { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public string? Company { get; set; }
    public string? CompanyAddress1 { get; set; }
    public string? CompanyAddress2 { get; set; }
    public string? CompanyPostalCode { get; set; }
    public string? CompanyAnnualRevenue { get; set; }
    public int? CompanyNumberofEmployees { get; set; }
    public int? PreferredContactMethod { get; set; }
    public bool? FollowEmail { get; set; }
    public bool? DoNotEmail { get; set; }
    public bool? DoNotBulkEmail { get; set; }
    public bool? DoNotPhone { get; set; }
}

public class AccountSkillDto : IDto
{
    public Guid AccountId { get; set; }
    public Guid SkillId { get; set; }
    public SkillDto? Skill { get; set; }
}

public class SkillDto
{
    public string Name { get; set; } = default!;
}

public class AccountSubSkillDto : IDto
{
    public Guid AccountId { get; set; }
    public Guid SubSkillId { get; set; }
    public SubSkillsDto? SubSkill { get; set; }
}

public class SubSkillsDto
{
    public string? SubSkillName { get; set; }
}

public class AccountMediaDto : IDto
{
    public Guid AccountId { get; set; }
    public Guid MediaId { get; set; }
    public MediaDto? Media { get; set; }
}

public class MediaDto : IDto
{
    public string MediaName { get; set; } = default!;

    public Guid MediaGuid { get; set; }

    public string? MimeType { get; set; }

    public string PathURL { get; set; } = default!;

}

public class AccountTechnicalCoordinatorDto : IDto
{
    public Guid AccountId { get; set; }
    public Guid? UserId { get; set; }
}

public class AccountSalesCoordinatorDto : IDto
{
    public Guid AccountId { get; set; }
    public Guid UserId { get; set; }

}
