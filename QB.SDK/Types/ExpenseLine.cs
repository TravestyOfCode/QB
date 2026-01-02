namespace QB.SDK;

public class ExpenseLine
{
    public string? TxnLineID { get; set; }
    public ListRef? AccountRef { get; set; }
    public decimal? Amount { get; set; }
    public string? Memo { get; set; }
    public ListRef? CustomerRef { get; set; }
    public ListRef? ClassRef { get; set; }
    public ListRef? SalesTaxCodeRef { get; set; }
    public BillableStatus? BillableStatus { get; set; }
    public ListRef? SalesRepRef { get; set; }
    public List<DataExt>? DataExtRet { get; set; }
}