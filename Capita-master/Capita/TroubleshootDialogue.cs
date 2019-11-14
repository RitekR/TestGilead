using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;


namespace Capita
{
    public class TroubleshootDialogue:WaterfallDialog
    {

        public TroubleshootDialogue(string dialogId, IEnumerable<WaterfallStep> steps = null) : base(dialogId, steps)
        {

            this.AddStep(async (stepContext, cancellationToken) =>
            {
                string text = "We will help you regarding trouble shoot issue";
                string message = "We are under construction, Have a nice day!☺️";
                var cardAttachment = Card.CreateAdaptiveCardAttachments(text, message);
                await stepContext.Context.SendActivityAsync(MessageFactory.Attachment(cardAttachment), cancellationToken);
                return await stepContext.EndDialogAsync();
            });
        }
        public static string Id => "Troubleshoot";
        public static TroubleshootDialogue Instance { get; } = new TroubleshootDialogue(Id);
    }
}
