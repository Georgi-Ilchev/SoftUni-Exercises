using Microsoft.EntityFrameworkCore;
using MyWebServer;
using MyWebServer.Controllers;
using MyWebServer.Results.Views;
using SulsApp.Data;
using System;
using System.Threading.Tasks;

namespace Suls
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
                    .Add<SulsDbContext>())
                .WithConfiguration<SulsDbContext>(c => c.Database.Migrate())
                .Start();

        //Add-Migration UserProductTables -o Data/Migrations
    }
}
