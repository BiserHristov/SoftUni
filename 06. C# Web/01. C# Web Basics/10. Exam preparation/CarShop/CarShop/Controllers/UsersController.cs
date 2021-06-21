using CarShop.Data;
using CarShop.Data.Models;
using CarShop.Models.Users;
using CarShop.Services;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Controllers
{
    public class UsersController : Controller
    {
        private readonly CarShopDbContext db;
        private readonly IValidator validator;
        private readonly IPasswordHasher passwordHasher;

        public UsersController(CarShopDbContext db, IValidator validator, IPasswordHasher passwordHasher)
        {
            this.db = db;
            this.validator = validator;
            this.passwordHasher = passwordHasher;
        }


        public HttpResponse Register() => View();

        [HttpPost]
        public HttpResponse Register(UserRegisterModel model)
        {
            var modelErrors = validator.ValidateUserRegistration(model);

            if (db.Users.Any(u => u.Email == model.Email))
            {
                modelErrors.Add("Email is already taken!");
            }

            if (db.Users.Any(u => u.Username == model.Username))
            {
                modelErrors.Add("Username is already taken!");
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
        public HttpResponse Login() => View();

        [HttpPost]
        public HttpResponse Login(UserLoginModel model)
        {
            var hashedPassword = this.passwordHasher.HashPassword(model.Password);

            var userId = this.db
                .Users
                .Where(u => u.Username == model.Username && u.Password == hashedPassword)
                .Select(u => u.Id)
                .FirstOrDefault();

            if (userId == null)
            {
                return Error("Username or/and email is/are not valid!");
            }

            this.SignIn(userId);

            return Redirect("/Repositories/All");
        }

        [Authorize]
        public HttpResponse Logout()
        {
            this.SignOut();

            return Redirect("/");
        }
    }
}
