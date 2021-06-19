using MyWebServer.Controllers;
using MyWebServer.Http;

namespace Git.Controllers
{
    public class HomeController : Controller
    {
        public HttpResponse Index()
            => View();
    }
}
