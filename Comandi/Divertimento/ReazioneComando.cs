using System;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;

namespace KheetoNetworkBot.Comandi.Divertimento
{
    public class ReazioneComando : BaseCommandModule
    {
        [Command("reazione")]
        [Description("Minigame - Il primo che reagisce vince.")]
        public async Task WaitForReaction(CommandContext command)
        {
            var interactivity = command.Client.GetInteractivity();

            var emoji = DiscordEmoji.FromName(command.Client, ":tada:");

            DiscordMessage messaggio = await command.RespondAsync($"Chi reagisce prima all'embed che sto per mandare con {emoji} vince!");

            var em = await interactivity.WaitForReactionAsync(xe => xe.Emoji == emoji && xe.Message == messaggio, command.User, TimeSpan.FromSeconds(60));
            if (!em.TimedOut)
            {
                await messaggio.RespondAsync((em.Result.User as DiscordMember).DisplayName + " ha vinto!");
            }
            else
            {
                await messaggio.RespondAsync("Nessuno ha reagito in tempo.");
            }
        }
    }
}

