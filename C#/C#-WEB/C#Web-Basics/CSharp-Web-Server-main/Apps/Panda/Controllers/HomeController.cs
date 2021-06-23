using MyWebServer.Controllers;
using MyWebServer.Http;
using Panda.Data;
using Panda.ViewModels.Home;
using System.Linq;

namespace Panda.Controllers
{
    public class HomeController : Controller
    {
        private readonly PandaDbContext data;

        public HomeController(PandaDbContext data)
        {
            this.data = data;
        }

        public HttpResponse Index()
        {
            if (this.User.IsAuthenticated)
            {
                var userId = this.GetUserId();

                var user = this.data.Users
                                    .FirstOrDefault(u => u.Id == userId);

                var viewModel = new IndexLoggedInViewModel()
                {
                    Username = user.Username
                };

                return this.View(viewModel, "IndexLoggedIn");
            }

            return View();
        }
    }
}
