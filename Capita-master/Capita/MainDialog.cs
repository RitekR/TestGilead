using System.Collections.Generic;
using System.Linq;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Choices;

namespace Capita
{
    public class MainDialog:WaterfallDialog
    {
        public MainDialog(string dialogId, IEnumerable<WaterfallStep> steps = null) : base(dialogId, steps)
        {
            AddStep(async (stepContext, cancellationToken) =>
            {


                return await stepContext.PromptAsync("choicePrompt",
                    new PromptOptions
                    {
                        Prompt = stepContext.Context.Activity.CreateReply("I am here to help you with below services."),
                        Choices = new[] { new Choice { Value = "Service request" }, new Choice { Value = "Incidence" }, new Choice { Value = "Trouble shooting" } }.ToList()
                    });

            });
            AddStep(async (stepContext, cancellationToken) =>
            {
                var response = (stepContext.Result as FoundChoice)?.Value;

                
                    if (response == "Service request")
                    {
                   
                   
                     return await stepContext.BeginDialogAsync(ServiceRequestDialog.Id);
                }

                    if (response == "Incidence")
                    {
                   
                    return await stepContext.BeginDialogAsync(IncidenceDialog.Id);

                }
                if (response == "Trouble shooting")
                {

                    return await stepContext.BeginDialogAsync(TroubleshootDialogue.Id);

                }

              
                return await stepContext.EndDialogAsync(cancellationToken : cancellationToken);
            });
           

        }
       
        public static string Id => "mainDialog";
        public static MainDialog Instance { get; } = new MainDialog(Id);
    }
   
}
