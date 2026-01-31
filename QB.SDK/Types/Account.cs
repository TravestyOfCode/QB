namespace QB.SDK;

public class Account
{
    public string? ListID { get; set; }
    public DateTime? TimeCreated { get; set; }
    public DateTime? TimeModified { get; set; }
    public string? EditSequence { get; set; }
    public string? Name { get; set; }
    public string? FullName { get; set; }
    public bool? IsActive { get; set; }
    public ListRef? ParentRef { get; set; }
    public int? Sublevel { get; set; }
    public AccountType? AccountType { get; set; }
    public SpecialAccountType? SpecialAccountType { get; set; }
    public bool? IsTaxAccount { get; set; }
    public string? AccountNumber { get; set; }
    public string? BankNumber { get; set; }
    public string? Desc { get; set; }
    public decimal? Balance { get; set; }
    public decimal? TotalBalance { get; set; }
    public ListRef? SalesTaxCodeRef { get; set; }
    public TaxLineInfo? TaxLineInfoRet { get; set; }
    public CashFlowClassification? CashFlowClassification { get; set; }
    public ListRef? CurrencyRef { get; set; }
    public List<DataExt>? DataExtRet { get; set; }
}
