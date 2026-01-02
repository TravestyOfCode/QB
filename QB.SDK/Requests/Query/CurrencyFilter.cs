namespace QB.SDK;

public class CurrencyFilter : IQBXML
{
    public List<string>? ListID { get; set; }
    public List<string>? FullName { get; set; }

    public XElement ToQBXML()
    {
        return new XElement(nameof(CurrencyFilter))
            .Append(ListID)
            .Append(FullName);
    }
}
