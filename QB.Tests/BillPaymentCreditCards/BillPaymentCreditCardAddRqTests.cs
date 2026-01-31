using QB.SDK;

namespace QB.Tests.BillPaymentCreditCards;

public class BillPaymentCreditCardAddRqTests(QBXMLSchemaFixture fixture) : IClassFixture<QBXMLSchemaFixture>
{
    [Fact]
    public void GeneratesCorrectRequestString()
    {
        // Arrange
        var addRq = new BillPaymentCreditCardAdd()
        {
            PayeeEntityRef = "Vendor",
            CreditCardAccountRef = "Visa",
            TxnDate = new DateOnly(2025, 12, 27),
            RefNumber = "12345",
            AppliedToTxnAdd = [
                new(){ TxnID = "ABC", DiscountAmount = 123.0m, DiscountAccountRef = "Discounts", PaymentAmount = 500m }
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