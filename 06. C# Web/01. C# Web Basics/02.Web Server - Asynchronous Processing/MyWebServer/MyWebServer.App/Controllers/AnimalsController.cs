using MyWebServer.HTTP;
using MyWebServer.Controllers;


namespace MyWebServer.App.Controllers
{
    public class AnimalsController : Controller
    {
        public AnimalsController(HTTPRequest request)
            : base(request)
        {
        }
        public HTTPResponse Cats()
        {
            const string nameKey = "Name";
            var query = Request.Query;
            var catName = query.ContainsKey(nameKey)
            ? query[nameKey]
            : "the cats";

            return base.Html($"<h1>Hello from {catName}!</h1>");
        }
        //public HTTPResponse Dogs()
        //{
        //    const string nameKey = "Name";
        //    var query = Request.Query;
        //    var dogName = query.ContainsKey(nameKey)
        //    ? query[nameKey]
        //    : "the DOGS";

        //    return base.Html($"<h1>Hello from {dogName}!</h1>");
        //}

        public HTTPResponse Dogs() => View("/Views/Animals/Dogs.cshtml");
    }
}
