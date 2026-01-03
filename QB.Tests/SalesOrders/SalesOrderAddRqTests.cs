using QB.SDK;

namespace QB.Tests.SalesOrders;

public class SalesOrderAddRqTests(QBXMLSchemaFixture fixture) : IClassFixture<QBXMLSchemaFixture>
{
    [Fact]
    public void GeneratesCorrectRequestString()
    {
        // Arrange
        var addRq = new SalesOrderAdd()
        {
            CustomerRef = "TestCustomer",
            TxnDate = new DateOnly(2025, 12, 27),
            RefNumber = "12345",
            SalesOrderLineAdd =
            [
                new SalesOrderLineAdd(){ ItemRef = "Item", Amount = 100.0m },
                new SalesOrderLineGroupAdd() { ItemGroupRef = "A" }
            ]
        };

        var rq = new QBXMLRequest([addRq]);

        // Act
        string validationErrors = string.Empty;
        rq.ToXDocument().Validate(fixture.QBXMLSchema, (o, e) =>
        {
            validationErrors += e.Message + Environment.NewLine;
        });

        // Assert
        Assert.Equal<object>(string.Empty, validationErrors);
    }
}
