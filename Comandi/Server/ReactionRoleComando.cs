using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Exceptions;
using KheetoNetworkBot.LIB;

namespace KheetoNetworkBot.Comandi.Server
{
    public class ReactionRoleComando : BaseCommandModule
    {
        [Command("ReactionRole")]
        [Description("Crea un messaggio con un reaction role.")]
        [RequirePermissions(DSharpPlus.Permissions.ManageGuild)]
        public async Task Comando(CommandContext command, string title, string description, string color, DiscordEmoji emoji, DiscordRole role)
        {
            await new SingleReactionRole(command, title, description, color, emoji, role).RunAsync().ConfigureAwait(false);
        }
    }
}
