using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace BSBot
{
    class MyBot
    {
        public DiscordClient discord;
        public CommandService commands;

        public readonly string token = "Token";

        public MyBot()
        {
            discord = new DiscordClient(x =>
            {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });

            discord.UsingCommands(x =>
            {
                x.PrefixChar = '*';
                x.AllowMentionPrefix = true;
            });

            commands = discord.GetService<CommandService>();

            Commands();

            discord.ExecuteAndWait(async () =>
            {
                while (true)
                {
                    await discord.Connect(token, TokenType.Bot);
                    discord.SetGame("*help for help");
                    break;
                }

            });
        }

        private void Commands()
        {
            //commands
            
            commands.CreateCommand("help")
                .Description("Help with all Command problems (exept bugs)")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("**```Help Index```**");
                    await e.Channel.SendMessage("*```help [command] (type 'all' for all available commands)```*");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"[{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second},{DateTime.Now.Millisecond}] [{e.User.Name}] Used *help");
                    Console.ForegroundColor = ConsoleColor.White;

                });

            commands.CreateCommand("infspam")
                .Description("Keep sending messages until the bot is disabled")
                .Do(async (e) =>
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"[{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second},{DateTime.Now.Millisecond}] [{e.User.Name}] Used *Infspam");
                    Console.ForegroundColor = ConsoleColor.White;
                    for (int i = 0; i >= 0; i++)
                    {
                        await Task.Delay(1001);
                        await e.Channel.SendMessage($"{i.ToString()}");
                        Console.WriteLine($"{i}" + " Was send successfully");

                    }
                });
        }

        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine($"[{e.Source}] [{e.Message}]");
        }
    }
}
