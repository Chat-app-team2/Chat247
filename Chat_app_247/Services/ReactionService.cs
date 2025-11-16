using Chat_app_247.Models;
using FireSharp.Interfaces;
using FireSharp.Response;
using System.Collections.Generic;
using System.Threading.Tasks;
using MessageModel = Chat_app_247.Models.Message;

namespace Chat_app_247.Services
{
    public class ReactionService
    {
        private readonly IFirebaseClient _client;

        public ReactionService(IFirebaseClient client)
        {
            _client = client;
        }

        public async Task ToggleReactionAsync(string chatId, string messageId, string emoji, string userId)
        {

            FirebaseResponse res =
                await _client.GetAsync($"Conversations/{chatId}/Messages/{messageId}");
            var msg = res.ResultAs<MessageModel>();

            if (msg == null) return;

            if (msg.Reactions == null)
                msg.Reactions = new Dictionary<string, List<string>>();

            if (!msg.Reactions.ContainsKey(emoji))
                msg.Reactions[emoji] = new List<string>();

            var users = msg.Reactions[emoji];


            if (users.Contains(userId))
            {
                users.Remove(userId);

                if (users.Count == 0)
                    msg.Reactions.Remove(emoji);
            }
            else
            {

                users.Add(userId);
            }


            await _client.UpdateAsync(
                $"Conversations/{chatId}/Messages/{messageId}",
                new { Reactions = msg.Reactions });
        }
    }
}
