using System.Linq;

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

    /// <summary>
    /// Converts a SalesOrderLineBase into a Mod request line.
    /// </summary>
    /// <param name="line">The SalesOrderLineBase to convert.</param>
    /// <returns>Either a SalesOrderLineMod or SalesOrderLineGroupMod depending on the type of line.</returns>
    public override SalesOrderLineModBase ToMod(SalesOrderLineBase lineBase)
    {
        var line = lineBase as SalesOrderLineGroup ?? throw new InvalidOperationException("Unable to convert SalesOrderLineBase to SalesOrderLineGroup.");

        line.TxnLineID.ThrowIfNullOrWhiteSpace();

        return new SalesOrderLineGroupMod()
        {
            TxnLineID = line.TxnLineID,
            ItemGroupRef = line.ItemGroupRef,
            Quantity = line.Quantity,
            UnitOfMeasure = line.UnitOfMeasure,
            OverrideUOMSetRef = line.OverrideUOMSetRef,
            SalesOrderLineMod = line.SalesOrderLineRet?.Select(l => l.ToMod()).ToList()
        };
    }
}
