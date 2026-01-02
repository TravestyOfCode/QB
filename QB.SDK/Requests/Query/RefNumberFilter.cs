namespace QB.SDK;

public class RefNumberFilter : IQBXML
{
    public required MatchCriterion MatchCriterion { get; set; }
    public required string RefNumber { get; set; }

    public XElement ToQBXML()
    {
        return new XElement(nameof(RefNumberFilter))
            .Append(MatchCriterion)
            .Append(RefNumber);
    }
}
