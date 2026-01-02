namespace QB.SDK;

public class SalesOrderQuery : QueryRq, IQBXML
{
    public string? TxnID { get; set; }
    public string? RefNumber { get; set; }
    public string? RefNumberCaseSensitive { get; set; }
    public ModifiedDateRangeFilter? ModifiedDateRangeFilter { get; set; }
    public TxnDateRangeFilter? TxnDateRangeFilter { get; set; }
    public EntityFilter? EntityFilter { get; set; }
    public RefNumberFilter? RefNumberFilter { get; set; }
    public RefNumberRangeFilter? RefNumberRangeFilter { get; set; }
    public CurrencyFilter? CurrencyFilter { get; set; }
    public bool? IncludeLineItems { get; set; }
    public bool? IncludeLinkedTxns { get; set; }
    public string? OwnerID { get; set; }

    public override XElement ToQBXML()
    {
        return new XElement($"{nameof(SalesOrderQuery)}Rq")
            .AppendAttribute(requestID)
            .AppendAttribute(metaData)
            .AppendAttribute(iterator)
            .AppendAttribute(iteratorID)
            .Append(TxnID)
            .Append(RefNumber)
            .Append(RefNumberCaseSensitive)
            .Append(MaxReturned)
            .Append(ModifiedDateRangeFilter)
            .Append(TxnDateRangeFilter)
            .Append(EntityFilter)
            .Append(RefNumberFilter)
            .Append(RefNumberRangeFilter)
            .Append(CurrencyFilter)
            .Append(IncludeLineItems)
            .Append(IncludeLinkedTxns)
            .Append(OwnerID);
    }
}
