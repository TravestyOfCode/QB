namespace QB.SDK;

public class SalesOrderLineGroupAdd : SalesOrderLineAddBase
{
    public ListRef? ItemGroupRef { get; set; }

    /// <summary>
    /// Converts the object to a XElement represenation according to the QBXML specification.
    /// </summary>
    /// <returns>A XElement respresentation of the object.</returns>
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