namespace QB.SDK;

public class ARRefundCreditCard
{
    public string? TxnID { get; set; }
    public DateTime? TimeCreated { get; set; }
    public DateTime? TimeModified { get; set; }
    public string? EditSequence { get; set; }
    public int? TxnNumber { get; set; }
    public ListRef? CustomerRef { get; set; }
    public ListRef? RefundFromAccountRef { get; set; }
    public ListRef? ARAccountRef { get; set; }
    public DateOnly? TxnDate { get; set; }
    public string? RefNumber { get; set; }
    public decimal? TotalAmount { get; set; }
    public ListRef? CurrencyRef { get; set; }
    public float? ExchangeRate { get; set; }
    public decimal? TotalAmountInHomeCurrency { get; set; }
    public Address? Address { get; set; }
    public ListRef? PaymentMethodRef { get; set; }
    public string? Memo { get; set; }
    public CreditCardTxnInfo? CreditCardTxnInfo { get; set; }
    public string? ExternalGUID { get; set; }
    public List<RefundAppliedToTxn>? RefundAppliedToTxnRet { get; set; }
    public List<DataExt>? DataExtRet { get; set; }
}