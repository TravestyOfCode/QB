namespace QB.SDK;

public class ItemGroupLineAdd : ItemLineAddBase
{
    public ListRef? ItemGroupRef { get; set; }

    public override XElement ToQBXML()
    {
        return new XElement(nameof(ItemGroupLineAdd))
            .Append(ItemGroupRef)
            .Append(Quantity)
            .Append(UnitOfMeasure)
            .Append(InventorySiteRef)
            .Append(InventorySiteLocationRef)
            .Append(DataExt);
    }
}
