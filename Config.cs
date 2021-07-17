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
using KheetoNetworkBot.Comandi.Info;

namespace KheetoNetworkBot
{
    public class Config
    {
        public static DiscordClient Client;
        
        public Config(DiscordClient client)
        {
            Client = client;
        }

        #region Config Bot

        public DiscordConfiguration configBot = new DiscordConfiguration
        {
            Token = "NjU2OTE4NTQ4NDcxMzQ5MjYw.XfppEg.e8AnuUpjL6X9YOK_9DNq1rx-whc",
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

        #region Config Comandi

        public CommandsNextConfiguration configComandi = new CommandsNextConfiguration
        {
            StringPrefixes = new string[] { "k!" },
            EnableDms = false,
            EnableDefaultHelp = true,
            EnableMentionPrefix = true,
        };

        #endregion

        #region Config Interactivity

        public InteractivityConfiguration configInteractivity = new InteractivityConfiguration
        {

            PaginationBehaviour = DSharpPlus.Interactivity.Enums.PaginationBehaviour.WrapAround,
            PaginationDeletion = DSharpPlus.Interactivity.Enums.PaginationDeletion.DeleteMessage,
            PaginationEmojis = new PaginationEmojis()
            {
                Left = DiscordEmoji.FromName(Client, ":arrow_left:"),
                Right = DiscordEmoji.FromName(Client, ":arrow_right:"),
                SkipLeft = DiscordEmoji.FromName(Client, ":rewind:"),
                SkipRight = DiscordEmoji.FromName(Client, ":fast_forward:"),
                Stop = DiscordEmoji.FromName(Client, ":octagonal_sign:")
            },
            PollBehaviour = DSharpPlus.Interactivity.Enums.PollBehaviour.DeleteEmojis,
            Timeout = new TimeSpan(0, 0, 60),
        };

        #endregion

        #region Config Voice Next

        public VoiceNextConfiguration configVoice = new VoiceNextConfiguration
        {
            AudioFormat = AudioFormat.Default,
            EnableIncoming = false,
            PacketQueueSize = 25,
        };

        #endregion
    }
}
