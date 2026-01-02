namespace QB.SDK;

public abstract class SalesOrderLineModBase
{
    public string? TxnLineID { get; set; }
    public decimal? Quantity { get; set; }
    public string? UnitOfMeasure { get; set; }

    public abstract XElement ToQBXML();
}

internal static class SalesOrderLineModBaseExtensions
{
    public static XElement Append(this XElement element, List<SalesOrderLineModBase>? values)
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