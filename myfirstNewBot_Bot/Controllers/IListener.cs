using Telegram.Bot.Types;

namespace myfirstNewBot_Bot.Controllers
{
    public interface IListener
    {
        public async Task GetUpdate(Update update) { }

        public CommandExecutor Exceutor { get; }
    }
}
