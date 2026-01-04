namespace QB.SDK;

public abstract class TxnNoAccountQuery : QueryRq, IQBXML
{
    private List<string>? _TxnID;
    private List<string>? _RefNumber;
    private List<string>? _RefNumberCaseSensitive;
    private int? _MaxReturned;
    private ModifiedDateRangeFilter? _ModifiedDateRangeFilter;
    private TxnDateRangeFilter? _TxnDateRangeFilter;
    private RefNumberFilter? _RefNumberFilter;
    private RefNumberRangeFilter? _RefNumberRangeFilter;
    private EntityFilter? _EntityFilter;

    /// <summary>
    /// One or more TxnID values. QuickBooks generates a unique TxnID for each 
    /// transaction that is added to QuickBooks.
    /// </summary>
    public List<string>? TxnID
    {
        get => _TxnID;
        set
        {
            if (value != null)
            {
                RefNumber.ExclusiveThrow(nameof(TxnID));
                RefNumberCaseSensitive.ExclusiveThrow(nameof(TxnID));
                MaxReturned.ExclusiveThrow(nameof(TxnID));
                ModifiedDateRangeFilter.ExclusiveThrow(nameof(TxnID));
                TxnDateRangeFilter.ExclusiveThrow(nameof(TxnID));
                RefNumberFilter.ExclusiveThrow(nameof(TxnID));
                RefNumberRangeFilter.ExclusiveThrow(nameof(TxnID));
                EntityFilter.ExclusiveThrow(nameof(TxnID));
            }
            _TxnID = value;
        }
    }

    /// <summary>
    /// A list of one or more RefNumber values. A RefNumber is a string of characters
    /// that refers to a transaction and that can be arbitrarily changed by the QuickBooks user.
    /// You should use this case sensitive ref number list rather than RefNumber list, 
    /// because it provides much better performance if the refNumber values contains 
    /// letters, not just digits.
    /// </summary>
    public List<string>? RefNumber
    {
        get => _RefNumber;
        set
        {
            if (value != null)
            {
                TxnID.ExclusiveThrow(nameof(RefNumber));
                RefNumberCaseSensitive.ExclusiveThrow(nameof(RefNumber));
                MaxReturned.ExclusiveThrow(nameof(RefNumber));
                ModifiedDateRangeFilter.ExclusiveThrow(nameof(RefNumber));
                TxnDateRangeFilter.ExclusiveThrow(nameof(RefNumber));
                RefNumberFilter.ExclusiveThrow(nameof(RefNumber));
                RefNumberRangeFilter.ExclusiveThrow(nameof(RefNumber));
                EntityFilter.ExclusiveThrow(nameof(RefNumber));
            }
            _RefNumber = value;
        }
    }

    /// <summary>
    /// A list of one or more case sensitive RefNumber values. A RefNumber is a string
    /// of characters that refers to a transaction and that can be arbitrarily changed
    /// by the QuickBooks user.
    /// Requires QBSDK version 4.0 or higher.
    /// </summary>
    public List<string>? RefNumberCaseSensitive
    {
        get => _RefNumberCaseSensitive;
        set
        {
            if (value != null)
            {
                TxnID.ExclusiveThrow(nameof(RefNumberCaseSensitive));
                RefNumber.ExclusiveThrow(nameof(RefNumberCaseSensitive));
                ModifiedDateRangeFilter.ExclusiveThrow(nameof(RefNumberCaseSensitive));
                MaxReturned.ExclusiveThrow(nameof(RefNumberCaseSensitive));
                TxnDateRangeFilter.ExclusiveThrow(nameof(RefNumberCaseSensitive));
                RefNumberFilter.ExclusiveThrow(nameof(RefNumberCaseSensitive));
                RefNumberRangeFilter.ExclusiveThrow(nameof(RefNumberCaseSensitive));
                EntityFilter.ExclusiveThrow(nameof(RefNumberCaseSensitive));
            }
            _RefNumberCaseSensitive = value;
        }
    }

    /// <summary>
    /// Limits the number of objects that a query returns. (To get a count of how 
    /// many objects could possibly be returned, use the metaData query attribute.) If 
    /// you include a MaxReturned value, it must be at least 1.
    /// </summary>
    public int? MaxReturned
    {
        get => _MaxReturned;
        set
        {
            if (value != null)
            {
                TxnID.ExclusiveThrow(nameof(MaxReturned));
                RefNumber.ExclusiveThrow(nameof(MaxReturned));
                RefNumberCaseSensitive.ExclusiveThrow(nameof(MaxReturned));
                RefNumberFilter.ExclusiveThrow(nameof(MaxReturned));
                RefNumberRangeFilter.ExclusiveThrow(nameof(MaxReturned));
            }

            if (string.IsNullOrWhiteSpace(iteratorID))
            {
                if (value != null)
                {
                    iterator = Iterator.Start;
                }
                else
                {
                    iterator = null;
                }
            }
            else
            {
                iterator = Iterator.Continue;
            }

            _MaxReturned = value;
        }
    }

