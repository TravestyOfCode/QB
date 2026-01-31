namespace QB.SDK;

public class BillPaymentCheck
{
    public string? TxnID { get; set; }
    public DateTime? TimeCreated { get; set; }
    public DateTime? TimeModified { get; set; }
    public string? EditSequence { get; set; }
    public int? TxnNumber { get; set; }
    public ListRef? PayeeEntityRef { get; set; }
    public ListRef? APAccountRef { get; set; }
    public DateOnly? TxnDate { get; set; }
    public ListRef? BankAccountRef { get; set; }
    public decimal? Amount { get; set; }
    public ListRef? CurrencyRef { get; set; }
    public float? ExchangeRate { get; set; }
    public decimal? AmountInHomeCurrency { get; set; }
    public string? RefNumber { get; set; }
    public string? Memo { get; set; }
    public Address? Address { get; set; }
    public bool? IsToBePrinted { get; set; }
    public string? ExternalGUID { get; set; }
    public List<AppliedToTxn>? AppliedToTxnRet { get; set; }
    public List<DataExt>? DataExtRet { get; set; }
}
