namespace QB.SDK;

public class Customer
{
    public string? ListID { get; set; }
    public DateTime? TimeCreated { get; set; }
    public DateTime? TimeModified { get; set; }
    public string? EditSequence { get; set; }
    public string? Name { get; set; }
    public string? FullName { get; set; }
    public bool? IsActive { get; set; }
    public ListRef? ClassRef { get; set; }
    public ListRef? ParentRef { get; set; }
    public int? Sublevel { get; set; }
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
    public List<Contact>? ContactsRet { get; set; }
    public ListRef? CustomerTypeRef { get; set; }
    public ListRef? TermsRef { get; set; }
    public ListRef? SalesRepRef { get; set; }
    public decimal? Balance { get; set; }
    public decimal? TotalBalance { get; set; }
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
    public List<AdditionalNote>? AdditionalNotesRet { get; set; }
    public PreferredDeliveryMethod? PreferredDeliveryMethod { get; set; }
    public ListRef? PriceLevelRef { get; set; }
    public string? ExternalGUID { get; set; }
    public string? TaxRegistrationNumber { get; set; }
    public ListRef? CurrencyRef { get; set; }
    public List<DataExt>? DataExtRet { get; set; }

    public CustomerMod ToMod()
    {
        // Check for null on required Mod properties.
        ListID.ThrowIfNullOrWhiteSpace();
        EditSequence.ThrowIfNullOrWhiteSpace();

        // Generate the Mod request.
        return new CustomerMod()
        {
            ListID = ListID,
            EditSequence = EditSequence,
            Name = Name,
            IsActive = IsActive,
            ClassRef = ClassRef,
            ParentRef = ParentRef,
            CompanyName = CompanyName,
            Salutation = Salutation,
            FirstName = FirstName,
            MiddleName = MiddleName,
            LastName = LastName,
            JobTitle = JobTitle,
            BillAddress = BillAddress,
            ShipAddress = ShipAddress,
            ShipToAddress = ShipToAddress,
            Phone = Phone,
            AltPhone = AltPhone,
            Fax = Fax,
            Email = Email,
            Cc = Cc,
            Contact = Contact,
            AltContact = AltContact,
            AdditionalContactRef = AdditionalContactRef,
            ContactsMod = ContactsRet,
            CustomerTypeRef = CustomerTypeRef,
            TermsRef = TermsRef,
            SalesRepRef = SalesRepRef,
            SalesTaxCodeRef = SalesTaxCodeRef,
            ItemSalesTaxRef = ItemSalesTaxRef,
            SalesTaxCountry = SalesTaxCountry,
            ResaleNumber = ResaleNumber,
            AccountNumber = AccountNumber,
            CreditLimit = CreditLimit,
            PreferredPaymentMethodRef = PreferredPaymentMethodRef,
            CreditCardInfo = CreditCardInfo,
            JobStatus = JobStatus,
            JobStartDate = JobStartDate,
            JobProjectedEndDate = JobProjectedEndDate,
            JobEndDate = JobEndDate,
            JobDesc = JobDesc,
            JobTypeRef = JobTypeRef,
            Notes = Notes,
            AdditionalNotesMod = AdditionalNotesRet,
            PreferredDeliveryMethod = PreferredDeliveryMethod,
            PriceLevelRef = PriceLevelRef,
            TaxRegistrationNumber = TaxRegistrationNumber,
            CurrencyRef = CurrencyRef
        };
    }
}