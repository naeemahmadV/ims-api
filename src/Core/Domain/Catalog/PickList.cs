namespace FSH.WebApi.Domain.Catalog;
public class PickList : AuditableEntity, IAggregateRoot
{
    public string SalesOrder { get; set; }
    public string DocEntry { get; set; }
    public int SOLineNo { get; set; }
    public string BatchNo { get; set; }
    public int PickQty { get; set; }
    public int SPQ { get; set; }
    public int CtnQty { get; set; }
    public string DateCode { get; set; }
    public string ActualETD { get; set; }
    public string CustRefNo { get; set; }
    public string CustPartNum { get; set; }
    public string ItemCode { get; set; }
    public string ItemDesc { get; set; }
    public string IESONum { get; set; }
    public string IECustRef { get; set; }
    public string Processed { get; set; }
    public string CRD { get; set; }
    public string Packed { get; set; }
    public string BPCode { get; set; }
    public string SPQUnit { get; set; }
    public string PackUOM { get; set; }
    public string CartonUOM { get; set; }
    public Guid PackageTypeId { get; set; }
    public virtual PackageType PackageType { get; private set; } = default!;
    public Guid LabelTypeId { get; set; }
    public virtual LabelTypes LabelType { get; private set; } = default!;
    public Guid StepTypeId { get; set; }
    public virtual StepTypes StepType { get; private set; } = default!;

    public PickList() { }
    public PickList(string salesorder, string docentry, int solineno, string batchno, int pickqty, int spq, int ctnqty, string datecode, string actualetd, string custrefno,
        string custpartnum, string itemcode, string itemdesc, string iesonum, string iecustref, string processed, string crd, string packed, string bpcode, string spqunit,
        string packuom, string cartonuom, Guid packageTypeId, Guid labelTypeId, Guid stepTypeId)
    {
        SalesOrder = salesorder;
        DocEntry = docentry;
        SOLineNo = solineno;
        BatchNo = batchno;
        PickQty = pickqty;
        SPQ = spq;
        CtnQty = ctnqty;
        DateCode = datecode;
        ActualETD = actualetd;
        CustRefNo = custrefno;
        CustPartNum = custpartnum;
        ItemCode = itemcode;
        ItemDesc = itemdesc;
        IESONum = iesonum;
        IECustRef = iecustref;
        Processed = processed;
        CRD = crd;
        Packed = packed;
        BPCode = bpcode;
        SPQUnit = spqunit;
        PackUOM = packuom;
        CartonUOM = cartonuom;
        PackageTypeId = packageTypeId;
        LabelTypeId = labelTypeId;
        StepTypeId = stepTypeId;
    }

    public PickList Update(string salesorder, string docentry, int solineno, string batchno, int pickqty, int spq, int ctnqty, string datecode, string actualetd, string custrefno,
        string custpartnum, string itemcode, string itemdesc, string iesonum, string iecustref, string processed, string crd, string packed, string bpcode, string spqunit,
        string packuom, string cartonuom, Guid? packageTypeId, Guid? labelTypeId, Guid? stepTypeId)
    {
        if (salesorder is not null && SalesOrder?.Equals(salesorder) is not true) SalesOrder = salesorder;
        if (docentry is not null && DocEntry?.Equals(docentry) is not true) DocEntry = docentry;
        if (solineno > 0 && SOLineNo.Equals(solineno) is not true) SOLineNo = solineno;
        if (batchno is not null && BatchNo?.Equals(batchno) is not true) BatchNo = batchno;
        if (pickqty > 0 && PickQty.Equals(pickqty) is not true) PickQty = pickqty;
        if (spq > 0 && SPQ.Equals(spq) is not true) SPQ = spq;
        if (ctnqty > 0 && CtnQty.Equals(ctnqty) is not true) CtnQty = ctnqty;
        if (datecode is not null && DateCode?.Equals(datecode) is not true) DateCode = datecode;
        if (actualetd is not null && ActualETD?.Equals(actualetd) is not true) ActualETD = actualetd;
        if (custrefno is not null && CustRefNo?.Equals(custrefno) is not true) CustRefNo = custrefno;
        if (custpartnum is not null && CustPartNum?.Equals(custpartnum) is not true) CustPartNum = custpartnum;
        if (itemcode is not null && ItemCode?.Equals(itemcode) is not true) ItemCode = itemcode;
        if (itemdesc is not null && ItemDesc?.Equals(itemdesc) is not true) ItemDesc = itemdesc;
        if (iesonum is not null && IESONum?.Equals(iesonum) is not true) IESONum = iesonum;
        if (iecustref is not null && IECustRef?.Equals(iecustref) is not true) IECustRef = iecustref;
        if (processed is not null && Processed?.Equals(processed) is not true) Processed = processed;
        if (crd is not null && CRD?.Equals(crd) is not true) CRD = crd;
        if (packed is not null && Packed?.Equals(packed) is not true) Packed = packed;
        if (bpcode is not null && BPCode?.Equals(bpcode) is not true) BPCode = bpcode;
        if (spqunit is not null && SPQUnit?.Equals(spqunit) is not true) SPQUnit = spqunit;
        if (packuom is not null && PackUOM?.Equals(packuom) is not true) PackUOM = packuom;
        if (cartonuom is not null && CartonUOM?.Equals(cartonuom) is not true) CartonUOM = cartonuom;
        if (packageTypeId.HasValue && packageTypeId.Value != Guid.Empty && !PackageTypeId.Equals(packageTypeId.Value)) PackageTypeId = packageTypeId.Value;
        if (labelTypeId.HasValue && labelTypeId.Value != Guid.Empty && !LabelTypeId.Equals(labelTypeId.Value)) LabelTypeId = labelTypeId.Value;
        if (stepTypeId.HasValue && stepTypeId.Value != Guid.Empty && !StepTypeId.Equals(stepTypeId.Value)) StepTypeId = stepTypeId.Value;
        return this;
    }
}
