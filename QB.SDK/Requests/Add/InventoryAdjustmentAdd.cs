namespace QB.SDK;

public class InventoryAdjustmentAdd : QBRequest
{
    public string? defMacro { get; set; }
    public required ListRef AccountRef { get; set; }
    public DateOnly? TxnDate { get; set; }
    public string? RefNumber { get; set; }
    public ListRef? InventorySiteRef { get; set; }
    public ListRef? CustomerRef { get; set; }
    public ListRef? ClassRef { get; set; }
    public string? Memo { get; set; }
    public string? ExternalGUID { get; set; }
    public List<InventoryAdjustmentLineAdd>? InventoryAdjustmentLineAdd { get; set; }
    public InventoryAdjustment? Results { get; private set; }

    internal override void ParseResponse(QBResponse response)
    {
        var rs = response as InventoryAdjustmentAddRs ?? throw new InvalidOperationException("Unable to parse response as InventoryAdjustmentAddRs.");
        StatusCode = rs.StatusCode;
        StatusMessage = rs.StatusMessage;
        StatusSeverity = rs.StatusSeverity;
        Results = rs.InventoryAdjustmentRet;
    }

    public override XElement ToQBXML()
    {
        var rq = new XElement(nameof(InventoryAdjustmentAdd))
            .Append(AccountRef)
            .Append(TxnDate)
            .Append(RefNumber)
            .Append(InventorySiteRef)
            .Append(CustomerRef)
            .Append(ClassRef)
            .Append(Memo)
            .Append(ExternalGUID)
            .Append(InventoryAdjustmentLineAdd);

        return new XElement($"{nameof(InventoryAdjustmentAdd)}Rq")
            .AppendAttribute(requestID)
            .AppendAttribute(defMacro)
            .Append(rq)
            .Append(IncludeRetElement);
    }
}
