namespace MyFirstMvcApp.Controllers
{
    using System;
    using SUS.HTTP;
    using SUS.MvcFramework;
    using MyFirstMvcApp.ViewModels;

    public class HomeController : Controller
    {
        public HttpResponse Index(HttpRequest request)
        {
            var viewModel = new IndexViewModel();

            viewModel.CurrentYear = DateTime.UtcNow.Year;
            viewModel.Message = "Welcome to Battle Cards";

            return this.View();
            //return this.View(viewModel);
        }
    }
}
