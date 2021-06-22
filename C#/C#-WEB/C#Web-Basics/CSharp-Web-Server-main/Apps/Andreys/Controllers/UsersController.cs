namespace Andreys.Controllers
{
    using Andreys.Data;
    using Andreys.Data.Models;
    using Andreys.Models.Users;
    using Andreys.Services;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System.Linq;
    public class UsersController : Controller
    {
        private readonly AndreysDbContext data;
        private readonly IValidator validator;
        private readonly IPasswordHasher passwordHasher;
        public UsersController(IValidator validator, AndreysDbContext data, IPasswordHasher passwordHasher)
        {
            this.validator = validator;
            this.data = data;
            this.passwordHasher = passwordHasher;
        }

        public HttpResponse Login() => this.View();
        public HttpResponse Register() => this.View();

        [Authorize]
        public HttpResponse Logout()
        {
            this.SignOut();

            return Redirect("/");
        }


        [HttpPost]
        public HttpResponse Login(LoginUserFormModel model)
        {
            var hashedPassword = this.passwordHasher.HashPassword(model.Password);

            var userId = this.data.Users
                                .Where(u => u.Username == model.Username && u.Password == hashedPassword)
                                .Select(u => u.Id)
                                .FirstOrDefault();

            if (userId == null)
            {
                //return Error("Username and password combination is not valid.");
                return Redirect("Users/Login");
            }

            this.SignIn(userId);

            return Redirect("/");
        }

        [HttpPost]
        public HttpResponse Register(RegisterUserFormModel model)
        {
            var modelErrors = this.validator.ValidateUser(model);

            if (this.data.Users.Any(u => u.Username == model.Username))
            {
                //modelErrors.Add($"User with '{model.Username}' username already exist.");
                return this.Redirect("/Users/Register");
            }

            if (this.data.Users.Any(u => u.Email == model.Email))
            {
                //modelErrors.Add($"User with '{model.Email}' e-mail already exist.");
                return this.Redirect("/Users/Register");
            }

            if (modelErrors.Any())
            {
                //return Error(modelErrors);
                return this.Redirect("/Users/Register");
            }

            var user = new User
            {
                Username = model.Username,
                Password = this.passwordHasher.HashPassword(model.Password),
                Email = model.Email
            };

            this.data.Users.Add(user);
            this.data.SaveChanges();

            return Redirect("/Users/Login");
        }

        //public IEnumerable<DisplayAllProductsViewModel> DisplayAll(AndreysDbContext data)
        //{
        //    var allProducts = data
        //        .Products
        //        .Select(p => new DisplayAllProductsViewModel()
        //        {
        //            Id = p.Id,
        //            ImageUrl = p.ImageUrl,
        //            Name = p.Name,
        //            Price = p.Price
        //        })
        //        .ToList();


        //    return (IEnumerable<DisplayAllProductsViewModel>)this.View(allProducts);
        //}
    }
}
