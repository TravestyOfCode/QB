namespace QB.SDK;

public class RefundAppliedToTxnAdd
{
    public string? useMacro { get; set; }
    public string? TxnID { get; set; }
    public decimal? RefundAmount { get; set; }

    internal XElement ToQBXML()
    {
        return new XElement(nameof(RefundAppliedToTxnAdd))
            .AppendAttribute(useMacro)
            .Append(TxnID)
            .Append(RefundAmount);
    }
}

internal static class RefundAppliedToTxnAddExtensions
{
    public static XElement Append(this XElement element, RefundAppliedToTxnAdd? value)
    {
        if (value != null)
        {
            element.Add(value.ToQBXML());
        }
        return element;
    }
    public static XElement Append(this XElement element, List<RefundAppliedToTxnAdd>? values)
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