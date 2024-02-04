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
            client = new TelegramBotClient("6274205942:AAG2jfNAVC9eaRI2A4-Pkbgi9NYSIo8Akdg");
            return client;
        }
    }
}
