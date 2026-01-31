namespace QB.SDK;

public class LinkedTxn : IQBXML
{
    public string? TxnID { get; set; }
    public TxnType? TxnType { get; set; }
    public DateOnly? TxnDate { get; set; }
    public string? RefNumber { get; set; }
    public LinkType? LinkType { get; set; }
    public decimal? Amount { get; set; }

    public XElement ToQBXML()
    {
        return new XElement(nameof(LinkedTxn))
            .Append(TxnID)
            .Append(TxnType)
            .Append(TxnDate)
            .Append(RefNumber)
            .Append(LinkType)
            .Append(Amount);
    }
}
