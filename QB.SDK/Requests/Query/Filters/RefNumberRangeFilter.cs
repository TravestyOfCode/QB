namespace QB.SDK;

public class RefNumberRangeFilter : IQBXML
{
    /// <summary>
    /// The first RefNumber in the search range. If FromRefNumber is omitted, 
    /// the range will begin with first number on the list.
    /// </summary>
    public string? FromRefNumber { get; set; }

    /// <summary>
    /// The final RefNumber in the search range. If ToRefNumber is omitted, 
    /// the range will end with last number on the list. 
    /// </summary>
    public string? ToRefNumber { get; set; }

    /// <summary>
    /// Converts the object to a XElement represenation according to the QBXML specification.
    /// </summary>
    /// <returns>A XElement respresentation of the object.</returns>
    public XElement ToQBXML()
    {
        return new XElement(nameof(RefNumberRangeFilter))
            .Append(FromRefNumber)
            .Append(ToRefNumber);
    }
}
