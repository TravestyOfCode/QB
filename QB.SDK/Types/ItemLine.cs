namespace QB.SDK;

public class ItemLine : ItemLineBase
{
    public ListRef? ItemRef { get; set; }
    public ListRef? InventorySiteRef { get; set; }
    public ListRef? InventorySiteLocationRef { get; set; }
    public string? SerialNumber { get; set; }
    public string? LotNumber { get; set; }
    public decimal? Cost { get; set; }
    public decimal? Amount { get; set; }
    public ListRef? CustomerRef { get; set; }
    public ListRef? ClassRef { get; set; }
    public ListRef? SalesTaxCodeRef { get; set; }
    public BillableStatus? BillableStatus { get; set; }
    public ListRef? SalesRepRef { get; set; }
}
