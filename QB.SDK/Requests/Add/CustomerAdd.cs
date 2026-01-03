namespace QB.SDK;

public class CustomerAdd : QBRequest
{
    public string? Name { get; set; }
    public bool? IsActive { get; set; }
    public ListRef? ClassRef { get; set; }
    public ListRef? ParentRef { get; set; }
    public string? CompanyName { get; set; }
    public string? Salutation { get; set; }
    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }
    public string? JobTitle { get; set; }
    public Address? BillAddress { get; set; }
    public Address? ShipAddress { get; set; }
    public List<ShipToAddress>? ShipToAddress { get; set; }
    public string? Phone { get; set; }
    public string? AltPhone { get; set; }
    public string? Fax { get; set; }
    public string? Email { get; set; }
    public string? Cc { get; set; }
    public string? Contact { get; set; }
    public string? AltContact { get; set; }
    public List<AdditionalContact>? AdditionalContactRef { get; set; }
    public List<Contact>? Contacts { get; set; }
    public ListRef? CustomerTypeRef { get; set; }
    public ListRef? TermsRef { get; set; }
    public ListRef? SalesRepRef { get; set; }
    public decimal? OpenBalance { get; set; }
    public DateOnly? OpenBalanceDate { get; set; }
    public ListRef? SalesTaxCodeRef { get; set; }
    public ListRef? ItemSalesTaxRef { get; set; }
    public SalesTaxCountry? SalesTaxCountry { get; set; }
    public string? ResaleNumber { get; set; }
    public string? AccountNumber { get; set; }
    public decimal? CreditLimit { get; set; }
    public ListRef? PreferredPaymentMethodRef { get; set; }
    public CreditCardInfo? CreditCardInfo { get; set; }
    public JobStatus? JobStatus { get; set; }
    public DateOnly? JobStartDate { get; set; }
    public DateOnly? JobProjectedEndDate { get; set; }
    public DateOnly? JobEndDate { get; set; }
    public string? JobDesc { get; set; }
    public ListRef? JobTypeRef { get; set; }
    public string? Notes { get; set; }
    public List<AdditionalNote>? AdditionalNotes { get; set; }
    public PreferredDeliveryMethod? PreferredDeliveryMethod { get; set; }
    public ListRef? PriceLevelRef { get; set; }
    public string? ExternalGUID { get; set; }
    public string? TaxRegistrationNumber { get; set; }
    public ListRef? CurrencyRef { get; set; }

    public override XElement ToQBXML()
    {
        var rq = new XElement(nameof(CustomerAdd))
            .Append(Name)
            .Append(IsActive)
            .Append(ClassRef)
            .Append(ParentRef)
            .Append(CompanyName)
            .Append(Salutation)
            .Append(FirstName)
            .Append(MiddleName)
            .Append(LastName)
            .Append(JobTitle)
            .Append(BillAddress)
            .Append(ShipAddress)
            .Append(ShipToAddress)
            .Append(Phone)
            .Append(AltPhone)
            .Append(Fax)
            .Append(Email)
            .Append(Cc)
            .Append(Contact)
            .Append(AltContact)
            .Append(AdditionalContactRef)
            .Append(Contacts)
            .Append(CustomerTypeRef)
            .Append(TermsRef)
            .Append(SalesRepRef)
            .Append(OpenBalance)
            .Append(OpenBalanceDate)
            .Append(SalesTaxCodeRef)
            .Append(ItemSalesTaxRef)
            .Append(SalesTaxCountry)
            .Append(ResaleNumber)
            .Append(AccountNumber)
            .Append(CreditLimit)
            .Append(PreferredPaymentMethodRef)
            .Append(CreditCardInfo)
            .Append(JobStatus)
            .Append(JobStartDate)
            .Append(JobProjectedEndDate)
            .Append(JobEndDate)
            .Append(JobDesc)
            .Append(JobTypeRef)
            .Append(Notes)
            .Append(AdditionalNotes)
            .Append(PreferredDeliveryMethod)
            .Append(PriceLevelRef)
            .Append(ExternalGUID)
            .Append(TaxRegistrationNumber)
            .Append(CurrencyRef);

        return new XElement($"{nameof(CustomerAdd)}Rq")
            .AppendAttribute(requestID)
            .Append(rq)
            .Append(IncludeRetElement);
    }
}