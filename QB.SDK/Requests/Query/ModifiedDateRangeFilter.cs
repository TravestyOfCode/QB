namespace QB.SDK;

public class ModifiedDateRangeFilter : IQBXML
{
    public DateOnly? FromModifiedDate { get; set; }
    public DateOnly? ToModifiedDate { get; set; }

    public XElement ToQBXML()
    {
        return new XElement(nameof(ModifiedDateRangeFilter))
            .Append(FromModifiedDate)
            .Append(ToModifiedDate);
    }
}
