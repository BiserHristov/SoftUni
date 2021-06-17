using MyWebServer.HTTP;
using MyWebServer.Identity;
using MyWebServer.Results;
using System.Runtime.CompilerServices;

namespace MyWebServer.Controllers
{

    public abstract class Controller
    {
        private const string UserSessionKey = "AuthenticatedUserId";
        protected Controller(HTTPRequest request)
        {
            this.Request = request;
            this.Response = new HTTPResponse(HttpStatusCode.OK);
            this.User = this.Request.Session.ContainsKey(UserSessionKey)
                ? new UserIdentity { Id = this.Request.Session[UserSessionKey] }
                : new();
        }

        protected HTTPRequest Request { get; private init; }

        protected HTTPResponse Response { get; private set; }

        protected UserIdentity User { get; private set; } = new UserIdentity();

        protected void SignIn(string userid)
        {
            this.Request.Session[UserSessionKey] = userid;
            this.User = new UserIdentity { Id = userid };
        }
        protected void SignOut()
        {
            this.Request.Session.Remove(UserSessionKey);
            this.User = new UserIdentity();
        }

        protected ActionResult Text(string text)
        {
            return new TextResult(this.Response, text);
        }

        protected ActionResult Html(string html)
        {
            return new HtmlResult(this.Response, html);
        }

        protected ActionResult Redirect(string location)
        {
            return new RedirectResult(this.Response, location);
        }

        protected ActionResult View([CallerMemberName] string viewName = "")
            => new ViewResult(this.Response, viewName, this.GetType().GetControllerName(), null);

        protected ActionResult View(string viewName, object model)
            => new ViewResult(this.Response, viewName, this.GetType().GetControllerName(), model);

        protected ActionResult View(object model, [CallerMemberName] string viewName = "")
        => new ViewResult(this.Response, viewName, this.GetType().GetControllerName(), model);

       
    }
}
