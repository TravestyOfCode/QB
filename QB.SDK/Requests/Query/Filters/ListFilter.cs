namespace QB.SDK;

public class ListFilter : IQBXMLNamed
{
    public List<string>? ListID { get; set; }
    public List<string>? FullName { get; set; }

    public XElement ToQBXML(string name = nameof(ListFilter))
    {
        return new XElement(name)
                .Append(ListID)
                .Append(FullName);
    }
}
