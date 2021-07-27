using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus;
using System.Threading.Tasks;

namespace KheetoNetworkBot.Comandi.Info
{
    public class PingComando : BaseCommandModule
    {
        [Command("Ping")]
        [Description("Mostra le informazioni del server.")]
        public async Task Comando(CommandContext command)
        {

            DiscordEmbedBuilder.EmbedFooter footer = new DiscordEmbedBuilder.EmbedFooter
            {
                Text = "Kheeto Network Bot",
                IconUrl = "https://cdn.discordapp.com/icons/654083852838502413/9a50cb8c9806ea2c26e36a0ea0bb76ec.webp?size=128",
            };

            DiscordEmbedBuilder embed = new DiscordEmbedBuilder
            {
                Color = new DiscordColor("#FF0000"),
                Title = "Ping del Bot",
                Description = command.Client.Ping + "ms",
                Footer = footer,
            };

            await command.Message.CreateReactionAsync(DiscordEmoji.FromName(command.Client, ":ping_pong:"));
            await command.RespondAsync(embed);
        }
    }
}
