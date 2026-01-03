using System.Linq;

namespace QB.SDK;

public class SalesOrder
{
    public string? TxnID { get; set; }
    public DateTime? TimeCreated { get; set; }
    public DateTime? TimeModified { get; set; }
    public string? EditSequence { get; set; }
    public int? TxnNumber { get; set; }
    public ListRef? CustomerRef { get; set; }
    public ListRef? ClassRef { get; set; }
    public ListRef? TemplateRef { get; set; }
    public DateOnly? TxnDate { get; set; }
    public string? RefNumber { get; set; }
    public Address? BillAddress { get; set; }
    public Address? ShipAddress { get; set; }
    public string? PONumber { get; set; }
    public ListRef? TermsRef { get; set; }
    public DateOnly? DueDate { get; set; }
    public ListRef? SalesRepRef { get; set; }
    public string? FOB { get; set; }
    public DateOnly? ShipDate { get; set; }
    public ListRef? ShipMethodRef { get; set; }
    public decimal? Subtotal { get; set; }
    public ListRef? ItemSalesTaxRef { get; set; }
    public decimal? SalesTaxPercentage { get; set; }
    public decimal? SalesTaxTotal { get; set; }
    public decimal? TotalAmount { get; set; }
    public ListRef? CurrencyRef { get; set; }
    public float? ExchangeRate { get; set; }
    public decimal? TotalAmountInHomeCurrency { get; set; }
    public bool? IsManuallyClosed { get; set; }
    public bool? IsFullyInvoiced { get; set; }
    public string? Memo { get; set; }
    public ListRef? CustomerMsgRef { get; set; }
    public bool? IsToBePrinted { get; set; }
    public bool? IsToBeEmailed { get; set; }
    public bool? IsTaxIncluded { get; set; }
    public ListRef? CustomerSalesTaxCodeRef { get; set; }
    public string? Other { get; set; }
    public string? ExternalGUID { get; set; }
    public List<LinkedTxn>? LinkedTxn { get; set; }
    [XmlElement("SalesOrderLineRet", typeof(SalesOrderLine))]
    [XmlElement("SalesOrderLineGroupRet", typeof(SalesOrderLineGroup))]
    public List<SalesOrderLineBase>? SalesOrderLines { get; set; }
    public List<DataExt>? DataExtRet { get; set; }

    public SalesOrderMod ToMod()
    {
        // Check for null on required Mod properties.
        TxnID.ThrowIfNullOrWhiteSpace();
        EditSequence.ThrowIfNullOrWhiteSpace();

        // Generate the Mod request.
        return new SalesOrderMod()
        {
            TxnID = TxnID,
            EditSequence = EditSequence,
            CustomerRef = CustomerRef,
            ClassRef = ClassRef,
            TemplateRef = TemplateRef,
            TxnDate = TxnDate,
            RefNumber = RefNumber,
            BillAddress = BillAddress,
            ShipAddress = ShipAddress,
            PONumber = PONumber,
            TermsRef = TermsRef,
            DueDate = DueDate,
            SalesRepRef = SalesRepRef,
            FOB = FOB,
            ShipDate = ShipDate,
            ShipMethodRef = ShipMethodRef,
            ItemSalesTaxRef = ItemSalesTaxRef,
            IsManuallyClosed = IsManuallyClosed,
            Memo = Memo,
            CustomerMsgRef = CustomerMsgRef,
            IsToBePrinted = IsToBePrinted,
            IsToBeEmailed = IsToBeEmailed,
            IsTaxIncluded = IsTaxIncluded,
            CustomerSalesTaxCodeRef = CustomerSalesTaxCodeRef,
            Other = Other,
            ExchangeRate = ExchangeRate,
            SalesOrderLineMod = SalesOrderLines?.Select(l => l.ToMod()).ToList()
        };
    }
}