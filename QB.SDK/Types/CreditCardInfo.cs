namespace QB.SDK;

public class CreditCardInfo : IQBXML
{
    public string? CreditCardNumber { get; set; }
    public int? ExpirationMonth { get; set; }
    public int? ExpirationYear { get; set; }
    public string? NameOnCard { get; set; }
    public string? CreditCardAddress { get; set; }
    public string? CreditCardPostalCode { get; set; }

    public XElement ToQBXML()
    {
        return new XElement(nameof(CreditCardInfo))
            .Append(CreditCardNumber)
            .Append(ExpirationMonth)
            .Append(ExpirationYear)
            .Append(NameOnCard)
            .Append(CreditCardAddress)
            .Append(CreditCardPostalCode);
    }
}