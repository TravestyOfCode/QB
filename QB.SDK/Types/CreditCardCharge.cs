namespace QB.SDK;

public class CreditCardCharge
{
    public string? TxnID { get; set; }
    public DateTime? TimeCreated { get; set; }
    public DateTime? TimeModified { get; set; }
    public string? EditSequence { get; set; }
    public int? TxnNumber { get; set; }
    public ListRef? AccountRef { get; set; }
    public ListRef? PayeeEntityRef { get; set; }
    public DateOnly? TxnDate { get; set; }
    public decimal? Amount { get; set; }
    public ListRef? CurrencyRef { get; set; }
    public float? ExchangeRate { get; set; }
    public decimal? AmountInHomeCurrency { get; set; }
    public string? RefNumber { get; set; }
    public string? Memo { get; set; }
    public bool? IsTaxIncluded { get; set; }
    public ListRef? SalesTaxCodeRef { get; set; }
    public string? ExternalGUID { get; set; }
    public List<ExpenseLine>? ExpenseLineRet { get; set; }
    [XmlElement("ItemLineRet", typeof(ItemLine))]
    [XmlElement("ItemGroupLineRet", typeof(ItemGroupLine))]
    public List<ItemLineBase>? ItemLines { get; set; }
    public List<DataExt>? DataExtRet { get; set; }
}


