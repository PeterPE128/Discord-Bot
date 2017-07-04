using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace BSBot
{
    class help
    {
        internal static void HelpCommands(CommandService commands, DiscordClient discord)
        {
            //help entry opening
            var begin = "***Displaying help for:***";

            //help entry ending
            var end = "*```(There are no further entries available on this subject)```*";

            //Variable to store all the data from *help help
            var hemoglobin = new List<String>();

            //Variable to store all the data from *help all
            var helplist = new List<String>();

            //Variable to store all the data from *infspam and *infttsspam
            var SpamHelp = new List<String>();

            //help commands:


            //help all
            commands.CreateCommand("help all")
                .Description("shows all commands in a neat list")
                .Do(async (e) =>
                {
                    helplist.Add("***A list of all commands:***");
                    helplist.Add("=================================");
                    helplist.Add("help");
                    helplist.Add("*`Description: shows help`*");
                    helplist.Add("**`Usage: *help [command] (type 'all' for a list of all available commands.)`**");
                    helplist.Add(" ");
                    helplist.Add("infspam");
                    helplist.Add("*`Description: sends a value until the bot is stopped`*");
                    helplist.Add("**`Usage: *infspam`**");
                    helplist.Add(" ");
                    helplist.Add("haha");
                    helplist.Add("*`Description: sends a laughing TTS (Text-To-Speech) Message`*");
                    helplist.Add("**`Usage: *haha`**");
                    await e.Channel.SendMessage(string.Join("\n", helplist));
                    Console.Write(string.Join("\n", helplist));
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"[{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second},{DateTime.Now.Millisecond}] [{e.User.Name}] Used *help all");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" ");
                });

            //help help

            commands.CreateCommand("help help")
                .Description("see *help in file MyBot.cs")
                .Do(async (e) =>
                {
                    hemoglobin.Add("***Displaying help for:***");
                    hemoglobin.Add("`*help`");
                    hemoglobin.Add("*`Description: shows help`*");
                    hemoglobin.Add("**`Usage: *help [command] (type 'all' for a list of all available commands.)`**");
                    hemoglobin.Add(" ");
                    hemoglobin.Add(end);
                    await e.Channel.SendMessage(string.Join("\n", hemoglobin));
                    Console.Write(string.Join("\n", hemoglobin));
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"[{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second},{DateTime.Now.Millisecond}] [{e.User.Name}] Used *help help");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" ");

                });

            //help infspam and help infttsspam
            commands.CreateCommand("help infspam")
                .Alias(new string[] {"help infttsspam"})
                .Do(async (e) =>
                {
                    SpamHelp.Add(begin);
                    SpamHelp.Add("`*infspam and *infttsspam`");
                    SpamHelp.Add("*`Description: keeps sending messages until the bot is stopped.`*");
                    SpamHelp.Add("**`Usage: *infspam`**");
                    SpamHelp.Add(" ");
                    SpamHelp.Add("***Aternatives:***");
                    SpamHelp.Add("`*infttsspam`");
                    SpamHelp.Add("*`Description: keeps sending Text-to-Speech messages until the bot is stopped. (Warning: due to its high annoyance factor, this command is DISABLED by default!)`*");
                    SpamHelp.Add("**`Usage: *infttsspam`**");
                    SpamHelp.Add(" ");
                    SpamHelp.Add(end);
                    await e.Channel.SendMessage(string.Join("\n", SpamHelp));
                    Console.Write(string.Join("\n", SpamHelp));
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"[{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second},{DateTime.Now.Millisecond}] [{e.User.Name}] Used *help infspam or *help infttsspam");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" ");
                });

        }
    }
}
