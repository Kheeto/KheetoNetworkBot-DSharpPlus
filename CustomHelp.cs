using System;
using System.Collections.Generic;
using System.Text;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Entities;
using DSharpPlus.CommandsNext.Converters;

namespace KheetoNetworkBot
{
    public class CustomHelp : BaseHelpFormatter
    {
        DiscordEmbedBuilder embed = new DiscordEmbedBuilder();
        StringBuilder stringBuilder = new StringBuilder();

        public CustomHelp(CommandContext ctx) : base(ctx)
        {
            embed.Color = new DiscordColor("#FF0000");
            embed.Title = "Kheeto Network - Help";
            embed.Description = "Lista dei comandi del Bot Kheeto Network.";
        }

        public override CommandHelpMessage Build()
        {
            return new CommandHelpMessage(embed: embed);
            return new CommandHelpMessage(content: stringBuilder.ToString());
        }

        public override BaseHelpFormatter WithCommand(Command command)
        {
            embed.Title = "Comando \"" + command.Name + "\" - Help";
            embed.Description = command.Description;
            stringBuilder.AppendLine("Comando: " + command.Name + command.Description);

            string argomenti = "```";
            int index = 0;

            foreach(CommandOverload overl in command.Overloads)
            {
                foreach(CommandArgument arg in overl.Arguments)
                {
                    index++;
                    if (overl.Arguments.Count == 1 || overl.Arguments.Count == index)
                    {
                        argomenti = argomenti + arg.Name + ". ";
                    }
                    else
                    {
                        argomenti = argomenti + arg.Name + ", ";
                    }
                  
                }
            }

            argomenti = argomenti + "```";

            if (argomenti == "``````") argomenti = "Nessun argomento richiesto.";

            embed.AddField("Argomenti del Comando", argomenti);
            stringBuilder.AppendLine("Argomenti del Comando" + argomenti);

            return this;
        }

        public override BaseHelpFormatter WithSubcommands(IEnumerable<Command> subcommands)
        {
            embed.Description = "Usa k!help <comando> per le informazioni specifiche di un comando.";
            string comandi = "```";

            foreach (Command command in subcommands)
            {
                char[] commandChars = command.Name.ToCharArray();
                string commandName = null;
                bool first = true;
                foreach(char c in commandChars)
                {
                    if (c == commandChars[0] && first)
                    {
                        first = false;
                        char[] chars = c.ToString().ToUpper().ToCharArray();
                        commandName = commandName + chars[0].ToString();
                    }
                    else
                    {
                        commandName = commandName + c.ToString();
                    }
                }
                if(commandName != null) comandi = comandi + commandName + ", ";
            }

            comandi = comandi + "```";
            embed.AddField("Comandi del Bot:", comandi);

            return this;
        }
    }
}
