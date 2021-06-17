namespace MyWebServer.App.Controllers
{
    using MyWebServer.App.Data;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System.Linq;

    public class CatsController : Controller
    {
        private readonly IData data;

        public CatsController(IData data)
        {
            this.data = data;
        }

        public HttpResponse All()
        {
            var cats = this.data.Cats.ToList();

            return View(cats);
        }

        public HttpResponse AllHtml()
        {
            var cats = this.data.Cats.ToList();

            var result = "<h1>All cats in the system:</h1>";
            result += "<ul>";

            foreach (var cat in cats)
            {
                result += "<li>";
                result += cat.Name + "-" + cat.Age;
                result += "</li>";
            }
            result += "</ul>";

            return Html(result);
        }

        [HttpGet]
        public HttpResponse Create() => View();

        [HttpGet]
        public HttpResponse Save(string name, int age)
        {
            //var name = this.Request.Form["Name"];
            //var age = this.Request.Form["Age"];

            return Text($"{name} - {age}");
        }
    }
}
