namespace QB.SDK;

public class SalesOrderAdd : QBRequest
{
    public string? defMacro { get; set; }
    public ListRef? CustomerRef { get; set; }
    public ListRef? ClassRef { get; set; }
    public ListRef? TemplateRef { get; set; }
    public DateOnly? TxnDate { get; set; }
    public string? RefNumber { get; set; }
    public Address? BillAddress { get; set; }
    public Address? ShipAddress { get; set; }
    public string? PONumber { get; set; }
    public ListRef? TermsRef { get; set; }
    public DateOnly? DueDate { get; set; }
    public ListRef? SalesRepRef { get; set; }
    public string? FOB { get; set; }
    public DateOnly? ShipDate { get; set; }
    public ListRef? ShipMethodRef { get; set; }
    public ListRef? ItemSalesTaxRef { get; set; }
    public bool? IsManuallyClosed { get; set; }
    public string? Memo { get; set; }
    public ListRef? CustomerMsgRef { get; set; }
    public bool? IsToBePrinted { get; set; }
    public bool? IsToBeEmailed { get; set; }
    public bool? IsTaxIncluded { get; set; }
    public ListRef? CustomerSalesTaxCodeRef { get; set; }
    public string? Other { get; set; }
    public float? ExchangeRate { get; set; }
    public string? ExternalGUID { get; set; }
    public List<SalesOrderLineAddBase>? SalesOrderLineAdd { get; set; }
    public SalesOrder? Results { get; private set; }

    internal override void ParseResponse(QBResponse response)
    {
        var rs = response as SalesOrderAddRs ?? throw new InvalidOperationException("Unable to parse response as SalesOrderAddRs.");
        StatusCode = rs.StatusCode;
        StatusMessage = rs.StatusMessage;
        StatusSeverity = rs.StatusSeverity;
        Results = rs.SalesOrderRet;
    }

    public override XElement ToQBXML()
    {
        var rq = new XElement(nameof(SalesOrderAdd))
            .Append(CustomerRef)
            .Append(ClassRef)
            .Append(TemplateRef)
            .Append(TxnDate)
            .Append(RefNumber)
            .Append(BillAddress)
            .Append(ShipAddress)
            .Append(PONumber)
            .Append(TermsRef)
            .Append(DueDate)
            .Append(SalesRepRef)
            .Append(FOB)
            .Append(ShipDate)
            .Append(ShipMethodRef)
            .Append(ItemSalesTaxRef)
            .Append(IsManuallyClosed)
            .Append(Memo)
            .Append(CustomerMsgRef)
            .Append(IsToBePrinted)
            .Append(IsToBeEmailed)
            .Append(IsTaxIncluded)
            .Append(CustomerSalesTaxCodeRef)
            .Append(Other)
            .Append(ExchangeRate)
            .Append(ExternalGUID)
            .Append(SalesOrderLineAdd);

        return new XElement($"{nameof(SalesOrderAdd)}Rq")
            .AppendAttribute(requestID)
            .AppendAttribute(defMacro)
            .Append(rq)
            .Append(IncludeRetElement);
    }
}