using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using KheetoNetworkBot.Meme;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KheetoNetworkBot.Comandi.Divertimento
{
    public class MemeComando : BaseCommandModule
    {
        [Command("Meme")]
        [Description("Manda una meme casuale.")]
        public async Task Comando(CommandContext command)
        {

            await command.TriggerTypingAsync();

            int random = new Random().Next(1, 16);

            switch(random)
            {
                case 1:
                    await new MemeMaker("Meme!", "https://i.imgflip.com/5hrvcm.jpg", command).RunAsync().ConfigureAwait(false);
                    return;
                case 2:
                    await new MemeMaker("Meme!", "https://i.imgflip.com/5hrz6o.jpg", command).RunAsync().ConfigureAwait(false);
                    return;
                case 3:
                    await new MemeMaker("Meme!", "https://i.imgflip.com/5hrzcd.jpg", command).RunAsync().ConfigureAwait(false);
                    return;
                case 4:
                    await new MemeMaker("Meme!", "https://i.imgflip.com/5hrzff.jpg", command).RunAsync().ConfigureAwait(false);
                    return;
                case 5:
                    await new MemeMaker("Meme!", "https://i.imgflip.com/5hrzkf.jpg", command).RunAsync().ConfigureAwait(false);
                    return;
                case 6:
                    await new MemeMaker("Meme!", "https://i.imgflip.com/5hrzmi.jpg", command).RunAsync().ConfigureAwait(false);
                    return;
                case 7:
                    await new MemeMaker("Meme!", "https://i.imgflip.com/5hrzo2.jpg", command).RunAsync().ConfigureAwait(false);
                    return;
                case 8:
                    await new MemeMaker("Meme!", "https://i.imgflip.com/5hrzrd.jpg", command).RunAsync().ConfigureAwait(false);
                    return;
                case 9:
                    await new MemeMaker("Meme!", "https://i.imgflip.com/5hrzup.jpg", command).RunAsync().ConfigureAwait(false);
                    return;
                case 10:
                    await new MemeMaker("Meme!", "https://i.imgflip.com/5hs05a.jpg", command).RunAsync().ConfigureAwait(false);
                    return;
                case 11:
                    await new MemeMaker("Meme!", "https://i.imgflip.com/5hs07j.jpg", command).RunAsync().ConfigureAwait(false);
                    return;
                case 12:
                    await new MemeMaker("Meme!", "https://i.imgflip.com/5hs09x.jpg", command).RunAsync().ConfigureAwait(false);
                    return;
                case 13:
                    await new MemeMaker("Meme!", "https://i.imgflip.com/5hs0ek.jpg", command).RunAsync().ConfigureAwait(false);
                    return;
                case 14:
                    await new MemeMaker("Meme!", "https://i.imgflip.com/5hs0gb.jpg", command).RunAsync().ConfigureAwait(false);
                    return;
                case 15:
                    await new MemeMaker("Meme!", "https://i.imgflip.com/5hs0ln.jpg", command).RunAsync().ConfigureAwait(false);
                    return;
                case 16:
                    await new MemeMaker("Meme!", "https://i.imgflip.com/5hs0ph.jpg", command).RunAsync().ConfigureAwait(false);
                    return;
            }


        }

    }
}
