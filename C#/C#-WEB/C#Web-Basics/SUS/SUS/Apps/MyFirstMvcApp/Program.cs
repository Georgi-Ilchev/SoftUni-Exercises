namespace MyFirstMvcApp
{
    using MyFirstMvcApp.Controllers;
    using SUS.HTTP;
    using System.Threading.Tasks;
    class Program
    {
        static async Task Main(string[] args)
        {
            IHttpServer server = new HttpServer();

            server.AddRoute("/", new HomeController().Index);

            server.AddRoute("/favicon.ico", new StaticFilesController().Favicon);

            server.AddRoute("/about", new HomeController().About);

            server.AddRoute("/users/login", new UsersController().Login);

            server.AddRoute("/users/register", new UsersController().Register);

            await server.StartAsync(80);
        }
    }
}
