using System.ComponentModel.DataAnnotations.Schema;

namespace FSH.WebApi.Domain.Catalog;
public class Opportunity : AuditableEntity, IAggregateRoot
{
    public string? Topic { get; set; }
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }
    public string? Designation { get; set; }

    public string? BusinessPhone { get; set; }
    public string? Website { get; set; }

    public string? MobilePhone { get; set; }

    public string? JobDescription { get; set; }

    [ForeignKey("Country")]
    public Guid? CountryId { get; set; }

    public virtual Country? Country { get; set; }

    [ForeignKey("State")]
    public Guid? StateId { get; set; }

    public virtual State? State { get; set; }

    [ForeignKey("City")]
    public Guid? CityId { get; set; }

    public virtual City? City { get; set; }

    [ForeignKey("Lead")]
    public Guid? LeadId { get; set; }

    public virtual Lead? Lead { get; set; }

    public string? TimeZone { get; set; }

    [ForeignKey("OpportunitySource")]
    public Guid? OpportunitySourceId { get; set; }

    public virtual OpportunitySource? OpportunitySource { get; set; }

    public IList<OpportunitySkill>? OpportunitySkills { get; set; }
    public IList<OpportunitySubSkill>? OpportunitySubSkills { get; set; }
    public IList<OpportunitySalesCoordinator>? SalesCoordinators { get; set; }
    public IList<OpportunityTechnicalCoordinator>? TechnicalCoordinators { get; set; }
    public IList<OpportunityMedia>? OpportunityMedias { get; set; }

    public string? OpportunityStatus { get; set; }

    public bool FreeTrialOffered { get; set; }
    public string? PrefferedShift { get; set; }
    public int NumberOfResources { get; set; }

    public DateTime? ExpectedStartDate { get; set; }

    public string? DomainORIndustry { get; set; }

    public int Budget { get; set; }

    public int Rating { get; set; }

    public string? OpportunityType { get; set; }

    public bool NDAShared { get; set; }

    public DateTime? NDASharedOn { get; set; }

    public string? TechnicalCoordinatorStatus { get; set; }
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

    public bool? OpportunityWon { get; set; }
    public bool? OpportunityLost { get; set; }

    public Opportunity(string? topic, string? firstName, string? lastName, string? email, string? businessPhone, string? mobilePhone, string? jobDescription, Guid? countryId, Guid? stateId, Guid? cityId, Guid? leadId, string? timeZone, Guid? opportunitySourceId, string? opportunityStatus, bool freeTrialOffered, string? prefferedShift, int numberOfResources, DateTime? expectedStartDate, string? domainORIndustry, int budget, int rating, string? opportunityType, bool nDAShared, DateTime? nDASharedOn, string? technicalCoordinatorStatus, string? website, string? designation, string? company, string? companyAddress1, string? companyAddress2, string? companyPostalCode, string? companyAnnualRevenue, int? companyNumberofEmployees, int? preferredContactMethod, bool? followEmail, bool? doNotEmail, bool? doNotBulkEmail, bool? doNotPhone, bool? opportunityWon, bool? opportunityLost)
    {
        Topic = topic;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        BusinessPhone = businessPhone;
        MobilePhone = mobilePhone;
        JobDescription = jobDescription;
        CountryId = countryId;
        StateId = stateId;
        CityId = cityId;
        LeadId = leadId;
        TimeZone = timeZone;
        OpportunitySourceId = opportunitySourceId;
        OpportunityStatus = opportunityStatus;
        FreeTrialOffered = freeTrialOffered;
        PrefferedShift = prefferedShift;
        NumberOfResources = numberOfResources;
        ExpectedStartDate = expectedStartDate;
        DomainORIndustry = domainORIndustry;
        Budget = budget;
        Rating = rating;
        OpportunityType = opportunityType;
        NDAShared = nDAShared;
        NDASharedOn = nDASharedOn;
        TechnicalCoordinatorStatus = technicalCoordinatorStatus;
        Website = website;
        Designation = designation;
        Company = company;
        CompanyAddress1 = companyAddress1;
        CompanyAddress2 = companyAddress2;
        CompanyPostalCode = companyPostalCode;
        CompanyAnnualRevenue = companyAnnualRevenue;
        CompanyNumberofEmployees = companyNumberofEmployees;
        PreferredContactMethod = preferredContactMethod;
        FollowEmail = followEmail;
        DoNotEmail = doNotEmail;
        DoNotBulkEmail = doNotBulkEmail;
        DoNotPhone = doNotPhone;
        OpportunityWon = opportunityWon;
        OpportunityLost = opportunityLost;
    }

    public Opportunity Update(string? topic, string? firstName, string? lastName, string? email, string? businessPhone, string? mobilePhone, string? jobDescription, Guid? countryId, Guid? stateId, Guid? cityId, Guid? leadId, string? timeZone, Guid? opportunitySourceId, string? opportunityStatus, bool freeTrialOffered, string? prefferedShift, int numberOfResources, DateTime? expectedStartDate, string? domainORIndustry, int budget, int rating, string? opportunityType, bool nDAShared, DateTime? nDASharedOn, string? technicalCoordinatorStatus, string? website, string? designation, string? company, string? companyAddress1, string? companyAddress2, string? companyPostalCode, string? companyAnnualRevenue, int? companyNumberofEmployees, int? preferredContactMethod, bool? followEmail, bool? doNotEmail, bool? doNotBulkEmail, bool? doNotPhone, bool? opportunityWon, bool? opportunityLost)
    {
        if (topic is not null && Topic?.Equals(topic) is not true) Topic = topic;
        if (firstName is not null && FirstName?.Equals(firstName) is not true) FirstName = firstName;
        if (lastName is not null && LastName?.Equals(lastName) is not true) LastName = lastName;
        if (email is not null && Email?.Equals(email) is not true) Email = email;
        if (businessPhone is not null && BusinessPhone?.Equals(businessPhone) is not true) BusinessPhone = businessPhone;
        if (mobilePhone is not null && MobilePhone?.Equals(mobilePhone) is not true) MobilePhone = mobilePhone;
        if (jobDescription is not null && JobDescription?.Equals(jobDescription) is not true) JobDescription = jobDescription;
        if (CountryId.Equals(countryId) is not true) CountryId = countryId;
        if (StateId.Equals(stateId) is not true) StateId = stateId;
        if (CityId.Equals(cityId) is not true) CityId = cityId;
        if (LeadId.Equals(leadId) is not true) LeadId = leadId;
        if (timeZone is not null && TimeZone?.Equals(timeZone) is not true) TimeZone = timeZone;
        if (OpportunitySourceId.Equals(opportunitySourceId) is not true) OpportunitySourceId = opportunitySourceId;
        if (opportunityStatus is not null && OpportunityStatus?.Equals(opportunityStatus) is not true) OpportunityStatus = opportunityStatus;
        if (FreeTrialOffered.Equals(freeTrialOffered) is not true) FreeTrialOffered = freeTrialOffered;
        if (prefferedShift is not null && PrefferedShift?.Equals(prefferedShift) is not true) PrefferedShift = prefferedShift;
        if (NumberOfResources.Equals(numberOfResources) is not true) NumberOfResources = numberOfResources;
        if (expectedStartDate is not null && ExpectedStartDate?.Equals(expectedStartDate) is not true) ExpectedStartDate = expectedStartDate;
        if (domainORIndustry is not null && DomainORIndustry?.Equals(domainORIndustry) is not true) DomainORIndustry = domainORIndustry;
        if (Budget.Equals(budget) is not true) Budget = budget;
        if (Rating.Equals(rating) is not true) Rating = rating;
        if (opportunityType is not null && OpportunityType?.Equals(opportunityType) is not true) OpportunityType = opportunityType;
        if (NDAShared.Equals(nDAShared) is not true) NDAShared = nDAShared;
        if (NDASharedOn.Equals(nDASharedOn) is not true) NDASharedOn = nDASharedOn;
        if (technicalCoordinatorStatus is not null && TechnicalCoordinatorStatus?.Equals(technicalCoordinatorStatus) is not true) TechnicalCoordinatorStatus = technicalCoordinatorStatus;
        if (website is not null && Website?.Equals(Website) is not true) Website = website;
        if (designation is not null && Designation?.Equals(designation) is not true) Designation = designation;
        if (company is not null && Company?.Equals(company) is not true) Company = company;
        if (companyAddress1 is not null && CompanyAddress1?.Equals(companyAddress1) is not true) CompanyAddress1 = companyAddress1;
        if (companyAddress2 is not null && CompanyAddress2?.Equals(companyAddress2) is not true) CompanyAddress2 = companyAddress2;
        if (companyPostalCode is not null && CompanyPostalCode?.Equals(companyPostalCode) is not true) CompanyPostalCode = companyPostalCode;
        if (companyAnnualRevenue is not null && CompanyAnnualRevenue?.Equals(companyAnnualRevenue) is not true) CompanyAnnualRevenue = companyAnnualRevenue;
        if (companyNumberofEmployees is not null && CompanyNumberofEmployees?.Equals(companyNumberofEmployees) is not true) CompanyNumberofEmployees = companyNumberofEmployees;
        if (preferredContactMethod is not null && PreferredContactMethod?.Equals(preferredContactMethod) is not true) PreferredContactMethod = preferredContactMethod;
        if (followEmail is not null && FollowEmail?.Equals(followEmail) is not true) FollowEmail = followEmail;
        if (doNotEmail is not null && DoNotEmail?.Equals(doNotEmail) is not true) DoNotEmail = doNotEmail;
        if (doNotBulkEmail is not null && DoNotBulkEmail?.Equals(doNotBulkEmail) is not true) DoNotBulkEmail = doNotBulkEmail;
        if (doNotPhone is not null && DoNotPhone?.Equals(doNotPhone) is not true) DoNotPhone = doNotPhone;
        if (opportunityWon is not null) OpportunityWon = opportunityWon;
        if (opportunityLost is not null) OpportunityLost = opportunityLost;
        return this;
    }
}
