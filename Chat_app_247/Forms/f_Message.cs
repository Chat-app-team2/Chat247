using Chat_app_247.Class;
using Chat_app_247.Config;
using Chat_app_247.Forms;
using Chat_app_247.Models;
using Firebase.Database;
using Firebase.Database.Query;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json; 
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using System.Windows.Forms;

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
        private bool _isLoadingMessages = false; // Chặn duplicate khi TẢI chat
        private bool _isSending = false;

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
        private async void UcFriend_OnChatClicked(object sender, User friend)
        {
            if (_isLoadingMessages) return;
            _isLoadingMessages = true;

            try
            {
                // Hủy listener tin nhắn cũ
                _messageSubscription?.Dispose();

                // Hiển thị thông tin
                pnl_information.Visible = true;
                pnl_mess.Visible = true;
                guna2HtmlLabel1.Text = friend.DisplayName;

                status.FillColor = friend.IsOnline ? Color.LimeGreen : Color.Gray;

                if (!string.IsNullOrEmpty(friend.ProfilePictureUrl))
                {
                    try
                    {
                        using (var client = new HttpClient()) // Thêm System.Net.Http
                        {
                            var data = await client.GetByteArrayAsync(friend.ProfilePictureUrl);
                            using (var ms = new MemoryStream(data)) // Thêm System.IO
                            {
                                pic_ava.Image = Image.FromStream(ms);
                            }
                        }
                    }
                    catch { pic_ava.Image = null; }
                }
                else { pic_ava.Image = null; }

                // Lấy ID phòng
                _currentConversationId = GetConversationId(_userId, friend.UserId);

                // Bắt đầu lắng nghe 
                await ListenForNewMessages(_currentConversationId);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Lỗi khi mở chat: {ex.Message}");
            }
            finally
            {
                // Tải xong, tắt cờ
                _isLoadingMessages = false;
            }
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
        private async Task ListenForNewMessages(string conversationId)
        {
            // 1. Dọn dẹp UI và mốc thời gian
            flpMessages.Controls.Clear();
            _lastMessageTimestamp = 0;

            var messageNode = _realtimeClient
                .Child("Conversations")
                .Child(conversationId)
                .Child("Messages");

            // 2. Tải lịch sử chat (Dùng GetAsync của FireSharp 1 LẦN)
            try
            {
                var path = $"Conversations/{conversationId}/Messages";
                FirebaseResponse existingMessagesRes = await _client.GetAsync(path);

                if (existingMessagesRes.Body != "null" && !string.IsNullOrEmpty(existingMessagesRes.Body))
                {
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
                Debug.WriteLine($"Lỗi tải lịch sử chat: {ex.Message}");
            }

            // 3. Add listener cho tin nhắn MỚI
            _messageSubscription = messageNode
                .AsObservable<Models.Message>()
                .Subscribe(
                    e =>
                    {
                        if (e.Object != null &&
                            e.EventType == Firebase.Database.Streaming.FirebaseEventType.InsertOrUpdate &&
                            e.Object.Timestamp > _lastMessageTimestamp)
                        {
                            _lastMessageTimestamp = e.Object.Timestamp;
                            this.Invoke((MethodInvoker)delegate
                            {
                                AddBubble(e.Object);
                            });
                        }
                    },
                    ex => { Debug.WriteLine($"Lỗi listener: {ex.Message}"); }
                );
        }


        /// <summary>
        /// Gửi tin nhắn mới (Dùng PostAsync của FirebaseDatabase.net)
        /// </summary>
        private async void btn_send_Click(object sender, EventArgs e)
        {
            if (_isSending) return;

            string content = txt_mess.Text.Trim();
            if (string.IsNullOrEmpty(content) || string.IsNullOrEmpty(_currentConversationId))
            {
                return;
            }

            try
            {
                _isSending = true;

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

                await _realtimeClient
                    .Child("Conversations")
                    .Child(_currentConversationId)
                    .Child("Messages")
                    .PostAsync(newMessage);

                var lastMsgPath = $"Conversations/{_currentConversationId}/LastMessage";
                await _client.SetAsync(lastMsgPath, newMessage);

                txt_mess.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi gửi tin nhắn: {ex.Message}");
            }
            finally
            {
                _isSending = false;
            }
        }
    }
}