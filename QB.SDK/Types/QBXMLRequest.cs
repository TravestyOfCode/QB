using System.Diagnostics.CodeAnalysis;

namespace QB.SDK;

[XmlRoot("QBXML")]
public class QBXMLRequest
{
    public required QBXMLMsgsRq QBXMLMsgsRq { get; set; }

    /// <summary>
    /// Creates a new QBXMLRequest with an empty Message Request list.
    /// </summary>
    public QBXMLRequest()
    {
        QBXMLMsgsRq = new QBXMLMsgsRq();
    }

    /// <summary>
    /// Creates a new QBXMLRequest with an empty Message Request list.
    /// </summary>
    /// <param name="onError">Specifies if the QBSDK should continue processing requests if one has an error.</param>
    [SetsRequiredMembers]
    public QBXMLRequest(OnError onError = OnError.continueOnError) => QBXMLMsgsRq = new QBXMLMsgsRq(onError);

    /// <summary>
    /// Creates a new QBXMLRequest using the supplied requests for the Message Request list.
    /// </summary>
    /// <param name="requests">The requests to add to the Message Request list.</param>
    /// <param name="onError">Specifies if the QBSDK should continue processing requests if one has an error.</param>
    [SetsRequiredMembers]
    public QBXMLRequest(List<QBRequest> requests, OnError onError = OnError.continueOnError) => QBXMLMsgsRq = new QBXMLMsgsRq(requests, onError);

    public XDocument ToXDocument()
    {
        var doc = new XDocument(new XDeclaration("1.0", "utf-8", null));
        doc.Add(new XProcessingInstruction("qbxml", "version=\"13.0\""));
        doc.Add(new XElement("QBXML", QBXMLMsgsRq.ToQBXML()));
        return doc;
    }

    public override string ToString()
    {
        var doc = ToXDocument();
        using var writer = new Utf8StringWriter();
        doc.Save(writer, SaveOptions.None);
        return writer.ToString();
    }
}
