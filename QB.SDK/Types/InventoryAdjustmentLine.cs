namespace QB.SDK;

public abstract class InventoryAdjustmentLine
{
    public string? TxnLineID { get; set; }
    public ListRef? ItemRef { get; set; }
    public string? SerialNumber { get; set; }
    public string? LotNumber { get; set; }
    public ListRef? InventorySiteLocationRef { get; set; }
    public decimal? QuantityDifference { get; set; }
    public decimal? ValueDifference { get; set; }
}
