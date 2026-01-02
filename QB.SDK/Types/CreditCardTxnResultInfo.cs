namespace QB.SDK;

public class CreditCardTxnResultInfo
{
    public int? ResultCode { get; set; }
    public string? ResultMessage { get; set; }
    public string? CreditCardTransID { get; set; }
    public string? MerchantAccountNumber { get; set; }
    public string? AuthorizationCode { get; set; }
    public AVSStatus? AVSStreet { get; set; }
    public AVSStatus? AVSZip { get; set; }
    public AVSStatus? CardSecurityCodeMatch { get; set; }
    public string? ReconBatchID { get; set; }
    public int? PaymentGroupingCode { get; set; }
    public PaymentStatus? PaymentStatus { get; set; }
    public DateTime? TxnAuthorizationTime { get; set; }
    public int? TxnAuthorizationStamp { get; set; }
    public string? ClientTransID { get; set; }

    internal XElement ToQBXML()
    {
        return new XElement(nameof(CreditCardTxnResultInfo))
            .Append(ResultCode)
            .Append(ResultMessage)
            .Append(CreditCardTransID)
            .Append(MerchantAccountNumber)
            .Append(AuthorizationCode)
            .Append(AVSStreet)
            .Append(AVSZip)
            .Append(CardSecurityCodeMatch)
            .Append(ReconBatchID)
            .Append(PaymentGroupingCode)
            .Append(PaymentStatus)
            .Append(TxnAuthorizationTime)
            .Append(TxnAuthorizationStamp)
            .Append(ClientTransID);
    }
}

internal static class CreditCardTxnResultInfoExtensions
{
    public static XElement Append(this XElement element, CreditCardTxnResultInfo? value)
    {
        if (value != null)
        {
            element.Add(value.ToQBXML());
        }
        return element;
    }
}