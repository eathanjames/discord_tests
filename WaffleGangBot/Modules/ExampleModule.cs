using System.Threading;
using Discord.Commands;
using System.Threading.Tasks;

namespace WaffleGangBot.Modules
{
    [Name("Say")]
    public class SayModule : ModuleBase<SocketCommandContext>
    {
        [Command("say"), Alias("s")]
        [Summary("Make the bot say something")]
        public Task Say([Remainder]string text) => ReplyAsync(text);
    }

    [Name("Echo")]
    public class EchoModule : ModuleBase<SocketCommandContext>
    {
        [Command("echo"), Alias("e")]
        [Summary("Make the bot say something, then repeat again 10 seconds later")]
        public Task Echo([Remainder]string text) => ReplyAsync(text);
        
    }
}