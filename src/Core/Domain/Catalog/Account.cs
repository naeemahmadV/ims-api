﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Domain.Catalog;
public class Account : AuditableEntity, IAggregateRoot
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

    public string? TimeZone { get; set; }

    [ForeignKey("AccountSource")]
    public Guid? AccountSourceId { get; set; }

    public virtual AccountSource? AccountSource { get; set; }

    public IList<AccountSkill>? AccountSkills { get; set; }
    public IList<AccountSubSkill>? AccountSubSkills { get; set; }
    public IList<AccountSalesCoordinator>? AccountSalesCoordinators { get; set; }
    public IList<AccountTechnicalCoordinator>? AccountTechnicalCoordinators { get; set; }
    public IList<AccountMedia>? AccountMedias { get; set; }

    public string? AccountStatus { get; set; }

    public bool FreeTrialOffered { get; set; }
    public string? PrefferedShift { get; set; }
    public int NumberOfResources { get; set; }

    public DateTime? ExpectedStartDate { get; set; }

    public string? DomainORIndustry { get; set; }

    public int Budget { get; set; }

    public int Rating { get; set; }

    public string? AccountType { get; set; }

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

    public Account(string? topic, string? firstName, string? lastName, string? email, string? businessPhone, string? mobilePhone, string? jobDescription, Guid? countryId, Guid? stateId, Guid? cityId, string? timeZone, Guid? accountSourceId, string? accountStatus, bool freeTrialOffered, string? prefferedShift, int numberOfResources, DateTime? expectedStartDate, string? domainORIndustry, int budget, int rating, string? accountType, bool nDAShared, DateTime? nDASharedOn, string? technicalCoordinatorStatus, string? website, string? designation, string? company, string? companyAddress1, string? companyAddress2, string? companyPostalCode, string? companyAnnualRevenue, int? companyNumberofEmployees, int? preferredContactMethod, bool? followEmail, bool? doNotEmail, bool? doNotBulkEmail, bool? doNotPhone)
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
        TimeZone = timeZone;
        AccountSourceId = accountSourceId;
        AccountStatus = accountStatus;
        FreeTrialOffered = freeTrialOffered;
        PrefferedShift = prefferedShift;
        NumberOfResources = numberOfResources;
        ExpectedStartDate = expectedStartDate;
        DomainORIndustry = domainORIndustry;
        Budget = budget;
        Rating = rating;
        AccountType = accountType;
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
    }

    public Account Update(string? topic, string? firstName, string? lastName, string? email, string? businessPhone, string? mobilePhone, string? jobDescription, Guid? countryId, Guid? stateId, Guid? cityId, string? timeZone, Guid? accountSourceId, string? accountStatus, bool freeTrialOffered, string? prefferedShift, int numberOfResources, DateTime? expectedStartDate, string? domainORIndustry, int budget, int rating, string? accountType, bool nDAShared, DateTime? nDASharedOn, string? technicalCoordinatorStatus, string? website, string? designation, string? company, string? companyAddress1, string? companyAddress2, string? companyPostalCode, string? companyAnnualRevenue, int? companyNumberofEmployees, int? preferredContactMethod, bool? followEmail, bool? doNotEmail, bool? doNotBulkEmail, bool? doNotPhone)
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
        if (timeZone is not null && TimeZone?.Equals(timeZone) is not true) TimeZone = timeZone;
        if (AccountSourceId.Equals(accountSourceId) is not true) AccountSourceId = accountSourceId;
        if (accountStatus is not null && AccountStatus?.Equals(accountStatus) is not true) AccountStatus = accountStatus;
        if (FreeTrialOffered.Equals(freeTrialOffered) is not true) FreeTrialOffered = freeTrialOffered;
        if (prefferedShift is not null && PrefferedShift?.Equals(prefferedShift) is not true) PrefferedShift = prefferedShift;
        if (NumberOfResources.Equals(numberOfResources) is not true) NumberOfResources = numberOfResources;
        if (expectedStartDate is not null && ExpectedStartDate?.Equals(expectedStartDate) is not true) ExpectedStartDate = expectedStartDate;
        if (domainORIndustry is not null && DomainORIndustry?.Equals(domainORIndustry) is not true) DomainORIndustry = domainORIndustry;
        if (Budget.Equals(budget) is not true) Budget = budget;
        if (Rating.Equals(rating) is not true) Rating = rating;
        if (accountType is not null && AccountType?.Equals(accountType) is not true) AccountType = accountType;
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

        return this;
    }

}
