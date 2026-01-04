namespace QB.SDK;

public class RefNumberFilter : IQBXML
{
    /// <summary>
    /// The criterion to match.
    /// </summary>
    public required MatchCriterion MatchCriterion { get; set; }

    /// <summary>
    /// A string of characters that refers to this transaction and that can be 
    /// arbitrarily changed by the QuickBooks user. 
    /// </summary>
    public required string RefNumber { get; set; }

    /// <summary>
    /// Converts the object to a XElement represenation according to the QBXML specification.
    /// </summary>
    /// <returns>A XElement respresentation of the object.</returns>
    public XElement ToQBXML()
    {
        return new XElement(nameof(RefNumberFilter))
            .Append(MatchCriterion)
            .Append(RefNumber);
    }

    public static RefNumberFilter StartsWith(string refNumber) => new() { MatchCriterion = MatchCriterion.StartsWith, RefNumber = refNumber };
    public static RefNumberFilter Contains(string refNumber) => new() { MatchCriterion = MatchCriterion.Contains, RefNumber = refNumber };
    public static RefNumberFilter EndsWith(string refNumber) => new() { MatchCriterion = MatchCriterion.EndsWith, RefNumber = refNumber };
}
