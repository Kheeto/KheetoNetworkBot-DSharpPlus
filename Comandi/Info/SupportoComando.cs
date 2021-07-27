using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using KheetoNetworkBot.Handler;
using KheetoNetworkBot.Handler.Steps;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KheetoNetworkBot.Comandi.Info
{
    public class SupportoComando : BaseCommandModule
    {
        [Command("Supporto")]
        [Description("Inizia un dialogo in privato con il Bot.")]
        public async Task Comando(CommandContext command)
        {
            var firstStep = new IntStep("Scrivi il numero della domanda che vuoi farmi!\n:one: Come faccio a entrare nel server?\n:two: Come funziona l'economia?\n:three: Come faccio a diventare staff?\n:four: Sono stato bannato ingiustamente", null, 1, 4);
            var secondStep1 = new TextStep("**COME ENTRARE NEL SERVER**:\n**1.** Apri minecraft in una qualunque versione da 1.8.8 all'ultima\n**2.** Vai su Multiplayer\n**3.** Premi su \"Add Server\" o \"Aggiungi Server\" in basso, come nome metti Kheeto Network e come indirizzo **mc.kheeto67.it**\n**4.** Torna sulla lista dei server e entra in quello che si chiama Kheeto Network.", null);
            var secondStep2 = new TextStep("**COME FUNZIONA L'ECONOMIA DEL SURVIVAL**:\n**1.** Parti con 200 dollari. Con \"/bal\" puoi vedere il tuo conto.\n**2.** Con \"/ah\" puoi aprire il menu delle aste dove puoi comprare oggetti venduti dagli altri.\n**3.** Per vendere oggetti nelle aste usa il comando \"/ah sell [QUANTITA] [PREZZO]\"", null);
            var secondStep3 = new TextStep("**COME DIVENTARE STAFF**:\n**1.** Vai nel server Discord di Kheeto Network nel canale Chiedi-Provino\n**2.** Apri il link del Google Form nel messaggio di \"Monica\".", null);
            var secondStep4 = new TextStep("**COSA FARE SE SEI STATO BANNATO INGIUSTAMENTE**:\n**1.** Vai nel server Discord di Kheeto Network nel canale Chiedi-Unban\n**2.** scrivi/manda tutte le prove che hai di essere stato bannato ingiustamente\n**3.** Verrai contattato dallo Staff.", null);

            await command.TriggerTypingAsync();

            string input = string.Empty;

            firstStep.OnValidResult += (result) =>
            {
                switch(result)
                {
                    case 1:
                        firstStep.SetNextStep(secondStep1);
                        return;
                    case 2:
                        firstStep.SetNextStep(secondStep2);
                        return;
                    case 3:
                        firstStep.SetNextStep(secondStep3);
                        return;
                    case 4:
                        firstStep.SetNextStep(secondStep4);
                        return;
                }
            };

            await command.RespondAsync("Ti ho scritto in privato!");
            await command.Message.CreateReactionAsync(DiscordEmoji.FromName(command.Client, ":white_check_mark:"));

            var userChannel = await command.Member.CreateDmChannelAsync().ConfigureAwait(false);

            var inputDialogueHandler = new DialogueHandler(command.Client, userChannel, command.User, firstStep);

            bool succeeded = await inputDialogueHandler.ProcessDialogue().ConfigureAwait(false);

            if (!succeeded) return;

        }

        public async Task MemeAsync(string fileName, string embedTitle, CommandContext command)
        {
            await command.TriggerTypingAsync();

            DiscordEmbedBuilder embed = new DiscordEmbedBuilder
            {
                Title = embedTitle,
                Color = new DiscordColor("#CD0000"),
                ImageUrl = "./FotoMeme/" + fileName
            };

            await command.RespondAsync(embed);
        }

    }
}
