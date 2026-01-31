namespace QB.SDK;

public class BillPaymentCreditCardAdd : QBRequest
{
    public string? defMacro { get; set; }
    public required ListRef PayeeEntityRef { get; set; }
    public ListRef? APAccountRef { get; set; }
    public DateOnly? TxnDate { get; set; }
    public required ListRef CreditCardAccountRef { get; set; }
    public string? RefNumber { get; set; }
    public string? Memo { get; set; }
    public float? ExchangeRate { get; set; }
    public string? ExternalGUID { get; set; }
    public List<AppliedToTxnAdd>? AppliedToTxnAdd { get; set; }
    public BillPaymentCreditCard? Results { get; set; }

    internal override void ParseResponse(QBResponse response)
    {
        var rs = response as BillPaymentCreditCardAddRs ?? throw new InvalidOperationException("Unable to parse response as BillPaymentCreditCardAddRs.");
        StatusCode = rs.StatusCode;
        StatusMessage = rs.StatusMessage;
        StatusSeverity = rs.StatusSeverity;
        Results = rs.BillPaymentCreditCardRet;
    }

    public override XElement ToQBXML()
    {
        var rq = new XElement(nameof(BillPaymentCreditCardAdd))
            .AppendAttribute(defMacro)
            .Append(PayeeEntityRef)
            .Append(APAccountRef)
            .Append(TxnDate)
            .Append(CreditCardAccountRef)
            .Append(RefNumber)
            .Append(Memo)
            .Append(ExchangeRate)
            .Append(ExternalGUID)
            .Append(AppliedToTxnAdd);

        return new XElement($"{nameof(BillPaymentCreditCardAdd)}Rq")
            .AppendAttribute(requestID)
            .Append(rq)
            .Append(IncludeRetElement);
    }
}