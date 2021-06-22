using MyWebServer.Controllers;
using MyWebServer.Http;
using SharedTrip.Data;
using SharedTrip.Data.Models;
using SharedTrip.Models.Trips;
using SharedTrip.Services;
using System;
using System.Linq;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly SharedTripDbContext data;
        private readonly IValidator validator;

        public TripsController(SharedTripDbContext data, IValidator validator)
        {
            this.data = data;
            this.validator = validator;
        }

        [Authorize]
        public HttpResponse All()
        {
            var viewModel = this.data.Trips
                                 .Select(t => new GetAllTripsViewModel()
                                 {
                                     Id = t.Id,
                                     StartPoint = t.StartPoint,
                                     EndPoint = t.EndPoint,
                                     DepartureTime = t.DepartureTime,
                                     Seats = t.Seats - t.UserTrips.Count
                                 })
                                 .ToList();

            return this.View(viewModel);

        }

        [Authorize]
        public HttpResponse Add()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Add(AddTripInputModel model)
        {
            var modelErrors = this.validator.ValidateTrip(model);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var trip = new Trip()
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                DepartureTime = DateTime.Parse(model.DepartureTime),
                ImagePath = model.ImagePath,
                Seats = model.Seats,
                Description = model.Description
            };

            this.data.Trips.Add(trip);
            this.data.SaveChanges();

            return Redirect("/Trips/All");
        }

        [Authorize]
        public HttpResponse Details(string tripId)
        {
            var viewModel = this.data.Trips
                                      .Where(t => t.Id == tripId)
                                      .Select(t => new GetDetailsTripViewModel()
                                      {
                                          Id = t.Id,
                                          StartPoint = t.StartPoint,
                                          EndPoint = t.EndPoint,
                                          DepartureTime = t.DepartureTime,
                                          Seats = t.Seats - t.UserTrips.Count,
                                          Description = t.Description,
                                          ImagePath = t.ImagePath
                                      })
                                      .FirstOrDefault();

            return View(viewModel);
        }

        [Authorize]
        public HttpResponse AddUserToTrip(string tripId)
        {
            var userId = this.GetUserId();

            if (this.CanAddUserToTrip(userId, tripId))
            {
                return this.Redirect($"/Trips/Details?tripId={tripId}");
            }

            return this.Redirect("/");
        }

        public bool CanAddUserToTrip(string userId, string tripId)
        {
            if (this.data.UserTrips
                    .Any(ut => ut.UserId == userId &&
                               ut.TripId == tripId) ||
                this.data.Trips
                    .Where(t => t.Id == tripId)
                    .Select(t => t.Seats - t.UserTrips.Count)
                    .FirstOrDefault() == 0)
            {
                return false;
            }

            this.data.UserTrips.Add(new UserTrip()
            {
                TripId = tripId,
                UserId = userId
            });

            this.data.SaveChanges();

            return true;
        }
    }
}
