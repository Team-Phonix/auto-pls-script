using System;
using System.Threading;
using System.Threading.Tasks;
using Discord.WebSocket;

namespace ZalocaScript_Solo
{
    internal struct Program
    {
        #region Variables
        /// <summary>
        /// The token.
        /// </summary>
        private const string token1 = "mfa.nLzee-2Kh6YediPfXH1PV7KT06Ql1zZpgw6OX7Y9NpraytTLpuItKVHY1BIdhL_Z6LVtTY2T5QTmkfNXVVPM";

        /// <summary>
        /// The Discord instance.
        /// </summary>
        private static DiscordSocketClient client;
        #endregion


        private static async Task Main()
        {
            Console.WriteLine("Connecting...");
            await initialize_client();
            Console.WriteLine("Done");
            client.Connected += ClientOnReady;
            client.Disconnected += ClientOnDisconnected;
            await Task.Delay(-1);
        }


        private static Task ClientOnDisconnected(Exception arg)
        {
            Console.WriteLine($"Failed Connecting: {arg}");
            return Task.CompletedTask;
        }


        private static Task ClientOnReady()
        {
            Console.WriteLine($"Ready and connected as {client.CurrentUser.Username}#{client.CurrentUser.Discriminator}!");
            start_sending();
            return Task.CompletedTask;
        }

        private static void start_sending() => new Thread(async () =>
        {
            const string beg = "pls beg", dep = "pls dep all", hunt = "pls hunt", fish = "pls fish";
            const ushort wait = 45000;
            const ulong guild = 781908450854174731, channel = 825806449598267452;
            while (true)
            {
                await client.GetGuild(guild).GetTextChannel(channel).SendMessageAsync(beg);
                await client.GetGuild(guild).GetTextChannel(channel).SendMessageAsync(dep);
                await client.GetGuild(guild).GetTextChannel(channel).SendMessageAsync(hunt);
                await client.GetGuild(guild).GetTextChannel(channel).SendMessageAsync(fish);
                await Task.Delay(wait);
            }
        }).Start();


        private static async Task initialize_client()
        {
            client = new DiscordSocketClient();
            await client.LoginAsync(0, token1);
            await client.StartAsync();
        }
    }
}
