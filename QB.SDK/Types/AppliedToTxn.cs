
namespace QB.SDK;

public class AppliedToTxn : IQBXMLNamed
{
    public string? TxnID { get; set; }
    public TxnType? TxnType { get; set; }
    public DateOnly? TxnDate { get; set; }
    public string? RefNumber { get; set; }
    public decimal? BalanceRemaining { get; set; }
    public decimal? Amount { get; set; }
    public decimal? DiscountAmount { get; set; }
    public ListRef? DiscountAccountRef { get; set; }
    public ListRef? DiscountClassRef { get; set; }
    public List<LinkedTxn>? LinkedTxn { get; set; }

    public XElement ToQBXML(string name = nameof(AppliedToTxn))
    {
        return new XElement(name)
            .Append(TxnID)
            .Append(TxnType)
            .Append(TxnDate)
            .Append(RefNumber)
            .Append(BalanceRemaining)
            .Append(Amount)
            .Append(DiscountAmount)
            .Append(DiscountAccountRef)
            .Append(DiscountClassRef)
            .Append(LinkedTxn);
    }
}
