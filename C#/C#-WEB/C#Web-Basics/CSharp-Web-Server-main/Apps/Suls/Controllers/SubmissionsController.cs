using MyWebServer.Controllers;
using MyWebServer.Http;
using Suls.Data.Models;
using Suls.Services;
using Suls.ViewModels.Submissions;
using SulsApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suls.Controllers
{
    public class SubmissionsController : Controller
    {
        private readonly SulsDbContext data;
        private readonly ISubmissionsService submissionsService;

        public SubmissionsController(SulsDbContext data, ISubmissionsService submissionsService)
        {
            this.data = data;
            this.submissionsService = submissionsService;
        }

        [Authorize]
        public HttpResponse Create(string id)
        {
            var name = this.data.Problems
                .Where(p => p.Id == id)
                .FirstOrDefault()
                .ToString();

            var viewModel = new CreateSubmissionViewModel()
            {
                Id = id,
                Name = name
            };

            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Create(string problemId, string code)
        {
            //page throw error for 2 constructors 

            if (string.IsNullOrEmpty(code) || code.Length < 30 || code.Length > 800)
            {
                //return this.Error("Code should be between 30 and 800 characters.");

                return this.Redirect("/Submissions/Create");
            }

            var userId = this.GetUserId();

            this.submissionsService.Create(problemId, code, userId);

            return this.Redirect("/");
        }

        [Authorize]
        public HttpResponse Delete(string id)
        {
            var submission = this.data
                .Submissions
                .FirstOrDefault(s => s.Id == id);

            this.data.Submissions.Remove(submission);
            this.data.SaveChanges();

            return Redirect("/");
        }
    }
}
