using Discord.Commands;
using Discord;

namespace TeamLaurBullying.Modules
{
    public class MuteModule : ModuleBase<SocketCommandContext>
    {
        [Command("STFU")]
        [Alias("mute", "stfu", "shutup", "shut up", "su")]
        [Summary("Mutes anoying person")]
        public async Task STFU(IGuildUser user)
        {
            user.AddRoleAsync(1000459806395600996);
            Console.WriteLine("done");
        }
    }
}
