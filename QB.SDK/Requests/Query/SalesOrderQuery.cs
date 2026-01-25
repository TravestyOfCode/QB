using System.Linq;

namespace QB.SDK;

public class SalesOrderQuery : TxnNoAccountQuery
{
    internal override void ParseResponse(QBResponse response)
    {
        var rs = response as SalesOrderQueryRs ?? throw new InvalidOperationException("Unable to parse response as SalesOrderQueryRs.");
        StatusCode = rs.StatusCode;
        StatusMessage = rs.StatusMessage;
        StatusSeverity = rs.StatusSeverity;
        iteratorID = rs.IteratorID;
        ReturnedCount = int.TryParse(rs.ReturnedCount, out var retCount) ? retCount : -1;
        RemainingCount = int.TryParse(rs.RemainingCount, out var remCount) ? remCount : -1;
        Results = rs.Results;
    }

    public List<SalesOrder>? Results { get; private set; }

    /// <summary>
    /// Converts the object to a XElement represenation according to the QBXML specification.
    /// </summary>
    /// <returns>A XElement respresentation of the object.</returns>
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

    /// <summary>
    /// Generates a SalesOrderQuery request filtering by a list of RefNumbers.
    /// </summary>
    /// <param name="refNumbers">The list of RefNumbers to use for filtering.</param>
    /// <param name="isCaseSensitive">Determines if the filter list is case sensitive. Recommend to leave as true (default) if case sensitive does not matter.</param>
    /// <returns>A SalesOrderQuery request.</returns>
    public static SalesOrderQuery ByRefNumbers(IEnumerable<string> refNumbers, bool isCaseSensitive = true)
    {
        return isCaseSensitive ? new() { RefNumberCaseSensitive = refNumbers.ToList() } : new() { RefNumber = refNumbers.ToList() };
    }

    /// <summary>
    /// Generates a SalesOrderQuery request filtering by a single RefNumber.
    /// </summary>
    /// <param name="refNumbers">The RefNumber to use for filtering.</param>
    /// <param name="isCaseSensitive">Determines if the RefNumber is case sensitive. Recommend to leave as true (default) if case sensitive does not matter.</param>
    /// <returns>A SalesOrderQuery request.</returns>
    public static SalesOrderQuery ByRefNumber(string refNumber, bool isCaseSensitive = true)
    {
        return isCaseSensitive ? new() { RefNumberCaseSensitive = [refNumber] } : new() { RefNumber = [refNumber] };
    }

    /// <summary>
    /// Generates a SalesOrderQuery request filtering by a list of TxnIDs.
    /// </summary>
    /// <param name="refNumbers">The list of TxnIDs to use for filtering.</param>
    /// <returns>A SalesOrderQuery request.</returns>
    public static SalesOrderQuery ByTxnIDs(IEnumerable<string> txnIDs)
    {
        return new() { TxnID = [.. txnIDs] };
    }

    /// <summary>
    /// Generates a SalesOrderQuery request filtering by a specific TxnIDs.
    /// </summary>
    /// <param name="refNumbers">A TxnIDs to use for filtering.</param>
    /// <returns>A SalesOrderQuery request.</returns>
    public static SalesOrderQuery ByTxnID(string txnID)
    {
        return new() { TxnID = [txnID] };
    }
}

public static class SalesOrderQueryExtensions
{
    /// <summary>
    /// Queries QuickBooks for a single SalesOrder with a specific RefNumber.
    /// </summary>
    /// <param name="qbConnection">The QB Connection to execute the query.</param>
    /// <param name="refNumber">The specific RefNumber to query for.</param>
    /// <param name="isCaseSensitive">Determines if the RefNumber is case sensitive. Recommend to leave as true (default) if case sensitive does not matter.</param>
    /// <returns>The SalesOrder with the requested RefNumber if it was found, otherwise null.</returns>
    public static SalesOrder? FindSalesOrdersByRefNumber(this QBConnection qbConnection, string refNumber, bool isCaseSensitive = true)
    {
        // Generate the request using the static constructor
        var request = new QBXMLRequest([SalesOrderQuery.ByRefNumber(refNumber, isCaseSensitive)]);

        // Process the request.
        var response = qbConnection.ProcessRequest(request);

        // Check if we have a successful response.
        var soResponse = response.QBXMLMsgsRs?.Results?[0] as SalesOrderQueryRs ?? throw new QBSDKException();

        // Found result: "0", Not Found result: "500"
        if (soResponse.StatusCode == "0" || soResponse.StatusCode == "500")
        {
            return soResponse.Results?[0];
        }

        // Some other error occured.
        throw new QBSDKException(soResponse);
    }

