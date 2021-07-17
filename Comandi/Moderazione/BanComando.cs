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
    public class BanComando : BaseCommandModule
    {
        [Command("ban")]
        [Description("Banna un utente dal server.")]
        [RequirePermissions(DSharpPlus.Permissions.BanMembers)]
        public async Task Comando(CommandContext command, [Description("Utente da Bannare.")] DiscordMember Utente, [Description("Motivo del Ban") ]params string[] Motivo)
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
                await Utente.BanAsync(0, motivoFinale);
                await command.RespondAsync("Utente bannato con successo");
            } catch(NotFoundException)
            {
                await command.RespondAsync("Utente non trovato - DSharpPlus.Exceptions.NotFoundException");
            } catch(BadRequestException)
            {
                await command.RespondAsync("Impossibile bannare l'utente - DSharpPlus.Exceptions.BadRequestException");
            } catch(ServerErrorException)
            {
                await command.RespondAsync("Errore del Server - DSharpPlus.Exceptions.ServerErrorException");
            }
        }
    }
}
