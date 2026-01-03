using QB.SDK;

namespace QB.Tests.SalesOrders;

public class SalesOrderTests(QBXMLSchemaFixture fixture) : IClassFixture<QBXMLSchemaFixture>
{
    [Fact]
    public void ToModThrowsArgumentExceptionOnNullTxnID()
    {
        var so = new SalesOrder();

        Assert.Throws<ArgumentException>(() => so.ToMod());
    }

    [Fact]
    public void ToModThrowsArgumentExceptionOnEmptyTxnID()
    {
        var so = new SalesOrder() { TxnID = string.Empty };

        Assert.Throws<ArgumentException>(() => so.ToMod());
    }

    [Fact]
    public void ToModThrowsArgumentExceptionOnNullEditSequence()
    {
        var so = new SalesOrder();

        Assert.Throws<ArgumentException>(() => so.ToMod());
    }

    [Fact]
    public void ToModThrowsArgumentExceptionOnEmptyEditSequence()
    {
        var so = new SalesOrder() { EditSequence = string.Empty };

        Assert.Throws<ArgumentException>(() => so.ToMod());
    }

    [Fact]
    public void ToModGeneratesCorrectRequestString()
    {
        // Arrange
        var so = new SalesOrder()
        {
            TxnID = "ABC123",
            EditSequence = "AAAA-BBBBB",
            CustomerRef = "Customer",
            TxnDate = new DateOnly(2025, 12, 31),
            SalesOrderLines =
            [
                new SalesOrderLine(){ TxnLineID = "AAA", ItemRef = "OH", Desc = "This is a description", Amount = 100m },
                new SalesOrderLineGroup(){ TxnLineID = "BBB", ItemGroupRef = "A", SalesOrderLineRet =
                [
                    new SalesOrderLine(){ TxnLineID = "AAA", ItemRef = "OH", Desc = "This is a description", Amount = 100m },
                    new SalesOrderLine(){ TxnLineID = "AAA", ItemRef = "OH", Desc = "This is a description", Amount = 100m },
                    new SalesOrderLine(){ TxnLineID = "AAA", ItemRef = "OH", Desc = "This is a description", Amount = 100m }
                ]}
            ]
        };

        var qbxml = new QBXMLRequest([so.ToMod()]);

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
