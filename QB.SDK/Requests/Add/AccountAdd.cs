namespace QB.SDK;

public class AccountAdd : QBRequest
{
    public string? Name { get; set; }
    public bool? IsActive { get; set; }
    public ListRef? ParentRef { get; set; }
    public AccountType? AccountType { get; set; }
    public string? AccountNumber { get; set; }
    public string? BankNumber { get; set; }
    public string? Desc { get; set; }
    public decimal? OpenBalance { get; set; }
    public DateOnly? OpenBalanceDate { get; set; }
    public ListRef? SalesTaxCodeRef { get; set; }
    public int? TaxLineID { get; set; }
    public ListRef? CurrencyRef { get; set; }
    public Account? Results { get; set; }

    internal override void ParseResponse(QBResponse response)
    {
        var rs = response as AccountAddRs ?? throw new InvalidOperationException("Unable to parse response as AccountAddRs.");
        StatusCode = rs.StatusCode;
        StatusMessage = rs.StatusMessage;
        StatusSeverity = rs.StatusSeverity;
        Results = rs.AccountRet;
    }

    public override XElement ToQBXML()
    {
        var rq = new XElement(nameof(AccountAdd))
            .Append(Name)
            .Append(IsActive)
            .Append(ParentRef)
            .Append(AccountType)
            .Append(AccountNumber)
            .Append(BankNumber)
            .Append(Desc)
            .Append(OpenBalance)
            .Append(OpenBalanceDate)
            .Append(SalesTaxCodeRef)
            .Append(TaxLineID)
            .Append(CurrencyRef)
            .Append(IncludeRetElement);

        return new XElement($"{nameof(AccountAdd)}Rq")
            .AppendAttribute(requestID)
            .Append(rq)
            .Append(IncludeRetElement);
    }
}
