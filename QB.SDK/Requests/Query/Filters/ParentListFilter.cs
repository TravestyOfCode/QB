namespace QB.SDK;

public class ParentListFilter : IQBXMLNamed
{
    public List<string>? ListID { get; set; }
    public List<string>? FullName { get; set; }
    public bool? IncludeChildren { get; set; }

    public XElement ToQBXML(string name = nameof(ParentListFilter))
    {
        return IncludeChildren == true
            ? new XElement(name)
                .Append(ListID, "ListIDWithChildren")
                .Append(FullName, "FullNameWithChildren")
            : new XElement(name)
                .Append(ListID)
                .Append(FullName);
    }
}
