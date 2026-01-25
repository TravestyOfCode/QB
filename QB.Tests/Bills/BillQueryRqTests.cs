using QB.SDK;

namespace QB.Tests.Bills;

public class BillQueryRqTests(QBXMLSchemaFixture fixture) : IClassFixture<QBXMLSchemaFixture>
{
    [Fact]
    public void ThrowsIfTxnIDIsNotExclusive()
    {
        // Arrange
        var rq = new BillQuery() { TxnID = ["ABC"] };

        // Assert
        Assert.Throws<InvalidOperationException>(() => rq.RefNumber = ["123"]);
        Assert.Throws<InvalidOperationException>(() => rq.RefNumberCaseSensitive = ["123"]);
        Assert.Throws<InvalidOperationException>(() => rq.MaxReturned = 1);
        Assert.Throws<InvalidOperationException>(() => rq.ModifiedDateRangeFilter = new() { FromModifiedDate = DateTime.Now });
        Assert.Throws<InvalidOperationException>(() => rq.TxnDateRangeFilter = new() { DateMacro = DateMacro.All });
        Assert.Throws<InvalidOperationException>(() => rq.RefNumberFilter = RefNumberFilter.Contains("ABC"));
        Assert.Throws<InvalidOperationException>(() => rq.RefNumberRangeFilter = new RefNumberRangeFilter() { FromRefNumber = "ABC" });
        Assert.Throws<InvalidOperationException>(() => rq.EntityFilter = new() { FullName = ["ABC"] });
        Assert.Throws<InvalidOperationException>(() => rq.AccountFilter = new() { FullName = ["ABC"] });
    }

    [Fact]
    public void ThrowsIfRefNumberIsNotExclusive()
    {
        // Arrange
        var rq = new BillQuery() { RefNumber = ["ABC"] };

        // Assert
        Assert.Throws<InvalidOperationException>(() => rq.TxnID = ["123"]);
        Assert.Throws<InvalidOperationException>(() => rq.RefNumberCaseSensitive = ["123"]);
        Assert.Throws<InvalidOperationException>(() => rq.MaxReturned = 1);
        Assert.Throws<InvalidOperationException>(() => rq.ModifiedDateRangeFilter = new() { FromModifiedDate = DateTime.Now });
        Assert.Throws<InvalidOperationException>(() => rq.TxnDateRangeFilter = new() { DateMacro = DateMacro.All });
        Assert.Throws<InvalidOperationException>(() => rq.RefNumberFilter = RefNumberFilter.Contains("ABC"));
        Assert.Throws<InvalidOperationException>(() => rq.RefNumberRangeFilter = new RefNumberRangeFilter() { FromRefNumber = "ABC" });
        Assert.Throws<InvalidOperationException>(() => rq.EntityFilter = new() { FullName = ["ABC"] });
        Assert.Throws<InvalidOperationException>(() => rq.AccountFilter = new() { FullName = ["ABC"] });
    }

    [Fact]
    public void ThrowsIfRefNumberCaseSensitiveIsNotExclusive()
    {
        // Arrange
        var rq = new BillQuery() { RefNumberCaseSensitive = ["ABC"] };

        // Assert
        Assert.Throws<InvalidOperationException>(() => rq.TxnID = ["123"]);
        Assert.Throws<InvalidOperationException>(() => rq.RefNumber = ["123"]);
        Assert.Throws<InvalidOperationException>(() => rq.MaxReturned = 1);
        Assert.Throws<InvalidOperationException>(() => rq.ModifiedDateRangeFilter = new() { FromModifiedDate = DateTime.Now });
        Assert.Throws<InvalidOperationException>(() => rq.TxnDateRangeFilter = new() { DateMacro = DateMacro.All });
        Assert.Throws<InvalidOperationException>(() => rq.RefNumberFilter = RefNumberFilter.Contains("ABC"));
        Assert.Throws<InvalidOperationException>(() => rq.RefNumberRangeFilter = new RefNumberRangeFilter() { FromRefNumber = "ABC" });
        Assert.Throws<InvalidOperationException>(() => rq.EntityFilter = new() { FullName = ["ABC"] });
        Assert.Throws<InvalidOperationException>(() => rq.AccountFilter = new() { FullName = ["ABC"] });
    }

    [Fact]
    public void ThrowsIfMaxReturnedIsNotExclusive()
    {
        // Arrange
        var rq = new BillQuery() { MaxReturned = 1 };

        // Assert
        Assert.Throws<InvalidOperationException>(() => rq.TxnID = ["123"]);
        Assert.Throws<InvalidOperationException>(() => rq.RefNumberCaseSensitive = ["123"]);
        Assert.Throws<InvalidOperationException>(() => rq.RefNumber = ["1"]);
        Assert.Throws<InvalidOperationException>(() => rq.RefNumberFilter = RefNumberFilter.Contains("ABC"));
        Assert.Throws<InvalidOperationException>(() => rq.RefNumberRangeFilter = new RefNumberRangeFilter() { FromRefNumber = "ABC" });
    }

