using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Exceptions;

namespace KheetoNetworkBot.Comandi.Moderazione
{
    public class NickComando : BaseCommandModule
    {
        [Command("nick")]
        [Description("Gives someone a new nickname.")]
        [RequirePermissions(Permissions.ManageNicknames)]
        public async Task ChangeNickname(CommandContext command, [Description("Utente a cui cambiare il nick")] DiscordMember member, [RemainingText, Description("Nickname da mettere")] string new_nickname)
        {
            await command.TriggerTypingAsync();

            try
            {
                await member.ModifyAsync(x =>
                {
                    x.Nickname = new_nickname;
                    x.AuditLogReason = $"Nick impostato da {command.User.Username} ({command.User.Id}).";
                });

                var emoji = DiscordEmoji.FromName(command.Client, ":+1:");

                await command.RespondAsync(emoji);
            }
            catch (Exception)
            {
                await command.RespondAsync("C'è stato un errore nell'impostare il nick.");
            }
        }
    }
}
