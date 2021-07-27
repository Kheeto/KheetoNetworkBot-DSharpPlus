using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KheetoNetworkBot.Meme
{
    public class Meme
    {
        public string embedTitle;
        public string memeURL;
        CommandContext command;

        public Meme(string embedTitle, string memeURL, CommandContext command)
        {
            this.embedTitle = embedTitle;
            this.memeURL = memeURL;
            this.command = command;
        }

        public async Task RunAsync()
        {
            DiscordEmbedBuilder.EmbedFooter footer = new DiscordEmbedBuilder.EmbedFooter
            {
                Text = "Meme mandata da " + command.Member.Mention,
                IconUrl = command.User.AvatarUrl
            };

            DiscordEmbedBuilder embed = new DiscordEmbedBuilder
            {
                Title = embedTitle,
                Color = new DiscordColor("#CD0000"),
                Footer = footer,
                ImageUrl = memeURL
            };

            await command.Message.DeleteAsync();
            await command.Channel.SendMessageAsync(embed);
        }
    }
}
