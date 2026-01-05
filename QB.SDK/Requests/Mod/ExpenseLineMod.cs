
namespace QB.SDK;

public class ExpenseLineMod : IQBXML
{
    public required string TxnLineID { get; set; }
    public ListRef? AccountRef { get; set; }
    public decimal? Amount { get; set; }
    public string? Memo { get; set; }
    public ListRef? CustomerRef { get; set; }
    public ListRef? ClassRef { get; set; }
    public ListRef? SalesTaxCodeRef { get; set; }
    public BillableStatus? BillableStatus { get; set; }
    public ListRef? SalesRepRef { get; set; }

    public XElement ToQBXML()
    {
        return new XElement(nameof(ExpenseLineMod))
            .Append(TxnLineID)
            .Append(AccountRef)
            .Append(Amount)
            .Append(Memo)
            .Append(CustomerRef)
            .Append(ClassRef)
            .Append(SalesTaxCodeRef)
            .Append(BillableStatus)
            .Append(SalesRepRef);
    }
}
