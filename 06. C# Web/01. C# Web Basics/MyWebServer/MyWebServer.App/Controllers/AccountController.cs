using MyWebServer.Controllers;
using MyWebServer.HTTP;
using MyWebServer.Results;
using System;

namespace MyWebServer.App.Controllers
{
    public class AccountController : Controller
    {
        public AccountController(HTTPRequest request) 
            : base(request)
        {
        }

        public ActionResult ActionWithCookies()
        {
            const string cookieName = "My-Cookie";
            if (this.Request.Cookies.ContainsKey(cookieName))
            {
                var cookie = this.Request.Cookies[cookieName];
                return Text($"Cookies already exist - {cookie}");

            }

            this.Response.AddCookie(cookieName, "My-value");
            this.Response.AddCookie("My-second-cookie", "My-second-value");
            return Text("Hello");
        }

        public ActionResult ActionWithSession()
        {
            const string currentDateKey = "CurrentDate";

            if (this.Request.Session.ContainsKey(currentDateKey))
            {
                var currentDate = this.Request.Session[currentDateKey];
                return Text($"Stored date: {currentDate}!");

            }

            this.Request.Session[currentDateKey] = DateTime.UtcNow.ToString();

            return Text("Current date stored!");
        }

        public HTTPResponse LogIn()
        {
            var someuserId = "MyuserId";
            this.SignIn(someuserId);
            return Text("User authenticated!");
        }

        public HTTPResponse LogOut()
        {
            this.SignOut();
            return Text("User sighned out!");
        }

        public HTTPResponse AuthenticationCheck()
        {
            if (this.User.IsAuthenticated)
            {
                return Text($"Authenticated user: {this.User.Id}");
            }

            return Text("User is not authenticated");
        }
    }
}
