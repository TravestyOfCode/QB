namespace QB.SDK;

public class TxnDateRangeFilter : IQBXML
{
    private DateOnly? _FromTxnDate;
    private DateOnly? _ToTxnDate;
    private DateMacro? _DateMacro;

    public TxnDateRangeFilter() { }
    public TxnDateRangeFilter(DateOnly? from, DateOnly? to)
    {
        _FromTxnDate = from;
        _ToTxnDate = to;
    }
    public TxnDateRangeFilter(DateMacro dateMacro)
    {
        _DateMacro = dateMacro;
    }

    /// <summary>
    /// Selects transactions created on or after this date. Must be between 01/01/1901 and 12/31/9999.
    /// </summary>
    public DateOnly? FromTxnDate
    {
        get => _FromTxnDate;
        set
        {
            if (value != null)
            {
                ToTxnDate.ExclusiveThrow(nameof(FromTxnDate));
                DateMacro.ExclusiveThrow(nameof(FromTxnDate));
            }
            _FromTxnDate = value;
        }
    }

    /// <summary>
    /// Selects transactions created on or before this date. Must be between 01/01/1901 and 12/31/9999.
    /// </summary>
    public DateOnly? ToTxnDate
    {
        get => _ToTxnDate;
        set
        {
            if (value != null)
            {
                FromTxnDate.ExclusiveThrow(nameof(ToTxnDate));
                DateMacro.ExclusiveThrow(nameof(ToTxnDate));
            }
            _ToTxnDate = value;
        }
    }

    /// <summary>
    /// Selects transactions created within the range of the selected value.
    /// </summary>
    public DateMacro? DateMacro
    {
        get => _DateMacro;
        set
        {
            if (value != null)
            {
                FromTxnDate.ExclusiveThrow(nameof(DateMacro));
                ToTxnDate.ExclusiveThrow(nameof(DateMacro));
            }
            _DateMacro = value;
        }
    }

    /// <summary>
    /// Converts the object to a XElement represenation according to the QBXML specification.
    /// </summary>
    /// <returns>A XElement respresentation of the object.</returns>
    public XElement ToQBXML()
    {
        return new XElement(nameof(TxnDateRangeFilter))
            .Append(FromTxnDate)
            .Append(ToTxnDate)
            .Append(DateMacro);
    }
}
