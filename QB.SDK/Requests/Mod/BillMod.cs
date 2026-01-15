namespace QB.SDK;

public class BillMod : QBRequest, IQBXML
{
    /// <summary>
    /// QuickBooks generates a unique TxnID for each transaction that is added to QuickBooks. 
    /// </summary>
    public required string TxnID { get; set; }

    /// <summary>
    /// A number that the server generates and assigns to this object. Every time the object 
    /// is changed, the server will change its EditSequence value. When you try to modify 
    /// a list object, you must provide its EditSequence. 
    /// </summary>
    public required string EditSequence { get; set; }

    /// <summary>
    /// A VendorRef aggregate refers to any person or company from whom a small business 
    /// owner buys goods and services. If a VendorRef aggregate includes both FullName 
    /// and ListID, FullName will be ignored. 
    /// </summary>
    public ListRef? VendorRef { get; set; }

    /// <summary>
    /// If an address request fails, some combination of address fields might be too long.
    /// </summary>
    public Address? VendorAddress { get; set; }

    /// <summary>
    /// Refers to an accounts payable account in the QuickBooks file. (The AccountType of 
    /// this account will be AccountsPayable.) If APAccountRef is missing, this will use 
    /// the QuickBooks default AP account. In a request, if an APAccountRef aggregate includes 
    /// both FullName and ListID, FullName will be ignored.
    /// </summary>
    public ListRef? APAccountRef { get; set; }

    /// <summary>
    /// The date of the transaction.
    /// </summary>
    public DateOnly? TxnDate { get; set; }

    /// <summary>
    /// The date on which payment is due. 
    /// </summary>
    public DateOnly? DueDate { get; set; }

    /// <summary>
    /// A string of characters that refers to this transaction and that can be arbitrarily 
    /// changed by the QuickBooks user.
    /// </summary>
    public string? RefNumber { get; set; }

    /// <summary>
    /// Refers to the payment terms associated with this entity. (This will be an item on 
    /// the DateDrivenTerms or StandardTerms list.) If a TermsRef aggregate includes both
    /// FullName and ListID, FullName will be ignored. 
    /// </summary>
    public ListRef? TermsRef { get; set; }

    /// <summary>
    /// Appears in the A/P register and in reports that include this bill. 
    /// </summary>
    public string? Memo { get; set; }

    /// <summary>
    /// For future use with international versions of QuickBooks. 
    /// </summary>
    public bool? IsTaxIncluded { get; set; }

    /// <summary>
    /// Each item on a sales form is assigned a sales-tax code that indicates whether 
    /// the item is taxable or non-taxable, and why.
    /// </summary>
    public ListRef? SalesTaxCodeRef { get; set; }

    /// <summary>
    /// The exchange rate is the market price for which this currency can be exchanged 
    /// for the currency used by the QuickBooks company file as the "home" currency. 
    /// The exchange rate should be considered a snapshot of the rates in effect at the AsOfDate.
    /// </summary>
    public float? ExchangeRate { get; set; }

    /// <summary>
    /// Set ClearExpenseLines to true to clear all the expense lines.
    /// To modify individual lines, use ExpenseLineMod. 
    /// </summary>
    public bool? ClearExpenseLines { get; set; }

    /// <summary>
    /// A list of ExpenseLine objects, each representing one line in this expense. 
    /// </summary>
    public List<ExpenseLineMod>? ExpenseLineMod { get; set; }

    /// <summary>
    /// Set ClearItemLines to true to clear all the item lines.
    /// To modify individual lines, use ItemLineMod. 
    /// </summary>
    public bool? ClearItemLines { get; set; }

    /// <summary>
    /// An ItemLine is used to track any portion of a transaction that represents 
    /// the purchase of an "item." If ItemLineAdd does not specify an Amount, Cost, 
    /// or Quantity, then QuickBooks will calculate Amount based on a Quantity 
    /// of 1 and the suggested Cost.
    /// </summary>
    public List<ItemLineModBase>? ItemLineMod { get; set; }

    /// <summary>
    /// Converts the object to a XElement represenation according to the QBXML specification.
    /// </summary>
    /// <returns>A XElement respresentation of the object.</returns>
    public override XElement ToQBXML()
    {
        var rq = new XElement(nameof(BillMod))
            .Append(TxnID)
            .Append(EditSequence)
            .Append(VendorRef)
            .Append(VendorAddress)
            .Append(APAccountRef)
            .Append(TxnDate)
            .Append(DueDate)
            .Append(RefNumber)
            .Append(TermsRef)
            .Append(Memo)
            .Append(IsTaxIncluded)
            .Append(SalesTaxCodeRef)
            .Append(ExchangeRate)
            .Append(ClearExpenseLines)
            .Append(ExpenseLineMod)
            .Append(ClearItemLines)
            .Append(ItemLineMod);

        return new XElement($"{nameof(BillMod)}Rq")
            .AppendAttribute(requestID)
            .Append(rq)
            .Append(IncludeRetElement);
    }
}