    /// <summary>
    /// Queries QuickBooks for a single SalesOrder with a specific RefNumber.
    /// </summary>
    /// <param name="qbConnection">The QB Connection to execute the query.</param>
    /// <param name="refNumbers">The list of RefNumbers to query for.</param>
    /// <param name="isCaseSensitive">Determines if the RefNumbers are case sensitive. Recommend to leave as true (default) if case sensitive does not matter.</param>
    /// <returns>A List<SalesOrder> with the requested RefNumbers if they were found, otherwise null.</returns>
    public static List<SalesOrder>? FindSalesOrdersByRefNumbers(this QBConnection qbConnection, IEnumerable<string> refNumbers, bool isCaseSensitive = true)
    {
        // Generate the request using the static constructor
        var request = new QBXMLRequest([SalesOrderQuery.ByRefNumbers(refNumbers, isCaseSensitive)]);

        // Process the request.
        var response = qbConnection.ProcessRequest(request);

        // Check if we have a successful response.
        var soResponse = response.QBXMLMsgsRs?.Results?[0] as SalesOrderQueryRs ?? throw new QBSDKException();

        // Found result: "0", Not Found result: "500"
        if (soResponse.StatusCode == "0" || soResponse.StatusCode == "500")
        {
            return soResponse.Results;
        }

        // Some other error occured.
        throw new QBSDKException(soResponse);
    }

    /// <summary>
    /// Queries QuickBooks for a single SalesOrder with a specific TxnID.
    /// </summary>
    /// <param name="qbConnection">The QB Connection to execute the query.</param>
    /// <param name="txnID">The specific TxnID to query for.</param>
    /// <returns>The SalesOrder with the requested TxnID. Throws <see cref="QBSDKException">QBSDKException</see> if the SalesOrder does not exist.</returns>
    /// <exception cref="QBSDKException">Thrown when there was an error processing the query, including if the requested TxnID does not exist.</exception>
    public static SalesOrder GetSalesOrderByTxnID(this QBConnection qbConnection, string txnID)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(nameof(txnID));

        // Generate the request using the static constructor.
        var request = new QBXMLRequest([SalesOrderQuery.ByTxnID(txnID)]);

        // Process the request.
        var response = qbConnection.ProcessRequest(request);

        // Check if we have a successful response.
        var soResponse = response.QBXMLMsgsRs?.Results?[0] as SalesOrderQueryRs ?? throw new QBSDKException();

        // Found result: "0"
        if (soResponse.StatusCode == "0")
        {
            return soResponse.Results![0];
        }

        // Some error occured, including Not Found "500"
        throw new QBSDKException(soResponse);
    }

    /// <summary>
    /// Queries QuickBooks for a single SalesOrder with a specific RefNumber.
    /// </summary>
    /// <param name="qbConnection">The QB Connection to execute the query.</param>
    /// <param name="refNumber">The specific TxnID to query for.</param>
    /// <returns>The SalesOrder with the requested RefNumber. Throws <see cref="QBSDKException">QBSDKException</see> if the SalesOrder does not exist.</returns>
    /// <exception cref="QBSDKException">Thrown when there was an error processing the query, including if the requested RefNumber does not exist.</exception>
    public static SalesOrder GetSalesOrderByRefNumber(this QBConnection qbConnection, string refNumber)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(nameof(refNumber));

        // Generate the request using the static constructor.
        var request = new QBXMLRequest([SalesOrderQuery.ByRefNumber(refNumber)]);

        // Process the request.
        var response = qbConnection.ProcessRequest(request);

        // Check if we have a successful response.
        var soResponse = response.QBXMLMsgsRs?.Results?[0] as SalesOrderQueryRs ?? throw new QBSDKException();

        // Found result: "0"
        if (soResponse.StatusCode == "0")
        {
            return soResponse.Results![0];
        }

        // Some error occured, including Not Found "500"
        throw new QBSDKException(soResponse);
    }
}