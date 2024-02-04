using Telegram.Bot.Types;
using Telegram.Bot;

namespace myfirstNewBot_Bot.Controllers.Commands
{
    public class StartCommand : ICommand
    {
        public TelegramBotClient Client => Bot.GetTelegramBot();


        public string Name => "/start";

        public async Task ExecuteAsync(Update update)
        {
            long chatId = update.Message.Chat.Id;
            string? userName = update.Message.From.Username;
            await Client.SendTextMessageAsync(chatId, $"Привет {userName}");
        }
    }
}
