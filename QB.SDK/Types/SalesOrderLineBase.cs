namespace QB.SDK;

public abstract class SalesOrderLineBase
{
    public string? TxnLineID { get; set; }
    public string? Desc { get; set; }
    public decimal? Quantity { get; set; }
    public string? UnitOfMeasure { get; set; }
    public ListRef? OverrideUOMSetRef { get; set; }
    public List<DataExt>? DataExtRet { get; set; }
}