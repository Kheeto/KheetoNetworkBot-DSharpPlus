using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Exceptions;

namespace KheetoNetworkBot.Comandi.Moderazione
{
    public class ClearComando : BaseCommandModule
    {
        [Command("Clear")]
        [Description("Cancella il determinato numero di messaggi.")]
        [RequirePermissions(DSharpPlus.Permissions.ManageMessages)]
        public async Task Comando(CommandContext command, [Description("Numero di messaggi da cancellare")] int Numero)
        {
            if (Numero <= 0)
            {
                await command.RespondAsync("Non posso eliminare 0 o meno messaggi!");
                return;
            }

            try
            {
                await command.Channel.DeleteMessagesAsync(command.Channel.GetMessagesAsync(Numero).Result);
            }
            catch (BadRequestException)
            {
                await command.Message.RespondAsync("Non posso eliminare messaggi più vecchi di 14 giorni per le limitazioni di Discord.");
            }

        }
    }
}
