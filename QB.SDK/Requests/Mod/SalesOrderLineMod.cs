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