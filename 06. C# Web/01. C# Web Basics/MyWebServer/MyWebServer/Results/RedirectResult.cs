using MyWebServer.HTTP;

namespace MyWebServer.Results
{
    public class RedirectResult : ActionResult
    {

        public RedirectResult(HTTPResponse response, string location) :
            base(response)
        {
            this.StatusCode = HttpStatusCode.Found;
            this.AddHeader(Header.Location, location);
        }

    }
}
