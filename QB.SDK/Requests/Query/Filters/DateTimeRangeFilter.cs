namespace QB.SDK;

public class DateTimeRangeFilter : IQBXMLNamed
{
    public DateTime? From { get; set; }
    public DateTime? To { get; set; }

    public XElement ToQBXML(string name = nameof(DateTimeRangeFilter))
    {
        return new XElement($"{name}RangeFilter")
            .Append(From, $"From{name}")
            .Append(To, $"To{name}");
    }
}
