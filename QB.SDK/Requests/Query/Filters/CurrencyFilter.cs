namespace QB.SDK;

public class CurrencyFilter : IQBXML
{
    private List<string>? _ListID { get; set; }
    private List<string>? _FullName { get; set; }

    /// <summary>
    /// One or more ListID values. When a list object is added to QuickBooks through 
    /// the SDK or through the QuickBooks user interface, the server assigns it a ListID.
    /// </summary>
    public List<string>? ListID
    {
        get => _ListID;
        set
        {
            if (value != null)
            {
                FullName.ExclusiveThrow(nameof(ListID));
            }
            _ListID = value;
        }
    }

    /// <summary>
    /// A list of one or more FullName values. The FullName is the name prefixed by 
    /// the names of each ancestor each separated by a colon ':' character.
    /// </summary>
    public List<string>? FullName
    {
        get => _FullName;
        set
        {
            if (value != null)
            {
                ListID.ExclusiveThrow(nameof(FullName));
            }
            _FullName = value;
        }
    }

    /// <summary>
    /// Converts the object to a XElement represenation according to the QBXML specification.
    /// </summary>
    /// <returns>A XElement respresentation of the object.</returns>
    public XElement ToQBXML()
    {
        return new XElement(nameof(CurrencyFilter))
            .Append(ListID)
            .Append(FullName);
    }
}
