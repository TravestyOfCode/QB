namespace QB.SDK;

public class LotNumberAdjustment : InventoryAdjustmentLineAdd
{
    public string? LotNumber { get; set; }
    public int? CountAdjustment { get; set; }
    public ListRef? InventorySiteLocationRef { get; set; }

    public override XElement ToQBXML()
    {
        var rq = new XElement(nameof(LotNumberAdjustment))
            .Append(LotNumber)
            .Append(CountAdjustment)
            .Append(InventorySiteLocationRef);

        return new XElement(nameof(InventoryAdjustmentLineAdd))
            .Append(ItemRef)
            .Append(rq);
    }
}
