namespace QB.SDK;

public class QueryRs<T> : QBResponse
{
    [XmlAttribute("iteratorID")]
    public string? IteratorID { get; set; }

    [XmlAttribute("iteratorRemainingCount")]
    public string? RemainingCount { get; protected set; }

    [XmlAttribute("retCount")]
    public string? ReturnedCount { get; protected set; }

    public List<T>? Results { get; protected set; }
}
