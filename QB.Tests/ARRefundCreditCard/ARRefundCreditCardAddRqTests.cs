using QB.SDK;

namespace QB.Tests.ARRefundCreditCard;

public class ARRefundCreditCardAddRqTests(QBXMLSchemaFixture fixture) : IClassFixture<QBXMLSchemaFixture>
{
    [Fact]
    public void GeneratesCorrectRequestString()
    {
        // Arrange
        var addRq = new ARRefundCreditCardAdd()
        {
            CustomerRef = "Customer",
            ARAccountRef = "Accounts Receivable",
            TxnDate = new DateOnly(2025, 12, 31),
            RefundAppliedToTxnAdd =
            [
                new RefundAppliedToTxnAdd(){ RefundAmount = 100m , TxnID = "123abc" }
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