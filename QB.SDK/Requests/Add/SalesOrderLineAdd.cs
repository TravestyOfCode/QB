namespace QB.SDK;

public class SalesOrderLineAdd : SalesOrderLineAddBase
{
    public ListRef? ItemRef { get; set; }
    public string? Desc { get; set; }
    public decimal? Rate { get; set; }
    public decimal? RatePercent { get; set; }
    public ListRef? PriceLevelRef { get; set; }
    public ListRef? ClassRef { get; set; }
    public decimal? Amount { get; set; }
    public OptionForPriceRuleConflict? OptionForPriceRuleConflict { get; set; }
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
        return new XElement(nameof(SalesOrderLineAdd))
            .Append(ItemRef)
            .Append(Desc)
            .Append(Quantity)
            .Append(UnitOfMeasure)
            .Append(Rate)
            .Append(RatePercent)
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
            .Append(Other2)
            .Append(DataExt);
    }
}
