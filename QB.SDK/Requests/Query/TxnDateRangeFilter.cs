namespace QB.SDK;

public class TxnDateRangeFilter : IQBXML
{
    public DateOnly? FromTxnDate { get; set; }
    public DateOnly? ToTxnDate { get; set; }

    public XElement ToQBXML()
    {
        return new XElement(nameof(TxnDateRangeFilter))
            .Append(FromTxnDate)
            .Append(ToTxnDate);
    }
}
