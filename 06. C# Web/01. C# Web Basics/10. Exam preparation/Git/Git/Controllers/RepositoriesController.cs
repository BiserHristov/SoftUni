using Git.Data.Models;
using Git.Models.Repositories;
using Git.Services;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly Validator validator;
        private readonly GitDbContext db;

        public RepositoriesController(Validator validator, GitDbContext db)
        {
            this.validator = validator;
            this.db = db;
        }


        public HttpResponse All()
        {
            var repositories = this.db
                 .Repositories
                 .Where(r => r.IsPublic || r.OwnerId == this.User.Id)
                 .Select(r => new AllRepositoriesViewModel
                 {
                     Id = r.Id,
                     Name = r.Name,
                     Owner = r.Owner.Username,
                     CreatedOn = r.CreatedOn.ToLocalTime().ToString("F"), //Transform Utc.Now to LocalTime
                     CommitsCount = r.Commits.Count()

                 })
                 .ToList();

            return View(repositories);
        }

        [Authorize]
        public HttpResponse Create() => View();

        [HttpPost]
        [Authorize]
        public HttpResponse Create(RepositoryCreateModel model)
        {
            var modelErrors = this.validator.ValidateRepositoryCreation(model);

            if (modelErrors.Count > 0)
            {
                return Error(modelErrors);
            }

            //var user = this.db.Users.FirstOrDefault(u => u.Id == this.User.Id);

            var repository = new Repository
            { 
                Name = model.Name,
                CreatedOn = DateTime.UtcNow, 
                IsPublic = model.RepositoryType == "Public" ,
                OwnerId = this.User.Id,
                
            };

            this.db.Repositories.Add(repository);
            this.db.SaveChanges();

            return this.Redirect("/Repositories/All");

        }


    }
}
