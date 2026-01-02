namespace QB.SDK;

public abstract class QBResponse
{
    [XmlAttribute("requestID")]
    public string? RequestID { get; set; }

    [XmlAttribute("statusCode")]
    public string? StatusCode { get; set; }

    [XmlAttribute("statusSeverity")]
    public string? StatusSeverity { get; set; }

    [XmlAttribute("statusMessage")]
    public string? StatusMessage { get; set; }

    public ErrorRecovery? ErrorRecovery { get; set; }
}
