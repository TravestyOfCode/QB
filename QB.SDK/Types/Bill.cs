namespace QB.SDK;

public class Bill
{
    public string? TxnID { get; set; }
    public DateTime? TimeCreated { get; set; }
    public DateTime? TimeModified { get; set; }
    public string? EditSequence { get; set; }
    public int? TxnNumber { get; set; }
    public ListRef? VendorRef { get; set; }
    public Address? VendorAddress { get; set; }
    public ListRef? APAccountRef { get; set; }
    public DateOnly? TxnDate { get; set; }
    public DateOnly? DueDate { get; set; }
    public decimal? AmountDue { get; set; }
    public ListRef? CurrencyRef { get; set; }
    public float? ExchangeRate { get; set; }
    public decimal? AmountDueInHomeCurrency { get; set; }
    public string? RefNumber { get; set; }
    public ListRef? TermsRef { get; set; }
    public string? Memo { get; set; }
    public bool? IsTaxIncluded { get; set; }
    public ListRef? SalesTaxCodeRef { get; set; }
    public bool? IsPaid { get; set; }
    public string? ExternalGUID { get; set; }
    public List<LinkedTxn>? LinkedTxn { get; set; }
    public List<ExpenseLine>? ExpenseLineRet { get; set; }
    public List<ItemLine>? ItemLineRet { get; set; }
    public List<ItemGroupLine>? ItemGroupLineRet { get; set; }
    public decimal? OpenAmount { get; set; }
    public List<DataExt>? DataExtRet { get; set; }

}