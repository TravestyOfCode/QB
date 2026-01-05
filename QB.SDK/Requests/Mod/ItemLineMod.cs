namespace QB.SDK;

public class ItemLineMod : ItemLineModBase
{
    public ListRef? ItemRef { get; set; }
    public ListRef? InventorySiteRef { get; set; }
    public ListRef? InventorySiteLocationRef { get; set; }
    public string? SerialNumber { get; set; }
    public string? LotNumber { get; set; }
    public string? Desc { get; set; }
    public decimal? Cost { get; set; }
    public decimal? Amount { get; set; }
    public ListRef? CustomerRef { get; set; }
    public ListRef? ClassRef { get; set; }
    public ListRef? SalesTaxCodeRef { get; set; }
    public BillableStatus? BillableStatus { get; set; }
    public ListRef? OverrideItemAccountRef { get; set; }
    public ListRef? SalesRepRef { get; set; }

    public override XElement ToQBXML()
    {
        return new XElement(nameof(ItemLineMod))
            .Append(TxnLineID)
            .Append(ItemRef)
            .Append(InventorySiteRef)
            .Append(InventorySiteLocationRef)
            .Append(SerialNumber)
            .Append(LotNumber)
            .Append(Desc)
            .Append(Quantity)
            .Append(UnitOfMeasure)
            .Append(OverrideUOMSetRef)
            .Append(Cost)
            .Append(Amount)
            .Append(CustomerRef)
            .Append(ClassRef)
            .Append(SalesTaxCodeRef)
            .Append(BillableStatus)
            .Append(OverrideItemAccountRef)
            .Append(SalesRepRef);
    }
}