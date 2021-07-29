using System;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using DSharpPlus.CommandsNext;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.VoiceNext;
using KheetoNetworkBot.Comandi.Utilità;
using KheetoNetworkBot.Comandi.Moderazione;
using KheetoNetworkBot.Comandi.Musica;
using KheetoNetworkBot.Comandi.Info;
using KheetoNetworkBot.Comandi.Divertimento;
using System.Collections.Generic;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;

namespace KheetoNetworkBot
{
    class Program
    {
        static void Main(string[] args)
        {
            new Bot().StartAsync().GetAwaiter().GetResult();
        }

    }

    public class Bot
    {
        public DiscordClient Client { get; private set; }
        public CommandsNextExtension Commands { get; private set; }
        public InteractivityExtension Interactivity { get; private set; }

        public async Task StartAsync() {

            #region Config Bot

            DiscordConfiguration configBot = new DiscordConfiguration
            {
                Token = "token xd",
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                MinimumLogLevel = Microsoft.Extensions.Logging.LogLevel.Debug,
                AlwaysCacheMembers = true,
                Proxy = null,
                GatewayCompressionLevel = GatewayCompressionLevel.Stream,
                MessageCacheSize = 2048,
                UseRelativeRatelimit = false,
            };

            #endregion

            Client = new DiscordClient(configBot);

            Client.Ready += OnReady;

            #region Config Comandi

            CommandsNextConfiguration configComandi = new CommandsNextConfiguration
            {
                StringPrefixes = new string[] { "k!" },
                EnableDms = false,
                EnableDefaultHelp = true,
                EnableMentionPrefix = true,
                CaseSensitive = false,
            };

            #endregion

            #region Config Interactivity

            PaginationEmojis paginationEmojis = new PaginationEmojis();
            paginationEmojis.Left = DiscordEmoji.FromName(Client, ":arrow_left:");
            paginationEmojis.Right = DiscordEmoji.FromName(Client, ":arrow_right:");
            paginationEmojis.SkipLeft = DiscordEmoji.FromName(Client, ":rewind:");
            paginationEmojis.SkipRight = DiscordEmoji.FromName(Client, ":fast_forward:");
            paginationEmojis.Stop = DiscordEmoji.FromName(Client, ":octagonal_sign:");

            InteractivityConfiguration configInteractivity = new InteractivityConfiguration
            {
                PaginationBehaviour = DSharpPlus.Interactivity.Enums.PaginationBehaviour.WrapAround,
                PaginationDeletion = DSharpPlus.Interactivity.Enums.PaginationDeletion.DeleteEmojis,
                PaginationEmojis = paginationEmojis,
                PollBehaviour = DSharpPlus.Interactivity.Enums.PollBehaviour.DeleteEmojis,
                Timeout = new TimeSpan(0, 0, 60),
            };

            #endregion

            #region Config Voice Next

            VoiceNextConfiguration configVoice = new VoiceNextConfiguration
            {
                AudioFormat = AudioFormat.Default,
                EnableIncoming = false,
                PacketQueueSize = 25,
            };

            #endregion

            Commands = Client.UseCommandsNext(configComandi);
            Commands.SetHelpFormatter<CustomHelp>();

            await RegistraComandiAsync().ConfigureAwait(false);

            Client.UseInteractivity(configInteractivity);
            Client.UseVoiceNext(configVoice);

            await Client.ConnectAsync(null, UserStatus.Idle).ConfigureAwait(false);

            await Task.Delay(-1);
        }

        async Task RegistraComandiAsync()
        {
            Commands.RegisterCommands<AnnuncioComando>();
            Commands.RegisterCommands<EmbedComando>();
            Commands.RegisterCommands<RipetiComando>();
            Commands.RegisterCommands<SayComando>();
            Commands.RegisterCommands<ClearComando>();
            Commands.RegisterCommands<CancellaComando>();
            Commands.RegisterCommands<KickComando>();
            Commands.RegisterCommands<BanComando>();
            Commands.RegisterCommands<InfoComando>();
            Commands.RegisterCommands<ImmagineComando>();
            Commands.RegisterCommands<StatoComando>();
            Commands.RegisterCommands<JoinComando>();
            Commands.RegisterCommands<LeaveComando>();
            Commands.RegisterCommands<PlayComando>();
            Commands.RegisterCommands<PollComando>();
            Commands.RegisterCommands<CodiceComando>();
            Commands.RegisterCommands<ReazioneComando>();
            Commands.RegisterCommands<LoremIpsumComando>();
            Commands.RegisterCommands<MathComando>();
            Commands.RegisterCommands<PingComando>();
            Commands.RegisterCommands<SudoComando>();
            Commands.RegisterCommands<NickComando>();
            Commands.RegisterCommands<SupportoComando>();
            Commands.RegisterCommands<GrattaEVinciComando>();
            Commands.RegisterCommands<MemeComando>();
            Commands.RegisterCommands<ReactionRoleComando>();
        }

        async Task OnReady(DiscordClient client, ReadyEventArgs ev)
        {
            Console.WriteLine("Bot Avviato");
            DiscordActivity attivita = new DiscordActivity
            {
                ActivityType = ActivityType.Competing,
                Name = "mc.kheeto67.it",
            };
            await Client.UpdateStatusAsync(attivita, UserStatus.DoNotDisturb);
            Console.WriteLine("Stato del Bot Aggiornato");
        }
    }

}
