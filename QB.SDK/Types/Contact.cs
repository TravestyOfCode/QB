namespace QB.SDK;

public class Contact : IQBXMLNamed
{
    public string? Salutation { get; set; }
    public required string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }
    public string? JobTitle { get; set; }
    public List<AdditionalContact>? AdditionalContactRef { get; set; }

    public XElement ToQBXML(string name = nameof(Contact))
    {
        return new XElement(name)
            .Append(Salutation)
            .Append(FirstName)
            .Append(MiddleName)
            .Append(LastName)
            .Append(JobTitle)
            .Append(AdditionalContactRef);
    }
}
