namespace QB.SDK;

public class ListRef
{
    public string? ListID { get; set; }

    public string? FullName { get; set; }

    internal XElement ToQBXML(string name = nameof(ListRef))
    {
        return new XElement(name)
            .Append(ListID)
            .Append(FullName);
    }

    public static implicit operator ListRef(string name) => new() { FullName = name };
}

internal static class ListRefExtensions
{
    public static XElement Append(this XElement element, ListRef? value, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value != null)
        {
            element.Add(value.ToQBXML(name));
        }
        return element;
    }
}
