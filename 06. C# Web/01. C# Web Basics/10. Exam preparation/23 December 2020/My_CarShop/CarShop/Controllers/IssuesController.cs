using CarShop.Data;
using CarShop.Data.Models;
using CarShop.Models.Issues;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Controllers
{
    public class IssuesController : Controller
    {
        private readonly CarShopDbContext db;

        public IssuesController(CarShopDbContext db)
        {
            this.db = db;
        }

        [Authorize]
        public HttpResponse CarIssues(string carId)
        {

            if (carId == null)
            {
                return BadRequest();
            }

            var car = this.db.Cars
                .Where(c => c.Id == carId)
                .Select(c => new CarIssuesOutputModel
                {
                    Id = c.Id,
                    Model = c.Model,
                    Year = c.Year,
                    UserIsMechanic=this.db.Users.Where(u=>u.Id==this.User.Id).Select(u=>u.IsMechanic).FirstOrDefault(),
                    Issues = c.Issues.Select(i => new IssueOutputModel
                    {
                        Id = i.Id,
                        Description = i.Description,
                        IsFixed = i.IsFixed
                    })
                    .ToList()
                })
                .FirstOrDefault();

            if (car == null)
            {
                return BadRequest();
            }

            return View(car);

        }

        [Authorize]
        public HttpResponse Add(string carId)
        {
            if (carId == null)
            {
                return BadRequest();

            }

            var car = this.db.Cars.Find(carId);

            if (car == null)
            {
                return BadRequest();
            }

            return View(new IssueViewModel { CarId = carId });
        }



        [HttpPost]
        [Authorize]
        public HttpResponse Add(string description, string carId)
        {
            if (description == null || carId == null)
            {
                return BadRequest();
            }

            var car = this.db.Cars.Find(carId);

            if (car == null)
            {
                return BadRequest();
            }

            var issue = new Issue
            {
                Description = description,
                CarId = carId,

            };

            car.Issues.Add(issue);
            db.SaveChanges();

            return Redirect($"/Issues/CarIssues?carId={carId}");

        }

        public HttpResponse Delete(string issueId, string carId)
        {
            if (issueId == null || carId == null)
            {
                return BadRequest();
            }

            var issue = this.db.Issues
                .Where(i => i.Id == issueId &&
                            i.CarId == carId)
                .FirstOrDefault();

            if (issue == null)
            {
                return BadRequest();
            }

            this.db.Issues.Remove(issue);
            db.SaveChanges();

            return Redirect($"/Issues/CarIssues?carId={carId}");
        }
        public HttpResponse Fix(string issueId, string carId)
        {
            var isMechanic = this.db.Users
                .Where(u => u.Id == this.User.Id)
                .Select(u => u.IsMechanic)
                .FirstOrDefault();

            if (!isMechanic)
            {
                return BadRequest();
            }

            if (issueId == null || carId == null)
            {
                return BadRequest();
            }

            var issue = this.db.Issues
                .Where(i => i.Id == issueId &&
                            i.CarId == carId)
                .FirstOrDefault();

            if (issue == null)
            {
                return BadRequest();
            }

            issue.IsFixed = true;
            db.SaveChanges();

            return Redirect($"/Issues/CarIssues?carId={carId}");
        }
    }
}
