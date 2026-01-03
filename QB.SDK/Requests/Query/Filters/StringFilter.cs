namespace QB.SDK;

public class StringFilter : IQBXMLNamed
{
    public required MatchCriterion MatchCriterion { get; set; }
    public required string Value { get; set; }

    public XElement ToQBXML(string name = nameof(StringFilter))
    {
        return new XElement($"{name}Filter")
            .Append(MatchCriterion)
            .Append(Value, name);
    }
}
