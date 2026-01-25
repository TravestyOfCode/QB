namespace QB.SDK;

public class BillAdd : QBRequest
{
    public string? defMacro { get; set; }
    public required ListRef VendorRef { get; set; }
    public Address? VendorAddress { get; set; }
    public ListRef? APAccountRef { get; set; }
    public DateOnly? TxnDate { get; set; }
    public DateOnly? DueDate { get; set; }
    public string? RefNumber { get; set; }
    public ListRef? TermsRef { get; set; }
    public string? Memo { get; set; }
    public bool? IsTaxIncluded { get; set; }
    public ListRef? SalesTaxCodeRef { get; set; }
    public float? ExchangeRate { get; set; }
    public string? ExternalGUID { get; set; }
    public List<string>? LinkToTxnID { get; set; }
    public List<ExpenseLineAdd>? ExpenseLines { get; set; }
    public List<ItemLineAddBase>? ItemLines { get; set; }
    public Bill? Results { get; private set; }

    internal override void ParseResponse(QBResponse response)
    {
        var rs = response as BillAddRs ?? throw new InvalidOperationException("Unable to parse response as BillAddRs.");
        StatusCode = rs.StatusCode;
        StatusMessage = rs.StatusMessage;
        StatusSeverity = rs.StatusSeverity;
        Results = rs.BillRet;
    }

    public override XElement ToQBXML()
    {
        var rq = new XElement(nameof(BillAdd))
            .AppendAttribute(defMacro)
            .Append(VendorRef)
            .Append(VendorAddress)
            .Append(APAccountRef)
            .Append(TxnDate)
            .Append(DueDate)
            .Append(RefNumber)
            .Append(TermsRef)
            .Append(Memo)
            .Append(IsTaxIncluded)
            .Append(SalesTaxCodeRef)
            .Append(ExchangeRate)
            .Append(ExternalGUID)
            .Append(LinkToTxnID)
            .Append(ExpenseLines)
            .Append(ItemLines);

        return new XElement($"{nameof(BillAdd)}Rq")
            .AppendAttribute(requestID)
            .Append(rq)
            .Append(IncludeRetElement);
    }
}
