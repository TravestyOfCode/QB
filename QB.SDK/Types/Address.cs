namespace QB.SDK;

public class Address
{
    public string? Addr1 { get; set; }
    public string? Addr2 { get; set; }
    public string? Addr3 { get; set; }
    public string? Addr4 { get; set; }
    public string? Addr5 { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? PostalCode { get; set; }
    public string? Country { get; set; }
    public string? Note { get; set; }

    public XElement ToQBXML(string name = nameof(Address))
    {
        return new XElement(name)
            .Append(Addr1)
            .Append(Addr2)
            .Append(Addr3)
            .Append(Addr4)
            .Append(Addr5)
            .Append(City)
            .Append(State)
            .Append(PostalCode)
            .Append(Country)
            .Append(Note);
    }
}

internal static class AddressExtensions
{
    public static XElement Append(this XElement element, Address? value, [CallerArgumentExpression(nameof(value))] string name = nameof(Address))
    {
        if (value != null)
        {
            element.Add(value.ToQBXML(name));
        }
        return element;
    }
}

