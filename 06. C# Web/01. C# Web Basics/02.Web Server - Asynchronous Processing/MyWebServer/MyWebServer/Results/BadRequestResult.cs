
using MyWebServer.HTTP;

namespace MyWebServer.Results
{
    public class BadRequestResult : HTTPResponse
    {
        public BadRequestResult()
            : base(HttpStatusCode.BadRequest)
        {
        }
    }
}
