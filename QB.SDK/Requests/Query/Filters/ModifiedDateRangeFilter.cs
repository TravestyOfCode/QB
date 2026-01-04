namespace QB.SDK;

public class ModifiedDateRangeFilter : IQBXML
{
    public DateTime? FromModifiedDate { get; set; }
    public DateTime? ToModifiedDate { get; set; }

    public ModifiedDateRangeFilter() { }
    public ModifiedDateRangeFilter(DateTime? from, DateTime? to)
    {
        FromModifiedDate = from;
        ToModifiedDate = to;
    }

    public XElement ToQBXML()
    {
        return new XElement(nameof(ModifiedDateRangeFilter))
            .Append(FromModifiedDate)
            .Append(ToModifiedDate);
    }
}
