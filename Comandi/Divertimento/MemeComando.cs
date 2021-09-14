using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using KheetoNetworkBot.LIB;
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
                    await MemeMaker.CreateMeme("Meme!", "https://i.imgflip.com/5hrvcm.jpg", command).ConfigureAwait(false);
                    return;
                case 2:
                    await MemeMaker.CreateMeme("Meme!", "https://i.imgflip.com/5hrz6o.jpg", command).ConfigureAwait(false);
                    return;
                case 3:
                    await MemeMaker.CreateMeme("Meme!", "https://i.imgflip.com/5hrzcd.jpg", command).ConfigureAwait(false);
                    return;
                case 4:
                    await MemeMaker.CreateMeme("Meme!", "https://i.imgflip.com/5hrzff.jpg", command).ConfigureAwait(false);
                    return;
                case 5:
                    await MemeMaker.CreateMeme("Meme!", "https://i.imgflip.com/5hrzkf.jpg", command).ConfigureAwait(false);
                    return;
                case 6:
                    await MemeMaker.CreateMeme("Meme!", "https://i.imgflip.com/5hrzmi.jpg", command).ConfigureAwait(false);
                    return;
                case 7:
                    await MemeMaker.CreateMeme("Meme!", "https://i.imgflip.com/5hrzo2.jpg", command).ConfigureAwait(false);
                    return;
                case 8:
                    await MemeMaker.CreateMeme("Meme!", "https://i.imgflip.com/5hrzrd.jpg", command).ConfigureAwait(false);
                    return;
                case 9:
                    await MemeMaker.CreateMeme("Meme!", "https://i.imgflip.com/5hrzup.jpg", command).ConfigureAwait(false);
                    return;
                case 10:
                    await MemeMaker.CreateMeme("Meme!", "https://i.imgflip.com/5hs05a.jpg", command).ConfigureAwait(false);
                    return;
                case 11:
                    await MemeMaker.CreateMeme("Meme!", "https://i.imgflip.com/5hs07j.jpg", command).ConfigureAwait(false);
                    return;
                case 12:
                    await MemeMaker.CreateMeme("Meme!", "https://i.imgflip.com/5hs09x.jpg", command).ConfigureAwait(false);
                    return;
                case 13:
                    await MemeMaker.CreateMeme("Meme!", "https://i.imgflip.com/5hs0ek.jpg", command).ConfigureAwait(false);
                    return;
                case 14:
                    await MemeMaker.CreateMeme("Meme!", "https://i.imgflip.com/5hs0gb.jpg", command).ConfigureAwait(false);
                    return;
                case 15:
                    await MemeMaker.CreateMeme("Meme!", "https://i.imgflip.com/5hs0ln.jpg", command).ConfigureAwait(false);
                    return;
                case 16:
                    await MemeMaker.CreateMeme("Meme!", "https://i.imgflip.com/5hs0ph.jpg", command).ConfigureAwait(false);
                    return;
                case 17:
                    await MemeMaker.CreateMeme("Meme!", "https://i.imgflip.com/5hs1sy.jpg", command).ConfigureAwait(false);
                    return;
                case 18:
                    await MemeMaker.CreateMeme("Meme!", "https://i.imgflip.com/5hs1we.jpg", command).ConfigureAwait(false);
                    return;
                case 19:
                    await MemeMaker.CreateMeme("Meme!", "https://i.imgflip.com/5hs24l.jpg", command).ConfigureAwait(false);
                    return;
                case 20:
                    await MemeMaker.CreateMeme("Meme!", "https://i.imgflip.com/5hs2be.jpg", command).ConfigureAwait(false);
                    return;
                case 21:
                    await MemeMaker.CreateMeme("WISHLIST KARLSON NOW GAMERS!", "https://i.imgflip.com/5hs2i0.jpg", command).ConfigureAwait(false);
                    return;
                case 22:
                    await MemeMaker.CreateMeme("WISHLIST KARLSON NOW GAMERS!", "https://i.imgflip.com/5hs2qw.jpg", command).ConfigureAwait(false);
                    return;
                case 23:
                    await MemeMaker.CreateMeme("WISHLIST KARLSON NOW GAMERS!", "https://i.imgflip.com/5hs2qw.jpg", command).ConfigureAwait(false);
                    return;
                case 24:
                    await MemeMaker.CreateMeme("KARLSON VIBE", "https://i.imgflip.com/5hs2uw.jpg", command).ConfigureAwait(false);
                    return;
                case 25:
                    await MemeMaker.CreateMeme("DRINK YOUR MILK KIDS", "https://i.imgflip.com/5hs34x.jpg", command).ConfigureAwait(false);
                    return;
                case 26:
                    await MemeMaker.CreateMeme("APRI IL LINK", "https://www.youtube.com/watch?v=FUmJLH2RRy8", command, false).ConfigureAwait(false);
                    return;
                case 27:
                    await MemeMaker.CreateMeme("Premi qui", "https://www.youtube.com/watch?v=ox46xNpFRbQ", command, false).ConfigureAwait(false);
                    return;
                case 28:
                    await MemeMaker.CreateMeme("Premi qui per il video", "https://www.youtube.com/watch?v=2PT_ecMf99k", command, false, true, "https://i.imgflip.com/5hs3s9.jpg").ConfigureAwait(false);
                    return;
                case 29:
                    await MemeMaker.CreateMeme("DANI NECK REVEAL", "https://www.youtube.com/watch?v=VnxpmFiShro", command, false, true, "https://i.ytimg.com/vi/VnxpmFiShro/maxresdefault.jpg").ConfigureAwait(false);
                    return;
                case 30:
                    await MemeMaker.CreateMeme("Non usate le hack o puzzate", "https://i.imgflip.com/5hs5e5.jpg", command).ConfigureAwait(false);
                    return;
                case 31:
                    await MemeMaker.CreateMeme("Meme", "https://i.imgflip.com/5hs5ko.jpg", command).ConfigureAwait(false);
                    return;
                case 32:
                    await MemeMaker.CreateMeme("Meme", "https://i.imgflip.com/5hs5t9.jpg", command).ConfigureAwait(false);
                    return;
                case 33:
                    await MemeMaker.CreateMeme("Meme", "https://i.imgflip.com/5hs60p.jpg", command).ConfigureAwait(false);
                    return;
                case 34:
                    await MemeMaker.CreateMeme("Meme", "https://i.imgflip.com/5hs64l.jpg", command).ConfigureAwait(false);
                    return;
                case 35:
                    await MemeMaker.CreateMeme("Meme", "https://i.imgflip.com/5hs6ce.jpg", command).ConfigureAwait(false);
                    return;
                case 36:
                    await MemeMaker.CreateMeme("Meme", "https://i.imgflip.com/5hs6pj.jpg", command).ConfigureAwait(false);
                    return;
                case 37:
                    await MemeMaker.CreateMeme("Meme", "https://i.imgflip.com/5hs6um.jpg", command).ConfigureAwait(false);
                    return;
            }


        }

    }
}
