using Telegram.Bot.Types;
using Telegram.Bot;

namespace myfirstNewBot_Bot.Controllers.Commands
{
    public class RegisterCommand : ICommand, IListener
    {


        public TelegramBotClient Client => Bot.GetTelegramBot();
        public string Name => "/Регистрация";
        public CommandExecutor Exceutor { get; }
        public RegisterCommand(CommandExecutor exceutor)
        {
            Exceutor = exceutor;
        }
        private string? phone;
        private string? name;
        public async Task ExecuteAsync(Update update)
        {
            long chatId = update.Message.Chat.Id;
            Exceutor.StartListen(this);
            await Client.SendTextMessageAsync(chatId, $"Введите номер!");
        }

        public async Task GetUpdate(Update update)
        {
            long chatId = update.Message.Chat.Id;
            if (update.Message.Text == null) return;

            if (phone == null)
            {
                phone = update.Message.Text;
                await Client.SendTextMessageAsync(chatId, "Введите имя!");
            }
            else
            {
                name = update.Message.Text;
                await Client.SendTextMessageAsync(chatId, "Регистрация завершена!");
                Exceutor.StopListen();
            }

        }
    }
}
