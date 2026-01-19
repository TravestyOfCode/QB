namespace QB.SDK;

public class SalesOrderLineGroupMod : SalesOrderLineModBase
{
    public ListRef? ItemGroupRef { get; set; }
    public ListRef? OverrideUOMSetRef { get; set; }
    public List<SalesOrderLineMod>? SalesOrderLineMod { get; set; }

    /// <summary>
    /// Converts the object to a XElement represenation according to the QBXML specification.
    /// </summary>
    /// <returns>A XElement respresentation of the object.</returns>
    public override XElement ToQBXML()
    {
        return new XElement(nameof(SalesOrderLineGroupMod))
            .Append(TxnLineID)
            .Append(ItemGroupRef)
            .Append(Quantity)
            .Append(UnitOfMeasure)
            .Append(OverrideUOMSetRef)
            .Append(SalesOrderLineMod);
    }
}
