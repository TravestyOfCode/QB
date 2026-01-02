using QB.SDK;
using System.Xml.Schema;

namespace QB.Tests;

public class InventoryAdjustmentAddRqTests(QBXMLSchemaFixture fixture) : IClassFixture<QBXMLSchemaFixture>
{
    [Fact]
    public void QuantityAdjustmentGeneratesCorrectRequestString()
    {
        // Arrange
        var addRq = new InventoryAdjustmentAdd()
        {
            AccountRef = "COGS",
            TxnDate = new DateOnly(2025, 12, 31),
            Memo = "Adjustment",
            InventoryAdjustmentLineAdd =
            [
                new QuantityAdjustment(){ ItemRef = "A", NewQuantity  = 10 },
                new ValueAdjustment(){ItemRef = "B", NewValue = 100m }
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

    [Fact]
    public void ValueAdjustmentGeneratesCorrectRequestString()
    {
        // Arrange
        var addRq = new InventoryAdjustmentAdd()
        {
            AccountRef = "COGS",
            TxnDate = new DateOnly(2025, 12, 31),
            Memo = "Adjustment",
            InventoryAdjustmentLineAdd =
            [
                new ValueAdjustment() { ItemRef = "B", NewValue = 100m }
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
