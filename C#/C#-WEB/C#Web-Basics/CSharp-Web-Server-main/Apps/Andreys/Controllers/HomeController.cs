namespace Andreys.Controllers
{
    using Andreys.Services;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    public class HomeController : Controller
    {
        //private readonly IProductService productService;

        //public HomeController(IProductService productService)
        //{
        //    this.productService = productService;
        //}

        public HttpResponse Index()
        {
            return View();
        }

        //public HttpResponse Home()
        //{
        //    var viewModel = this.productService.DisplayAll();
        //    return View(viewModel);
        //}
    }
}
