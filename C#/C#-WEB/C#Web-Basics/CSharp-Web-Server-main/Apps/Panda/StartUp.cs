using Microsoft.EntityFrameworkCore;
using MyWebServer;
using MyWebServer.Controllers;
using MyWebServer.Results.Views;
using Panda.Data;
using System.Threading.Tasks;

namespace Panda
{
    public class StartUp
    {
        public static async Task Main()
             => await HttpServer
                 .WithRoutes(routes => routes
                     .MapStaticFiles()
                     .MapControllers())
                 .WithServices(services => services
                     .Add<IViewEngine, CompilationViewEngine>()
                     //.Add<IValidator, Validator>()
                     //.Add<IPasswordHasher, PasswordHasher>()
                     .Add<PandaDbContext>())
                 .WithConfiguration<PandaDbContext>(c => c.Database.Migrate())
                 .Start();

        //Add-Migration UserProductTables -o Data/Migrations
    }
}
