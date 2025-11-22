using Chat_app_247.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Chat_app_247.Models;   // nơi có class Conversation


namespace Chat_app_247.Services
{
    internal class FirebaseDatabaseService
    {
        // khởi tạo Httpclient để gửi các yêu cầu  HTTP đến firebase 
        private readonly HttpClient _http = new();

        public async Task PutAsync<T>(string path, T data, string idToken)
        { // base url không có auth
            var baseUrl = $"{FirebaseConfigFile.DatabaseURL.TrimEnd('/')}/{path}.json";

            // Nếu idToken rỗng thì không gắn ?auth=
            var url = string.IsNullOrEmpty(idToken)
                ? baseUrl
                : $"{baseUrl}?auth={idToken}";

            var json = JsonSerializer.Serialize(data);

            var res = await _http.PutAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));

            if (!res.IsSuccessStatusCode)
                throw new Exception("Không thể ghi dữ liệu.");
        }
        /// <summary>
        /// Tạo 1 cuộc trò chuyện nhóm mới trên Firebase.
        /// Ghi vào node: Conversations/{conversationId}
        /// </summary>
        public async Task<string> CreateGroupConversationAsync(
            string groupName,
            List<string> participantIds,
            string currentUserId,
            string idToken,
            string groupImageUrl = null)
        {
            if (string.IsNullOrWhiteSpace(groupName))
                throw new ArgumentException("Tên nhóm không được để trống.", nameof(groupName));

            if (participantIds == null)
                participantIds = new List<string>();

            // đảm bảo người tạo cũng là thành viên
            if (!participantIds.Contains(currentUserId))
                participantIds.Add(currentUserId);

            // tự sinh ConversationId
            string conversationId = Guid.NewGuid().ToString("N");

            var conversation = new Conversation
            {
                ConversationId = conversationId,
                IsGroupChat = true,
                GroupName = groupName,
                GroupImageUrl = groupImageUrl,
                ParticipantIds = participantIds,
                AdminIds = new List<string> { currentUserId },
                LastMessage = null,
                TypingIndicator = new Dictionary<string, bool>()
            };

            // dùng lại PutAsync để ghi vào: Conversations/{conversationId}
            string path = $"Conversations/{conversationId}";
            await PutAsync(path, conversation, idToken);

            return conversationId;
        }
    }
}
