using Microsoft.Extensions.DependencyInjection;
using System;

namespace OOP___Solid
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceProvider service = new ServiceCollection()
                .AddScoped<IReader, Reader>()
                .AddScoped<IWriter, SuperWriter>()
                //AddScoped<IWriter, Writer>()
                .AddScoped<Copy, Copy>()
                .BuildServiceProvider();

            //IReader reader = service.GetService<IReader>();
            //IWriter writer = service.GetService<IWriter>();

            Copy cp = service.GetService<Copy>();

            cp.CopyAllChars();
        }
    }
}
