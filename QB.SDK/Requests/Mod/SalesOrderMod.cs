
using System.Linq;

namespace QB.SDK;

public class SalesOrderMod : QBRequest
{
    public required string TxnID { get; set; }
    public required string EditSequence { get; set; }
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
    public ListRef? ItemSalesTaxRef { get; set; }
    public bool? IsManuallyClosed { get; set; }
    public string? Memo { get; set; }
    public ListRef? CustomerMsgRef { get; set; }
    public bool? IsToBePrinted { get; set; }
    public bool? IsToBeEmailed { get; set; }
    public bool? IsTaxIncluded { get; set; }
    public ListRef? CustomerSalesTaxCodeRef { get; set; }
    public string? Other { get; set; }
    public float? ExchangeRate { get; set; }
    public List<SalesOrderLineModBase>? SalesOrderLineMod { get; set; }

    /// <summary>
    /// Converts the object to a XElement represenation according to the QBXML specification.
    /// </summary>
    /// <returns>A XElement respresentation of the object.</returns>
    public override XElement ToQBXML()
    {
        var rq = new XElement(nameof(SalesOrderMod))
            .Append(TxnID)
            .Append(EditSequence)
            .Append(CustomerRef)
            .Append(ClassRef)
            .Append(TemplateRef)
            .Append(TxnDate)
            .Append(RefNumber)
            .Append(BillAddress)
            .Append(ShipAddress)
            .Append(PONumber)
            .Append(TermsRef)
            .Append(DueDate)
            .Append(SalesRepRef)
            .Append(FOB)
            .Append(ShipDate)
            .Append(ShipMethodRef)
            .Append(ItemSalesTaxRef)
            .Append(IsManuallyClosed)
            .Append(Memo)
            .Append(CustomerMsgRef)
            .Append(IsToBePrinted)
            .Append(IsToBeEmailed)
            .Append(IsTaxIncluded)
            .Append(CustomerSalesTaxCodeRef)
            .Append(Other)
            .Append(ExchangeRate)
            .Append(SalesOrderLineMod);

        return new XElement($"{nameof(SalesOrderMod)}Rq")
            .AppendAttribute(requestID)
            .Append(rq)
            .Append(IncludeRetElement);
    }
}

public static class SalesOrderModExtensions
{
    public static SalesOrderMod ToMod(SalesOrder so)
    {
        // Null checks for requried fields.
        ArgumentNullException.ThrowIfNull(so);
        so.TxnID.ThrowIfNullOrWhiteSpace();
        so.EditSequence.ThrowIfNullOrWhiteSpace();

        return new SalesOrderMod()
        {
            TxnID = so.TxnID,
            EditSequence = so.EditSequence,
            CustomerRef = so.CustomerRef,
            ClassRef = so.ClassRef,
            TemplateRef = so.TemplateRef,
            TxnDate = so.TxnDate,
            RefNumber = so.RefNumber,
            BillAddress = so.BillAddress,
            ShipAddress = so.ShipAddress,
            PONumber = so.PONumber,
            TermsRef = so.TermsRef,
            DueDate = so.DueDate,
            SalesRepRef = so.SalesRepRef,
            FOB = so.FOB,
            ShipDate = so.ShipDate,
            ShipMethodRef = so.ShipMethodRef,
            ItemSalesTaxRef = so.ItemSalesTaxRef,
            IsManuallyClosed = so.IsManuallyClosed,
            Memo = so.Memo,
            CustomerMsgRef = so.CustomerMsgRef,
            IsToBePrinted = so.IsToBePrinted,
            IsToBeEmailed = so.IsToBeEmailed,
            IsTaxIncluded = so.IsTaxIncluded,
            CustomerSalesTaxCodeRef = so.CustomerSalesTaxCodeRef,
            Other = so.Other,
            ExchangeRate = so.ExchangeRate,
            SalesOrderLineMod = so.SalesOrderLines?.Select(l => l.ToMod()).ToList(),
        };
    }
}