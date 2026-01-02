namespace QB.SDK;

public class SalesOrderLineGroupAdd : SalesOrderLineAddBase
{
    public ListRef? ItemGroupRef { get; set; }

    public override XElement ToQBXML()
    {
        return new XElement(nameof(SalesOrderLineGroupAdd))
            .Append(ItemGroupRef)
            .Append(Quantity)
            .Append(UnitOfMeasure)
            .Append(InventorySiteRef)
            .Append(InventorySiteLocationRef)
            .Append(DataExt);
    }
}