namespace QB.SDK;

public class QBXMLMsgsRs
{
    [XmlElement(typeof(CreditCardChargeAddRs))]
    [XmlElement(typeof(BillAddRs))]
    [XmlElement(typeof(InventoryAdjustmentAddRs))]
    [XmlElement(typeof(SalesOrderAddRs))]
    [XmlElement(typeof(SalesOrderModRs))]
    public List<QBResponse>? Results { get; set; }
}
