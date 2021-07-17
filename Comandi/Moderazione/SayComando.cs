using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace KheetoNetworkBot.Comandi.Moderazione
{
    public class SayComando : BaseCommandModule
    {
        [Command("Say")]
        [Description("Ripete quello che è stato scritto dall'utente")]
        [RequirePermissions(DSharpPlus.Permissions.ManageMessages)]
        public async Task Comando(CommandContext command, [Description("Testo da Ripetere.")] params string[] Testo)
        {
            if(Testo.Length == 0)
            {
                await command.RespondAsync("Scrivi anche un testo da ripetere.");
                return;
            }
            string messaggio = null;
            foreach(string arg in Testo)
            {
                messaggio = messaggio + arg + " ";
            }
            await command.Channel.SendMessageAsync(messaggio);
            await command.Message.DeleteAsync();
        }
    }
}
