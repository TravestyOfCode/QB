namespace QB.SDK;

public class DateRangeFilter : IQBXMLNamed
{
    public DateOnly? From { get; set; }
    public DateOnly? To { get; set; }
    public DateMacro? DateMacro { get; set; }

    public XElement ToQBXML(string name = nameof(DateRangeFilter))
    {
        return new XElement($"{name}RangeFilter")
            .Append(From, $"From{name}")
            .Append(To, $"To{name}")
            .Append(DateMacro);
    }
}
