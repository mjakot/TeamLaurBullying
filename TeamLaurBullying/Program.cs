using Discord;
using Discord.WebSocket;
using Discord.Commands;

namespace TeamLaurBullying
{
    public class Program
    {
        public static DiscordSocketClient _client;
        public static CommandService _commands;

        public static void Main(string[] args) => MainAsync().GetAwaiter().GetResult();

        private static async Task MainAsync()
        {
            _client = new DiscordSocketClient();
            _commands = new CommandService();

            var token = "token";

            _client.Log += _client_Log;
            _client.Ready += _client_Ready;

            _client.LoginAsync(TokenType.Bot, token);
            _client.StartAsync();

            await Task.Delay(-1);
        }

        private static Task _client_Ready()
        {

            _client.SetGameAsync("Your mom");
            
            return Task.CompletedTask;
        }

        private static Task _client_Log(LogMessage arg)
        {
            Console.WriteLine(arg.ToString());
            
            return Task.CompletedTask;
        }
    }
}