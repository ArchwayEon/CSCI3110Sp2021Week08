using LINQLecture.ExtensionClasses;
using LINQLecture.Models;
using LINQLecture.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQLecture.Controllers
{
   public class HomeController : Controller
   {
      private readonly ISupplierPartsRepository _supplierPartsRepo;
      private readonly ILogger<HomeController> _logger;

      public HomeController(ISupplierPartsRepository supplierPartsRepo, ILogger<HomeController> logger)
      {
         _supplierPartsRepo = supplierPartsRepo;
         _logger = logger;
      }

      public IActionResult Index()
      {
         return View();
      }

      public IActionResult FilteringEM()
      {
         ViewData["Message"] = "Parts that cost less than 12.0 (Extension Method syntax)";
         var query = _supplierPartsRepo.ReadAllSupplierParts();
         // Extension method syntax
         var model = query.Where(sp => sp.Price < 12.0m);
         return View("PartSupplierPrice", model);
      }

      public IActionResult FilteringQ()
      {
         ViewData["Message"] = "Parts that cost less than 12.0 (Query syntax)";
         var query = _supplierPartsRepo.ReadAllSupplierParts();
         // Query syntax
         var model = from sp in query
                     where sp.Price < 12.0m
                     select sp;
         return View("PartSupplierPrice", model);
      }

      public IActionResult SortingEM()
      {
         ViewData["Message"] = "Parts sorted by price then by name (EM)";
         var query = _supplierPartsRepo.ReadAllSupplierParts();
         // Extension method syntax
         var model = query
            .OrderBy(sp => sp.Price)
            .ThenBy(sp => sp.Part.Name);
         return View("PartSupplierPrice", model);
      }

      public IActionResult SortingQ()
      {
         ViewData["Message"] = "Parts sorted by price then by name (Q)";
         var query = _supplierPartsRepo.ReadAllSupplierParts();
         var model = from sp in query
                     orderby sp.Price, sp.Part.Name
                     select sp;
         return View("PartSupplierPrice", model);
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

      public IActionResult Sets()
      {
         int[] twos = { 0, 2, 4, 6, 8, 10, 12, 14 };
         int[] threes = { 0, 3, 6, 9, 12, 15, 18, 21 };
         var data = new StringBuilder();
         data.Append("Twos: " + string.Join(",", twos) + "\n");
         data.Append("Threes: " + string.Join(",", threes) + "\n");
         data.Append('\n');

         var q1 = twos.Except(threes);
         data.Append("Twos except threes\n");
         data.Append(string.Join(",", q1.ToArray()));
         data.Append('\n');

         var q2 = twos.Intersect(threes);
         data.Append("Twos intersect threes\n");
         data.Append(string.Join(",", q2.ToArray()));
         data.Append('\n');

         return Content(data.ToString());
      }


      public IActionResult ExtensionMethodExamples()
      {
         string name = "Jeffrey"; // The middle character is 'f'
         // Using the static class with the static method
         char middle1 = StringExtensionsNotQuite.MiddleChar(name);
         // Using the static class with the extension method
         // Note that the extension method is called as if it's part
         // of the string class
         char middle2 = name.MiddleChar();
         return Content($"The middle character of {name} is {middle1} {middle2}");
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
