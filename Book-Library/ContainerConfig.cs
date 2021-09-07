using Autofac;
using Book_Library.Infrastructure;
using Book_Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Library
{
    class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<BusinessLogic>().As<IBusinessLogic>();
            builder.RegisterType<JsonTakenBookData>().As<ITakenBookData>();
            builder.RegisterType<TakenBookService>().As<ITakenBookService>();
            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<BookService>().As<IBookService>();
            builder.RegisterType<JsonBookData>().As<IBookData>();
            return builder.Build();
        }
    }
}
