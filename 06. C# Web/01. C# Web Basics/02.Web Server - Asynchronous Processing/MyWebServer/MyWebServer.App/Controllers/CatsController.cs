using MyWebServer.Controllers;
using MyWebServer.HTTP;

namespace MyWebServer.App.Controllers
{
    public class CatsController : Controller
    {
        public CatsController(HTTPRequest request) : base(request)
        {
        }


        public HTTPResponse Create() => View();

        public HTTPResponse Save() => Text($"{this.Request.Form["Name"]} - {this.Request.Form["Age"]}");
    }
}
