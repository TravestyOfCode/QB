namespace QB.SDK;

public abstract class SalesOrderLineAddBase
{
    public decimal? Quantity { get; set; }
    public string? UnitOfMeasure { get; set; }
    public ListRef? InventorySiteRef { get; set; }
    public ListRef? InventorySiteLocationRef { get; set; }
    public List<DataExt>? DataExt { get; set; }

    public abstract XElement ToQBXML();
}

internal static class SalesOrderLineAddBaseExtensions
{
    public static XElement Append(this XElement element, List<SalesOrderLineAddBase>? values)
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