namespace QB.SDK;

public class QBXMLMsgsRq
{
    public OnError OnError { get; set; }

    public List<QBRequest> Requests { get; set; } = [];

    /// <summary>
    /// Creates a QBXMLMsgsRq with an empty request list.
    /// </summary>
    public QBXMLMsgsRq() : this(OnError.continueOnError) { }

    /// <summary>
    /// Creates a QBXMLMsgsRq with an empty request list.
    /// </summary>
    /// <param name="onError">Specifies if the QBSDK should continue processing requests if one has an error.</param>
    public QBXMLMsgsRq(OnError onError = OnError.continueOnError)
    {
        OnError = onError;
    }

    /// <summary>
    /// Creates a QBXMLMsgsRq with an empty request list.
    /// </summary>
    /// <param name="requests">The list of requests to add to the QBSMLMsgsRq.</param>
    /// <param name="onError">Specifies if the QBSDK should continue processing requests if one has an error.</param>
    public QBXMLMsgsRq(List<QBRequest> requests, OnError onError = OnError.continueOnError)
    {
        OnError = onError;
        Requests = requests;
    }

    public XElement ToQBXML(string name = nameof(QBXMLMsgsRq))
    {
        return new XElement(name, new XAttribute("onError", OnError))
            .Append(Requests);
    }
}
