namespace QB.SDK;

public class SerialNumberAdjustment : InventoryAdjustmentLineAdd
{
    public string? AddSerialNumber { get; set; }
    public string? RemoveSerialNumber { get; set; }
    public ListRef? InventorySiteLocationRef { get; set; }

    public override XElement ToQBXML()
    {
        var rq = new XElement(nameof(SerialNumberAdjustment))
            .Append(AddSerialNumber)
            .Append(RemoveSerialNumber)
            .Append(InventorySiteLocationRef);

        return new XElement(nameof(InventoryAdjustmentLineAdd))
            .Append(ItemRef)
            .Append(rq);
    }
}
