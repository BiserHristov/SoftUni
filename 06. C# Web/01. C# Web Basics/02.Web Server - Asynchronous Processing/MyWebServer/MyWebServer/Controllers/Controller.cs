using MyWebServer.HTTP;
using MyWebServer.Responses;

namespace MyWebServer.Controllers
{
    
    public abstract class Controller
    {
        protected Controller(HTTPRequest request)
        {
            this.Request = request;
        }

        protected HTTPRequest Request { get; private init; }
        protected HTTPResponse Text(string text)
        {
            return new TextResponse(text);
        }

        protected HTTPResponse Html(string html)
        {
            return new HtmlResponse(html);
        }

        protected HTTPResponse Redirect(string location)
        {
            return new RedirectResponse(location);
        }
    }
}
