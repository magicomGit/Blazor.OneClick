using Blazor.OneClick.Constants;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace Blazor.OneClick.TelegramBot
{
    public static class TelegramBotHelper
    {


        public delegate void NewMessageReceiveHandler(Update update);

        public static event NewMessageReceiveHandler? OnMessageEvent;
        public static void NewMessageReceive(Update update)
        {
            if (OnMessageEvent != null)
            {
                OnMessageEvent(update);
            }


        }

        public static async Task<bool> OnCallbackQuery(Update update, ITelegramBotClient _bot, ChatMediator _chatMediator)
        {
            if (update.CallbackQuery != null)
            {
                string query = update?.CallbackQuery?.Data;
                var lines = query.Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries);

                // Чат админа с пользователем

                var adminTelegramId = Settings.AdminTelegramId;

                if (lines[0].Contains("reply"))
                {
                    var userId = long.Parse(lines[1]);
                    var adminId = update.CallbackQuery.From.Id;
                    var userMessage = _chatMediator.GetMessageText(adminId.ToString(), userId);



                    var tempMessage = $"Вы отвечаете на сообщение: {userMessage}";
                    // Уведомляем админа
                    Message messageResponse = await _bot.SendTextMessageAsync(adminId, tempMessage);

                    _chatMediator.TempMessageAdmin = messageResponse.MessageId;

                    return true;
                }

            }
            return false;
        }


        public static async Task<bool> OnReplyToChat(Update update, ITelegramBotClient _bot, ChatMediator _chatMediator)
        {
            string message = update.Message.Text;
            var user_Id = update.Message?.From?.Id;
            var chatWithUser = _chatMediator.GetChatUser(user_Id.ToString());
            if (chatWithUser.HasValue)
            {
                if (_bot is null) return true;
                if (update is null || string.IsNullOrEmpty(message)) return true;

                try
                {
                    var adminId = Settings.AdminTelegramId;
                    var userId = _chatMediator.GetChatUser(adminId.ToString());
                    var userMessage = _chatMediator.GetMessageText(adminId.ToString(), userId);

                    var responseMessage = $"<blockquote>{userMessage}</blockquote>\n\n<b>{message}</b>";

                    // Сообщение пользователю
                    await _bot.SendTextMessageAsync(userId, responseMessage, parseMode: ParseMode.Html);

                    // Сообщение админу (редактируем)
                    await _bot.EditMessageTextAsync(adminId, _chatMediator.TempMessageAdmin, responseMessage, ParseMode.Html);

                    // Удаляю сообщение которое отправилось в чат от админа
                    await _bot.DeleteMessageAsync(adminId, _chatMediator.TempMessageAdmin + 1);

                    // Очищаем информацию о чате
                    _chatMediator.StopChat(adminId.ToString(), userId);
                    _chatMediator.TempMessageAdmin = 0;
                }
                catch (Exception ex)
                {
                    //Functionality.SaveTelegramBotErrorLog(Functionality.getStringFromException(ex));
                }
                return true;
            }
            return false;
        }


        public static async Task SendMessageToAdminAsync(string message, Update update, ITelegramBotClient _bot, ChatMediator chatMediator)
        {
            if (_bot is null || string.IsNullOrEmpty(message) || update is null) return;
            if (update.Message is null || update.Message.From is null) return;

            var adminTelegramId = Settings.AdminTelegramId;
            try
            {
                var userId = update.Message.From.Id;
                var userMessage = update.Message.Text;

                var inlineKeyboard = new InlineKeyboardMarkup(new[]
                {
             new[] { InlineKeyboardButton.WithCallbackData($"Ответить", $"reply&{userId}") }
         });

                var response = await _bot.SendTextMessageAsync(
                    adminTelegramId,
                    message,
                    replyMarkup: inlineKeyboard,
                    parseMode: ParseMode.Html
                );

                // Сохраняем сообщение пользователя
                chatMediator.StartChat(adminTelegramId.ToString(), userId, userMessage);
            }
            catch (Exception ex)
            {
                //Functionality.SaveTelegramBotErrorLog(Functionality.getStringFromException(ex));
            }
        }

    }
}
