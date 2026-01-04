namespace QB.SDK;

public abstract class QueryRq : QBRequest
{
    public Iterator? iterator { get; set; }

    public string? iteratorID { get; set; }

    public MetaData? metaData { get; set; }
}
