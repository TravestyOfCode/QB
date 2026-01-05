namespace QB.SDK;

public class AccountFilter : IQBXML
{
    private List<string>? _ListID { get; set; }
    private List<string>? _FullName { get; set; }
    private List<string>? _ListIDWithChildren { get; set; }
    private List<string>? _FullNameWithChildren { get; set; }

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
                ListIDWithChildren.ExclusiveThrow(nameof(ListID));
                FullNameWithChildren.ExclusiveThrow(nameof(ListID));
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
                ListIDWithChildren.ExclusiveThrow(nameof(FullName));
                FullNameWithChildren.ExclusiveThrow(nameof(FullName));
            }
            _FullName = value;
        }
    }

    /// <summary>
    /// Allows you to filter for data that relates to the specified object's ListID and its descendants.
    /// </summary>
    public List<string>? ListIDWithChildren
    {
        get => _ListIDWithChildren;
        set
        {
            if (value != null)
            {
                ListID.ExclusiveThrow(nameof(ListIDWithChildren));
                FullName.ExclusiveThrow(nameof(ListIDWithChildren));
                ListIDWithChildren.ExclusiveThrow(nameof(ListIDWithChildren));
            }
            _ListIDWithChildren = value;
        }
    }

    /// <summary>
    /// Allows you to filter for data that relates to the specified object's FullName and its descendants.
    /// </summary>
    public List<string>? FullNameWithChildren
    {
        get => _FullNameWithChildren;
        set
        {
            if (value != null)
            {
                ListID.ExclusiveThrow(nameof(FullNameWithChildren));
                FullName.ExclusiveThrow(nameof(FullNameWithChildren));
                ListIDWithChildren.ExclusiveThrow(nameof(FullNameWithChildren));
            }
            _FullNameWithChildren = value;
        }
    }

    /// <summary>
    /// Converts the object to a XElement represenation according to the QBXML specification.
    /// </summary>
    /// <returns>A XElement respresentation of the object.</returns>
    public XElement ToQBXML()
    {
        return new XElement(nameof(AccountFilter))
            .Append(ListID)
            .Append(FullName)
            .Append(ListIDWithChildren)
            .Append(FullNameWithChildren);
    }
}
