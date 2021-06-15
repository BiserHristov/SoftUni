using MyWebServer;
using MyWebServer.App.Controllers;
using MyWebServer.HTTP;
using MyWebServer.Controllers;
using System.Threading.Tasks;

namespace WebServer.App
{
    public class Startup
    {
        static async Task Main(string[] args)
        {
            IHTTPServer server = new HTTPServer(routes => routes
            .MapStaticFiles()
           .MapGet<HomeController>("/", c => c.Index())
           .MapGet<HomeController>("/softuni", c => c.ToSoftuni())
           .MapGet<HomeController>("/toCats", c => c.LocalRedirect())
           .MapGet<HomeController>("/Error", c => c.Error())
           .MapGet<HomeController>("/StaticFiles", c => c.StaticFiles())
           .MapGet<AnimalsController>("/Cats", c => c.Cats())
           .MapGet<AnimalsController>("/Turtles", c => c.Turtles())
           .MapGet<AnimalsController>("/Bunnies", c => c.Bunnies())
           .MapGet<AnimalsController>("/Dogs", c => c.Dogs())
           .MapGet<AccountController>("/Cookies", c => c.ActionWithCookies())
           .MapGet<AccountController>("/Sessions", c => c.ActionWithSession())
           .MapGet<AccountController>("/Login", c => c.LogIn())
           .MapGet<AccountController>("/Logout", c => c.LogOut())
           .MapGet<AccountController>("/Authentication", c => c.AuthenticationCheck())
           .MapGet<CatsController>("/Cats/Create", c => c.Create())
           .MapPost<CatsController>("/Cats/Save", c => c.Save()));


            //server.AddRoute("/", Home);
            //server.AddRoute("/about", About);
            //server.AddRoute("/users/login", Login);

            await server.Start();


        }

        //static HTTPResponse Home(HTTPRequest request)
        //{
        //    var responseBody = "<h1> Home...</h1>";
        //    var responseBodyBytes = Encoding.UTF8.GetBytes(responseBody);
        //    var response = new HTTPResponse(responseBodyBytes, "text/html");
        //    response.Headers.Add(new Header("Server", "SUS Server 1.1"));
        //    response.Cookies.Add(new ResponseCookie("testCookie", "testValue") { HttpOnly = true, MaxAge = 600 });

        //    return response;
        //}

        //static HTTPResponse About(HTTPRequest request)
        //{
        //    var responseBody = "<h1> About...</h1>";
        //    var responseBodyBytes = Encoding.UTF8.GetBytes(responseBody);
        //    var response = new HTTPResponse(responseBodyBytes, "text/html");
        //    response.Headers.Add(new Header("Server", "SUS Server 1.1"));
        //    response.Cookies.Add(new ResponseCookie("testCookie", "testValue") { HttpOnly = true, MaxAge = 600 });

        //    return response;
        //}

        //static HTTPResponse Login(HTTPRequest request)
        //{
        //    var responseBody = "<h1> Login...</h1>";
        //    var responseBodyBytes = Encoding.UTF8.GetBytes(responseBody);
        //    var response = new HTTPResponse(responseBodyBytes, "text/html");
        //    response.Headers.Add(new Header("Server", "SUS Server 1.1"));
        //    response.Cookies.Add(new ResponseCookie("testCookie", "testValue") { HttpOnly = true, MaxAge = 600 });

        //    return response;
        //}
    }
}
