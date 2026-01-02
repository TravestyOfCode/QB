namespace QB.SDK;

public abstract class QueryRq : QBRequest
{
    public Iterator? iterator { get; set; }

    public string? iteratorID { get; set; }

    public MetaData? metaData { get; set; }

    private int? _MaxReturned;
    public int? MaxReturned
    {
        get => _MaxReturned;
        set
        {
            if (string.IsNullOrWhiteSpace(iteratorID))
            {
                if (value != null)
                {
                    iterator = Iterator.Start;
                }
                else
                {
                    iterator = null;
                }
            }
            else
            {
                iterator = Iterator.Continue;
            }

            _MaxReturned = value;
        }
    }
}
