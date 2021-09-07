using Book_Library.Infrastructure;
using Book_Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Library
{
    public class Application : IApplication
    {
        IBusinessLogic _businessLogic;
        public Application(IBusinessLogic businessLogic)
        {
            _businessLogic = businessLogic;
        }
        public void Run()
        {
            _businessLogic.Menu();
            _businessLogic.ListenForCommand();
        }

    }
}
