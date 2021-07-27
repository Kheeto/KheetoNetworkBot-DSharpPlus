using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Exceptions;

namespace KheetoNetworkBot.Comandi.Moderazione
{
    public class SudoComando : BaseCommandModule
    {
        [Command("Sudo")]
        [Description("Esegue un comando come un altro utente.")]
        [RequirePermissions(DSharpPlus.Permissions.ManageGuild)]
        public async Task Comando(CommandContext command, [Description("Utente")] DiscordMember Utente, [RemainingText] [Description("Comando da eseguire") ] string Comando)
        {
            bool trovatoUtente = false;
            foreach(DiscordMember utente in command.Guild.Members.Values)
            {
                if (utente == Utente)
                {
                    trovatoUtente = true;
                    break;
                }

            }

            if(!trovatoUtente)
            {
                await command.RespondAsync("Utente non trovato nel server!");
                return;
            }

            await command.TriggerTypingAsync();

            var cmds = command.CommandsNext;

            var cmd = cmds.FindCommand(Comando, out var customArgs);

            var fakeContext = cmds.CreateFakeContext(Utente, command.Channel, Comando, command.Prefix, cmd, customArgs);

            await cmds.ExecuteCommandAsync(fakeContext);
        }
    }
}
