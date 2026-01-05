namespace QB.SDK;

public abstract class ItemLineModBase : IQBXML
{
    public required string TxnLineID { get; set; }
    public decimal? Quantity { get; set; }
    public string? UnitOfMeasure { get; set; }
    public ListRef? OverrideUOMSetRef { get; set; }

    public abstract XElement ToQBXML();
}
