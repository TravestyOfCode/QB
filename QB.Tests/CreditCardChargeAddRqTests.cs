using QB.SDK;
using System.Xml.Schema;

namespace QB.Tests;

public class CreditCardChargeAddRqTests(QBXMLSchemaFixture fixture) : IClassFixture<QBXMLSchemaFixture>
{
    [Fact]
    public void GeneratesCorrectRequestString()
    {
        // Arrange
        var addRq = new CreditCardChargeAdd()
        {
            AccountRef = "MasterCard",
            PayeeEntityRef = "Dell",
            TxnDate = new DateOnly(2025, 12, 27),
            RefNumber = string.Empty,
            ExpenseLines =
            [
                new ExpenseLineAdd(){ AccountRef = "Computer Equipment", Amount = 1304.55m, Memo ="New laptop for office." }
            ],
            ItemLines =
            [
                new ItemLineAdd(){ ItemRef = "TestItem", Amount = 123.04m, Quantity = 2 },
                new ItemGroupLineAdd() {ItemGroupRef = "GroupItem", Quantity = 1 }
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