    [Fact]
    public void ThrowsIfModifiedDateRangeFilterIsNotExclusive()
    {
        // Arrange
        var rq = new BillQuery() { ModifiedDateRangeFilter = new() { FromModifiedDate = DateTime.Now } };

        // Assert
        Assert.Throws<InvalidOperationException>(() => rq.TxnID = ["123"]);
        Assert.Throws<InvalidOperationException>(() => rq.RefNumberCaseSensitive = ["123"]);
        Assert.Throws<InvalidOperationException>(() => rq.RefNumber = ["1"]);
        Assert.Throws<InvalidOperationException>(() => rq.TxnDateRangeFilter = new() { DateMacro = DateMacro.All });
        Assert.Throws<InvalidOperationException>(() => rq.RefNumberFilter = RefNumberFilter.Contains("ABC"));
        Assert.Throws<InvalidOperationException>(() => rq.RefNumberRangeFilter = new RefNumberRangeFilter() { FromRefNumber = "ABC" });
    }

    [Fact]
    public void ThrowsIfTxnDateRangeFilterIsNotExclusive()
    {
        // Arrange
        var rq = new BillQuery() { TxnDateRangeFilter = new() { DateMacro = DateMacro.All } };

        // Assert
        Assert.Throws<InvalidOperationException>(() => rq.TxnID = ["123"]);
        Assert.Throws<InvalidOperationException>(() => rq.RefNumberCaseSensitive = ["123"]);
        Assert.Throws<InvalidOperationException>(() => rq.RefNumber = ["1"]);
        Assert.Throws<InvalidOperationException>(() => rq.ModifiedDateRangeFilter = new() { FromModifiedDate = DateTime.Now });
        Assert.Throws<InvalidOperationException>(() => rq.RefNumberFilter = RefNumberFilter.Contains("ABC"));
        Assert.Throws<InvalidOperationException>(() => rq.RefNumberRangeFilter = new RefNumberRangeFilter() { FromRefNumber = "ABC" });
    }

    [Fact]
    public void ThrowsIfRefNumberFilterIsNotExclusive()
    {
        // Arrange
        var rq = new BillQuery() { RefNumberFilter = RefNumberFilter.Contains("ABC") };

        // Assert
        Assert.Throws<InvalidOperationException>(() => rq.TxnID = ["123"]);
        Assert.Throws<InvalidOperationException>(() => rq.RefNumberCaseSensitive = ["123"]);
        Assert.Throws<InvalidOperationException>(() => rq.MaxReturned = 1);
        Assert.Throws<InvalidOperationException>(() => rq.ModifiedDateRangeFilter = new() { FromModifiedDate = DateTime.Now });
        Assert.Throws<InvalidOperationException>(() => rq.TxnDateRangeFilter = new() { DateMacro = DateMacro.All });
        Assert.Throws<InvalidOperationException>(() => rq.RefNumber = ["ABC"]);
        Assert.Throws<InvalidOperationException>(() => rq.RefNumberRangeFilter = new RefNumberRangeFilter() { FromRefNumber = "ABC" });
    }

    [Fact]
    public void ThrowsIfRefNumberRangeFilterIsNotExclusive()
    {
        // Arrange
        var rq = new BillQuery() { RefNumberRangeFilter = new() { FromRefNumber = "ABC" } };

        // Assert
        Assert.Throws<InvalidOperationException>(() => rq.TxnID = ["123"]);
        Assert.Throws<InvalidOperationException>(() => rq.RefNumberCaseSensitive = ["123"]);
        Assert.Throws<InvalidOperationException>(() => rq.MaxReturned = 1);
        Assert.Throws<InvalidOperationException>(() => rq.ModifiedDateRangeFilter = new() { FromModifiedDate = DateTime.Now });
        Assert.Throws<InvalidOperationException>(() => rq.TxnDateRangeFilter = new() { DateMacro = DateMacro.All });
        Assert.Throws<InvalidOperationException>(() => rq.RefNumber = ["ABC"]);
        Assert.Throws<InvalidOperationException>(() => rq.RefNumberFilter = RefNumberFilter.Contains("ABC"));
    }

    [Fact]
    public void GeneratesCorrectRequestString()
    {
        // Arrange
        var rq = new BillQuery()
        {
            MaxReturned = 100,
            TxnDateRangeFilter = new() { DateMacro = DateMacro.All },
            EntityFilter = new() { FullName = ["Customer"] },
            AccountFilter = new() { FullName = ["AP"] },
            CurrencyFilter = new() { FullName = ["USD"] },
            IncludeLineItems = true,
            IncludeLinkedTxns = true,
            IncludeRetElement = ["TxnDate", "RefNumber", "CustomerRef"],
            OwnerID = ["0"]
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

    [Fact]
    public void SuccesfullyQueriesQB()
    {
        // Arrange
        var rq = new BillQuery()
        {
            MaxReturned = 10,
            metaData = MetaData.MetaDataAndResponseData
        };
        var qbConnection = new QBConnection(new Microsoft.Extensions.Logging.Abstractions.NullLogger<QBConnection>());

        // Act
        qbConnection.ProcessRequest(rq);

        // Assert
        Assert.Equal("0", rq.StatusCode);
        Assert.Equal(10, rq.ReturnedCount);
        Assert.NotNull(rq.Results);
    }
}