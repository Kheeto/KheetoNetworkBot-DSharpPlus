using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

namespace KheetoNetworkBot.Comandi.Moderazione
{
    public class ImmagineComando : BaseCommandModule
    {
        [Command("Immagine")]
        [Description("Manda un immagine in un embed.")]
        public async Task Comando(CommandContext command, [Description("Link dell'immagine da convertire.")] string LinkImmagine)
        {

            if (LinkImmagine.Length == 0)
            {
                await command.RespondAsync("Manda il link di un immagine.");
                return;
            };

            DiscordEmbedBuilder.EmbedThumbnail thumbnail = new DiscordEmbedBuilder.EmbedThumbnail
            {
                Url = LinkImmagine,
            };

            DiscordEmbedBuilder.EmbedFooter footer = new DiscordEmbedBuilder.EmbedFooter
            {
                Text = command.Member.DisplayName,
                IconUrl = command.Message.Author.AvatarUrl
            };

            DiscordEmbedBuilder embed = new DiscordEmbedBuilder()
            {
                Title = command.Member.DisplayName,
                Description = "Ha mandato un immagine.",
                Color = command.Member.Color,
                Footer = footer,
                Thumbnail = thumbnail
            };

            await command.Channel.SendMessageAsync(embed);
            await command.Message.DeleteAsync();
        }
    }
}
