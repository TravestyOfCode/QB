namespace QB.SDK;

public class CreditCardTxnInputInfo
{
    public string? CreditCardNumber { get; set; }
    public int? ExpirationMonth { get; set; }
    public int? ExpirationYear { get; set; }
    public string? NameOnCard { get; set; }
    public string? CreditCardAddress { get; set; }
    public string? CreditCardPostalCode { get; set; }
    public string? CommercialCardCode { get; set; }
    public TransactionMode? TransactionMode { get; set; }
    public CreditCardTxnType? CreditCardTxnType { get; set; }

    public XElement ToQBXML()
    {
        return new XElement(nameof(CreditCardTxnInputInfo))
            .Append(CreditCardNumber)
            .Append(ExpirationMonth)
            .Append(ExpirationYear)
            .Append(NameOnCard)
            .Append(CreditCardAddress)
            .Append(CreditCardPostalCode)
            .Append(CommercialCardCode)
            .Append(TransactionMode)
            .Append(CreditCardTxnType);
    }
}

internal static class CreditCardTxnInputInfoExtensions
{
    public static XElement Append(this XElement element, CreditCardTxnInputInfo? value)
    {
        if (value != null)
        {
            element.Add(value.ToQBXML());
        }
        return element;
    }
}
