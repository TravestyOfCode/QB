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

    /// <summary>
    /// Converts a SalesOrderLineBase into a Mod request line.
    /// </summary>
    /// <param name="line">The SalesOrderLineBase to convert.</param>
    /// <returns>Either a SalesOrderLineMod or SalesOrderLineGroupMod depending on the type of line.</returns>
    public abstract SalesOrderLineModBase ToMod(SalesOrderLineBase lineBase);
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