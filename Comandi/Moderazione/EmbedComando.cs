using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using static DSharpPlus.Entities.DiscordEmbedBuilder;

namespace KheetoNetworkBot.Comandi.Moderazione
{
    public class EmbedComando : BaseCommandModule
    {
        [Command("Embed")]
        [Description("Comando per creare un embed personalizzato.")]
        [RequirePermissions(DSharpPlus.Permissions.ManageMessages)]
        public async Task Comando(CommandContext command)
        {
            string autore = null;
            string linkImmagine = null;

            DiscordEmbedBuilder embed = new DiscordEmbedBuilder()
            {

            };

            #region Titolo

            await command.Message.DeleteAsync();
            DiscordMessage messaggioTitolo = await command.Channel.SendMessageAsync("Ora scrivi, entro 60 secondi, il Titolo dell'Embed.");

            var titoloRicevuto = await command.Client.GetInteractivity().WaitForMessageAsync(msg => msg.Channel == command.Channel).ConfigureAwait(false);

            if (!titoloRicevuto.TimedOut)
            {
                embed.Title = titoloRicevuto.Result.Content;
                await titoloRicevuto.Result.DeleteAsync();
                await messaggioTitolo.DeleteAsync();
            }
            else
            {
                await command.Channel.SendMessageAsync("Non hai scritto niente in 60 secondi. Comando Cancellato.");
            }

            #endregion

            #region Descrizione

            DiscordMessage messaggioDescrizione = await command.Channel.SendMessageAsync("Ora scrivi, entro 60 secondi, la descrizione dell'Embed.");

            var descrizioneRicevuta = await command.Client.GetInteractivity().WaitForMessageAsync(msg => msg.Channel == command.Channel).ConfigureAwait(false);

            if (!descrizioneRicevuta.TimedOut)
            {
                embed.Description = descrizioneRicevuta.Result.Content;
                await descrizioneRicevuta.Result.DeleteAsync();
                await messaggioDescrizione.DeleteAsync();
            }
            else
            {
                await command.Channel.SendMessageAsync("Non hai scritto niente in 60 secondi. Comando Cancellato.");
            }

            #endregion

            #region Autore

            DiscordMessage messaggioAutore = await command.Channel.SendMessageAsync("Ora scrivi, entro 60 secondi, il nome dell'Autore.");

            var autoreRicevuto = await command.Client.GetInteractivity().WaitForMessageAsync(msg => msg.Channel == command.Channel).ConfigureAwait(false);

            if (!autoreRicevuto.TimedOut)
            {
                autore = autoreRicevuto.Result.Content;

                embed.Author = new EmbedAuthor() {
                    Name = autore
                };
                await autoreRicevuto.Result.DeleteAsync();
                await messaggioAutore.DeleteAsync();
            }
            else
            {
                await command.Channel.SendMessageAsync("Non hai scritto niente in 60 secondi. Comando Cancellato.");
            }

            #endregion

            #region ImmagineAutore

            DiscordMessage messaggioImgAutore = await command.Channel.SendMessageAsync("Ora manda, entro 60 secondi, il link dell'immagine dell'Autore.");

            var imgAutoreRicevuto = await command.Client.GetInteractivity().WaitForMessageAsync(msg => msg.Channel == command.Channel).ConfigureAwait(false);

            if (!imgAutoreRicevuto.TimedOut)
            {
                linkImmagine = imgAutoreRicevuto.Result.Content;

                embed.Author = new EmbedAuthor()
                {
                    Name = autore,
                    IconUrl = linkImmagine,
                };
                await imgAutoreRicevuto.Result.DeleteAsync();
                await messaggioImgAutore.DeleteAsync();
            }
            else
            {
                await command.Channel.SendMessageAsync("Non hai scritto niente in 60 secondi. Comando Cancellato.");
            }

            #endregion

            #region ImmagineEmbed

            DiscordMessage messaggioImmagine = await command.Channel.SendMessageAsync("Ora manda, entro 60 secondi, il link dell'Immagine dell'Embed.");

            var immagineRicevuta = await command.Client.GetInteractivity().WaitForMessageAsync(msg => msg.Channel == command.Channel).ConfigureAwait(false);

            if (!immagineRicevuta.TimedOut)
            {
                embed.Thumbnail = new EmbedThumbnail
                {
                    Url = immagineRicevuta.Result.Content,
                };
                await immagineRicevuta.Result.DeleteAsync();
                await messaggioImmagine.DeleteAsync();
            }
            else
            {
                await command.Channel.SendMessageAsync("Non hai scritto niente in 60 secondi. Comando Cancellato.");
            }

            #endregion

            #region ColoreEmbed

            DiscordMessage messaggioColore = await command.Channel.SendMessageAsync("Ora manda, entro 60 secondi, un codice esadecimale per il colore dell'Embed, esempio: #FF0000 = ROSSO.");

            var coloreRicevuto = await command.Client.GetInteractivity().WaitForMessageAsync(msg => msg.Channel == command.Channel).ConfigureAwait(false);

            if (!coloreRicevuto.TimedOut)
            {
                embed.Color = new DiscordColor(coloreRicevuto.Result.Content);
                await coloreRicevuto.Result.DeleteAsync();
                await messaggioColore.DeleteAsync();
            }
            else
            {
                await command.Channel.SendMessageAsync("Non hai scritto niente in 60 secondi. Comando Cancellato.");
            }

            #endregion

            await command.Channel.SendMessageAsync(embed);
        }
    }
}
