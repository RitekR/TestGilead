using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;


namespace Capita
{
    public class IncidenceDialog:WaterfallDialog
    {

        public IncidenceDialog(string dialogId, IEnumerable<WaterfallStep> steps = null) : base(dialogId, steps)
        {

            this.AddStep(async (stepContext, cancellationToken) =>
            {
                string text = " We will help you to resolve your incidence";
                string message = "We are under construction, Have a nice day!☺️";
                var cardAttachment = Card.CreateAdaptiveCardAttachments(text, message);
                await stepContext.Context.SendActivityAsync(MessageFactory.Attachment(cardAttachment), cancellationToken);              
                return await stepContext.EndDialogAsync();
            });
        }
        public static string Id => "IncidenceRequest";
        public static IncidenceDialog Instance { get; } = new IncidenceDialog(Id);
    }
}
