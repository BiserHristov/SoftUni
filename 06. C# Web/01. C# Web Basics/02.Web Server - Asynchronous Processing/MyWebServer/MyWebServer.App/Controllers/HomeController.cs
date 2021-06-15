using MyWebServer.HTTP;
using MyWebServer.Controllers;
using System;

namespace MyWebServer.App.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(HTTPRequest request)
            : base(request)
        {
        }

        public HTTPResponse Index()
        {

            return base.Text("Hello from Ivo!");
        }

        public HTTPResponse ToSoftuni()
        {
            return base.Redirect("https://softuni.bg");
        }

        public HTTPResponse LocalRedirect()
        {
            return base.Redirect("/cats");
        }

        public HTTPResponse Error()
        {
            throw new InvalidOperationException("Invalid action!");
        }
    }
}
