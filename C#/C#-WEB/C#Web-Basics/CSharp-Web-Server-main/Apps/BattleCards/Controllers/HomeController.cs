using MyWebServer.Controllers;
using MyWebServer.Http;

namespace BattleCards.Controllers
{
    public class HomeController : Controller
    {
        public HttpResponse Index()
        {
            if (this.User.IsAuthenticated)
            {
                return Redirect("/Cards/All");
            }

            return View();
        }
    }
}
