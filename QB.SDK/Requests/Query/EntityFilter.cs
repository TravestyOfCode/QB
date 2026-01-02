namespace QB.SDK;

public class EntityFilter : IQBXML
{
    public List<string>? ListID { get; set; }
    public List<string>? FullName { get; set; }
    public List<string>? ListIDWithChildren { get; set; }
    public List<string>? FullNameWithChildren { get; set; }

    public XElement ToQBXML()
    {
        return new XElement(nameof(EntityFilter))
            .Append(ListID)
            .Append(FullName)
            .Append(ListIDWithChildren)
            .Append(FullNameWithChildren);
    }
}
