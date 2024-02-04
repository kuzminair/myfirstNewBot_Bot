using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using myfirstNewBot_Bot.Models;
using Telegram.Bot;
using Telegram.Bot.Types;


namespace myfirstNewBot_Bot.Controllers
{
        [ApiController]
        [Route("/")]
        public class BotController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static UpdateDistributor<CommandExecutor> _distributor = new UpdateDistributor<CommandExecutor>();
        public BotController(ILogger<HomeController> logger)
        {

            _logger = logger;
        }
        [HttpPost]
        public async void Post(Update update)
        {
            if (update.Message == null) return;

            await _distributor.GetUpdate(update);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return View();
        }
        
        
        [HttpPost("Bot/But")]
        public async Task But([FromForm] MessageModel mes)
        {
            return;
        }




    }
    }

