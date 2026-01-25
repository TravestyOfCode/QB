namespace QB.SDK;

public abstract class QBRequest
{
    public readonly string requestID = Guid.NewGuid().ToString();

    public string? StatusCode { get; set; }

    public string? StatusSeverity { get; set; }

    public string? StatusMessage { get; set; }

    public List<string>? IncludeRetElement { get; set; }

    public abstract XElement ToQBXML();

    internal abstract void ParseResponse(QBResponse response);
}

internal static class QBRequestExtensions
{
    public static XElement Append(this XElement element, QBRequest? value)
    {
        if (value != null)
        {
            element.Add(value.ToQBXML());
        }
        return element;
    }
    public static XElement Append(this XElement element, List<QBRequest>? values)
    {
        if (values != null)
        {
            foreach (var value in values)
            {
                element.Add(value.ToQBXML());
            }
        }
        return element;
    }

}