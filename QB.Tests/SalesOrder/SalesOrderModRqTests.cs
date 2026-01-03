using QB.SDK;

namespace QB.Tests.SalesOrder;

public class SalesOrderModRqTests(QBXMLSchemaFixture fixture) : IClassFixture<QBXMLSchemaFixture>
{
    [Fact]
    public void GeneratesCorrectRequestString()
    {
        // Arrange
        var rq = new SalesOrderMod()
        {
            TxnID = "123ABC",
            EditSequence = "AAAAA",
            CustomerRef = "TestCustomer",
            TxnDate = new DateOnly(2025, 12, 27),
            RefNumber = "12345",
            SalesOrderLineMod =
            [
                new SalesOrderLineMod(){ TxnLineID = "ABC123", ItemRef = "Item", Amount = 100.0m },
                new SalesOrderLineGroupMod() { TxnLineID = "-1", ItemGroupRef = "A" }
            ]
        };

        var qbxml = new QBXMLRequest([rq]);

        // Act
        string validationErrors = string.Empty;
        qbxml.ToXDocument().Validate(fixture.QBXMLSchema, (o, e) =>
        {
            validationErrors += e.Message + Environment.NewLine;
        });

        // Assert
        Assert.Equal<object>(string.Empty, validationErrors);
    }
}