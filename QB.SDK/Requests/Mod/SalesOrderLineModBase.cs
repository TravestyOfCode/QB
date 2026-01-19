namespace QB.SDK;

public abstract class SalesOrderLineModBase
{
    public required string TxnLineID { get; set; }
    public decimal? Quantity { get; set; }
    public string? UnitOfMeasure { get; set; }

    /// <summary>
    /// Converts the object to a XElement represenation according to the QBXML specification.
    /// </summary>
    /// <returns>A XElement respresentation of the object.</returns>
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