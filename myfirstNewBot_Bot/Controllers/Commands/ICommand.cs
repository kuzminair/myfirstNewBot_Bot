using Telegram.Bot.Types;
using Telegram.Bot;

namespace myfirstNewBot_Bot.Controllers.Commands
{
    public interface ICommand
    {
        public TelegramBotClient Client { get; }

        public string Name { get; }

        public async Task ExecuteAsync(Update update) { }

    }
}
