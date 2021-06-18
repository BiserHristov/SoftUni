using MyWebServer.Controllers;
using MyWebServer.HTTP;

namespace MyWebServer.App.Controllers
{
    public class CatsController : Controller
    {
        public CatsController(HTTPRequest request) : base(request)
        {
        }

        [HttpGet]
        public HTTPResponse Create() => View();

        [HttpPost]
        public HTTPResponse Save()
        {
            var name = this.Request.Form["Name"];
            var age = this.Request.Form["Age"];

            return Text($"{name} - {age}");
        }
    }
}
