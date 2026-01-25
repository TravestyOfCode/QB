using System.Linq;

namespace QB.SDK;

public class BillQuery : TxnQuery
{
    internal override void ParseResponse(QBResponse response)
    {
        var rs = response as BillQueryRs ?? throw new InvalidOperationException("Unable to parse response as BillQueryRs.");
        StatusCode = rs.StatusCode;
        StatusMessage = rs.StatusMessage;
        StatusSeverity = rs.StatusSeverity;
        iteratorID = rs.IteratorID;
        ReturnedCount = int.TryParse(rs.ReturnedCount, out var retCount) ? retCount : -1;
        RemainingCount = int.TryParse(rs.RemainingCount, out var remCount) ? remCount : -1;
        Results = rs.Results;
    }

    public List<Bill>? Results { get; private set; }

    /// <summary>
    /// Converts the object to a XElement represenation according to the QBXML specification.
    /// </summary>
    /// <returns>A XElement respresentation of the object.</returns>
    public override XElement ToQBXML()
    {
        return new XElement($"{nameof(BillQuery)}Rq")
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
            .Append(AccountFilter)
            .Append(RefNumberFilter)
            .Append(RefNumberRangeFilter)
            .Append(CurrencyFilter)
            .Append(IncludeLineItems)
            .Append(IncludeLinkedTxns)
            .Append(IncludeRetElement)
            .Append(OwnerID);
    }

    /// <summary>
    /// Generates a BillQuery request filtering by a list of RefNumbers.
    /// </summary>
    /// <param name="refNumbers">The list of RefNumbers to use for filtering.</param>
    /// <param name="isCaseSensitive">Determines if the filter list is case sensitive. Recommend to leave as true (default) if case sensitive does not matter.</param>
    /// <returns>A BillQuery request.</returns>
    public static BillQuery ByRefNumbers(IEnumerable<string> refNumbers, bool isCaseSensitive = true)
    {
        return isCaseSensitive ? new() { RefNumberCaseSensitive = refNumbers.ToList() } : new() { RefNumber = refNumbers.ToList() };
    }

    /// <summary>
    /// Generates a BillQuery request filtering by a single RefNumber.
    /// </summary>
    /// <param name="refNumbers">The RefNumber to use for filtering.</param>
    /// <param name="isCaseSensitive">Determines if the RefNumber is case sensitive. Recommend to leave as true (default) if case sensitive does not matter.</param>
    /// <returns>A BillQuery request.</returns>
    public static BillQuery ByRefNumber(string refNumber, bool isCaseSensitive = true)
    {
        return isCaseSensitive ? new() { RefNumberCaseSensitive = [refNumber] } : new() { RefNumber = [refNumber] };
    }

    /// <summary>
    /// Generates a BillQuery request filtering by a list of TxnIDs.
    /// </summary>
    /// <param name="refNumbers">The list of TxnIDs to use for filtering.</param>
    /// <returns>A BillQuery request.</returns>
    public static BillQuery ByTxnIDs(IEnumerable<string> txnIDs)
    {
        return new() { TxnID = [.. txnIDs] };
    }

    /// <summary>
    /// Generates a BillQuery request filtering by a specific TxnIDs.
    /// </summary>
    /// <param name="refNumbers">A TxnIDs to use for filtering.</param>
    /// <returns>A BillQuery request.</returns>
    public static BillQuery ByTxnID(string txnID)
    {
        return new() { TxnID = [txnID] };
    }
}

