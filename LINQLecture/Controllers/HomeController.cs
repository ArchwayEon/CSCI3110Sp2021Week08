using LINQLecture.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LINQLecture.Controllers
{
   public class HomeController : Controller
   {
      private readonly ILogger<HomeController> _logger;

      public HomeController(ILogger<HomeController> logger)
      {
         _logger = logger;
      }

      public IActionResult Index()
      {
         return View();
      }

      public IActionResult LambdaExamples()
      {
         Func<double, double> Square = (x) => x * x;
         Func<double, double, double> Pow = (x, y) => Math.Pow(x, y);
         Action HelloWorld = () =>
         {
            _logger.LogInformation("Hello, World!");
         };
         Action<string> GreetWorld = (message) =>
         {
            string greeting = $"{message}, World!";
            _logger.LogInformation(greeting);
         };
         HelloWorld();
         GreetWorld("Hi");
         return Content($"5^2={Square(5)} 2^10={Pow(2,10)}");
      }

      public IActionResult Privacy()
      {
         return View();
      }

      [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
      public IActionResult Error()
      {
         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
      }
   }
}
