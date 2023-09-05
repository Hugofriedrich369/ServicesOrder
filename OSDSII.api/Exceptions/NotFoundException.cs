using System.Net;

namespace OSDSII.api.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(string resource) : base(
            "ERROR:001",
            $"{resource} not found",
            HttpStatusCode.NotFound,
            StatusCodes.Status404NotFound,
            DateTimeOffset.UtcNow,
            null)
        { }
        public NotFoundException(string message, Exception ex) : base(
            "ERROR:001",
            message,
            HttpStatusCode.NotFound,
            StatusCodes.Status404NotFound,
            DateTimeOffset.UtcNow,
            ex
            )
        { }
    }
}
