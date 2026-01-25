using Microsoft.Extensions.Logging;
using QBXMLRP2Lib;
using System.IO;
using System.Linq;

namespace QB.SDK;

public class QBConnection(ILogger<QBConnection> logger) : IDisposable
{
    private bool disposedValue;
    private IRequestProcessor5? rp;
    private string? ticket;

    /// <summary>
    /// The full path of the QuickBooks company file to open. If empty, will connect to the currently open company file.
    /// </summary>
    public string QBFile { get; set; } = string.Empty;

    /// <summary>
    /// The name of the application that displays when requesting SDK access.
    /// </summary>
    public string AppID { get; set; } = "QBSDK";

    /// <summary>
    /// Sends the requests to the QBSDK and processes the response.
    /// </summary>
    /// <param name="request">The QBXML Requests to process.</param>
    public void ProcessRequest(QBXMLRequest request)
    {
        Open();

        var result = rp!.ProcessRequest(ticket, request.ToString());

        // Deserialize the result into an QBXMLResponse
        using var reader = new StringReader(result);
        var deSer = new XmlSerializer(typeof(QBXMLResponse));
        var response = (QBXMLResponse?)deSer.Deserialize(reader) ?? throw new InvalidOperationException("Unable to parse response from QuickBooks.");

        foreach (var rq in request.QBXMLMsgsRq.Requests)
        {
            var rs = response.QBXMLMsgsRs.Results.Where(r => r.RequestID == rq.requestID).Single();
            rq.ParseResponse(rs);
        }
    }

    /// <summary>
    /// Sends the request to the QBSDK and processes the response.
    /// </summary>
    /// <param name="request">The QB Request to process.</param>
    public void ProcessRequest(QBRequest request)
    {
        var qbxml = new QBXMLRequest([request]);
        ProcessRequest(qbxml);
    }

    /// <summary>
    /// Opens a connection to QuickBooks SDK.
    /// </summary>
    public void Open()
    {
        if (IsFileOpen())
        {
            return;
        }

        Close();

        rp = new RequestProcessor3();
        rp.OpenConnection2(AppID, AppID, QBXMLRPConnectionType.localQBD);
        ticket = rp.BeginSession(QBFile, QBFileMode.qbFileOpenDoNotCare);

    }

    /// <summary>
    /// Checks to see if the correct company file is already open based on the QBFile property.
    /// </summary>
    /// <returns>True if the QBFile is currently open, otherwise false.</returns>
    private bool IsFileOpen()
    {
        if (rp == null || string.IsNullOrWhiteSpace(ticket))
        {
            return false;
        }

        try
        {
            var file = rp.GetCurrentCompanyFileName(ticket);
            return System.IO.Path.GetFullPath(file).Equals(System.IO.Path.GetFullPath(QBFile));
        }
        catch (Exception ex)
        {
            logger.LogWarning("Unable to verify if correct company file is open: {ex}", ex);
            return false;
        }
    }

    /// <summary>
    /// Tries to end the current session with the QuickBooks company file.
    /// </summary>
    private void EndSession()
    {
        try
        {
            if (!string.IsNullOrWhiteSpace(ticket) && rp != null)
            {
                rp.EndSession(ticket);
            }
        }
        catch (Exception ex)
        {
            logger.LogWarning("There was an eror trying to end the session with QuickBooks: {ex}", ex);
        }
        finally
        {
            ticket = null;
        }
    }

    /// <summary>
    /// Tries to close the connection to the QuickBooks application.
    /// </summary>
    private void CloseConnection()
    {
        try
        {
            rp?.CloseConnection();
        }
        catch (Exception ex)
        {
            logger.LogWarning("There was an eror trying to close the connection to QuickBooks: {ex}", ex);
        }
        finally
        {
            ticket = null;
            rp = null;
        }
    }

    /// <summary>
    /// Closes both the company file and application connections.
    /// </summary>
    public void Close()
    {
        CloseConnection();
        EndSession();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                // TODO: dispose managed state (managed objects)
            }

            // Free unmanaged resources (unmanaged objects) and override finalizer
            Close();

            // TODO: set large fields to null
            disposedValue = true;
        }
    }

    // Override finalizer as 'Dispose(bool disposing)' has code to free unmanaged resources
    ~QBConnection()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: false);
    }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
