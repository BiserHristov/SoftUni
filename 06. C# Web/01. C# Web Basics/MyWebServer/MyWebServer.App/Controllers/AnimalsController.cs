using MyWebServer.HTTP;
using MyWebServer.Controllers;
using MyWebServer.App.Models.Animals;

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
            const string ageKey = "Age";

            var query = Request.Query;
            var catName = query.ContainsKey(nameKey)
            ? query[nameKey]
            : string.Empty;

            var catAge = query.ContainsKey(ageKey)
           ? int.Parse(query[ageKey])
           : 0;

            return View(new CatViewModel { Name = catName, Age = catAge });
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

        public HTTPResponse Dogs() => View(new DogViewModel
        {
            Name = "Rex",
            Age = 33,
            Breed = "Street Perfect"
        });

        public HTTPResponse Bunnies() => View("Rabbits");
        public HTTPResponse Turtles() => View("Animals/Wild/Turtles");

    }
}
