namespace QB.SDK;

public class SalesOrderLine : SalesOrderLineBase
{
    public ListRef? ItemRef { get; set; }
    public decimal? Rate { get; set; }
    public decimal? RatePercent { get; set; }
    public ListRef? ClassRef { get; set; }
    public decimal? Amount { get; set; }
    public ListRef? InventorySiteRef { get; set; }
    public ListRef? InventorySiteLocationRef { get; set; }
    public string? SerialNumber { get; set; }
    public string? LotNumber { get; set; }
    public ListRef? SalesTaxCodeRef { get; set; }
    public decimal? Invoiced { get; set; }
    public bool? IsManuallyClosed { get; set; }
    public string? Other1 { get; set; }
    public string? Other2 { get; set; }

    internal override SalesOrderLineMod ToMod()
    {
        // Check for required property
        TxnLineID.ThrowIfNullOrWhiteSpace();

        return new SalesOrderLineMod()
        {
            TxnLineID = TxnLineID,
            ItemRef = ItemRef,
            Desc = Desc,
            Quantity = Quantity,
            UnitOfMeasure = UnitOfMeasure,
            OverrideUOMSetRef = OverrideUOMSetRef,
            Rate = Rate,
            RatePercent = RatePercent,
            //PriceLevelRef = PriceLevelRef,
            ClassRef = ClassRef,
            Amount = Amount,
            //OptionForPriceRuleConflict = OptionForPriceRuleConflict,
            InventorySiteRef = InventorySiteRef,
            InventorySiteLocationRef = InventorySiteLocationRef,
            SerialNumber = SerialNumber,
            LotNumber = LotNumber,
            SalesTaxCodeRef = SalesTaxCodeRef,
            IsManuallyClosed = IsManuallyClosed,
            Other1 = Other1,
            Other2 = Other2
        };
    }
}
