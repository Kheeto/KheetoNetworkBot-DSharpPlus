using System;
using System.Collections.Generic;
using System.Text;

namespace KheetoNetworkBot.Handler.Steps.Data
{
    public class ReactionStepData
    {
        public IDialogueStep NextStep { get; set; }
        public string Content { get; set; }
    }
}
