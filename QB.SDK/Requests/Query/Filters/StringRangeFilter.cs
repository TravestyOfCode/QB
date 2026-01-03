namespace QB.SDK;

public class StringRangeFilter : IQBXMLNamed
{
    public string? From { get; set; }
    public string? To { get; set; }

    public XElement ToQBXML(string name = nameof(StringRangeFilter))
    {
        return new XElement($"{name}RangeFilter")
            .Append(From, $"From{name}")
            .Append(To, $"To{name}");
    }
}
