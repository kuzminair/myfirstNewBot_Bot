﻿using myfirstNewBot_Bot.Controllers.Commands;
using System.Windows.Input;
using Telegram.Bot.Types;
using ICommand = myfirstNewBot_Bot.Controllers.Commands.ICommand;
namespace myfirstNewBot_Bot.Controllers
{
    public class CommandExecutor : ITelegramUpdateLister
    {
        private List<ICommand> commands;
        private IListener? listener = null;


        public CommandExecutor()
        {
            commands = new List<ICommand>()
            {
                new StartCommand(), new RegisterCommand(this) /// Здесь добавляем наши команды

            };
        }


        public async Task GetUpdate(Update update)
        {

            if (listener == null)
            {
                await ExecuteCommand(update);
            }
            else
            {
                await listener.GetUpdate(update);
            }


        }

        private async Task ExecuteCommand(Update update)
        {
            Message msg = update.Message;


            foreach (var command in commands)
            {
                if (command.Name == msg.Text)
                {
                    await command.ExecuteAsync(update);
                }
            }
        }

        public void StartListen(IListener newListener)
        {
            listener = newListener;
        }

        public void StopListen()
        {
            listener = null;
        }
    }
}
