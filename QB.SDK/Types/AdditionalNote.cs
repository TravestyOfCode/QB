namespace QB.SDK;

public class AdditionalNote : IQBXMLNamed
{
    public int? NoteID { get; set; }
    public required string Note { get; set; }

    public XElement ToQBXML(string name = nameof(AdditionalNote))
    {
        return new XElement(name)
            .Append(NoteID)
            .Append(Note);
    }

    public static implicit operator AdditionalNote(string value) => new() { Note = value };
    public static implicit operator string(AdditionalNote value) => value.Note;
}
