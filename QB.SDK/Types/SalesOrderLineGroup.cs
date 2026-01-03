using System.Linq;

namespace QB.SDK;

public class SalesOrderLineGroup : SalesOrderLineBase
{
    public ListRef? ItemGroupRef { get; set; }
    public bool? IsPrintItemsInGroup { get; set; }
    public decimal? TotalAmount { get; set; }
    public List<SalesOrderLine>? SalesOrderLineRet { get; set; }

    internal override SalesOrderLineModBase ToMod()
    {
        // Check for required property
        TxnLineID.ThrowIfNullOrWhiteSpace();

        return new SalesOrderLineGroupMod()
        {
            TxnLineID = TxnLineID,
            ItemGroupRef = ItemGroupRef,
            Quantity = Quantity,
            UnitOfMeasure = UnitOfMeasure,
            OverrideUOMSetRef = OverrideUOMSetRef,
            SalesOrderLineMod = SalesOrderLineRet?.Select(l => l.ToMod()).ToList()
        };
    }
}