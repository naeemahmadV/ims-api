namespace FSH.WebApi.Domain.Catalog;
public class StepTypes : AuditableEntity, IAggregateRoot
{
    public string StepType { get; set; }
    public string StepName { get; set; }
    public string Details { get; set; }
    public string BPCode { get; set; }

    public StepTypes() { }

    public StepTypes(string steptype, string stepname, string details, string bPCode)
    {
        StepType = steptype;
        StepName = stepname;
        Details = details;
        BPCode = bPCode;
    }

    public StepTypes Update(string steptype, string stepname, string details, string bPCode)
    {
        if (steptype is not null && StepType?.Equals(steptype) is not true) StepType = steptype;
        if (stepname is not null && StepName?.Equals(stepname) is not true) StepName = stepname;
        if (details is not null && Details?.Equals(details) is not true) Details = details;
        if (bPCode is not null && BPCode?.Equals(bPCode) is not true) BPCode = bPCode;
        return this;
    }
}
