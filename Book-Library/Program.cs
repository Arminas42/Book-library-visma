using Autofac;
using Book_Library.Models;
using Book_Library.Services;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;

namespace Book_Library
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = ContainerConfig.Configure();

            using(var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();
                app.Run();
            }
        }
        
    }
}
