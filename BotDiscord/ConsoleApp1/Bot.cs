using System;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using DSharpPlus.Interactivity;
using Microsoft.Extensions.Logging;
using DSharpPlus.Entities;

namespace Bot { 

    public class Bot
    {
        private DiscordClient _cliente;

        static void Main() => new Bot();

        public async Task RodarBotAssicrono()
        {
            DiscordConfiguration cfgBot = new DiscordConfiguration()
            {
                Token = "token",
                TokenType = TokenType.Bot,
                ReconnectIndefinitely = true,
                GatewayCompressionLevel = GatewayCompressionLevel.Stream,
                AutoReconnect = true,
                MinimumLogLevel = LogLevel.Debug,
            };

            _cliente = new DiscordClient(cfgBot);
            _cliente.Ready += cliente_Pronto;

            string[] Prefixo = new string[1];
            Prefixo[0] = "!";

            CommandsNextExtension ComandosBot = _cliente.UseCommandsNext(new CommandsNextConfiguration()
            {
                StringPrefixes = Prefixo,
                EnableDms = false,
                CaseSensitive = false,
                EnableDefaultHelp = false,
                EnableMentionPrefix = true,
                IgnoreExtraArguments = true
            });

          ComandosBot.CommandExecuted += ComandosBot_ExecutarCommando;

            await _cliente.ConnectAsync();
            await Task.Delay(-1);


        }

        private Task cliente_Pronto(ReadyEventArgs e)
        {
            
            _cliente.Logger.LogDebug($"Bot onlline ,{DateTime.Now} " ,e);
            _cliente.UpdateStatusAsync(new DiscordActivity("ajuda!", ActivityType.Playing),UserStatus.Online);
         }

    }

      
}
