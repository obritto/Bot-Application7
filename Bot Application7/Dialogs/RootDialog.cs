using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Collections.Generic;

namespace Bot_Application7.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedStart);
        }

        public async Task MessageReceivedStart(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var activity = await argument;

            if (activity != null && activity.Text != null)
            {
                var replyMessage = context.MakeMessage();
                replyMessage.Attachments = new List<Attachment>();

                switch (activity.Text.ToLower())
                {
                    case "static-card":
                        {
                            ShowStaticCard(replyMessage);
                            break;
                        }
                    case "hero-card":
                        {
                            ShowHeroCard(replyMessage);
                            break;
                        }
                    case "thumbnail-card":
                        {
                            ExibirThumbnailCard(replyMessage);
                            break;
                        }
                    case "receipt-card":
                        {
                            ExibirReceiptCard(replyMessage);
                            break;
                        }
                    case "signin-card":
                        {
                            ExibirSignInCard(replyMessage);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }

                await context.PostAsync(replyMessage);

            }

            context.Wait(MessageReceivedStart);
        }

        private static void ExibirSignInCard(IMessageActivity replyMessage)
        {
            List<CardAction> cardButtons = new List<CardAction>();
            CardAction plButton = new CardAction()
            {
                Value = "https://<OAuthSignInURL>",
                Type = "signin",
                Title = "FAZER LOGIN"
            };
            cardButtons.Add(plButton);
            SigninCard plCard = new SigninCard(text: "Me autoriza por favor", buttons: cardButtons);
            Attachment plAttachment = plCard.ToAttachment();
            replyMessage.Attachments.Add(plAttachment);
        }

        private static void ExibirReceiptCard(IMessageActivity replyMessage)
        {
            List<CardImage> cardImages = new List<CardImage>();
            cardImages.Add(new CardImage(url: "https://i.ytimg.com/vi/xqFK_Mt7Ias/hqdefault.jpg"));
            List<CardAction> cardButtons = new List<CardAction>();
            CardAction plButton = new CardAction()
            {
                Value = "https://www.youtube.com/ata275",
                Type = "openUrl",
                Title = "Canal Tiago Britto"
            };
            cardButtons.Add(plButton);
            ReceiptItem lineItem1 = new ReceiptItem()
            {
                Title = "Vídeo 1",
                Subtitle = "Push Notification Android",
                Text = null,
                Image = new CardImage(url: "https://i.ytimg.com/vi/lB2cHAcw1e0/hqdefault.jpg?sqp=-oaymwEWCMQBEG5IWvKriqkDCQgBFQAAiEIYAQ==&rs=AOn4CLBmNxzr7QYRLfP_u2Baw5PzaBKUlA"),
                Price = "1,00",
                Quantity = "1",
                Tap = null
            };
            ReceiptItem lineItem2 = new ReceiptItem()
            {
                Title = "Vídeo 2",
                Subtitle = "Push Notification iOS",
                Text = null,
                Image = new CardImage(url: "https://i.ytimg.com/vi/GSSOlao-GLw/mqdefault.jpg"),
                Price = "1,50",
                Quantity = "3",
                Tap = null
            };
            List<ReceiptItem> receiptList = new List<ReceiptItem>();
            receiptList.Add(lineItem1);
            receiptList.Add(lineItem2);
            ReceiptCard plCard = new ReceiptCard()
            {
                Title = "Veja os vídeos do canal",
                Buttons = cardButtons,
                Items = receiptList,
                Total = "2,50",
                Tax = "0,25"
            };
            Attachment plAttachment = plCard.ToAttachment();
            replyMessage.Attachments.Add(plAttachment);
        }

        private static void ExibirThumbnailCard(IMessageActivity replyMessage)
        {
            List<CardImage> cardImages = new List<CardImage>();
            cardImages.Add(new CardImage(url: "https://i.ytimg.com/vi/xqFK_Mt7Ias/hqdefault.jpg"));
            List<CardAction> cardButtons = new List<CardAction>();
            CardAction plButton = new CardAction()
            {
                Value = "https://www.youtube.com/ata275",
                Type = "openUrl",
                Title = "Canal Tiago Britto"
            };
            cardButtons.Add(plButton);
            ThumbnailCard plCard = new ThumbnailCard()
            {
                Title = "Canal Tiago Britto",
                Subtitle = "Canal de desenvolvedor para desenvolvedor",
                Images = cardImages,
                Buttons = cardButtons
            };
            Attachment plAttachment = plCard.ToAttachment();
            replyMessage.Attachments.Add(plAttachment);
        }

        private static void ShowHeroCard(IMessageActivity replyMessage)
        {
            List<CardImage> cardImages = new List<CardImage>();
            cardImages.Add(new CardImage(url: "https://i.ytimg.com/vi/xqFK_Mt7Ias/hqdefault.jpg"));
            cardImages.Add(new CardImage(url: "https://i.ytimg.com/vi/ihDMm37Br54/hqdefault.jpg?sqp=-oaymwEWCMQBEG5IWvKriqkDCQgBFQAAiEIYAQ==&rs=AOn4CLBZcoSgwEtHxGZiijbuA6x6q_1yyQ"));
            cardImages.Add(new CardImage(url: "https://i.ytimg.com/vi/uV4UFKOEzHU/mqdefault.jpg"));

            List<CardAction> cardButtons = new List<CardAction>();
            CardAction plButton = new CardAction()
            {
                Value = "https://www.youtube.com/ata275",
                Type = "openUrl",
                Title = "Canal Tiago Britto"
            };
            cardButtons.Add(plButton);
            HeroCard plCard = new HeroCard()
            {
                Title = "Canal Tiago Britto",
                Subtitle = "Canal de desenvolvedor para desenvolvedor",
                Images = cardImages,
                Buttons = cardButtons
            };
            Attachment plAttachment = plCard.ToAttachment();
            replyMessage.Attachments.Add(plAttachment);
        }

        private static void ShowStaticCard(IMessageActivity replyMessage)
        {
            replyMessage.Attachments.Add(new Attachment()
            {
                ContentUrl = "https://i.ytimg.com/vi/ihDMm37Br54/hqdefault.jpg?sqp=-oaymwEWCMQBEG5IWvKriqkDCQgBFQAAiEIYAQ==&rs=AOn4CLBZcoSgwEtHxGZiijbuA6x6q_1yyQ",
                ContentType = "image/png",
                Name = "food.png"
            });
        }

    }
}