
namespace QB.SDK;

public class ARRefundCreditCardAdd : QBRequest
{
    public ListRef? CustomerRef { get; set; }
    public ListRef? RefundFromAccountRef { get; set; }
    public ListRef? ARAccountRef { get; set; }
    public DateOnly? TxnDate { get; set; }
    public string? RefNumber { get; set; }
    public Address? Address { get; set; }
    public ListRef? PaymentMethodRef { get; set; }
    public string? Memo { get; set; }
    public CreditCardTxnInfo? CreditCardTxnInfo { get; set; }
    public float? ExchangeRate { get; set; }
    public string? ExternalGUID { get; set; }
    public List<RefundAppliedToTxnAdd>? RefundAppliedToTxnAdd { get; set; }

    public override XElement ToQBXML()
    {
        var rq = new XElement(nameof(ARRefundCreditCardAdd))
            .AppendAttribute(requestID)
            .Append(CustomerRef)
            .Append(RefundFromAccountRef)
            .Append(ARAccountRef)
            .Append(TxnDate)
            .Append(RefNumber)
            .Append(Address)
            .Append(PaymentMethodRef)
            .Append(Memo)
            .Append(CreditCardTxnInfo)
            .Append(ExchangeRate)
            .Append(ExternalGUID)
            .Append(RefundAppliedToTxnAdd);

        return new XElement($"{nameof(ARRefundCreditCardAdd)}Rq")
            .Append(rq);
    }
}