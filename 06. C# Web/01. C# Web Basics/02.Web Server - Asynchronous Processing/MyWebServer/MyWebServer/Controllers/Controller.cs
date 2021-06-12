using MyWebServer.HTTP;
using MyWebServer.Results;
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

        protected HTTPResponse Response { get; private init; }
        protected HTTPResponse Text(string text)
        {
            return new TextResult(text);
        }

        protected HTTPResponse Html(string html)
        {
            return new HtmlResult(html);
        }

        protected HTTPResponse Redirect(string location)
        {
            return new RedirectResult(location);
        }

        protected HTTPResponse View([CallerMemberName] string viewName = "")
            => new ViewResult(viewName, GetControllerName(), null);

        protected HTTPResponse View(string viewName, object model)
            => new ViewResult(viewName, GetControllerName(), model);

        protected HTTPResponse View(object model, [CallerMemberName] string viewName = "")
        => new ViewResult(viewName, GetControllerName(), model);

        private string GetControllerName()
            => this.GetType().Name.Replace(nameof(Controller), string.Empty);
    }
}
