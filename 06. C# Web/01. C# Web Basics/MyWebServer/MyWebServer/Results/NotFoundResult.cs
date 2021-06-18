using MyWebServer.HTTP;

namespace MyWebServer.Results
{
    public class NotFoundResult : ActionResult
    {
        public NotFoundResult(HTTPResponse response)
            : base(response)
        {
            this.StatusCode = HttpStatusCode.NotFound;
        }
    }
}
