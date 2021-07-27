using System;
using System.Linq;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using KheetoNetworkBot.Utils;

namespace KheetoNetworkBot.Comandi.Utilità
{
    public class MathComando : BaseCommandModule
    {
        [Command("Math")]
        [Description("Esegue operazioni matematiche.")]
        public async Task Comando(CommandContext command, [Description("Operazione")] MathOperation operation, [Description("Operando n.1")] double num1, [Description("Operando n.2")] double num2)
        {
            double result = 0.0f;
            DiscordEmoji emoji = DiscordEmoji.FromName(command.Client, ":white_check_mark:");
            switch (operation)
            {
                case MathOperation.ADD:
                    result = num1 + num2;
                    break;

                case MathOperation.SUBTRACT:
                    result = num1 - num2;
                    break;

                case MathOperation.MULTIPLY:
                    result = num1 * num2;
                    break;

                case MathOperation.DIVIDE:
                    result = num1 / num2;
                    break;

                case MathOperation.PERCENT:
                    result = num1 % num2;
                    break;
            }

            await command.RespondAsync($"{emoji} Il risultato è {result.ToString("#,##0.00")}");
        }
    }
}
