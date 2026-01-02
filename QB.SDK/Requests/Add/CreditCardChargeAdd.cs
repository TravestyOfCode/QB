namespace QB.SDK;

public class CreditCardChargeAdd : QBRequest
{
    public string? defMacro { get; set; }
    public ListRef? AccountRef { get; set; }
    public ListRef? PayeeEntityRef { get; set; }
    public DateOnly? TxnDate { get; set; }
    public string? RefNumber { get; set; }
    public string? Memo { get; set; }
    public bool? IsTaxIncluded { get; set; }
    public ListRef? SalesTaxCodeRef { get; set; }
    public float? ExchangeRate { get; set; }
    public string? ExternalGUID { get; set; }
    public List<ExpenseLineAdd>? ExpenseLines { get; set; }
    public List<ItemLineAddBase>? ItemLines { get; set; }

    public override XElement ToQBXML()
    {
        var rq = new XElement(nameof(CreditCardChargeAdd))
            .AppendAttribute(defMacro)
            .Append(AccountRef)
            .Append(PayeeEntityRef)
            .Append(TxnDate)
            .Append(RefNumber)
            .Append(Memo)
            .Append(IsTaxIncluded)
            .Append(SalesTaxCodeRef)
            .Append(ExchangeRate)
            .Append(ExternalGUID)
            .Append(ExpenseLines)
            .Append(ItemLines);

        return new XElement($"{nameof(CreditCardChargeAdd)}Rq")
            .AppendAttribute(requestID)
            .Append(rq)
            .Append(IncludeRetElement);
    }
}
