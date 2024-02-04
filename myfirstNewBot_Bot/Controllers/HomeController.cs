using Microsoft.AspNetCore.Mvc;
using myfirstNewBot_Bot.Models;
using System.Diagnostics;

namespace myfirstNewBot_Bot.Controllers
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

        public string GetPerson(int id, string name, int age) => $"Id: {id} Name: {name} Age: {age}";

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
