namespace FSH.WebApi.Domain.Catalog;
public class LabelTypes : AuditableEntity, IAggregateRoot
{
    public string LabelType { get; set; }
    public string LabelName { get; set; }
    public string Details { get; set; }
    public string BPCode { get; set; }

    public LabelTypes(string labeltype, string labelname, string details, string bpcode)
    {
        LabelType = labeltype;
        LabelName = labelname;
        Details = details;
        BPCode = bpcode;
    }
    public LabelTypes() { }

    public LabelTypes Update(string labeltype, string labelname, string details, string bpcode)
    {
        if (labeltype is not null && LabelType?.Equals(labeltype) is not true) LabelType = labeltype;
        if (labelname is not null && LabelName?.Equals(labelname) is not true) LabelName = labelname;
        if (details is not null && Details?.Equals(details) is not true) Details = details;
        if (bpcode is not null && BPCode?.Equals(bpcode) is not true) BPCode = bpcode;
        return this;
    }
}
