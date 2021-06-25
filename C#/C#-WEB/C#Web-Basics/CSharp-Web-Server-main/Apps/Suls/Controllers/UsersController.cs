using MyWebServer.Controllers;
using MyWebServer.Http;
using Suls.Data.Models;
using Suls.Services;
using Suls.ViewModels.Users;
using SulsApp.Data;
using System.Linq;

namespace Suls.Controllers
{
    public class UsersController : Controller
    {
        private readonly SulsDbContext data;
        private readonly IPasswordHasher passwordHasher;
        private readonly IValidator validator;

        public UsersController(SulsDbContext data, IPasswordHasher passwordHasher, IValidator validator)
        {
            this.data = data;
            this.passwordHasher = passwordHasher;
            this.validator = validator;
        }

        public HttpResponse Login()
        {
            if (this.User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }
            return this.View();
        }

        public HttpResponse Register()
        {
            if (this.User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginFormModel model)
        {
            var hashedPassword = this.passwordHasher.HashPassword(model.Password);

            var userId = this.data.Users
                                .Where(u => u.Username == model.Username && u.Password == hashedPassword)
                                .Select(u => u.Id)
                                .FirstOrDefault();

            if (userId == null)
            {
                //return Error("Username and password combination is not valid.");
                return this.Redirect("/Users/Login");
            }

            this.SignIn(userId);

            return Redirect("/");
        }

        [HttpPost]
        public HttpResponse Register(RegisterFormModel model)
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
                return Error(modelErrors);
            }

            var user = new User
            {
                Username = model.Username,
                Email = model.Email,
                Password = this.passwordHasher.HashPassword(model.Password),
            };

            data.Users.Add(user);
            data.SaveChanges();

            return Redirect("/Users/Login");
        }

        [Authorize]
        public HttpResponse Logout()
        {
            this.SignOut();
            return Redirect("/");
        }
    }
}
