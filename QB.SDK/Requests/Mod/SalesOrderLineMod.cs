namespace QB.SDK;

public class SalesOrderLineMod : SalesOrderLineModBase
{
    public ListRef? ItemRef { get; set; }
    public string? Desc { get; set; }
    public ListRef? OverrideUOMSetRef { get; set; }
    public decimal? Rate { get; set; }
    public decimal? RatePercent { get; set; }
    public ListRef? PriceLevelRef { get; set; }
    public ListRef? ClassRef { get; set; }
    public decimal? Amount { get; set; }
    public OptionForPriceRuleConflict? OptionForPriceRuleConflict { get; set; }
    public ListRef? InventorySiteRef { get; set; }
    public ListRef? InventorySiteLocationRef { get; set; }
    public string? SerialNumber { get; set; }
    public string? LotNumber { get; set; }
    public ListRef? SalesTaxCodeRef { get; set; }
    public bool? IsManuallyClosed { get; set; }
    public string? Other1 { get; set; }
    public string? Other2 { get; set; }

    /// <summary>
    /// Converts the object to a XElement represenation according to the QBXML specification.
    /// </summary>
    /// <returns>A XElement respresentation of the object.</returns>
    public override XElement ToQBXML()
    {
        return new XElement(nameof(SalesOrderLineMod))
            .Append(TxnLineID)
            .Append(ItemRef)
            .Append(Desc)
            .Append(Quantity)
            .Append(UnitOfMeasure)
            .Append(OverrideUOMSetRef)
            .Append(Rate)
            .Append(RatePercent)
            .Append(PriceLevelRef)
            .Append(ClassRef)
            .Append(Amount)
            .Append(OptionForPriceRuleConflict)
            .Append(InventorySiteRef)
            .Append(InventorySiteLocationRef)
            .Append(SerialNumber)
            .Append(LotNumber)
            .Append(SalesTaxCodeRef)
            .Append(IsManuallyClosed)
            .Append(Other1)
            .Append(Other2);
    }

    /// <summary>
    /// Converts a SalesOrderLineBase into a Mod request line.
    /// </summary>
    /// <param name="line">The SalesOrderLineBase to convert.</param>
    /// <returns>Either a SalesOrderLineMod or SalesOrderLineGroupMod depending on the type of line.</returns>
    public override SalesOrderLineModBase ToMod(SalesOrderLineBase lineBase)
    {
        var line = lineBase as SalesOrderLine ?? throw new InvalidOperationException("Unable to convert SalesOrderLineBase to SalesOrderLine.");

        line.TxnLineID.ThrowIfNullOrWhiteSpace();

        return new SalesOrderLineMod()
        {
            ItemRef = line.ItemRef,
            Desc = line.Desc,
            OverrideUOMSetRef = line.OverrideUOMSetRef,
            Rate = line.Rate,
            RatePercent = line.RatePercent,
            //PriceLevelRef = line.PriceLevelRef,
            ClassRef = line.ClassRef,
            Amount = line.Amount,
            //OptionForPriceRuleConflict = line.OptionForPriceRuleConflict,
            InventorySiteRef = line.InventorySiteRef,
            InventorySiteLocationRef = line.InventorySiteLocationRef,
            SerialNumber = line.SerialNumber,
            LotNumber = line.LotNumber,
            SalesTaxCodeRef = line.SalesTaxCodeRef,
            IsManuallyClosed = line.IsManuallyClosed,
            Other1 = line.Other1,
            Other2 = line.Other2,
            TxnLineID = line.TxnLineID,
            Quantity = line.Quantity,
            UnitOfMeasure = line.UnitOfMeasure
        };
    }
}

internal static class SalesOrderLineModExtensions
{
    public static XElement Append(this XElement element, List<SalesOrderLineMod>? values)
    {
        if (values != null)
        {
            foreach (var value in values)
            {
                element.Add(value.ToQBXML());
            }
        }
        return element;
    }
}