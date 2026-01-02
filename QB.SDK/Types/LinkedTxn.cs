namespace QB.SDK;

public class LinkedTxn
{
    public string? TxnID { get; set; }
    public TxnType? TxnType { get; set; }
    public DateOnly? TxnDate { get; set; }
    public string? RefNumber { get; set; }
    public LinkType? LinkType { get; set; }
    public decimal? Amount { get; set; }
}
