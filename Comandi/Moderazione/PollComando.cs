using System;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;

namespace KheetoNetworkBot.Comandi.Moderazione
{
    public class PollComando : BaseCommandModule
    {
        [Command("poll")]
        [Description("Manda un sondaggio con le reazioni date.")]
        [RequirePermissions(DSharpPlus.Permissions.ManageGuild)]
        public async Task Poll(CommandContext command, [Description("Durata")] TimeSpan duration, [Description("Reazioni possibili")] params DiscordEmoji[] options)
        {
            var interactivity = command.Client.GetInteractivity();
            var poll_options = options.Select(xe => xe.ToString());

            DiscordEmbedBuilder.EmbedFooter footer = new DiscordEmbedBuilder.EmbedFooter
            {
                Text = "Kheeto Network - Sondaggi",
                IconUrl = "https://cdn.discordapp.com/icons/654083852838502413/9a50cb8c9806ea2c26e36a0ea0bb76ec.webp?size=128",
            };

            var embed = new DiscordEmbedBuilder
            {
                Color = new DiscordColor("#CD0000"),
                Title = "Sondaggio",
                Description = string.Join(" ", poll_options),
                Footer = footer
            };

            var msg = await command.RespondAsync(embed);

            for (var i = 0; i < options.Length; i++)
                await msg.CreateReactionAsync(options[i]);

            var poll_result = await interactivity.CollectReactionsAsync(msg, duration);
            var results = poll_result.Where(xkvp => options.Contains(xkvp.Emoji))
                .Select(xkvp => $"{xkvp.Emoji}: {xkvp.Total}");

            await command.RespondAsync(string.Join("\n", results));
        }
    }
}

