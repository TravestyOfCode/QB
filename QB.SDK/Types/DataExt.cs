namespace QB.SDK;

public class DataExt
{
    public string? OwnerID { get; set; }
    public string? DataExtName { get; set; }
    public DataExtType? DataExtType { get; set; }
    public string? DataExtValue { get; set; }

    internal XElement ToQBXML(string name = nameof(DataExt))
    {
        return new XElement(name)
            .Append(OwnerID)
            .Append(DataExtName)
            .Append(DataExtType)
            .Append(DataExtValue);
    }
}

internal static class DataExtExtensions
{
    public static XElement Append(this XElement element, DataExt? value, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value != null)
        {
            element.Add(value.ToQBXML(name));
        }
        return element;
    }
    public static XElement Append(this XElement element, List<DataExt>? values, [CallerArgumentExpression(nameof(values))] string name = "")
    {
        if (values != null)
        {
            foreach (var value in values)
            {
                element.Add(value.ToQBXML(name));
            }
        }
        return element;
    }

}