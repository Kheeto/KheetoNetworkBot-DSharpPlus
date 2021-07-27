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
    public class LeaveComando : BaseCommandModule
    {
        [Command("Leave")]
        [Description("Esce dal canale vocale.")]
        public async Task Comando(CommandContext command)
        {
            var vnext = command.Client.GetVoiceNext();
            if (vnext == null)
            {
                await command.RespondAsync("Impossibile connettere il Bot in un canale vocale, VoiceNext non trovato.");
                return;
            }

            var voiceState = command.Member?.VoiceState;
            if (voiceState?.Channel == null && command == null)
            {
                await command.RespondAsync("Non sei in un canale vocale.");
                return;
            }

            DiscordChannel channel = voiceState.Channel;

            var vnc = vnext.GetConnection(command.Guild);
            if (vnc == null)
            {
                await command.RespondAsync("Non sono connesso a un canale vocale.");
                return;
            }

            if(vnc.TargetChannel != channel)
            {
                await command.RespondAsync("Non sono nello stesso canale vocale in cui sei tu.");
                return;
            }

            vnc.Disconnect();
            await command.Message.CreateReactionAsync(DiscordEmoji.FromName(command.Client, ":wave:"));
        }
    }
}
