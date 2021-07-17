using System;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using DSharpPlus.CommandsNext;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.VoiceNext;
using KheetoNetworkBot.Comandi.Moderazione;

namespace DSharpPlusTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            new Bot().EseguiBot().GetAwaiter().GetResult();
        }
    }

    public class Bot
    {
        public DiscordClient Client { get; private set; }
        public CommandsNextExtension Commands { get; private set; }
        public InteractivityExtension Interactivity { get; private set; }

        public async Task EseguiBot()
        {
            Config config = new Config(Client);

            Client = new DiscordClient(config.configBot);

            Client.Ready += OnReady;

            Commands = Client.UseCommandsNext(config.configComandi);
            Commands.SetHelpFormatter<CustomHelp>();

            await RegistraComandi().ConfigureAwait(false);

            Client.UseInteractivity(config.configInteractivity);
            Client.UseVoiceNext(config.configVoice);

            await Client.ConnectAsync(null, UserStatus.Idle);
            await Task.Delay(-1);
        }

        async Task RegistraComandi()
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
