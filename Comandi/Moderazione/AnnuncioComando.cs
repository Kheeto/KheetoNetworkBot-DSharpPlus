using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus;
using System.Threading.Tasks;

namespace KheetoNetworkBot.Comandi.Moderazione
{
    public class AnnuncioComando : BaseCommandModule
    {
        [Command("annuncio")]
        [Description("Manda un annuncio in un embed nel canale Annunci.")]
        [RequirePermissions(DSharpPlus.Permissions.ManageGuild)]
        public async Task Comando(CommandContext command, [Description("Testo dell'annuncio")] params string[] Testo)
        {
            string testoAnnuncio = null;
            foreach(string arg in Testo)
            {
                testoAnnuncio = testoAnnuncio + arg + " ";
            }

            DiscordEmbedBuilder.EmbedFooter footer = new DiscordEmbedBuilder.EmbedFooter
            {
                Text = "Kheeto Network - Annunci",
                IconUrl = "https://cdn.discordapp.com/icons/654083852838502413/9a50cb8c9806ea2c26e36a0ea0bb76ec.webp?size=128",
            };

            DiscordEmbedBuilder embed = new DiscordEmbedBuilder
            {
                Color = new DiscordColor("#FF0000"),
                Title = "Annuncio",
                Description = testoAnnuncio,
                Footer = footer,
            };

            await command.Channel.SendMessageAsync(embed);
            await command.Message.DeleteAsync();

            DiscordMessage pingEveryone = command.Channel.SendMessageAsync("@everyone").Result;
            await pingEveryone.DeleteAsync();

        }
    }
}
