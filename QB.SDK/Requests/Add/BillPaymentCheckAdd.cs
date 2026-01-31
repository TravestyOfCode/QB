namespace QB.SDK;

public class BillPaymentCheckAdd : QBRequest
{
    public string? defMacro { get; set; }
    public required ListRef PayeeEntityRef { get; set; }
    public ListRef? APAccountRef { get; set; }
    public DateOnly? TxnDate { get; set; }
    public required ListRef BankAccountRef { get; set; }
    public bool? IsToBePrinted { get; set; }
    public string? RefNumber { get; set; }
    public string? Memo { get; set; }
    public float? ExchangeRate { get; set; }
    public string? ExternalGUID { get; set; }
    public List<AppliedToTxnAdd>? AppliedToTxnAdd { get; set; }
    public BillPaymentCheck? Results { get; set; }

    internal override void ParseResponse(QBResponse response)
    {
        var rs = response as BillPaymentCheckAddRs ?? throw new InvalidOperationException("Unable to parse response as BillPaymentCheckAddRs.");
        StatusCode = rs.StatusCode;
        StatusMessage = rs.StatusMessage;
        StatusSeverity = rs.StatusSeverity;
        Results = rs.BillPaymentCheckRet;
    }

    public override XElement ToQBXML()
    {
        var rq = new XElement(nameof(BillPaymentCheckAdd))
            .AppendAttribute(defMacro)
            .Append(PayeeEntityRef)
            .Append(APAccountRef)
            .Append(TxnDate)
            .Append(BankAccountRef)
            .Append(IsToBePrinted)
            .Append(RefNumber)
            .Append(Memo)
            .Append(ExchangeRate)
            .Append(ExternalGUID)
            .Append(AppliedToTxnAdd)
            .Append(IncludeRetElement);

        return new XElement($"{nameof(BillPaymentCheckAdd)}Rq")
            .AppendAttribute(requestID)
            .Append(rq)
            .Append(IncludeRetElement);
    }
}
