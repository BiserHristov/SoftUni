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
            this.Response = new HTTPResponse(HttpStatusCode.OK);
        }

        protected HTTPRequest Request { get; private init; }

        protected HTTPResponse Response { get; private init; }
        protected ActionResult Text(string text)
        {
            return new TextResult(this.Response,text);
        }

        protected ActionResult Html(string html)
        {
            return new HtmlResult(this.Response,html);
        }

        protected ActionResult Redirect(string location)
        {
            return new RedirectResult(this.Response,location);
        }

        protected ActionResult View([CallerMemberName] string viewName = "")
            => new ViewResult(this.Response,viewName, GetControllerName(), null);

        protected ActionResult View(string viewName, object model)
            => new ViewResult(this.Response,viewName, GetControllerName(), model);

        protected ActionResult View(object model, [CallerMemberName] string viewName = "")
        => new ViewResult(this.Response,viewName, GetControllerName(), model);

        private string GetControllerName()
            => this.GetType().Name.Replace(nameof(Controller), string.Empty);
    }
}
