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
        public static DateTime StartupTime = DateTime.Now;

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

            help.HelpCommands(commands, discord);

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
                    await e.Channel.SendMessage("*```help [command] (type 'all' for a list of all available commands.)```*");
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
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"{i}" + " Was send successfully");
                        Console.ForegroundColor = ConsoleColor.White;

                    }
                });
            commands.CreateCommand("haha")
                .Description("Laughing")
                .Do(async (e) =>
                {
                    await e.Channel.SendTTSMessage("Hahahahahahahahahaha! Hahahahahahahahahahahahahahahahahahahaha! Ha! Ha! Haha!");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"[{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second},{DateTime.Now.Millisecond}] [{e.User.Name}] Used *haha");
                    Console.ForegroundColor = ConsoleColor.White;
                });
            commands.CreateCommand("shut up")
                .Description("sends an Image that sais Shut up")
                .Do(async (e) =>
                {
                    await e.Channel.SendFile(@"./Img/shut-up.jpg");
                });

            commands.CreateCommand("uptime")
                .Do(async (e) =>
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"[{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second},{DateTime.Now.Millisecond}] [{e.User.Name}] Used *uptime");
                    Console.ForegroundColor = ConsoleColor.White;
                    await e.Channel.SendMessage($"the bot is now {DateTime.Now - StartupTime} active");
                });

            //It is HIGHLY reccomended that *infspam and *infttsspam are disabled by default!
            /*commands.CreateCommand("infttsspam")
                .Description("Keep sending TTS messages until the bot is disabled")
                .Do(async (e) =>
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"[{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second},{DateTime.Now.Millisecond}] [{e.User.Name}] Used *InfTTSspam");
                    Console.ForegroundColor = ConsoleColor.White;
                    for (int i = 0; i >= 0; i++)
                    {
                        await Task.Delay(1001);
                        await e.Channel.SendTTSMessage($"{i.ToString()}");
                        Console.WriteLine($"{i}" + " Was send successfully via TTS");

                    }
                });*/
        }

        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine($"[{e.Source}] [{e.Message}]");
        }
    }
}
