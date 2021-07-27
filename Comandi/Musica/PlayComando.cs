using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.VoiceNext;
using DSharpPlus.VoiceNext.Codec;
using YoutubeDLSharp;

namespace KheetoNetworkBot.Comandi.Musica
{
    public class PlayComando : BaseCommandModule
    {
        bool youtubeDL = true;

        [Command("Play")]
        [Description("Riproduce la musica nel canale vocale.")]
        public async Task Comando(CommandContext command)
        {

            var voiceNext = command.Client.GetVoiceNext();
            if (voiceNext == null)
            {
                await command.RespondAsync("Impossibile connettere il Bot in un canale vocale, VoiceNext non trovato.");
                return;
            }

            var vnc = voiceNext.GetConnection(command.Guild);
            if (vnc == null)
            {
                await command.RespondAsync("Non sono connesso a un canale vocale, prima usa il comando `k!join`.");
                return;
            }

            var voiceState = command.Member?.VoiceState;
            if (voiceState?.Channel == null && command == null)
            {
                await command.RespondAsync("Non sei in un canale vocale.");
                return;
            }

            if (vnc.TargetChannel != voiceState.Channel)
            {
                await command.RespondAsync("Non sono nello stesso canale vocale in cui sei tu.");
                return;
            }

            await command.Guild.CurrentMember.SetDeafAsync(true);
            await command.Message.CreateReactionAsync(DiscordEmoji.FromName(command.Client, ":headphones:"));

            while (vnc.IsPlaying)
                await vnc.WaitForPlaybackFinishAsync();

            Exception exc = null;
            await command.Message.RespondAsync($"Riproducendo musica nel canale vocale.");

            try
            {
                await PlayMusic(vnc, command);
            }
            catch (Exception ex) { exc = ex; }

            if (exc != null)
                await command.RespondAsync($"Errore: `{exc.GetType()}: {exc.Message}`");
        }

        Stream GetStream()
        {
            var psi = new ProcessStartInfo
            {
                FileName = "ffmpeg.exe",
                Arguments = $@"-i ""musica.mp3"" -ac 2 -f s16le -ar 48000 pipe:1 -loglevel quiet",
                RedirectStandardOutput = true,
                UseShellExecute = false
            };
            var ffmpeg = Process.Start(psi);
            var ffout = ffmpeg.StandardOutput.BaseStream;

            return ffout;
        }

        async Task PlayMusic(VoiceNextConnection vnc, CommandContext command)
        {
            await vnc.SendSpeakingAsync(true);

            Stream ffout = GetStream();

            var txStream = vnc.GetTransmitSink();
            await ffout.CopyToAsync(txStream);
            await txStream.FlushAsync();
            await vnc.WaitForPlaybackFinishAsync();

            await MusicEnd(vnc, command);
        }

        async Task MusicEnd(VoiceNextConnection vnc, CommandContext command)
        {
            await vnc.SendSpeakingAsync(false);
            DiscordMessage messaggioFine = await command.Message.RespondAsync($"Finito di riprodurre la musica, la sto rimettendo...");

            await PlayMusic(vnc, command);
        }
    }

}
