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
    public class KickComando : BaseCommandModule
    {
        [Command("Kick")]
        [Description("Espelle un utente dal server.")]
        [RequirePermissions(DSharpPlus.Permissions.KickMembers)]
        public async Task Comando(CommandContext command, [Description("Utente da Espellere")] DiscordMember Utente, [Description("Motivo dell'Espulsione")] params string[] Motivo)
        {
            string motivoFinale = null;
            if (Motivo.Length > 0)
            {
                foreach (string arg in Motivo)
                {
                    motivoFinale = motivoFinale + arg + " ";
                }
            }
            try
            {
                await Utente.RemoveAsync(motivoFinale);
                await command.RespondAsync("Utente espulso con successo");
            }
            catch (NotFoundException)
            {
                await command.RespondAsync("Utente non trovato - DSharpPlus.Exceptions.NotFoundException");
            }
            catch (BadRequestException)
            {
                await command.RespondAsync("Impossibile espellere l'utente - DSharpPlus.Exceptions.BadRequestException");
            }
            catch (ServerErrorException)
            {
                await command.RespondAsync("Errore del Server - DSharpPlus.Exceptions.ServerErrorException");
            }
        }
    }
}
