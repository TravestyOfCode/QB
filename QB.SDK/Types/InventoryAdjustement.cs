namespace QB.SDK;

public class InventoryAdjustment : QBTxn
{
    public int? TxnNumber { get; set; }
    public ListRef? AccountRef { get; set; }
    public ListRef? InventorySiteRef { get; set; }
    public DateOnly? TxnDate { get; set; }
    public string? RefNumber { get; set; }
    public ListRef? CustomerRef { get; set; }
    public ListRef? ClassRef { get; set; }
    public string? Memo { get; set; }
    public string? ExternalGUID { get; set; }
    public List<InventoryAdjustmentLine>? InventoryAdjustmentLineRet { get; set; }
    public List<DataExt>? DataExtRet { get; set; }
}