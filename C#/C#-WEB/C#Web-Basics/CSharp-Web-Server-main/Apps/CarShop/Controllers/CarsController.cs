namespace CarShop.Controllers
{
    using CarShop.Data;
    using CarShop.Data.Models;
    using CarShop.Models.Cars;
    using CarShop.Services;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System.Linq;

    public class CarsController : Controller
    {
        private readonly IValidator validator;
        private readonly CarShopDbContext data;

        public CarsController(IValidator validator)
        {
            this.validator = validator;
        }

        [Authorize]
        public HttpResponse Add()
        {
            if (this.UserIsMechanic())
            {
                return Unauthorized();
            }

            return View();
        }

        [HttpPost]
        [Authorize]
        public HttpResponse Add(AddCarFormModel model)
        {
            if (this.UserIsMechanic())
            {
                return Unauthorized();
            }

            var modelErrors = this.validator.ValidateCar(model);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var car = new Car
            {
                Model = model.Model,
                Year = model.Year,
                PictureUrl = model.Image,
                PlateNumber = model.PlateNumber,
                OwnerId = this.User.Id
            };

            this.data.Cars.Add(car);

            this.data.SaveChanges();

            return Redirect("/Cars/All");
        }

        public HttpResponse All() => View();

        private bool UserIsMechanic()
            => this.data.Users
                        .Any(u => u.Id == this.User.Id && u.IsMechanic);
    }
}
