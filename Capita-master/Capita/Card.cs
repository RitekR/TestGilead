using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using Microsoft.Bot.Builder.AI.Luis;
using AdaptiveCards;
using Newtonsoft.Json;

namespace Capita
{
    public static class Card
    {

        public static Attachment CreateAdaptiveCardAttachment(string text, string message)
        {
            AdaptiveCard card = new AdaptiveCard();



            card.Body.Add(new AdaptiveTextBlock()
            {
                Text = text,
                Size = AdaptiveTextSize.Medium
            });
            card.Body.Add(new AdaptiveTextBlock()
            {
                Text = message,
                Size = AdaptiveTextSize.Medium
            });
            card.Body.Add(new AdaptiveImage()
            {
                Url = new System.Uri("https://pokerground.com/en/wp-content/uploads/2016/07/lazy-bot-poker-eng.jpg"),
                Size = AdaptiveImageSize.Medium,
                Style = AdaptiveImageStyle.Person
            });
            string json = card.ToJson();
            //var adaptiveCardJson = File.ReadAllText(filePath);

            var adaptiveCardAttachment = new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(json),
            };
            return adaptiveCardAttachment;
        }
        
        public static Attachment CreateAdaptiveCardAttachments(string text, string message)
        {
            AdaptiveCard card = new AdaptiveCard();



            card.Body.Add(new AdaptiveTextBlock()
            {
                Text = text,
                Size = AdaptiveTextSize.Medium
            });
            card.Body.Add(new AdaptiveTextBlock()
            {
                Text = message,
                Size = AdaptiveTextSize.Medium
            });
            card.Body.Add(new AdaptiveImage()
            {
                Url = new System.Uri("https://accelerator-origin.kkomando.com/wp-content/uploads/2016/04/shutterstock_386672542-970x546.jpg"),
                Size = AdaptiveImageSize.Medium,
                Style = AdaptiveImageStyle.Person
            });
            string json = card.ToJson();
            //var adaptiveCardJson = File.ReadAllText(filePath);

            var adaptiveCardAttachment = new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(json),
            };
            return adaptiveCardAttachment;
        }
    }
}
