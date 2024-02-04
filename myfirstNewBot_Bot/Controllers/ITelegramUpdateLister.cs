using Telegram.Bot.Types;

namespace myfirstNewBot_Bot.Controllers
{
    public interface ITelegramUpdateLister
    {
        Task GetUpdate(Update update);
    }
}
