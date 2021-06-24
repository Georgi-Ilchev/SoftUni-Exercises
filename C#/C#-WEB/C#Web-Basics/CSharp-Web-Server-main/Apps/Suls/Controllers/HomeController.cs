using MyWebServer.Controllers;
using MyWebServer.Http;
using Suls.ViewModels.Problems;
using SulsApp.Data;
using System.Linq;

namespace Suls.Controllers
{
    public class HomeController : Controller
    {
        private readonly SulsDbContext data;

        public HomeController(SulsDbContext data)
        {
            this.data = data;
        }

        public HttpResponse Index()
        {
            if (this.User.IsAuthenticated)
            {
                var viewModel = this.data
                    .Problems
                    .Select(p => new DisplayAllProblemsViewModel()
                    {
                        Id = p.Id,
                        Count = p.Submissions.Count,
                        Name = p.Name
                    })
                    .ToList();

                return this.View(viewModel, "IndexLoggedIn");
            }

            return this.View();
        }
    }
}
