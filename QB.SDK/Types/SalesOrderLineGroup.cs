namespace QB.SDK;

public class SalesOrderLineGroup : SalesOrderLineBase
{
    public ListRef? ItemGroupRef { get; set; }
    public bool? IsPrintItemsInGroup { get; set; }
    public decimal? TotalAmount { get; set; }
    public List<SalesOrderLine>? SalesOrderLineRet { get; set; }
}