namespace SUS.MvcFramework
{
    using SUS.HTTP;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public static class Host
    {
        public static async Task CreateHostAsync(List<Route> routeTable, int port = 80)
        {
            IHttpServer server = new HttpServer(routeTable);

            await server.StartAsync(port);
        }
    }
}