    /// <summary>
    /// Filters according to the dates when transactions were last modified. The 
    /// ModifiedDateRangeFilter aggregate is not required to contain any elements, but 
    /// if it is empty, it is recommend that you leave it out altogether.
    /// </summary>
    public ModifiedDateRangeFilter? ModifiedDateRangeFilter
    {
        get => _ModifiedDateRangeFilter;
        set
        {
            if (value != null)
            {
                TxnID.ExclusiveThrow(nameof(ModifiedDateRangeFilter));
                RefNumber.ExclusiveThrow(nameof(ModifiedDateRangeFilter));
                RefNumberCaseSensitive.ExclusiveThrow(nameof(ModifiedDateRangeFilter));
                TxnDateRangeFilter.ExclusiveThrow(nameof(ModifiedDateRangeFilter));
                RefNumberFilter.ExclusiveThrow(nameof(ModifiedDateRangeFilter));
                RefNumberRangeFilter.ExclusiveThrow(nameof(ModifiedDateRangeFilter));
            }
            _ModifiedDateRangeFilter = value;
        }

    }

    /// <summary>
    /// Filters according to the original transaction dates.
    /// </summary>
    public TxnDateRangeFilter? TxnDateRangeFilter
    {
        get => _TxnDateRangeFilter;
        set
        {
            if (value != null)
            {
                TxnID.ExclusiveThrow(nameof(TxnDateRangeFilter));
                RefNumber.ExclusiveThrow(nameof(TxnDateRangeFilter));
                RefNumberCaseSensitive.ExclusiveThrow(nameof(TxnDateRangeFilter));
                ModifiedDateRangeFilter.ExclusiveThrow(nameof(TxnDateRangeFilter));
                RefNumberFilter.ExclusiveThrow(nameof(TxnDateRangeFilter));
                RefNumberRangeFilter.ExclusiveThrow(nameof(TxnDateRangeFilter));
            }
            _TxnDateRangeFilter = value;
        }
    }

    /// <summary>
    /// Filters according to RefNumber. 
    /// </summary>
    public RefNumberFilter? RefNumberFilter
    {
        get => _RefNumberFilter;
        set
        {
            if (value != null)
            {
                TxnID.ExclusiveThrow(nameof(RefNumberFilter));
                RefNumber.ExclusiveThrow(nameof(RefNumberFilter));
                RefNumberCaseSensitive.ExclusiveThrow(nameof(RefNumberFilter));
                MaxReturned.ExclusiveThrow(nameof(RefNumberFilter));
                ModifiedDateRangeFilter.ExclusiveThrow(nameof(RefNumberFilter));
                TxnDateRangeFilter.ExclusiveThrow(nameof(RefNumberFilter));
                RefNumberRangeFilter.ExclusiveThrow(nameof(RefNumberFilter));
            }
            _RefNumberFilter = value;
        }
    }

    /// <summary>
    /// Filters according to RefNumber. The filtering code will do a numerical comparison 
    /// (if FromRefNumber and ToRefNumber only contain digits) or a lexicographical 
    /// comparison (if either FromRefNumber or ToRefNumber contain any nondigit characters).
    /// If you need to query for a RefNumber that is larger than the maximum long integer 
    /// value of 2147483647, specify a FromRefNumber that is <= 2147483647 without a ToRefNumber. 
    /// </summary>
    public RefNumberRangeFilter? RefNumberRangeFilter
    {
        get => _RefNumberRangeFilter;
        set
        {
            if (value != null)
            {
                TxnID.ExclusiveThrow(nameof(RefNumberRangeFilter));
                RefNumber.ExclusiveThrow(nameof(RefNumberRangeFilter));
                RefNumberCaseSensitive.ExclusiveThrow(nameof(RefNumberRangeFilter));
                MaxReturned.ExclusiveThrow(nameof(RefNumberRangeFilter));
                ModifiedDateRangeFilter.ExclusiveThrow(nameof(RefNumberRangeFilter));
                TxnDateRangeFilter.ExclusiveThrow(nameof(RefNumberRangeFilter));
                RefNumberFilter.ExclusiveThrow(nameof(RefNumberRangeFilter));
            }
            _RefNumberRangeFilter = value;
        }
    }

    /// <summary>
    /// A person on the QuickBooks Customer list.
    /// </summary>
    public EntityFilter? EntityFilter
    {
        get => _EntityFilter;
        set
        {
            if (value != null)
            {
                RefNumber.ExclusiveThrow(nameof(EntityFilter));
                RefNumberCaseSensitive.ExclusiveThrow(nameof(EntityFilter));
                TxnID.ExclusiveThrow(nameof(EntityFilter));
            }
            _EntityFilter = value;
        }
    }

    /// <summary>
    /// Filters by the specified currency. 
    /// </summary>
    public CurrencyFilter? CurrencyFilter { get; set; }

    /// <summary>
    /// This filter allows you to omit line items from a query response to get a smaller 
    /// result. The default value is false, so line items are omitted by default.
    /// </summary>
    public bool? IncludeLineItems { get; set; }

    /// <summary>
    /// If you set IncludeLinkedTxns to true, then the returned object will include a 
    /// list of all the transactions linked to the queried object.
    /// </summary>
    public bool? IncludeLinkedTxns { get; set; }

    /// <summary>
    /// Refers to the owner of a data extension:
    ///   If OwnerID is 0, this is a public data extension, also known as a custom 
    ///     field. Custom fields appear in the QuickBooks UI.
    ///   If OwnerID is a GUID, for example {6B063959-81B0-4622-85D6-F548C8CCB517}, 
    ///     this field is a private data extension defined by an integrated application.
    ///     Private data extensions do not appear in the QuickBooks UI.
    /// </summary>
    public List<string>? OwnerID { get; set; }

}
