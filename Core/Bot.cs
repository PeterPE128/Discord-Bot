﻿using System;
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
        DiscordClient discord;
        CommandService commands;

        public Core()
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
                //x.HelpMode = HelpMode.Public;            
            });

            commands = discord.GetService<CommandService>();

            Commands();

            discord.ExecuteAndWait(async () =>
            {
                while (true)
                {
                    await discord.Connect("MzI5OTYwNTMzOTU4NzIxNTM2.DDaDSQ.jabWwMLnciD96RsnuPJHSFrS-1k", TokenType.Bot);
                    Console.WriteLine("Bot connected correctly");
                    discord.SetGame("*help for commands");
                    break;
                }
            });
        }


            private void Commands()
        {

        }

        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine($"[{e.Source}] {e.Message}");
        }

    }
}
