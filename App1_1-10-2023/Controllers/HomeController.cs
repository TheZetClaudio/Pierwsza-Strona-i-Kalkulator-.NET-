using App1_1_10_2023.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace App1_1_10_2023.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Name = "Claudio";
            ViewBag.godzina = DateTime.Now.Hour;
            ViewBag.powitanie = ViewBag.godzina < 17 ? "Dzień Dobry" : "Dobry wieczor";
            return View();

            Dane[] osoby =
            {
                new Dane {Name = "Anna", Surname = "1"},
                new Dane {Name = "Jacek", Surname = "2"},
                new Dane {Name = "Wujt", Surname = "3"}

            }; return View(osoby);


        }
        public IActionResult UrodzinyForm()
        {
            return View();
        }
        public IActionResult Urodziny(Urodziny Urodziny)
        {
            ViewBag.powitanie = $"witaj {Urodziny.Imie} {DateTime.Now.Year - Urodziny.Rok}";
            return View();
        }
        public IActionResult Kalkulator(string firstNumber, string secondNumber, string Cal)
        {
            int a = Convert.ToInt32(firstNumber);
            int b = Convert.ToInt32(secondNumber);
            int c = 0;
            switch (Cal)
            {
                case "Add":
                    c = a + b;
                    break;
                case "Sub":
                    c = a - b;
                    break;
                case "Mul":
                    c = a * b;
                    break;
                case "Div":
                    c = a / b;
                    break;
            }
            ViewBag.Result = c;
            return View();

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}