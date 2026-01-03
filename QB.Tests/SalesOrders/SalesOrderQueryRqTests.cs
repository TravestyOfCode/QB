using QB.SDK;

namespace QB.Tests.SalesOrders;

public class SalesOrderQueryRqTests(QBXMLSchemaFixture fixture) : IClassFixture<QBXMLSchemaFixture>
{
    [Fact]
    public void GeneratesCorrectRequestString()
    {
        // Arrange
        var rq = new SalesOrderQuery()
        {
            RefNumber = ["12345"],
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