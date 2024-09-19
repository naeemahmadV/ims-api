using System.ComponentModel.DataAnnotations;

namespace FSH.WebApi.Application;
public class LeadDto : IDto
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

    public Guid? LeadSourceId { get; set; }

    public string? LeadSourceSourceName { get; set; } = default!;

    public string? LeadStatus { get; set; }
    public IList<LeadSkillDto>? LeadSkills { get; set; }
    public IList<LeadSubSkillDto>? LeadSubSkills { get; set; }
    public IList<SalesCoordinatorDto>? SalesCoordinators { get; set; }
    public IList<TechnicalCoordinatorDto>? TechnicalCoordinators { get; set; }
    public IList<LeadMediaDto>? LeadMedias { get; set; }
    public bool FreeTrialOffered { get; set; }

    public string? PrefferedShift { get; set; }

    public int NumberOfResources { get; set; }

    public DateTime? ExpectedStartDate { get; set; }

    public string? DomainORIndustry { get; set; }

    public int Budget { get; set; }

    public int Rating { get; set; }

    public string? LeadType { get; set; }

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

public class LeadSkillDto : IDto
{
    public Guid LeadId { get; set; }
    public Guid SkillId { get; set; }
    public SkillDto? Skill { get; set; }
}

public class SkillDto
{
    public string Name { get; set; } = default!;
}

public class LeadSubSkillDto : IDto
{
    public Guid LeadId { get; set; }
    public Guid SubSkillId { get; set; }
    public SubSkillsDto? SubSkill { get; set; }
}

public class SubSkillsDto
{
    public string? SubSkillName { get; set; }
}

public class SalesCoordinatorDto : IDto
{
    public Guid LeadId { get; set; }
    public Guid UserId { get; set; }

}

public class TechnicalCoordinatorDto : IDto
{
    public Guid LeadId { get; set; }
    public Guid? UserId { get; set; }
}

public class LeadMediaDto : IDto
{
    public Guid LeadId { get; set; }
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

