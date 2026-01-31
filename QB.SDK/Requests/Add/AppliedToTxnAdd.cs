namespace QB.SDK;

public class AppliedToTxnAdd : IQBXML
{
    public string? TxnID { get; set; }
    public decimal? PaymentAmount { get; set; }
    public List<SetCredit>? SetCredit { get; set; }
    public decimal? DiscountAmount { get; set; }
    public ListRef? DiscountAccountRef { get; set; }
    public ListRef? DiscountClassRef { get; set; }

    public XElement ToQBXML()
    {
        return new XElement(nameof(AppliedToTxnAdd))
            .Append(TxnID)
            .Append(PaymentAmount)
            .Append(SetCredit)
            .Append(DiscountAmount)
            .Append(DiscountAccountRef)
            .Append(DiscountClassRef);
    }
}
