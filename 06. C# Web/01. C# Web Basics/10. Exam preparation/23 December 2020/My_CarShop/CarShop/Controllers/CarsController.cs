using CarShop.Data;
using CarShop.Data.Models;
using CarShop.Models.Cars;
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
    public class CarsController : Controller
    {
        private readonly CarShopDbContext db;
        private readonly IValidator validator;

        public CarsController(CarShopDbContext db, IValidator validator)
        {
            this.db = db;
            this.validator = validator;
        }
        [Authorize]
        public HttpResponse Add()
        {
            if (IsUserMechanic)
            {
                return Error("Mechanics cannot add cars.");
            }

            return View();

        }

        [HttpPost]
        [Authorize]
        public HttpResponse Add(CarInputAddModel model)
        {
            if (IsUserMechanic)
            {
                return Error("Mechanics cannot add cars.");
            }

            var modelErrors = this.validator.ValidateAddCarr(model);

            if (modelErrors.Count > 0)
            {
                return Error(modelErrors);
            }

            var car = new Car
            {
                Model = model.Model,
                Year = model.Year,
                PictureUrl = model.Image,
                PlateNumber = model.PlateNumber,
                OwnerId = this.User.Id,
            };

            this.db.Cars.Add(car);
            this.db.SaveChanges();

            return this.Redirect("/Cars/All");
        }

        [Authorize]
        public HttpResponse All()
        {
            if (!this.User.IsAuthenticated)
            {
                return Unauthorized();

            }

            var carsQuery = this.db
                .Cars
                .AsQueryable();

            if (IsUserMechanic)
            {
                carsQuery = carsQuery.Where(c => c.Issues.Any(i => !i.IsFixed));
            }
            else
            {
                carsQuery = carsQuery.Where(c => c.OwnerId == this.User.Id);
            }

            var cars = carsQuery
                .Select(c => new CarOutputModel
                {
                    Id = c.Id,
                    Image = c.PictureUrl,
                    Model = c.Model,
                    PlateNumber = c.PlateNumber,
                    Year = c.Year,
                    FixedIssues = c.Issues.Where(i => i.IsFixed).Count(),
                    RemainingIssues = c.Issues.Where(i => !i.IsFixed).Count(),

                })
                .ToList();

            return View(cars);
        }

        private bool IsUserMechanic =>
            this.db.Users
            .Where(u => u.Id == this.User.Id)
            .Select(u => u.IsMechanic)
            .FirstOrDefault();

    }
}
