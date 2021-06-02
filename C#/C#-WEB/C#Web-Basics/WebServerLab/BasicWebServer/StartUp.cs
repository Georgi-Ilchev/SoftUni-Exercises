namespace BasicWebServer
{
    using BasicWebServer.Server;
    using BasicWebServer.Server.Results;
    using System.Threading.Tasks;
    public class StartUp
    {
        public static async Task Main(string[] args)
        {
            var server = new HttpServer(routes => routes
            .MapGet("/", new TextResponse("Hello from gosho!"))
            .MapGet("/Cats", new TextResponse("Hello from the cats!"))
            .MapGet("/Dogs", new TextResponse("<h1>Hello from the dogs!<h1>", "text/html")));

            await server.Start();
        }
    }
}
