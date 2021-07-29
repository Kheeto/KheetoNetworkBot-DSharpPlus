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
        [Description("Manda una meme casuale tra quelle personalizzate di Kheeto Network.")]
        public async Task Comando(CommandContext command)
        {

            await command.TriggerTypingAsync();

            int random = new Random().Next(1, 38);

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
                case 17:
                    await new MemeMaker("Meme!", "https://i.imgflip.com/5hs1sy.jpg", command).RunAsync().ConfigureAwait(false);
                    return;
                case 18:
                    await new MemeMaker("Meme!", "https://i.imgflip.com/5hs1we.jpg", command).RunAsync().ConfigureAwait(false);
                    return;
                case 19:
                    await new MemeMaker("Meme!", "https://i.imgflip.com/5hs24l.jpg", command).RunAsync().ConfigureAwait(false);
                    return;
                case 20:
                    await new MemeMaker("Meme!", "https://i.imgflip.com/5hs2be.jpg", command).RunAsync().ConfigureAwait(false);
                    return;
                case 21:
                    await new MemeMaker("WISHLIST KARLSON NOW GAMERS!", "https://i.imgflip.com/5hs2i0.jpg", command).RunAsync().ConfigureAwait(false);
                    return;
                case 22:
                    await new MemeMaker("WISHLIST KARLSON NOW GAMERS!", "https://i.imgflip.com/5hs2qw.jpg", command).RunAsync().ConfigureAwait(false);
                    return;
                case 23:
                    await new MemeMaker("WISHLIST KARLSON NOW GAMERS!", "https://i.imgflip.com/5hs2qw.jpg", command).RunAsync().ConfigureAwait(false);
                    return;
                case 24:
                    await new MemeMaker("KARLSON VIBE", "https://i.imgflip.com/5hs2uw.jpg", command).RunAsync().ConfigureAwait(false);
                    return;
                case 25:
                    await new MemeMaker("DRINK YOUR MILK KIDS", "https://i.imgflip.com/5hs34x.jpg", command).RunAsync().ConfigureAwait(false);
                    return;
                case 26:
                    await new MemeMaker("APRI IL LINK", "https://www.youtube.com/watch?v=FUmJLH2RRy8", command, false).RunAsync().ConfigureAwait(false);
                    return;
                case 27:
                    await new MemeMaker("Premi qui", "https://www.youtube.com/watch?v=ox46xNpFRbQ", command, false).RunAsync().ConfigureAwait(false);
                    return;
                case 28:
                    await new MemeMaker("Premi qui per il video", "https://www.youtube.com/watch?v=2PT_ecMf99k", command, false, true, "https://i.imgflip.com/5hs3s9.jpg").RunAsync().ConfigureAwait(false);
                    return;
                case 29:
                    await new MemeMaker("DANI NECK REVEAL", "https://www.youtube.com/watch?v=VnxpmFiShro", command, false, true, "https://i.ytimg.com/vi/VnxpmFiShro/maxresdefault.jpg").RunAsync().ConfigureAwait(false);
                    return;
                case 30:
                    await new MemeMaker("Non usate le hack o puzzate", "https://i.imgflip.com/5hs5e5.jpg", command).RunAsync().ConfigureAwait(false);
                    return;
                case 31:
                    await new MemeMaker("Meme", "https://i.imgflip.com/5hs5ko.jpg", command).RunAsync().ConfigureAwait(false);
                    return;
                case 32:
                    await new MemeMaker("Meme", "https://i.imgflip.com/5hs5t9.jpg", command).RunAsync().ConfigureAwait(false);
                    return;
                case 33:
                    await new MemeMaker("Meme", "https://i.imgflip.com/5hs60p.jpg", command).RunAsync().ConfigureAwait(false);
                    return;
                case 34:
                    await new MemeMaker("Meme", "https://i.imgflip.com/5hs64l.jpg", command).RunAsync().ConfigureAwait(false);
                    return;
                case 35:
                    await new MemeMaker("Meme", "https://i.imgflip.com/5hs6ce.jpg", command).RunAsync().ConfigureAwait(false);
                    return;
                case 36:
                    await new MemeMaker("Meme", "https://i.imgflip.com/5hs6pj.jpg", command).RunAsync().ConfigureAwait(false);
                    return;
                case 37:
                    await new MemeMaker("Meme", "https://i.imgflip.com/5hs6um.jpg", command).RunAsync().ConfigureAwait(false);
                    return;
            }


        }

    }
}
