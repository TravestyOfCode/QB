using System.Xml.Schema;

namespace QB.Tests;

public class QBXMLSchemaFixture
{
    public XmlSchemaSet QBXMLSchema { get; }

    public QBXMLSchemaFixture()
    {
        QBXMLSchema = new XmlSchemaSet();
        QBXMLSchema.Add("", "C:\\Program Files\\Intuit\\IDN\\Common\\tools\\validator\\qbxmltypes160.xsd");
        QBXMLSchema.Add("", "C:\\Program Files\\Intuit\\IDN\\Common\\tools\\validator\\qbxml160.xsd");
        QBXMLSchema.Add("", "C:\\Program Files\\Intuit\\IDN\\Common\\tools\\validator\\qbxmlops160.xsd");
        QBXMLSchema.Add("", "C:\\Program Files\\Intuit\\IDN\\Common\\tools\\validator\\qbxmlso160.xsd");
    }
}
