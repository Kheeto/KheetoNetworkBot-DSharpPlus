using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KheetoNetworkBot.Comandi.Divertimento
{
    public class GrattaEVinciComando : BaseCommandModule
    {
        [Command("GrattaEVinci")]
        [Description("Gratta e vinci (di solito è gratta e perdi)")]
        public async Task Comando(CommandContext command)
        {
            double random = new Random().NextDouble();

            DiscordEmbedBuilder embed = new DiscordEmbedBuilder
            {
                Title = "Gratta e Vinci",
                Color = new DiscordColor("#CD0000"),
            };

            if(random > 0.30) { // sconfitta
                embed.Description = command.User.Mention + " ha perso!";
            } else // vittoria
            {
                embed.Description = command.User.Mention + " ha vinto!";
            }

            await command.RespondAsync(embed);


        }

    }
}