public static class BillQueryExtensions
{
    /// <summary>
    /// Queries QuickBooks for a single Bill with a specific RefNumber.
    /// </summary>
    /// <param name="qbConnection">The QB Connection to execute the query.</param>
    /// <param name="refNumber">The specific RefNumber to query for.</param>
    /// <param name="isCaseSensitive">Determines if the RefNumber is case sensitive. Recommend to leave as true (default) if case sensitive does not matter.</param>
    /// <returns>The Bill with the requested RefNumber if it was found, otherwise null.</returns>
    public static Bill? FindBillsByRefNumber(this QBConnection qbConnection, string refNumber, bool isCaseSensitive = true)
    {
        // Generate the request using the static constructor
        var request = BillQuery.ByRefNumber(refNumber, isCaseSensitive);

        // Process the request.
        qbConnection.ProcessRequest(request);

        // Check if we have a successful response.
        // Found result: "0", Not Found result: "500"
        if (request.StatusCode == "0" || request.StatusCode == "500")
        {
            return request.Results?[0];
        }

        // Some other error occured.
        throw new QBSDKException(request);
    }

    /// <summary>
    /// Queries QuickBooks for a single Bill with a specific RefNumber.
    /// </summary>
    /// <param name="qbConnection">The QB Connection to execute the query.</param>
    /// <param name="refNumbers">The list of RefNumbers to query for.</param>
    /// <param name="isCaseSensitive">Determines if the RefNumbers are case sensitive. Recommend to leave as true (default) if case sensitive does not matter.</param>
    /// <returns>A List<Bill> with the requested RefNumbers if they were found, otherwise null.</returns>
    public static List<Bill>? FindBillsByRefNumbers(this QBConnection qbConnection, IEnumerable<string> refNumbers, bool isCaseSensitive = true)
    {
        // Generate the request using the static constructor
        var request = BillQuery.ByRefNumbers(refNumbers, isCaseSensitive);

        // Process the request.
        qbConnection.ProcessRequest(request);

        // Check if we have a successful response.
        // Found result: "0", Not Found result: "500"
        if (request.StatusCode == "0" || request.StatusCode == "500")
        {
            return request.Results;
        }

        // Some other error occured.
        throw new QBSDKException(request);
    }

    /// <summary>
    /// Queries QuickBooks for a single Bill with a specific TxnID.
    /// </summary>
    /// <param name="qbConnection">The QB Connection to execute the query.</param>
    /// <param name="txnID">The specific TxnID to query for.</param>
    /// <returns>The Bill with the requested TxnID. Throws <see cref="QBSDKException">QBSDKException</see> if the Bill does not exist.</returns>
    /// <exception cref="QBSDKException">Thrown when there was an error processing the query, including if the requested TxnID does not exist.</exception>
    public static Bill GetBillByTxnID(this QBConnection qbConnection, string txnID)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(nameof(txnID));

        // Generate the request using the static constructor.
        var request = BillQuery.ByTxnID(txnID);

        // Process the request.
        qbConnection.ProcessRequest(request);

        // Check if we have a successful response.
        // Found result: "0"
        if (request.StatusCode == "0")
        {
            return request.Results![0];
        }

        // Some error occured, including Not Found "500"
        throw new QBSDKException(request);
    }

    /// <summary>
    /// Queries QuickBooks for a single Bill with a specific RefNumber.
    /// </summary>
    /// <param name="qbConnection">The QB Connection to execute the query.</param>
    /// <param name="refNumber">The specific TxnID to query for.</param>
    /// <returns>The Bill with the requested RefNumber. Throws <see cref="QBSDKException">QBSDKException</see> if the Bill does not exist.</returns>
    /// <exception cref="QBSDKException">Thrown when there was an error processing the query, including if the requested RefNumber does not exist.</exception>
    public static Bill GetBillByRefNumber(this QBConnection qbConnection, string refNumber)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(nameof(refNumber));

        // Generate the request using the static constructor.
        var request = BillQuery.ByRefNumber(refNumber);

        // Process the request.
        qbConnection.ProcessRequest(request);

        // Check if we have a successful response.
        // Found result: "0"
        if (request.StatusCode == "0")
        {
            return request.Results![0];
        }

        // Some error occured, including Not Found "500"
        throw new QBSDKException(request);
    }
}
