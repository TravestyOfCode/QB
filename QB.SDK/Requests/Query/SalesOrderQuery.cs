using System.Linq;

namespace QB.SDK;

public class SalesOrderQuery : QueryRq, IQBXML
{
    public List<string>? TxnID { get; set; }
    public List<string>? RefNumber { get; set; }
    public List<string>? RefNumberCaseSensitive { get; set; }
    public DateTimeRangeFilter? ModifiedDateRangeFilter { get; set; }
    public DateRangeFilter? TxnDateRangeFilter { get; set; }
    public ParentListFilter? EntityFilter { get; set; }
    public StringFilter? RefNumberFilter { get; set; }
    public StringRangeFilter? RefNumberRangeFilter { get; set; }
    public ListFilter? CurrencyFilter { get; set; }
    public bool? IncludeLineItems { get; set; }
    public bool? IncludeLinkedTxns { get; set; }
    public List<string>? OwnerID { get; set; }

    public override XElement ToQBXML()
    {
        return new XElement($"{nameof(SalesOrderQuery)}Rq")
            .AppendAttribute(requestID)
            .AppendAttribute(metaData)
            .AppendAttribute(iterator)
            .AppendAttribute(iteratorID)
            .Append(TxnID)
            .Append(RefNumber)
            .Append(RefNumberCaseSensitive)
            .Append(MaxReturned)
            .Append(ModifiedDateRangeFilter)
            .Append(TxnDateRangeFilter)
            .Append(EntityFilter)
            .Append(RefNumberFilter)
            .Append(RefNumberRangeFilter)
            .Append(CurrencyFilter)
            .Append(IncludeLineItems)
            .Append(IncludeLinkedTxns)
            .Append(IncludeRetElement)
            .Append(OwnerID);
    }

    public static SalesOrderQuery ByRefNumbers(IEnumerable<string> refNumbers, bool isCaseSensitive = true)
    {
        return isCaseSensitive ? new() { RefNumberCaseSensitive = refNumbers.ToList() } : new() { RefNumber = refNumbers.ToList() };
    }

    public static SalesOrderQuery ByRefNumber(string refNumber, bool isCaseSensitive = true)
    {
        return isCaseSensitive ? new() { RefNumberCaseSensitive = [refNumber] } : new() { RefNumber = [refNumber] };
    }

    public static SalesOrderQuery ByTxnIDs(IEnumerable<string> txnIDs)
    {
        return new() { TxnID = [.. txnIDs] };
    }

    public static SalesOrderQuery ByTxnID(string txnID)
    {
        return new() { TxnID = [txnID] };
    }
}

public static class SalesOrderQueryExtensions
{
    public static QBXMLResponse FindSalesOrdersByRefNumber(this QBConnection qbConnection, string refNumber, bool isCaseSensitive = true)
    {
        // Generate the request using the static constructor
        var rq = new QBXMLRequest([SalesOrderQuery.ByRefNumber(refNumber, isCaseSensitive)]);

        // Process the request and send the result.
        return qbConnection.ProcessRequest(rq);
    }

    public static QBXMLResponse FindSalesOrdersByRefNumbers(this QBConnection qbConnection, IEnumerable<string> refNumbers, bool isCaseSensitive = true)
    {
        // Generate the request using the static constructor
        var rq = new QBXMLRequest([SalesOrderQuery.ByRefNumbers(refNumbers, isCaseSensitive)]);

        // Process the request and send the result.
        return qbConnection.ProcessRequest(rq);
    }

    public static SalesOrder GetSalesOrderByTxnID(this QBConnection qbConnection, string txnID)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(nameof(txnID));

        // Generate the request using the static constructor.
        var request = new QBXMLRequest([SalesOrderQuery.ByTxnID(txnID)]);

        // Process the request.
        var response = qbConnection.ProcessRequest(request);

        // Check if we have a successful response.
        var soResponse = response.QBXMLMsgsRs?.Results?[0] as SalesOrderQueryRs;
        if (soResponse == null || soResponse.StatusCode != "0")
        {
            throw new KeyNotFoundException($"A SalesOrder with TxnID '{txnID}' was not found. The error was: {soResponse?.StatusMessage}");
        }

        // Return the SalesOrder if we have only one, otherwise throw an exception.
        return soResponse.Results?.Count switch
        {
            null => throw new InvalidOperationException("The SalesOrder response list was null."),
            0 => throw new InvalidOperationException("The SalesOrder response list was empty."),
            1 => soResponse.Results[0],
            _ => throw new InvalidOperationException($"The SalesOrder response list contains more than one SalesOrder with TxnID '{txnID}'.")
        };
    }

    public static SalesOrder GetSalesOrderByRefNumber(this QBConnection qbConnection, string refNumber)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(nameof(refNumber));

        // Generate the request using the static constructor.
        var request = new QBXMLRequest([SalesOrderQuery.ByRefNumber(refNumber)]);

        // Process the request.
        var response = qbConnection.ProcessRequest(request);

        // Check if we have a successful response.
        var soResponse = response.QBXMLMsgsRs?.Results?[0] as SalesOrderQueryRs;
        if (soResponse == null || soResponse.StatusCode != "0")
        {
            throw new KeyNotFoundException($"A SalesOrder with RefNumber '{refNumber}' was not found. The error was: {soResponse?.StatusMessage}");
        }

        // Return the SalesOrder if we have only one, otherwise throw an exception.
        return soResponse.Results?.Count switch
        {
            null => throw new InvalidOperationException("The SalesOrder response list was null."),
            0 => throw new InvalidOperationException("The SalesOrder response list was empty."),
            1 => soResponse.Results[0],
            _ => throw new InvalidOperationException($"The SalesOrder response list contains more than one SalesOrder with RefNumber '{refNumber}'.")
        };
    }
}