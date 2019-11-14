using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;

namespace Capita
{
    public class CapitaAccessor
    {
        public CapitaAccessor(ConversationState conversationState)
        {
            ConversationState = conversationState ?? throw new ArgumentNullException(nameof(conversationState));
        }
        public static string CapitaStateAccessorName { get; } = $"{nameof(CapitaStateStateAccessor)}.CapitaBotState";
        public IStatePropertyAccessor<State> CapitaStateStateAccessor { get; internal set; }
        public static string DialogStateAccessorName { get; } = $"{nameof(CapitaAccessor)}.DialogState";
        public IStatePropertyAccessor<DialogState> DialogStateAccessor { get; internal set; }
        public ConversationState ConversationState { get; }
    }
}
