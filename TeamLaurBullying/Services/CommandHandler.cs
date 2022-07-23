using Discord.Commands;
using Discord.WebSocket;
using System.Reflection;

namespace TeamLaurBullying.Services
{
    public class CommandHandler
    {
        private readonly DiscordSocketClient _client;
        private readonly CommandService _commands;

        public CommandHandler(DiscordSocketClient client, CommandService commands, IServiceProvider services)
        {
            _client = client;
            _commands = commands;
        }

        public async Task InstallCommandsAsync()
        {
            _client.MessageReceived += HandleCommandAsync;

            await _commands.AddModulesAsync(assembly: Assembly.GetEntryAssembly(), services: null);
        }

        private async Task HandleCommandAsync(SocketMessage arg)
        {
            Console.WriteLine(arg.ToString());

            var message = arg as SocketUserMessage;
            if (message == null) return;

            int argPos = 0;
            var context = new SocketCommandContext(_client, message);

            if (!(message.HasCharPrefix('T', ref argPos) || message.HasMentionPrefix(_client.CurrentUser, ref argPos)) || message.Author.IsBot) return;

            await _commands.ExecuteAsync(context: context, argPos: argPos, services: null);
        }
    }
}