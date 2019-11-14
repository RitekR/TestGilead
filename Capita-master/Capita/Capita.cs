using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using Microsoft.Bot.Builder.AI.Luis;
using Microsoft.Bot.Builder.Dialogs;


namespace Capita
{
    public class EmptyBot : ActivityHandler
    {

        private readonly DialogSet dialogs;

        public EmptyBot(CapitaAccessor capitaAccessor)
        {
            var dialogState = capitaAccessor.DialogStateAccessor;
            dialogs = new DialogSet(dialogState);
            dialogs.Add(MainDialog.Instance);
            dialogs.Add(ServiceRequestDialog.Instance);
            dialogs.Add(IncidenceDialog.Instance);
            dialogs.Add(TroubleshootDialogue.Instance);
            dialogs.Add(new ChoicePrompt("choicePrompt"));
     
            CapitaAccessor = capitaAccessor;
        }
        public CapitaAccessor CapitaAccessor { get; }
        public override async Task  OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default(CancellationToken))
        {
            var luisApp = new LuisApplication(
                   applicationId: "3485b012-bb8e-4239-a3d5-7529253fc5fe",
                   endpointKey: "203efc898c8c4c7eb7562c6d0d72c73a",
                   endpoint: "https://westus.api.cognitive.microsoft.com/luis/v2.0/apps/3485b012-bb8e-4239-a3d5-7529253fc5fe?verbose=true&timezoneOffset=-360&subscription-key=203efc898c8c4c7eb7562c6d0d72c73a&q=");


            if (!turnContext.Responded && turnContext.Activity.Type == ActivityTypes.Message)
            {
                var state = await CapitaAccessor.CapitaStateStateAccessor.GetAsync(turnContext, () => new State(), cancellationToken);
                turnContext.TurnState.Add("CapitaAccessors", CapitaAccessor);
                var dc = await dialogs.CreateContextAsync(turnContext, cancellationToken);

                var  dialogResult= await dc.ContinueDialogAsync(cancellationToken);
                if (!dc.Context.Responded)
                {                 
                            var recognizer = new LuisRecognizer(luisApp);
                    var recognizerResult = await recognizer.RecognizeAsync(turnContext, cancellationToken);
                    var (intent, score) = recognizerResult.GetTopScoringIntent();

                    switch (intent)
                    {
                        case "None":
                            await turnContext.SendActivityAsync("Sorry, I don't understand.");
                            break;
                        case "hello":
                            await turnContext.SendActivityAsync("Hello! How can I help you?");
                            break;
                        case "ServiceRequest":
                            await dc.BeginDialogAsync(MainDialog.Id, cancellationToken);
                            
                            break;

                        default:
                         
                            await dc.CancelAllDialogsAsync(cancellationToken);
                            break;

                    }

                 

                    }

                }
                   

            
            else
            {
               
                string text = "👋 Hi, I'm your virtual assistant!";
                string message = "Please ask your question";
                var cardAttachment = Card.CreateAdaptiveCardAttachment(text, message);
                await turnContext.SendActivityAsync(MessageFactory.Attachment(cardAttachment), cancellationToken);
            }
            await CapitaAccessor.ConversationState.SaveChangesAsync(turnContext, false, cancellationToken);
        }
      


    }
}
