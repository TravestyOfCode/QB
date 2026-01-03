namespace QB.SDK;

public class QueryRs<T> : QBResponse
{
    public int? RemainingCount { get; protected set; }

    public int? ReturnedCount { get; protected set; }

    public List<T>? Results { get; protected set; }
}
