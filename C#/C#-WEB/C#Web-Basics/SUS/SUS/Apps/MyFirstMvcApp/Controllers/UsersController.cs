namespace MyFirstMvcApp.Controllers
{
    using SUS.HTTP;
    using SUS.MvcFramework;
    public class UsersController : Controller
    {
        public HttpResponse Login(HttpRequest request)
        {
            return this.View();

            //var responseHtml = File.ReadAllText("Views/Users/Login.html");
            //var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            //var response = new HttpResponse("text/html", responseBodyBytes);

            //return response;
        }

        public HttpResponse Register(HttpRequest request)
        {
            return this.View();

            //var responseHtml = File.ReadAllText("Views/Users/Register.html");
            //var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            //var response = new HttpResponse("text/html", responseBodyBytes);

            //return response;
        }
    }
}
