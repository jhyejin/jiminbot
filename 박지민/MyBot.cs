using Discord;
using Discord.Commands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 박지민
{
    class MyBot
    {
        DiscordClient discord;

        public MyBot()
        {
            discord = new DiscordClient(x =>
            {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });

            discord.UsingCommands(x =>
            {
                x.PrefixChar = '!';
                x.AllowMentionPrefix = true;
            });

            var commands = discord.GetService<CommandService>();

            commands.CreateCommand("help")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("For any questions or problems, please message @jeonhyejin^^");
                });

            discord.ExecuteAndWait(async () =>
            {
                await discord.Connect("MzE0OTM0ODE3ODQwMDM3ODg4.DAAHRw.vuUEeukwAcnFBvbRN2YmAqbJIVk", TokenType.Bot);
            });
        }

        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
