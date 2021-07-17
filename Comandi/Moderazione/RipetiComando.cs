using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;

namespace KheetoNetworkBot.Comandi.Moderazione
{
    public class RipetiComando : BaseCommandModule
    {
        [Command("Ripeti")]
        [Description("Ripete quello che è stato scritto dall'utente dopo aver eseguito il comando")]
        [RequirePermissions(DSharpPlus.Permissions.ManageMessages)]
        public async Task Comando(CommandContext command)
        {
            await command.Message.DeleteAsync();
            DiscordMessage messaggioIniziale = await command.Channel.SendMessageAsync("Ora scrivi, entro 60 secondi, qualcosa che ripeterò.");

            var messaggioRicevuto = await command.Client.GetInteractivity().WaitForMessageAsync(msg => msg.Channel == command.Channel).ConfigureAwait(false);

            if (!messaggioRicevuto.TimedOut)
            {
                await command.Channel.SendMessageAsync(messaggioRicevuto.Result.Content);
                await messaggioRicevuto.Result.DeleteAsync();
            } else
            {
                await command.Channel.SendMessageAsync("Non hai scritto niente in 60 secondi. Comando Cancellato.");
            }

            await messaggioIniziale.DeleteAsync();
        }
    }
}
