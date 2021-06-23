using MyWebServer.Controllers;
using MyWebServer.Http;
using Panda.Data;
using Panda.Data.Models;
using Panda.Services;
using Panda.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panda.Controllers
{
    public class UsersController : Controller
    {
        private readonly PandaDbContext data;
        private readonly IValidator validator;
        private readonly IPasswordHasher passwordHasher;

        public UsersController(PandaDbContext data, IValidator validator, IPasswordHasher passwordHasher)
        {
            this.data = data;
            this.validator = validator;
            this.passwordHasher = passwordHasher;
        }

        public HttpResponse Login() => this.View();

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

        public HttpResponse Register() => this.View();

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

        public HttpResponse Logout()
        {
            this.SignOut();
            return Redirect("/");
        }
    }
}
