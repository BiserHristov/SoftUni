using MyWebServer.HTTP;
using MyWebServer.Responses;
using System.Runtime.CompilerServices;

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

        protected HTTPResponse View([CallerMemberName] string viewPath = "")
            => new ViewResponse(viewPath, GetControllerName());

        private string GetControllerName()
            => this.GetType().Name.Replace(nameof(Controller), string.Empty);
    }
}
