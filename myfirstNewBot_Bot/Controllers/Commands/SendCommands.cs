using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InlineQueryResults;

namespace myfirstNewBot_Bot.Controllers.Commands
{
    public class SendCommands : ICommand
    {
        public TelegramBotClient Client => Bot.GetTelegramBot();

        public string Name { get; set; }         
        
        public async Task ExecuteAsync(Update update)
        {
            long chatId = update.Message.Chat.Id;
            var msg = update.Message;
            if(msg.Photo!=null)
            {                           
                var idFile = update.Message.Photo.Last().FileId;
                var stringFile = await Client.GetFileAsync(idFile);
                var path = stringFile.FilePath;
                string savePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\file.jpg";
                await using FileStream fileStream = System.IO.File.OpenWrite(savePath);
                await Client.DownloadFileAsync(path, fileStream);
                fileStream.Close();
                await using Stream stream = System.IO.File.OpenRead(savePath);
                Message message = await Client.SendPhotoAsync(chatId, InputFile.FromStream(stream: stream,fileName: "fileBack.jpg"));
                return;

            }
            if (msg.Document != null)
            {
                var idFile = update.Message.Document.FileId;
                var stringFile = await Client.GetFileAsync(idFile);
                var path = stringFile.FilePath;
                string savePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\{msg.Document.FileName}";
                await using FileStream fileStream = System.IO.File.OpenWrite(savePath);
                await Client.DownloadFileAsync(path, fileStream);
                fileStream.Close();            
                await using Stream stream = System.IO.File.OpenRead(savePath);
                Message message = await Client.SendDocumentAsync(chatId,InputFile.FromStream(stream, msg.Document.FileName));
                return;
            }
            if (msg.Video != null)
            {
                var idFile = update.Message.Video.FileId;
                var stringFile = await Client.GetFileAsync(idFile);
                var path = stringFile.FilePath;
                string savePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\{msg.Video.FileName}";
                await using FileStream fileStream = System.IO.File.OpenWrite(savePath);
                await Client.DownloadFileAsync(path, fileStream);
                fileStream.Close();
                await using Stream stream = System.IO.File.OpenRead(savePath);
                Message message = await Client.SendVideoAsync(chatId, InputFile.FromStream(stream, msg.Video.FileName));
                return;
            }
            if (msg.Audio != null)
            {
                var idFile = update.Message.Audio.FileId;
                var stringFile = await Client.GetFileAsync(idFile);
                var path = stringFile.FilePath;
                string savePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\{msg.Audio.FileName}";
                await using FileStream fileStream = System.IO.File.OpenWrite(savePath);
                await Client.DownloadFileAsync(path, fileStream);
                fileStream.Close();
                await using Stream stream = System.IO.File.OpenRead(savePath);
                Message message = await Client.SendAudioAsync(chatId, InputFile.FromStream(stream, msg.Audio.FileName));
                return;
            }
        }

    }
}
