using MyWebServer.Controllers;
using MyWebServer.Http;
using SharedTrip.Data;
using SharedTrip.Data.Models;
using SharedTrip.Models.Trips;
using SharedTrip.Services;
using System;
using System.Linq;

using static SharedTrip.Data.DataConstants;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly IValidator validator;
        private readonly SharedTripDbContext db;

        public TripsController(IValidator validator, SharedTripDbContext db)
        {
            this.validator = validator;
            this.db = db;
        }

        [Authorize]
        public HttpResponse Add() => View();

        [Authorize]
        [HttpPost]
        public HttpResponse Add(TripAddFormModel model)
        {
            var modelErrors = this.validator.ValidateTrip(model);

            if (modelErrors.Count > 0)
            {
                return Redirect("/Trips/Add");
                //return Error(modelErrors);
            }

            var trip = new Trip
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                DepartureTime = DateTime.Parse(model.DepartureTime).ToUniversalTime(),
                Seats = model.Seats,
                Description = model.Description,
                ImagePath = model.ImagePath,
            };


            this.db.Trips.Add(trip);
            this.db.SaveChanges();

            return Redirect("/Trips/All");
        }

        [Authorize]
        public HttpResponse All()
        {
            var allTrips = this.db.Trips
                .Select(t => new TripsAllViewModel
                {
                    Id = t.Id,
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    DepartureTime = t.DepartureTime.ToLocalTime().ToString($"{DepartureTimeFormat}"),
                    Seats = t.Seats,
                })
                .ToList();

            return View(allTrips);
        }

        [Authorize]
        public HttpResponse Details(string tripId)
        {
            var trip = this.db
                .Trips
                .Where(t => t.Id == tripId)
                .Select(t => new TripViewModel
                {
                    Id = t.Id,
                    ImagePath = t.ImagePath,
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    DepartureTime = t.DepartureTime.ToLocalTime().ToString($"{DepartureTimeFormat}"),
                    Seats = t.Seats,
                    Description = t.Description

                })
                .FirstOrDefault();

            if (trip == null)
            {
                return Error("Trip does not exist!");
            }

            if (trip.Seats > 0 &&
                !this.db
                .UsersTrips
                .Any(ut => ut.TripId == tripId && ut.UserId == this.User.Id))
            {
                trip.IsJoinable = true;
            }

            return View(trip);
        }

        [Authorize]
        public HttpResponse AddUserToTrip(string tripId)
        {
            var trip = this.db.Trips
                .FirstOrDefault(t => t.Id == tripId);

            if (trip == null)
            {
                return Error("Trip does not exist");
            }

            var isJoined = this.db.UsersTrips.Any(ut => ut.TripId == tripId && ut.UserId == this.User.Id);

            if (isJoined || trip.Seats <= 0)
            {
                return Redirect($"/Trips/Details?tripId={tripId}");
            }

            var userTrip = new UserTrip
            {
                TripId = tripId,
                UserId = this.User.Id,
            };

            this.db.UsersTrips.Add(userTrip);
            trip.Seats--;
            this.db.SaveChanges();

            return Redirect("/Trips/All");
        }

    }
}
