using MyWebServer.Controllers;
using MyWebServer.Http;
using SharedTrip.Data;
using SharedTrip.Data.Models;
using SharedTrip.Models.Users;
using SharedTrip.Services;
using System.Linq;

namespace SharedTrip.Controllers
{
    public class UsersController : Controller
    {
        private readonly IValidator validator;
        private readonly IPasswordHasher passwordHasher;
        private readonly SharedTripDbContext db;

        public UsersController(
            IValidator validator,
            IPasswordHasher passwordHasher,
            SharedTripDbContext db)
        {
            this.validator = validator;
            this.db = db;
            this.passwordHasher = passwordHasher;
        }

        public HttpResponse Register()
        {
            if (this.User.IsAuthenticated)
            {
                return this.Redirect("/");
            }

            return View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterUserFormModel model)
        {
			if (this.User.IsAuthenticated)
            {
                return this.Redirect("/");
            }
			
            var modelErrors = this.validator.ValidateUser(model);

            if (this.db.Users.Any(u => u.Username == model.Username))
            {
                modelErrors.Add($"User with '{model.Username}' username already exists.");
            }

            if (this.db.Users.Any(u => u.Email == model.Email))
            {
                modelErrors.Add($"User with '{model.Email}' e-mail already exists.");
            }

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var user = new User
            {
                Username = model.Username,
                Password = this.passwordHasher.HashPassword(model.Password),
                Email = model.Email,
            };

            db.Users.Add(user);

            db.SaveChanges();

            return Redirect("/Users/Login");
        }

        public HttpResponse Login()
        {
            if (this.User.IsAuthenticated)
            {
                return this.Redirect("/");
            }

            return View();
        }
		
		
        [HttpPost]
        public HttpResponse Login(LoginUserFormModel model)
        {
			if (this.User.IsAuthenticated)
            {
                return this.Redirect("/");
            }
			
            var hashedPassword = this.passwordHasher.HashPassword(model.Password);

            var userId = this.db
                .Users
                .Where(u => u.Username == model.Username && u.Password == hashedPassword)
                .Select(u => u.Id)
                .FirstOrDefault();

            if (userId == null)
            {
                return Error("Username and password combination is not valid.");
            }

            this.SignIn(userId);

            return Redirect("/Trips/All"); 
        }

        [Authorize]
        public HttpResponse Logout()
        {
            this.SignOut();

            return Redirect("/");
        }
    }
}
