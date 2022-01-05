using System.Net;

namespace MovieFinder.Domain.Exceptions;

public class HttpStatusException : Exception
{
    public HttpStatusCode Status { get; private set; }

    public HttpStatusException(HttpStatusCode status, string message) : base(message)
    {
        Status = status;
    }
}