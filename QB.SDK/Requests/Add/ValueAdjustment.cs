namespace QB.SDK;

// TODO: Look into NewValue/ValueDifference as the xsd states maxOccurs="0"
public class ValueAdjustment : InventoryAdjustmentLineAdd
{
    public decimal? NewQuantity { get; set; }
    public decimal? QuantityDifference { get; set; }
    public decimal? NewValue { get; set; }
    public decimal? ValueDifference { get; set; }

    public override XElement ToQBXML()
    {
        var rq = new XElement(nameof(ValueAdjustment))
            .Append(NewQuantity)
            .Append(QuantityDifference)
            .Append(NewValue)
            .Append(ValueDifference);

        return new XElement(nameof(InventoryAdjustmentLineAdd))
            .Append(ItemRef)
            .Append(rq);
    }
}
