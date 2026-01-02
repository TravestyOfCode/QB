namespace QB.SDK;

public class QuantityAdjustment : InventoryAdjustmentLineAdd
{
    public decimal? NewQuantity { get; set; }
    public decimal? QuantityDifference { get; set; }
    public string? SerialNumber { get; set; }
    public string? LotNumber { get; set; }
    public ListRef? InventorySiteLocationRef { get; set; }

    public override XElement ToQBXML()
    {
        var rq = new XElement(nameof(QuantityAdjustment))
            .Append(NewQuantity)
            .Append(QuantityDifference)
            .Append(SerialNumber)
            .Append(LotNumber)
            .Append(InventorySiteLocationRef);

        return new XElement(nameof(InventoryAdjustmentLineAdd))
            .Append(ItemRef)
            .Append(rq);

    }
}
