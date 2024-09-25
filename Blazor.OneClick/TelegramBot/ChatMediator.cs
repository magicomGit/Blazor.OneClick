namespace Blazor.OneClick.TelegramBot
{
    public class ChatMediator
    {
        private readonly Dictionary<string, Dictionary<long, string>> _adminToUserChatMessages = new Dictionary<string, Dictionary<long, string>>();
        public int TempMessageAdmin { get; set; }
        public void StartChat(string adminId, long userId, string messageText)
        {
            if (!_adminToUserChatMessages.ContainsKey(adminId))
                _adminToUserChatMessages[adminId] = new Dictionary<long, string>();

            _adminToUserChatMessages[adminId][userId] = messageText;
        }

        public long? GetChatUser(string adminId)
        {
            if (_adminToUserChatMessages.ContainsKey(adminId))
            {
                var userChat = _adminToUserChatMessages[adminId];
                return userChat.Keys.FirstOrDefault();
            }
            return null;
        }

        public string GetMessageText(string adminId, long? userId)
        {
            return _adminToUserChatMessages.ContainsKey(adminId) &&
                _adminToUserChatMessages[adminId].ContainsKey((long)userId)
                ? _adminToUserChatMessages[adminId][(long)userId]
                : string.Empty;
        }


        public void StopChat(string adminId)
        {
            if (_adminToUserChatMessages.ContainsKey(adminId))
                _adminToUserChatMessages.Remove(adminId);
        }

        public void StopChat(string adminId, long? userId)
        {
            if (_adminToUserChatMessages.ContainsKey(adminId) &&
                _adminToUserChatMessages[adminId].ContainsKey((long)userId))
                _adminToUserChatMessages[adminId].Remove((long)userId);
            if (_adminToUserChatMessages[adminId].Count == 0)
                _adminToUserChatMessages.Remove(adminId);

        }
    }
}
