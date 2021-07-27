using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.VoiceNext;
using DSharpPlus.VoiceNext.Codec;

namespace KheetoNetworkBot.Comandi.Musica
{
    public class JoinComando : BaseCommandModule
    {
        [Command("Join")]
        [Description("Entra nel canale vocale.")]
        public async Task Comando(CommandContext command, [Description("Canale in cui entrare, se non specificato verrà usato il canale in cui l'utente si trova")] DiscordChannel channel = null)
        {

            var voiceNext = command.Client.GetVoiceNext();
            if (voiceNext == null)
            {
                await command.RespondAsync("Impossibile connettere il Bot in un canale vocale, VoiceNext non trovato.");
                return;
            }

            var vnc = voiceNext.GetConnection(command.Guild);
            if (vnc != null)
            {
                await command.RespondAsync("Sono già connesso a un canale vocale.");
                return;
            }

            var voiceState = command.Member?.VoiceState;
            if (voiceState?.Channel == null && channel == null)
            {
                await command.RespondAsync("Non sei in un canale vocale o non ne hai specificato uno.");
                return;
            }

            if (channel == null && voiceState.Channel != null)
                channel = voiceState.Channel;

            vnc = await voiceNext.ConnectAsync(channel);
            await command.Guild.CurrentMember.SetDeafAsync(true);
            await command.Message.CreateReactionAsync(DiscordEmoji.FromName(command.Client, ":white_check_mark:"));
        }

    }
}
