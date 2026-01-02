namespace QB.SDK;

public class CreditCardTxnInfo
{
    public CreditCardTxnInputInfo? CreditCardTxnInputInfo { get; set; }

    public CreditCardTxnResultInfo? CreditCardTxnResultInfo { get; set; }

    public XElement ToQBXML()
    {
        return new XElement(nameof(CreditCardTxnInfo))
            .Append(CreditCardTxnInputInfo)
            .Append(CreditCardTxnResultInfo);
    }
}

internal static class CreditCardTxnInfoExtensions
{
    public static XElement Append(this XElement element, CreditCardTxnInfo? value)
    {
        if (value != null)
        {
            element.Add(value.ToQBXML());
        }
        return element;
    }
}
