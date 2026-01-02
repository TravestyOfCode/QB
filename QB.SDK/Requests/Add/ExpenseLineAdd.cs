namespace QB.SDK;

public class ExpenseLineAdd
{
    public ListRef? AccountRef { get; set; }
    public decimal? Amount { get; set; }
    public string? Memo { get; set; }
    public ListRef? CustomerRef { get; set; }
    public ListRef? ClassRef { get; set; }
    public ListRef? SalesTaxCodeRef { get; set; }
    public BillableStatus? BillableStatus { get; set; }
    public ListRef? SalesRepRef { get; set; }
    public List<DataExt>? DataExt { get; set; }

    public XElement ToQBXML()
    {
        return new XElement(nameof(ExpenseLineAdd))
            .Append(AccountRef)
            .Append(Amount, 2)
            .Append(Memo)
            .Append(CustomerRef)
            .Append(ClassRef)
            .Append(SalesTaxCodeRef)
            .Append(BillableStatus)
            .Append(SalesRepRef)
            .Append(DataExt);
    }
}

internal static class ExpenseLineAddExtensions
{
    public static XElement Append(this XElement element, ExpenseLineAdd? value)
    {
        if (value != null)
        {
            element.Add(value.ToQBXML());
        }
        return element;
    }
    public static XElement Append(this XElement element, List<ExpenseLineAdd>? values)
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
