using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KheetoNetworkBot.Comandi.Divertimento
{
    public class MemeComando : BaseCommandModule
    {
        [Command("Meme")]
        [Description("Manda una meme casuale.")]
        public async Task Comando(CommandContext command)
        {

            await command.TriggerTypingAsync();

            DiscordEmbedBuilder embed = new DiscordEmbedBuilder
            {
                Title = "test xd",
                Color = new DiscordColor("#CD0000"),
                ImageUrl = "C:/Users/Utente/source/repos/KheetoNetworkBot/KheetoNetworkBot/Comandi/Divertimento/FotoMeme/Meme1.jfif"
            };

            await command.RespondAsync(embed);


        }

        public async Task MemeAsync(string fileName, string embedTitle, CommandContext command)
        {
            await command.TriggerTypingAsync();

            DiscordEmbedBuilder embed = new DiscordEmbedBuilder
            {
                Title = embedTitle,
                Color = new DiscordColor("#CD0000"),
                ImageUrl = "./FotoMeme/" + fileName
            };

            await command.RespondAsync(embed);
        }

    }
}
