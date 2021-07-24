using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using static DSharpPlus.Entities.DiscordEmbedBuilder;

namespace KheetoNetworkBot.Comandi.Utilità
{
    public class StatoComando : BaseCommandModule
    {
        [Command("Stato")]
        [Description("Comando che cambia lo stato del Bot.")]
        public async Task Comando(CommandContext command)
        {
            string statoBot = null;

            #region userIDcheck

            DiscordEmbedBuilder notKheetoEmbed = new DiscordEmbedBuilder()
            {
                Title = "Errore",
                Description = "Solo Kheeto può cambiare il mio stato!",
                Color = new DiscordColor("#CD0000"),
                ImageUrl = command.User.AvatarUrl,
                Footer = new DiscordEmbedBuilder.EmbedFooter()
                {
                    Text = command.Member.DisplayName + " ha provato a cambiare lo stato del Bot",
                    IconUrl = command.User.AvatarUrl,
                }
            };

            if (command.User.Id != 530817199632416778)
            {
                await command.Channel.SendMessageAsync(notKheetoEmbed);
                return;
            }

            #endregion

            DiscordEmbedBuilder embedScelta = new DiscordEmbedBuilder()
            {
                Color = new DiscordColor("#00CD00"),
                Title = "Che tipo di Stato?",
                Description = ":green_circle: Sta Giocando\n:yellow_circle: Sta Guardando\n:red_circle: In Competizione\n**REAGISCI CON IL TIPO DI STATO, ENTRO 60 SECONDI**.",
                Footer = new DiscordEmbedBuilder.EmbedFooter()
                {
                    Text = command.Member.DisplayName + " sta cambiando lo stato del Bot.",
                    IconUrl = command.User.AvatarUrl,
                }
            };

            DiscordMessage messaggioScelta = await command.Channel.SendMessageAsync(embedScelta);

            DiscordEmoji greenCircle = DiscordEmoji.FromName(command.Client, ":green_circle:");
            DiscordEmoji yellowCircle = DiscordEmoji.FromName(command.Client, ":yellow_circle:");
            DiscordEmoji redCircle = DiscordEmoji.FromName(command.Client, ":red_circle:");

            await messaggioScelta.CreateReactionAsync(DiscordEmoji.FromName(command.Client, ":green_circle:"));
            await messaggioScelta.CreateReactionAsync(DiscordEmoji.FromName(command.Client, ":yellow_circle:"));
            await messaggioScelta.CreateReactionAsync(DiscordEmoji.FromName(command.Client, ":red_circle:"));

            InteractivityExtension interactivity = command.Client.GetInteractivity();

            var tipoStato = await interactivity.WaitForReactionAsync(
                x => x.Message == messaggioScelta &&
                x.User == command.User &&
                (x.Emoji == greenCircle ||
                x.Emoji == yellowCircle ||
                x.Emoji == redCircle)).ConfigureAwait(false);

            await messaggioScelta.DeleteAsync();

            if (tipoStato.TimedOut)
            {
                await command.Channel.SendMessageAsync("Non hai reagito in 60 secondi. Comando Cancellato.");
                return;
            }

            DiscordEmoji tipoStatoEmoji = null;

            if (tipoStato.Result.Emoji == greenCircle) tipoStatoEmoji = greenCircle;
            if (tipoStato.Result.Emoji == yellowCircle) tipoStatoEmoji = yellowCircle;
            if (tipoStato.Result.Emoji == redCircle) tipoStatoEmoji = redCircle;

            DiscordEmbedBuilder embedStato = new DiscordEmbedBuilder()
            {
                Color = new DiscordColor("#00CD00"),
                Title = "Testo dello Stato.",
                Description = "**SCRIVI IL TESTO DELLO STATO DEL BOT, ENTRO 60 SECONDI**.",
                Footer = new DiscordEmbedBuilder.EmbedFooter()
                {
                    Text = command.Member.DisplayName + " sta cambiando lo stato del Bot.",
                    IconUrl = command.User.AvatarUrl,
                }
            };

            DiscordMessage messaggioStato = await command.RespondAsync(embedStato);

            var testoStato = await interactivity.WaitForMessageAsync(
                x => x.Channel == command.Channel &&
                x.Author == command.User).ConfigureAwait(false);

            await messaggioStato.DeleteAsync();

            if (testoStato.TimedOut)
            {
                await command.Channel.SendMessageAsync("Non hai scritto niente in 60 secondi. Comando Cancellato.");
                return;
            }

            DiscordActivity activity = new DiscordActivity
            {
                Name = testoStato.Result.Content,
            };

            if (tipoStatoEmoji == greenCircle) activity.ActivityType = ActivityType.Playing;
            if (tipoStatoEmoji == yellowCircle) activity.ActivityType = ActivityType.Watching;
            if (tipoStatoEmoji == redCircle) activity.ActivityType = ActivityType.Competing;

            DiscordEmbedBuilder embedStatoBot = new DiscordEmbedBuilder()
            {
                Color = new DiscordColor("#00CD00"),
                Title = "Stato del Bot",
                Description = ":green_circle: Online\n:yellow_circle: Inattivo\n:red_circle: Non Disturbare\n**REAGISCI CON IL TIPO DI STATO, ENTRO 60 SECONDI**.",
                Footer = new DiscordEmbedBuilder.EmbedFooter()
                {
                    Text = command.Member.DisplayName + " sta cambiando lo stato del Bot.",
                    IconUrl = command.User.AvatarUrl,
                }
            };

            DiscordMessage messaggioStatoBot = await command.Channel.SendMessageAsync(embedStatoBot);

            await messaggioStatoBot.CreateReactionAsync(DiscordEmoji.FromName(command.Client, ":green_circle:"));
            await messaggioStatoBot.CreateReactionAsync(DiscordEmoji.FromName(command.Client, ":yellow_circle:"));
            await messaggioStatoBot.CreateReactionAsync(DiscordEmoji.FromName(command.Client, ":red_circle:"));

            var tipoStatoBot = await interactivity.WaitForReactionAsync(
                x => x.Message == messaggioStatoBot &&
                x.User == command.User &&
                (x.Emoji == greenCircle ||
                x.Emoji == yellowCircle ||
                x.Emoji == redCircle)).ConfigureAwait(false);

            await messaggioStatoBot.DeleteAsync();

            if (tipoStatoBot.TimedOut)
            {
                await command.Channel.SendMessageAsync("Non hai reagito 60 in secondi. Comando Cancellato.");
                return;
            }

            DiscordEmoji tipoStatoBotEmoji = null;

            tipoStatoEmoji = tipoStatoBot.Result.Emoji;

            UserStatus statoUserBot = UserStatus.DoNotDisturb;

            if (tipoStatoBotEmoji == greenCircle) statoUserBot = UserStatus.Online;
            if (tipoStatoBotEmoji == yellowCircle) statoUserBot = UserStatus.Idle;
            if (tipoStatoBotEmoji == redCircle) statoUserBot = UserStatus.DoNotDisturb;

            await messaggioStatoBot.DeleteAsync();

            await command.Client.UpdateStatusAsync(activity, statoUserBot);

            await command.Message.DeleteAsync();
        }
    }
}
