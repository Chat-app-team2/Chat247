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
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat_app_247
{
    public partial class f_Message : Form
    {
        private IFirebaseClient _client;
        private string _userId;
        private string _currentConversationId;

        // Client mới cho Observable (FirebaseDatabase.net)
        private FirebaseClient _realtimeClient;

        // Biến này để hủy listener
        private IDisposable _messageSubscription;

        // Dùng để lọc tin nhắn
        private long _lastMessageTimestamp = 0;

        // Chặn duplicate khi TẢI chat
        private bool _isLoadingMessages = false;

        // Cờ chặn double-click gửi
        private bool _isSending = false;

        private UcEmojiPicker _emojiPicker;
        // Constructor
        public f_Message(IFirebaseClient client, string userId)
        {
            InitializeComponent();

            // Gán vào field (KHÔNG tạo biến local mới)
            _client = client;
            _userId = userId;

            // Client FirebaseDatabase.net
            _realtimeClient = new FirebaseClient(FirebaseConfigFile.DatabaseURL);

            // Cài đặt UI
            pnl_information.Visible = false;
            pnl_mess.Visible = false;
            // ====== TẠO UC EMOJI PICKER ======
            _emojiPicker = new UcEmojiPicker();
            _emojiPicker.Visible = false;             // ban đầu ẩn
            _emojiPicker.Dock = DockStyle.Top;        // NẰM TRÊN THANH GÕ
            _emojiPicker.OnEmojiSelected += EmojiPicker_OnEmojiSelected;

            // Thêm vào panel chứa THANH GÕ (panel có txt_mess, nút Gửi, nút emoji)
            pnl_mess.Controls.Add(_emojiPicker);      // <--- THAY bằng tên panel thật
            pnl_mess.Controls.SetChildIndex(_emojiPicker, 0); // UC ở trên, thanh gõ ở dưới
                                                              // BẮT SỰ KIỆN TEXTBOX
         
            // Gắn sự kiện load form
            this.Load += async (s, e) => await LoadFriendsListAsync();

        }

        // Dùng FireSharp để tải danh sách bạn bè
        private async Task LoadFriendsListAsync()
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
            if (string.Compare(uid1, uid2, StringComparison.Ordinal) < 0)
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
                        using (var httpClient = new HttpClient())
                        {
                            var data = await httpClient.GetByteArrayAsync(friend.ProfilePictureUrl);
                            using (var ms = new MemoryStream(data))
                            {
                                pic_ava.Image = Image.FromStream(ms);
                            }
                        }
                    }
                    catch
                    {
                        pic_ava.Image = null;
                    }
                }
                else
                {
                    pic_ava.Image = null;
                }

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
        private async void AddBubble(Models.Message message)
        {
            bool isMyMessage = (message.SenderId == _userId);

            // Tạo panel container với AutoSize
            Panel messageContainer = new Panel
            {
                Width = flpMessages.Width - 25,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                BackColor = Color.Transparent,
                Margin = new Padding(0, 5, 0, 5)
            };

            UserControl bubble;

            if (isMyMessage)
            {
                FirebaseResponse res = await _client.GetAsync($"Users/{_userId}");
                User data = res.ResultAs<User>();

                string myName = data.DisplayName;
                string urlAvt = data.ProfilePictureUrl;

                var ucMine = new UcBubbleMine();
                ucMine.SetMessage(message.Content, urlAvt, myName);
                bubble = ucMine;

                bubble.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                bubble.Location = new Point(messageContainer.Width - bubble.Width - 10, 5);
            }
            else
            {
                FirebaseResponse res = await _client.GetAsync($"Users/{message.SenderId}");
                User data = res.ResultAs<User>();

                string otName = data.DisplayName;
                string otUrlAvt = data.ProfilePictureUrl;

                var ucOther = new UcBubbleOther();
                ucOther.SetMessage(message.Content, otUrlAvt, otName);
                bubble = ucOther;

                bubble.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                bubble.Location = new Point(0, 5);
            }

            messageContainer.Controls.Add(bubble);
            flpMessages.Controls.Add(messageContainer);
            flpMessages.ScrollControlIntoView(messageContainer);
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

                if (existingMessagesRes.Body != "null" &&
                    !string.IsNullOrEmpty(existingMessagesRes.Body))
                {
                    var allMessages =
                        JsonConvert.DeserializeObject<Dictionary<string, Models.Message>>(existingMessagesRes.Body);

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
                    ex =>
                    {
                        Debug.WriteLine($"Lỗi listener: {ex.Message}");
                    });
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
            // CHỮ TRƯỚC – EMOJI SAU
            content = ReorderTextAndEmoji(content);
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

                // Lưu tin nhắn vào Realtime Database
                await _realtimeClient
                    .Child("Conversations")
                    .Child(_currentConversationId)
                    .Child("Messages")
                    .PostAsync(newMessage);

                // Cập nhật LastMessage cho cuộc trò chuyện
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


        private void btn_sendfile_Click(object sender, EventArgs e)
        {
            _emojiPicker.Visible = !_emojiPicker.Visible;
            _emojiPicker.BringToFront();
        }
        //Hàm nhận emoji từ UC
        private void EmojiPicker_OnEmojiSelected(string emoji)
        {

            txt_mess.Focus();

            if (string.IsNullOrWhiteSpace(txt_mess.Text))
            {
                // Nếu chưa có gì, chỉ gửi emoji thôi
                txt_mess.Text = emoji;
            }
            else
            {
                // Nếu đã có text, luôn thêm emoji sau cùng, có 1 khoảng trắng
                txt_mess.Text = txt_mess.Text.TrimEnd() + " " + emoji;
            }

            txt_mess.SelectionStart = txt_mess.TextLength;  // caret về cuối
        }
        // Đưa phần chữ (chữ/số) ra trước, phần emoji/ký tự đặc biệt ở đầu ra sau
        private string ReorderTextAndEmoji(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            input = input.Trim();

            // Tìm vị trí ký tự chữ/số đầu tiên (kể cả tiếng Việt)
            int firstTextIndex = -1;
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsLetterOrDigit(input[i]))
                {
                    firstTextIndex = i;
                    break;
                }
            }

            // Không có chữ => toàn emoji / ký tự đặc biệt => giữ nguyên
            if (firstTextIndex <= 0)
                return input;

            string leading = input.Substring(0, firstTextIndex).Trim();   // đoạn đầu (emoji)
            string textPart = input.Substring(firstTextIndex).Trim();     // đoạn chữ

            if (string.IsNullOrEmpty(leading) || string.IsNullOrEmpty(textPart))
                return input;

            // chữ trước, emoji sau
            return textPart + " " + leading;
        }
        private void f_Message_Load_1(object sender, EventArgs e)
        {
            
        }
       
    };

  }

        
       