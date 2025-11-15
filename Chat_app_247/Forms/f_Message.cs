using Chat_app_247.Forms;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Chat_app_247.Class;
using Chat_app_247.Models;
using Chat_app_247.Config;
using Firebase.Database;
using Firebase.Database.Query;
using System.Reactive.Linq;
using Newtonsoft.Json; 

namespace Chat_app_247
{
    public partial class f_Message : Form
    {
        private IFirebaseClient _client;
        private string _userId;
        private string _currentConversationId;
        private FirebaseClient _realtimeClient; // Client mới cho Observable
        private IDisposable _messageSubscription; // Biến này để hủy listener
        private long _lastMessageTimestamp = 0; // Dùng để lọc tin nhắn

        // Constructor
        public f_Message(IFirebaseClient client, string userId)
        {
            InitializeComponent();

            // Client FireSharp 
            _client = client;
            _userId = userId;

            // Client FirebaseDatabase.net 
            _realtimeClient = new FirebaseClient(FirebaseConfigFile.DatabaseURL);

            // Cài đặt UI
            pnl_information.Visible = false;
            pnl_mess.Visible = false;

            // Gắn sự kiện
            this.Load += (s, e) => LoadFriendsListAsync();
        }


        // Dùng FireSharp để tải danh sách bạn bè 
        private async void LoadFriendsListAsync()
        {
            if (_client == null || string.IsNullOrEmpty(_userId)) return;
            try
            {
                FirebaseResponse res = await _client.GetAsync($"Users/{_userId}/FriendIds");
                var friendIds = res.ResultAs<List<string>>();
                if (friendIds == null || friendIds.Count == 0) return;

                Message_panel.Controls.Clear();
                foreach (var friendId in friendIds)
                {
                    FirebaseResponse friendRes = await _client.GetAsync($"Users/{friendId}");
                    var friendUser = friendRes.ResultAs<User>();
                    if (friendUser != null)
                    {
                        UcMessUser ucFriend = new UcMessUser();
                        ucFriend.Dock = DockStyle.Top;
                        ucFriend.SetData(friendUser);
                        ucFriend.OnChatClicked += UcFriend_OnChatClicked; // Nối sự kiện
                        Message_panel.Controls.Add(ucFriend);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Lỗi tải danh sách bạn bè: {ex.Message}");
            }
        }

        // Hàm helper để tạo ID phòng chat
        private string GetConversationId(string uid1, string uid2)
        {
            if (string.Compare(uid1, uid2) < 0)
            {
                return $"{uid1}_{uid2}";
            }
            else
            {
                return $"{uid2}_{uid1}";
            }
        }

        // Xử lý khi nhấn nút "Chat" từ danh sách bạn bè
        private void UcFriend_OnChatClicked(object sender, User friend)
        {
            // Hủy listener tin nhắn cũ
            _messageSubscription?.Dispose();

            // Hiển thị thông tin
            pnl_information.Visible = true;
            pnl_mess.Visible = true;
            guna2HtmlLabel1.Text = friend.DisplayName;

            // Lấy ID phòng
            _currentConversationId = GetConversationId(_userId, friend.UserId);

            // Bắt đầu lắng nghe tin nhắn cho phòng mới
            ListenForNewMessages(_currentConversationId);
        }

        // Thêm bong bóng chat 
        private void AddBubble(Models.Message message)
        {
            UserControl bubble;

            if (message.SenderId == _userId)
            {
                var ucMine = new UcBubbleMine();
                ucMine.SetText(message.Content);
                bubble = ucMine;
            }
            else
            {
                var ucOther = new UcBubbleOther();
                ucOther.SetText(message.Content);
                bubble = ucOther;
            }

            flpMessages.Controls.Add(bubble);
            flpMessages.ScrollControlIntoView(bubble);
        }


        /// <summary>
        /// Tải lịch sử chat và lắng nghe tin nhắn mới bằng AsObservable.
        /// </summary>
        private async void ListenForNewMessages(string conversationId)
        {
            // Dọn dẹp UI và mốc thời gian
            flpMessages.Controls.Clear();
            _lastMessageTimestamp = 0;

            var messageNode = _realtimeClient
                .Child("Conversations")
                .Child(conversationId)
                .Child("Messages");

            // tải lịch sử chat (Dùng GetAsync của FireSharp 1 LẦN)
            try
            {
                // Dùng client FireSharp cũ để GET 1 lần
                var path = $"Conversations/{conversationId}/Messages";
                FirebaseResponse existingMessagesRes = await _client.GetAsync(path);

                if (existingMessagesRes.Body != "null" && !string.IsNullOrEmpty(existingMessagesRes.Body))
                {
                    // Dùng Newtonsoft.Json để Deserialize (FirebaseDatabase.net dùng)
                    var allMessages = JsonConvert.DeserializeObject<Dictionary<string, Models.Message>>(existingMessagesRes.Body);

                    if (allMessages != null && allMessages.Any())
                    {
                        var sortedMessages = allMessages.Values
                            .OrderBy(m => m.Timestamp)
                            .ToList();

                        foreach (var msg in sortedMessages)
                        {
                            AddBubble(msg);
                        }
                        _lastMessageTimestamp = sortedMessages.Last().Timestamp;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Lỗi tải lịch sử chat (hoặc DB rỗng/hỏng): {ex.Message}");
            }

            // add listener cho tin nhắn mới
            _messageSubscription = messageNode
                .AsObservable<Models.Message>() // Lắng nghe các object Message
                .Subscribe(
                    e => // OnNext 
                    {
                        // Chỉ xử lý tin nhắn mới (Insert) và mới hơn mốc thời gian
                        if (e.Object != null &&
                            e.EventType == Firebase.Database.Streaming.FirebaseEventType.InsertOrUpdate &&
                            e.Object.Timestamp > _lastMessageTimestamp)
                        {
                            _lastMessageTimestamp = e.Object.Timestamp;

                            // Cập nhật UI trên luồng chính
                            this.Invoke((MethodInvoker)delegate
                            {
                                AddBubble(e.Object);
                            });
                        }
                    },
                    ex => // OnError 
                    {
                        Debug.WriteLine($"Lỗi listener: {ex.Message}");
                    }
                );
        }


        /// <summary>
        /// Gửi tin nhắn mới (Dùng PostAsync của FirebaseDatabase.net)
        /// </summary>
        private async void btn_send_Click(object sender, EventArgs e)
        {
            string content = txt_mess.Text.Trim();
            if (string.IsNullOrEmpty(content) || string.IsNullOrEmpty(_currentConversationId))
            {
                return;
            }

            try
            {
                // Tạo đối tượng Message
                var newMessage = new Chat_app_247.Models.Message
                {
                    SenderId = _userId,
                    Timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                    MessageType = "Text",
                    Content = content,
                    FileUrl = "",
                    FileName = "",
                    ReadBy = new Dictionary<string, long>()
                };

                // Push tin nhắn mới (dùng PostAsync của FirebaseDatabase.net)
                await _realtimeClient
                    .Child("Conversations")
                    .Child(_currentConversationId)
                    .Child("Messages")
                    .PostAsync(newMessage); // Tự động serialize bằng Newtonsoft.Json

                // Cập nhật "LastMessage" (FireSharp)
                var lastMsgPath = $"Conversations/{_currentConversationId}/LastMessage";
                await _client.SetAsync(lastMsgPath, newMessage);

                // Xóa text box
                txt_mess.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi gửi tin nhắn: {ex.Message}");
            }
        }
    }
}