namespace QB.SDK;

public class QueryRs<T> : QBResponse
{
    [XmlAttribute("iteratorID")]
    public string? IteratorID { get; set; }

    [XmlAttribute("iteratorRemainingCount")]
    public string? RemainingCount { get; set; }

    [XmlAttribute("retCount")]
    public string? ReturnedCount { get; set; }

    public List<T>? Results { get; set; }
}
