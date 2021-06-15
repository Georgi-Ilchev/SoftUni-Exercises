namespace MyWebServer.App.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    public class CatsController : Controller
    {
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
