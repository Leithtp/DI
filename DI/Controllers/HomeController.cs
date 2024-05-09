using DI.Services.Logger;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using static DI.Services.Logger.ConsoleLogger;

namespace DI.Controllers
{
    public class HomeController : Controller
    {
        ITransientLogger _transientLogger;
        ITransientLogger _transientLogger2;

        IScopedLogger _scopedLogger;
        IScopedLogger _scopedLogger2;

        ISingletonLogger _singletonLogger;
        ISingletonLogger _singletonLogger2;

        Func<int, string> _add;

        public HomeController(ITransientLogger transientLogger, ITransientLogger transientLogger2,
                                IScopedLogger scopedLogger, IScopedLogger scopedLogger2,
                                ISingletonLogger singletonLogger, ISingletonLogger singletonLogger2,
                                Func<int, string> add)
        {
            _transientLogger = transientLogger;
            _transientLogger2 = transientLogger2;

            _scopedLogger = scopedLogger;
            _scopedLogger2 = scopedLogger2;

            _singletonLogger = singletonLogger;
            _singletonLogger2 = singletonLogger2;
            _add = add;


        }

        public IActionResult Index()
        {
            Console.WriteLine("Transient:");
            _transientLogger.LogGuid();
            _transientLogger2.LogGuid();

            Console.WriteLine("Scoped:");
            _scopedLogger.LogGuid();
            _scopedLogger2.LogGuid();

            Console.WriteLine("Singleton:");
            _singletonLogger.LogGuid();
            _singletonLogger2.LogGuid();

            Console.WriteLine(_add.Invoke(1));

            return View();
        }

       


    }
}
