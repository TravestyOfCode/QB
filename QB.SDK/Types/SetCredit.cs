namespace QB.SDK;

public class SetCredit : IQBXML
{
    public string? CreditTxnID { get; set; }
    public decimal? AppliedAmount { get; set; }
    public bool? Override { get; set; }

    public XElement ToQBXML()
    {
        return new XElement(nameof(SetCredit))
            .Append(CreditTxnID)
            .Append(AppliedAmount)
            .Append(Override);
    }
}
