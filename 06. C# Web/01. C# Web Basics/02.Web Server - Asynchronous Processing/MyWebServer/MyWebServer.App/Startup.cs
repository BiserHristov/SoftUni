using MyWebServer;
using MyWebServer.App.Controllers;
using MyWebServer.HTTP;
using MyWebServer.Controllers;

using System;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.App
{
    public class Startup
    {
        static async Task Main(string[] args)
        {
            IHTTPServer server = new HTTPServer(routes => routes
           .MapGet<HomeController>("/", c => c.Index())
           .MapGet<AnimalsController>("/Cats", c => c.Cats())
           .MapGet<HomeController>("/softuni", c => c.ToSoftuni())
           .MapGet<AnimalsController>("/Dogs", c => c.Dogs()));


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
