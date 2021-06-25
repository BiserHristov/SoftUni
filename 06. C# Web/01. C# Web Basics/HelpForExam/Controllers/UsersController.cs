using ChangeMe.Data;
using ChangeMe.Data.Models;
using ChangeMe.Models.Users;
using ChangeMe.Services;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeMe.Controllers
{
    public class UsersController : Controller
    {
        private readonly IValidator validator;
        private readonly IPasswordHasher passwordHasher;
        private readonly BattleCardsDbContext db;

        public UsersController(
            IValidator validator,
            IPasswordHasher passwordHasher,
            BattleCardsDbContext db)
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

            return Redirect("/Cars/All"); //Change the URL!
        }

        [Authorize]
        public HttpResponse Logout()
        {
            this.SignOut();

            return Redirect("/");
        }
    }
}
