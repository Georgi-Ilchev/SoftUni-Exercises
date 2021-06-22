using Microsoft.EntityFrameworkCore;
using MyWebServer;
using MyWebServer.Controllers;
using MyWebServer.Results.Views;
using SharedTrip.Data;
using System;
using System.Threading.Tasks;

namespace SharedTrip
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
                    //.Add<IUserService, UserService>()
                    .Add<SharedTipDbContext>())
                .WithConfiguration<SharedTipDbContext>(c => c.Database.Migrate())
                .Start();

        //Add-Migration UserProductTables -o Data/Migrations
    }

}
