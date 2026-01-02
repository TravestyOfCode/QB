namespace QB.SDK;

public abstract class InventoryAdjustmentLineAdd
{
    public required ListRef ItemRef { get; set; }

    public abstract XElement ToQBXML();
}

internal static class InventoryAdjustmentLineExtensions
{
    public static XElement Append(this XElement element, List<InventoryAdjustmentLineAdd>? values)
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