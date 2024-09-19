namespace FSH.WebApi.Domain.Catalog;
public class PackageType : AuditableEntity, IAggregateRoot
{
    public string Type { get; set; }
    public string Name { get; set; }
    public string Length { get; set; }
    public string Width { get; set; }
    public string Height { get; set; }
    public string Weight { get; set; }
    public string Volume { get; set; }
    public string UOM { get; set; }
    public string SubType { get; set; }

    public PackageType() { }

    public PackageType(string type, string name, string length, string width, string height, string weight, string volume, string uom, string subtype)
    {
        Type = type;
        Name = name;
        Length = length;
        Width = width;
        Height = height;
        Weight = weight;
        Volume = volume;
        UOM = uom;
        SubType = subtype;
    }

    public PackageType Update(string type, string name, string length, string width, string height, string weight, string volume, string uom, string subtype)
    {
        if (type is not null && Type?.Equals(type) is not true) Type = type;
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (length is not null && Length?.Equals(length) is not true) Length = length;
        if (width is not null && Width?.Equals(width) is not true) Width = width;
        if (height is not null && Height?.Equals(height) is not true) Height = height;
        if (weight is not null && Weight?.Equals(weight) is not true) Weight = weight;
        if (volume is not null && Volume?.Equals(volume) is not true) Volume = volume;
        if (uom is not null && UOM?.Equals(uom) is not true) UOM = uom;
        if (subtype is not null && SubType?.Equals(subtype) is not true) SubType = subtype;
        return this;
    }
}
