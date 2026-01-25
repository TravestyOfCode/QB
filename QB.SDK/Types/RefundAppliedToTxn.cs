namespace QB.SDK;

public class RefundAppliedToTxn
{
    public string? TxnID { get; set; }
    public TxnType? TxnType { get; set; }
    public DateOnly? TxnDate { get; set; }
    public string? RefNumber { get; set; }
    public decimal? CreditRemaining { get; set; }
    public decimal? RefundAmount { get; set; }
    public decimal? CreditRemainingInHomeCurrency { get; set; }
    public decimal? RefundAmountInHomeCurrency { get; set; }
}
