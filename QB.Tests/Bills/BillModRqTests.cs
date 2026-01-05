using QB.SDK;

namespace QB.Tests.Bills;

public class BillModRqTests(QBXMLSchemaFixture fixture) : IClassFixture<QBXMLSchemaFixture>
{
    [Fact]
    public void GeneratesCorrectRequestString()
    {
        // Arrange
        var addRq = new BillMod()
        {
            TxnID = "ABC123",
            EditSequence = "AAA",
            VendorRef = "Vendor",
            TxnDate = new DateOnly(2025, 12, 27),
            RefNumber = "12345",
            ItemLineMod =
            [
                new ItemLineMod() { TxnLineID = "AAA", ItemRef = "Materials", Desc = "12345 - Vendor", Amount = 100m, CustomerRef = "Customer", BillableStatus = BillableStatus.Billable }
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