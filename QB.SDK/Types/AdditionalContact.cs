namespace QB.SDK;

public class AdditionalContact : IQBXMLNamed
{
    public required string ContactName { get; set; }
    public required string ContactValue { get; set; }

    public XElement ToQBXML(string name = nameof(AdditionalContact))
    {
        return new XElement(name)
            .Append(ContactName)
            .Append(ContactValue);
    }

    // TODO: Add additional contact types
    public static AdditionalContact MainPhone(string value) => new() { ContactName = "Main Phone", ContactValue = value };
    public static AdditionalContact AltPhone(string value) => new() { ContactName = "Alt. Phone", ContactValue = value };
    public static AdditionalContact Email(string value) => new() { ContactName = "Email", ContactValue = value };
}