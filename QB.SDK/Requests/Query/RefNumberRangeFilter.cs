namespace QB.SDK;

public class RefNumberRangeFilter : IQBXML
{
    public string? FromRefNumber { get; set; }
    public string? ToRefNumber { get; set; }

    public XElement ToQBXML()
    {
        return new XElement(nameof(RefNumberRangeFilter))
            .Append(FromRefNumber)
            .Append(ToRefNumber);
    }
}
