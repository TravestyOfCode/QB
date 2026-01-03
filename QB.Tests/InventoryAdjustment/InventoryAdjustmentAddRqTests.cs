using QB.SDK;

namespace QB.Tests.InventoryAdjustment;

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

    [Fact]
    public void LotNumberAdjustmentGeneratesCorrectRequestString()
    {
        // Arrange
        var addRq = new InventoryAdjustmentAdd()
        {
            AccountRef = "COGS",
            TxnDate = new DateOnly(2025, 12, 31),
            Memo = "Adjustment",
            InventoryAdjustmentLineAdd =
            [
                new LotNumberAdjustment(){ ItemRef = "A", LotNumber = "123", CountAdjustment = 0, InventorySiteLocationRef = "Location"}
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
    public void SerialNumberAdjustmentGeneratesCorrectRequestString()
    {
        // Arrange
        var addRq = new InventoryAdjustmentAdd()
        {
            AccountRef = "COGS",
            TxnDate = new DateOnly(2025, 12, 31),
            Memo = "Adjustment",
            InventoryAdjustmentLineAdd =
            [
                new SerialNumberAdjustment(){ ItemRef = "A", AddSerialNumber = "ABC123", InventorySiteLocationRef = "Location" },
                new SerialNumberAdjustment(){ ItemRef = "A", RemoveSerialNumber = "ABC123", InventorySiteLocationRef = "Location" },
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
