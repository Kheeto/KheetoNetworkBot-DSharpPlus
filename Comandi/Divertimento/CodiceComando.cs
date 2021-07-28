using System;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;
using KheetoNetworkBot.LIB.Attributes;
using KheetoNetworkBot.LIB.Enums;

namespace KheetoNetworkBot.Comandi.Divertimento
{
    public class CodiceComando : BaseCommandModule
    {

        [Command("codice")]
        [Description("Minigame - Il primo che scrive il codice generato dal bot vince.")]
        public async Task Comando(CommandContext command)
        {
            var interactivity = command.Client.GetInteractivity();

            var codebytes = new byte[8];
            using (var rng = RandomNumberGenerator.Create())
                rng.GetBytes(codebytes);

            var code = BitConverter.ToString(codebytes).ToLower().Replace("-", "");

            await command.RespondAsync($"Il primo a scrivere questo codice vince: `{code}`");

            var msg = await interactivity.WaitForMessageAsync(xm => xm.Content.Contains(code), TimeSpan.FromSeconds(60));
            if (!msg.TimedOut)
            {
                await msg.Result.RespondAsync($"{msg.Result.Author.Mention} ha vinto!");
            }
            else
            {
                await command.RespondAsync("Nessuno ha scritto il codice in tempo lol");
            }
        }

    }
}

