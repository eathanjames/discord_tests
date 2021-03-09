using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using Discord.Commands;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Microsoft.VisualBasic;

namespace WaffleGangBot.Modules
{
    [Name("Say")]
    public class SayModule : ModuleBase<SocketCommandContext>
    {
        [Command("say"), Alias("s")]
        [Summary("Make the bot say something")]
        public Task Say([Remainder]string text) => ReplyAsync(text);
        
        [Command("echo"), Alias("e")]
        [Summary("Make the bot say something, then repeat again 10 seconds later")]
        public Task Echo([Remainder] string text)
        { 
            ReplyAsync(text);
            return Task.Delay(10000).ContinueWith(t => ReplyAsync(text));
        }
    }
    
    [Name("UserInfo")]
    public class IdentifyModule : ModuleBase<SocketCommandContext>
    {
        [Command("UserInfo"), AliasAttribute("user", "whois")]
        [Summary("Returns information about the current user, or one that is passed in")]
        public async Task UserInfoAsync(
            [Summary("The (optional) user to get info from")]
            IGuildUser user = null)
        {
            var userInfo = user ?? Context.Guild.CurrentUser;
            if(userInfo.IsBot)
            {
                await ReplyAsync("Beep boop bot time");
            }
            else if(userInfo.Nickname == "Greg" || userInfo.Username == "Greg")
            {
                await ReplyAsync("Greggy Eggy Weggy");
            }
            else if(userInfo.Nickname == "KickflipKing" || userInfo.Username == "KickflipKing")
            {
                await ReplyAsync("Landlord Daddy");
            }            
            else if(userInfo.Nickname == "Eathan" || userInfo.Username == "Eathan")
            {
                await ReplyAsync("Daddy Sempai uWu");
            }           
            else if(userInfo.Nickname == "Wallis" || userInfo.Username == "Wallis")
            {
                await ReplyAsync("");
            }
            else await ReplyAsync(userInfo.Mention);
        }
    }
    
    [Name("Toms Shame")]
    public class VRModule : ModuleBase<SocketCommandContext>
    {
        [Command("vr"), Alias("vive", "tom")]
        [Summary("How many days since Tom orders VR")]
        public Task DaysSinceAsync()
        {
            var startDate = new DateTime(2021, 01, 17);
            var daysCount = (DateTime.Now - startDate).Days;
            return ReplyAsync(daysCount.ToString(CultureInfo.InvariantCulture) + " days since Tom ordered his VR set.");
        }
    }
}