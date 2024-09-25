using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Blazor.OneClick.TelegramBot
{
    public class TelegramBotEngine
    {
        private readonly ITelegramBotClient _client;
        //private readonly HandleTextMessage _handlerText;
        //private readonly HandleCallbackQuery _handlerCallback;

        public TelegramBotEngine(ITelegramBotClient botClient)
        {
            _client = botClient;
            //Start();
        }

        public void Start()
        {
            try
            {
                var cts = new CancellationTokenSource();
                var cancellationToken = cts.Token;
                var receiverOptions = new ReceiverOptions
                {
                    AllowedUpdates = Array.Empty<UpdateType>(),
                    ThrowPendingUpdates = true
                };

                _client.StartReceiving(
                    HandleUpdateAsync,
                    HandleErrorAsync,
                    receiverOptions,
                    cancellationToken
                );
            }
            catch (Exception ex)
            {
                // Functionality.SaveErrorLog(Functionality.getStringFromException(ex));
            }
        }

        private async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            TelegramBotHelper.NewMessageReceive(update);
            // Если пришло текстовое сообщение
            if (update.Message != null)
            {
                //TelegramBotHelper.NewMessageReceive(update);

            }


            // Если пришёл Callback
            if (update.CallbackQuery != null)
            {

            }
        }

        private Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            string errorMessage = exception is ApiRequestException apiRequestException
                ? $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}"
                : exception.ToString();

            return Task.CompletedTask;
        }
    }
}
