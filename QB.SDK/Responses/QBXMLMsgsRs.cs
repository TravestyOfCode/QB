namespace QB.SDK;

public class QBXMLMsgsRs
{
    [XmlElement(typeof(AccountAddRs))]
    [XmlElement(typeof(BillAddRs))]
    [XmlElement(typeof(BillModRs))]
    [XmlElement(typeof(BillQueryRs))]
    [XmlElement(typeof(BillPaymentCheckAddRs))]
    [XmlElement(typeof(InventoryAdjustmentAddRs))]
    [XmlElement(typeof(SalesOrderAddRs))]
    [XmlElement(typeof(SalesOrderModRs))]
    [XmlElement(typeof(SalesOrderQueryRs))]
    public List<QBResponse> Results { get; set; } = [];
}
