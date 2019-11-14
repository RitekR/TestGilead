using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;


namespace Capita
{
    public class ServiceRequestDialog:WaterfallDialog
    {
        public ServiceRequestDialog(string dialogId, IEnumerable<WaterfallStep> steps = null) : base(dialogId, steps)
        {

            this.AddStep(async (stepContext, cancellationToken) =>
            {
                string text = "We will help you regarding SR";
                string message = "We are under construction, Have a nice day! ☺️";
                var cardAttachment = Card.CreateAdaptiveCardAttachments(text,message);
                await stepContext.Context.SendActivityAsync(MessageFactory.Attachment(cardAttachment), cancellationToken);

                //await stepContext.Context.SendActivityAsync($"you asked for SR");
                return await stepContext.EndDialogAsync();
            });
        }
        public static string Id => "checkServiceRequest";
        public static ServiceRequestDialog Instance { get; } = new ServiceRequestDialog(Id);
    
}
}
