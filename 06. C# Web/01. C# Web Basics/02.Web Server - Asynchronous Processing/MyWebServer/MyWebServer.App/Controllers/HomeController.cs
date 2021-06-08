using MyWebServer;
using MyWebServer.HTTP;
using MyWebServer.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
