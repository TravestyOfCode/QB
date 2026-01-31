using QB.SDK;

namespace QB.Tests.Accounts;

public class AccountAddRqTests(QBXMLSchemaFixture fixture) : IClassFixture<QBXMLSchemaFixture>
{
    [Fact]
    public void GeneratesCorrectRequestString()
    {
        // Arrange
        var addRq = new AccountAdd()
        {
            Name = "Customer",
            AccountType = AccountType.Bank,
            AccountNumber = "1234",
            OpenBalance = 123.0m,
            OpenBalanceDate = DateOnly.FromDateTime(DateTime.Now)
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
