namespace QB.SDK;

public abstract class ItemLineAddBase
{
    public ListRef? InventorySiteRef { get; set; }
    public ListRef? InventorySiteLocationRef { get; set; }
    public decimal? Quantity { get; set; }
    public string? UnitOfMeasure { get; set; }
    public List<DataExt>? DataExt { get; set; }

    public abstract XElement ToQBXML();
}

internal static class ItemLineAddBaseExtensions
{
    public static XElement Append(this XElement element, ItemLineAddBase? value)
    {
        if (value != null)
        {
            element.Add(value.ToQBXML());
        }
        return element;
    }
    public static XElement Append(this XElement element, List<ItemLineAddBase>? values)
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