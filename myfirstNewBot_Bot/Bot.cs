using Telegram.Bot;

namespace myfirstNewBot_Bot
{
    public class Bot
    {
        private static TelegramBotClient client { get; set; }

        public static TelegramBotClient GetTelegramBot()
        {
            if (client != null)
            {
                return client;
            }
            ///токен, который дал @BotFather
            client = new TelegramBotClient("6851420206:AAE5RUoAgiTF6V1zgUTQr5tOxbi2tDsl-Kg");
            return client;
        }
    }
}
