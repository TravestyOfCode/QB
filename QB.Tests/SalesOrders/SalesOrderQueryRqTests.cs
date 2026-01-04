using QB.SDK;

namespace QB.Tests.SalesOrders;

public class SalesOrderQueryRqTests(QBXMLSchemaFixture fixture) : IClassFixture<QBXMLSchemaFixture>
{
    [Fact]
    public void ThrowsIfTxnIDIsNotExclusive()
    {
        // Arrange
        var rq = new SalesOrderQuery() { TxnID = ["ABC"] };

        // Assert
        Assert.Throws<InvalidOperationException>(() => rq.RefNumber = ["123"]);
        Assert.Throws<InvalidOperationException>(() => rq.RefNumberCaseSensitive = ["123"]);
        Assert.Throws<InvalidOperationException>(() => rq.MaxReturned = 1);
        Assert.Throws<InvalidOperationException>(() => rq.ModifiedDateRangeFilter = new() { FromModifiedDate = DateTime.Now });
        Assert.Throws<InvalidOperationException>(() => rq.TxnDateRangeFilter = new() { DateMacro = DateMacro.All });
        Assert.Throws<InvalidOperationException>(() => rq.RefNumberFilter = RefNumberFilter.Contains("ABC"));
        Assert.Throws<InvalidOperationException>(() => rq.RefNumberRangeFilter = new RefNumberRangeFilter() { FromRefNumber = "ABC" });
        Assert.Throws<InvalidOperationException>(() => rq.EntityFilter = new() { FullName = ["ABC"] });
    }

    [Fact]
    public void ThrowsIfRefNumberIsNotExclusive()
    {
        // Arrange
        var rq = new SalesOrderQuery() { RefNumber = ["ABC"] };

        // Assert
        Assert.Throws<InvalidOperationException>(() => rq.TxnID = ["123"]);
        Assert.Throws<InvalidOperationException>(() => rq.RefNumberCaseSensitive = ["123"]);
        Assert.Throws<InvalidOperationException>(() => rq.MaxReturned = 1);
        Assert.Throws<InvalidOperationException>(() => rq.ModifiedDateRangeFilter = new() { FromModifiedDate = DateTime.Now });
        Assert.Throws<InvalidOperationException>(() => rq.TxnDateRangeFilter = new() { DateMacro = DateMacro.All });
        Assert.Throws<InvalidOperationException>(() => rq.RefNumberFilter = RefNumberFilter.Contains("ABC"));
        Assert.Throws<InvalidOperationException>(() => rq.RefNumberRangeFilter = new RefNumberRangeFilter() { FromRefNumber = "ABC" });
        Assert.Throws<InvalidOperationException>(() => rq.EntityFilter = new() { FullName = ["ABC"] });
    }

    [Fact]
    public void ThrowsIfRefNumberCaseSensitiveIsNotExclusive()
    {
        // Arrange
        var rq = new SalesOrderQuery() { RefNumberCaseSensitive = ["ABC"] };

        // Assert
        Assert.Throws<InvalidOperationException>(() => rq.TxnID = ["123"]);
        Assert.Throws<InvalidOperationException>(() => rq.RefNumber = ["123"]);
        Assert.Throws<InvalidOperationException>(() => rq.MaxReturned = 1);
        Assert.Throws<InvalidOperationException>(() => rq.ModifiedDateRangeFilter = new() { FromModifiedDate = DateTime.Now });
        Assert.Throws<InvalidOperationException>(() => rq.TxnDateRangeFilter = new() { DateMacro = DateMacro.All });
        Assert.Throws<InvalidOperationException>(() => rq.RefNumberFilter = RefNumberFilter.Contains("ABC"));
        Assert.Throws<InvalidOperationException>(() => rq.RefNumberRangeFilter = new RefNumberRangeFilter() { FromRefNumber = "ABC" });
        Assert.Throws<InvalidOperationException>(() => rq.EntityFilter = new() { FullName = ["ABC"] });
    }

    [Fact]
    public void ThrowsIfMaxReturnedIsNotExclusive()
    {
        // Arrange
        var rq = new SalesOrderQuery() { MaxReturned = 1 };

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
        var rq = new SalesOrderQuery() { ModifiedDateRangeFilter = new() { FromModifiedDate = DateTime.Now } };

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
        var rq = new SalesOrderQuery() { TxnDateRangeFilter = new() { DateMacro = DateMacro.All } };

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
        var rq = new SalesOrderQuery() { RefNumberFilter = RefNumberFilter.Contains("ABC") };

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
        var rq = new SalesOrderQuery() { RefNumberRangeFilter = new() { FromRefNumber = "ABC" } };

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
        var rq = new SalesOrderQuery()
        {
            MaxReturned = 100,
            TxnDateRangeFilter = new() { DateMacro = DateMacro.All },
            EntityFilter = new() { FullName = ["Customer"] },
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
}