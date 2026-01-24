namespace QB.SDK;

public abstract class QBObject
{
    public DateTime? TimeCreated { get; set; }
    public DateTime? TimeModified { get; set; }
    public string? EditSequence { get; set; }
}
