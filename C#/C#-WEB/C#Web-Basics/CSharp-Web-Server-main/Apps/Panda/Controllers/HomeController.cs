using MyWebServer.Controllers;
using MyWebServer.Http;

namespace Panda.Controllers
{
    public class HomeController : Controller
    {
        public HttpResponse Index()
        {
            //if (this.User.IsAuthenticated)
            //{
            //    return Redirect("/Trips/All");
            //}

            return View();
        }
    }
}
