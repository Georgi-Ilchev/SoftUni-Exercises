using MyWebServer.Controllers;
using MyWebServer.Http;
using Suls.Data.Models;
using Suls.Services;
using Suls.ViewModels.Problems;
using SulsApp.Data;
using System;
using System.Linq;

namespace Suls.Controllers
{
    public class ProblemsController : Controller
    {
        private readonly SulsDbContext data;
        private readonly IValidator validator;

        public ProblemsController(SulsDbContext data, IValidator validator)
        {
            this.data = data;
            this.validator = validator;
        }

        [Authorize]
        public HttpResponse Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Create(CreateProblemViewModel model)
        {
            var modelErrors = this.validator.ValidateProblem(model);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var problem = new Problem()
            {
                Name = model.Name,
                Points = model.Points,
            };

            this.data.Problems.Add(problem);
            this.data.SaveChanges();

            return Redirect("/");
        }
    }
}
