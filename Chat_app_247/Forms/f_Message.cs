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
using Chat_app_247.Services;

namespace Chat_app_247
{
    public partial class f_Message : Form
    {
        private IFirebaseClient _client;
        private string _userId;
        private string _currentConversationId;
        private List<User> _friends = new List<User>();

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
        // Chat hiện tại là nhóm hay cá nhân
        private bool _isCurrentGroupChat = false;

        // Nếu là chat cá nhân
        private User _currentFriendUser;

        // Nếu là chat nhóm
        private string _currentGroupName;
        private string _currentGroupImageUrl;
        private UcEmojiPicker _emojiPicker;

        private List<IDisposable> _lastMsgSubscriptions = new List<IDisposable>();

        //Bộ nhớ đệm thông tin user, tránh tải lại nhiều lần
        private Dictionary<string, User> _userCache = new Dictionary<string, User>();
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
            _emojiPicker.Dock = DockStyle.Top;
            _emojiPicker.Height = 0;
            _emojiPicker.OnEmojiSelected += EmojiPicker_OnEmojiSelected;

            pnlEmojiContainer.Controls.Add(_emojiPicker);
            _emojiPicker.Dock = DockStyle.Fill;

            // Gắn sự kiện load form
            this.Load += async (s, e) =>
            {
                await LoadFriendsListAsync();        // load bạn bè
                await LoadGroupConversationsAsync(); // load các nhóm mình đang tham gia
            };

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
                _friends.Clear();

                foreach (var friendId in friendIds)
                {
                    FirebaseResponse friendRes = await _client.GetAsync($"Users/{friendId}");
                    var friendUser = friendRes.ResultAs<User>();

                    if (friendUser != null)
                    {
                        // Lưu vào list bạn bè để dùng cho tạo nhóm
                        _friends.Add(friendUser);
                        UcMessUser ucFriend = new UcMessUser();
                        ucFriend.Dock = DockStyle.Top;
                        ucFriend.SetData(friendUser);
                        ucFriend.OnChatClicked += UcFriend_OnChatClicked; // Nối sự kiện
                        // Lắng nghe tin nhắn cuối
                        string convId = GetConversationId(_userId, friendUser.UserId);
                        ListenForLastMessage(convId, ucFriend);

                        Message_panel.Controls.Add(ucFriend);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Lỗi tải danh sách bạn bè: {ex.Message}");
            }
        }
        // Dùng FireSharp để tải danh sách GROUP mà mình là thành viên
        private async Task LoadGroupConversationsAsync()
        {
            try
            {
                // Lấy hết Conversations từ Firebase
                FirebaseResponse res = await _client.GetAsync("Conversations");

                if (res.Body == "null" || string.IsNullOrEmpty(res.Body))
                    return;

                // Parse JSON sang Dictionary<string, Conversation>
                var allConversations =
                    JsonConvert.DeserializeObject<Dictionary<string, Conversation>>(res.Body);

                if (allConversations == null) return;

                foreach (var kvp in allConversations)
                {
                    var conv = kvp.Value;

                    // chỉ lấy các cuộc chat nhóm mà mình là thành viên
                    if (conv != null &&
                        conv.IsGroupChat &&
                        conv.ParticipantIds != null &&
                        conv.ParticipantIds.Contains(_userId))
                    {
                        // ConversationId có thể null => dùng key Firebase
                        string convId = !string.IsNullOrEmpty(conv.ConversationId)
                                        ? conv.ConversationId
                                        : kvp.Key;

                        AddGroupItemToList(convId, conv.GroupName, conv.GroupImageUrl);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Lỗi tải danh sách nhóm: {ex.Message}");
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
                // ===== đánh dấu đang chat cá nhân =====
                _isCurrentGroupChat = false;
                _currentFriendUser = friend;
                _currentGroupName = null;
                _currentGroupImageUrl = null;
                // Hủy listener tin nhắn cũ
                _messageSubscription?.Dispose();
                // ẨN MÀN TẠO NHÓM nếu đang mở
                pnlCreateGroup.Visible = false;

                // Ẩn panel thông tin (nếu đang mở)
                pnlInfo.Visible = false;
                pnlInfo.Controls.Clear();
                //  dọn luôn control bên trong
                pnlCreateGroup.Controls.Clear();
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
        private async Task AddBubble(Models.Message message)
        {
            bool isMyMessage = (message.SenderId == _userId);

            // Chuẩn bị container
            Panel messageContainer = new Panel
            {
                Width = flpMessages.Width - 25,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                BackColor = Color.Transparent,
                Margin = new Padding(0, 5, 0, 5)
            };

            UserControl bubble;

            //  thông tin User
            string targetUserId = isMyMessage ? _userId : message.SenderId;
            User userParam = null;

            if (_userCache.ContainsKey(targetUserId))
            {
                // Nếu đã có trong cache->Lấy luôn
                userParam = _userCache[targetUserId];
            }
            else
            {
                // Nếu chưa có - Tải từ Firebase và lưu vào cache
                try
                {
                    FirebaseResponse res = await _client.GetAsync($"Users/{targetUserId}");
                    userParam = res.ResultAs<User>();
                    if (userParam != null)
                    {
                        _userCache[targetUserId] = userParam;
                    }
                }
                catch { }
            }

            // Nếu vẫn null thì tạo user tạm để không crash app
            if (userParam == null) userParam = new User { DisplayName = "Unknown", ProfilePictureUrl = "" };

            string displayName = userParam.DisplayName;
            string displayAvt = userParam.ProfilePictureUrl;

            // Tạo Bong bóng chat
            if (isMyMessage)
            {
                var ucMine = new UcBubbleMine();
                ucMine.SetMessage(message, displayAvt, displayName);
                bubble = ucMine;
                bubble.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                bubble.Location = new Point(messageContainer.Width - bubble.Width - 10, 5);
            }
            else
            {
                var ucOther = new UcBubbleOther();
                ucOther.SetMessage(message, displayAvt, displayName);
                bubble = ucOther;
                bubble.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                bubble.Location = new Point(0, 5);
            }

            // Add vào UI
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
                            await AddBubble(msg);
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

                            this.Invoke((MethodInvoker)async delegate
                            {
                                await AddBubble(e.Object);
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
            string content = txt_mess.Text.Trim();
            if (string.IsNullOrEmpty(content) || string.IsNullOrEmpty(_currentConversationId)) return;

            content = ReorderTextAndEmoji(content);

            await SendMessageToFirebase("Text", content);
        }

        private int emojiPanelHeight = 100;
        private void btn_sendfile_Click(object sender, EventArgs e)
        {

            if (pnlEmojiContainer.Height == 0)
            {
                pnlEmojiContainer.Height = emojiPanelHeight;  // mở panel emoji
            }
            else
            {
                pnlEmojiContainer.Height = 0;                 // đóng panel emoji
            }
        }
        //Hàm nhận emoji từ UC
        private void EmojiPicker_OnEmojiSelected(string emoji)
        {

            txt_mess.Focus();

            if (string.IsNullOrWhiteSpace(txt_mess.Text))
                txt_mess.Text = emoji;
            else
                txt_mess.Text = txt_mess.Text.TrimEnd() + " " + emoji;

            txt_mess.SelectionStart = txt_mess.Text.Length;

            // đóng panel emoji
            pnlEmojiContainer.Height = 0;
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

        private void Group_button_Click(object sender, EventArgs e)
        {
            var uc = new UC_TaoNhom();
            uc.Dock = DockStyle.Fill;

            uc.CurrentUserId = _userId;
            uc.IdToken = "";

            uc.LoadFriends(_friends);

            // Khi tạo nhóm xong:
            uc.GroupCreated += (convId, groupName, groupImageUrl) =>
            {
                // Ẩn màn tạo nhóm
                pnlCreateGroup.Visible = false;

                // Thêm UC đại diện cho nhóm vào list bên trái
                AddGroupItemToList(convId, groupName, groupImageUrl);

                // Mở luôn phòng chat nhóm
                OpenGroupConversation(convId, groupName, groupImageUrl);
            };

            // Khi bấm Hủy trên UC_TaoNhom  <-- ĐOẠN BẠN HỎI Ở ĐÂY
            uc.HuyTaoNhom += () =>
            {
                // Ẩn màn tạo nhóm + dọn control
                pnlCreateGroup.Visible = false;
                pnlCreateGroup.Controls.Clear();

                // Hiện lại khu vực chat
                pnl_information.Visible = true;
                pnl_mess.Visible = true;
            };

            // Ẩn chat, hiện panel tạo nhóm
            pnl_information.Visible = false;
            pnl_mess.Visible = false;

            pnlCreateGroup.Controls.Clear();
            pnlCreateGroup.Controls.Add(uc);
            pnlCreateGroup.Visible = true;
            pnlCreateGroup.BringToFront();
        }
        private async void OpenGroupConversation(string conversationId, string groupName, string groupImageUrl)
        {
            // ===== đánh dấu đang chat NHÓM =====
            _isCurrentGroupChat = true;
            _currentFriendUser = null;
            _currentGroupName = groupName;
            _currentGroupImageUrl = groupImageUrl;

            // Hủy listener cũ
            _messageSubscription?.Dispose();

            // ẨN MÀN TẠO NHÓM nếu đang mở
            pnlCreateGroup.Visible = false;
            pnlCreateGroup.Controls.Clear();
            // Ẩn panel thông tin (nếu đang mở)
            pnlInfo.Visible = false;
            pnlInfo.Controls.Clear();

            // Hiển thị khu vực chat
            pnl_information.Visible = true;
            pnl_mess.Visible = true;

            // tiêu đề = tên nhóm
            guna2HtmlLabel1.Text = groupName;

            // Nhóm không có trạng thái online -> xám
            status.FillColor = Color.Gray;

            // ảnh nhóm
            if (!string.IsNullOrEmpty(groupImageUrl))
            {
                try
                {
                    using (var http = new HttpClient())
                    {
                        var data = await http.GetByteArrayAsync(groupImageUrl);
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

            _currentConversationId = conversationId;

            await ListenForNewMessages(_currentConversationId);
        }
        private void AddGroupItemToList(string conversationId, string groupName, string groupImageUrl)
        {
            var ucGroup = new UcMessUser();
            ucGroup.Dock = DockStyle.Top;

            // DÙNG HÀM MỚI CHO NHÓM
            ucGroup.SetGroupData(conversationId, groupName, groupImageUrl);

            // Bấm Chat -> mở chat nhóm
            ucGroup.OnGroupChatClicked += (convId, name, imgUrl) =>
            {
                OpenGroupConversation(convId, name, imgUrl);
            };

            ListenForLastMessage(conversationId, ucGroup);

            // thêm vào trên cùng
            Message_panel.Controls.Add(ucGroup);
            Message_panel.Controls.SetChildIndex(ucGroup, 0);
        }

        private async void btnMore_Click(object sender, EventArgs e)
        {
            // Nếu chưa mở cuộc chat nào thì thôi
            if (string.IsNullOrEmpty(_currentConversationId))
                return;

            // Dọn panel info
            pnlInfo.Controls.Clear();

            // Hiện panel info, ẩn khung chat
            pnlInfo.Visible = true;
            flpMessages.Visible = false;
            pnl_mess.Visible = false;

            if (_isCurrentGroupChat)
            {
                // ==== THÔNG TIN NHÓM ====
                var ucGroupInfo = new UC_ThongTinNhom();
                ucGroupInfo.Dock = DockStyle.Fill;

                // Truyền client + conversationId cho UC, để nó tự đọc Firebase
                ucGroupInfo.FirebaseClient = _client;
                ucGroupInfo.ConversationId = _currentConversationId;
                ucGroupInfo.CurrentUserId = _userId;

                // Đăng ký sự kiện Đóng
                ucGroupInfo.OnCloseRequested += HideInfoPanel;

                // Gọi load từ Firebase
                await ucGroupInfo.LoadDataAsync();

                pnlInfo.Controls.Add(ucGroupInfo);
            }
            else
            {
                // ==== THÔNG TIN CÁ NHÂN ====
                if (_currentFriendUser == null) return;

                var ucUserInfo = new UC_ThongTinCaNhan();
                ucUserInfo.Dock = DockStyle.Fill;

                ucUserInfo.FirebaseClient = _client;
                ucUserInfo.UserId = _currentFriendUser.UserId;

                ucUserInfo.OnCloseRequested += HideInfoPanel;

                await ucUserInfo.LoadDataAsync();

                pnlInfo.Controls.Add(ucUserInfo);
            }
        }
        // Hàm dùng chung để ẩn panel info và quay lại màn chat
        private void HideInfoPanel()
        {
            pnlInfo.Visible = false;
            flpMessages.Visible = true;
            pnl_mess.Visible = true;
        }


        private async void btn_sendf_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn file hoặc ảnh";
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string filePath = ofd.FileName;
                    long fileSize = new FileInfo(filePath).Length;

                    // Kiểm tra dung lượng
                    if (fileSize > 10 * 1024 * 1024)
                    {
                        MessageBox.Show("File quá lớn! Vui lòng chọn file dưới 10MB.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Xác định loại tin nhắn
                    string ext = Path.GetExtension(filePath).ToLower();
                    string[] imgExts = { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
                    string msgType = Array.Exists(imgExts, x => x == ext) ? "Image" : "File";

                    // Upload lên Cloudinary
                    CloudinaryService cloudinary = new CloudinaryService();
                    string url = await Task.Run(() => cloudinary.UploadFile(filePath));

                    if (string.IsNullOrEmpty(url))
                    {
                        MessageBox.Show("Lỗi upload file. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Gửi tin nhắn lên Firebase
                    await SendMessageToFirebase(msgType, url, Path.GetFileName(filePath));
                }
            }
        }
        private async Task SendMessageToFirebase(string type, string contentOrUrl, string fileName = "")
        {
            try
            {
                if (_isSending) return;
                _isSending = true;
                string finalContent = contentOrUrl;

                if (type == "Text")
                {
                    finalContent = Chat_app_247.Services.EncryptionService.Encrypt(contentOrUrl);
                }

                var newMessage = new Chat_app_247.Models.Message
                {
                    SenderId = _userId,
                    Timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                    MessageType = type,
                    Content = (type == "Text") ? finalContent : "", // Nếu là file/ảnh thì content để trống 
                    FileUrl = (type != "Text") ? contentOrUrl : "",
                    FileName = fileName,
                    ReadBy = new Dictionary<string, long>()
                };

                // Gửi lên Firebase
                await _realtimeClient
                    .Child("Conversations")
                    .Child(_currentConversationId)
                    .Child("Messages")
                    .PostAsync(newMessage);

                // Cập nhật LastMessage
                var lastMsgPath = $"Conversations/{_currentConversationId}/LastMessage";
                await _client.SetAsync(lastMsgPath, newMessage);

                if (type == "Text") txt_mess.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi gửi tin: {ex.Message}");
            }
            finally
            {
                _isSending = false;
            }
        }

        // Hàm helper lắng nghe tin nhắn cuối
        private void ListenForLastMessage(string conversationId, UcMessUser uc)
        {
            var sub = _realtimeClient
                .Child("Conversations")
                .Child(conversationId)
                .Child("LastMessage")
                .AsObservable<object>() // Lắng nghe thuộc tính thay đổi
                .Subscribe(d =>
                {
                    // Khi thuộc tính Timestamp thay đổi -> Có tin nhắn mới
                    if (d.Key == "Timestamp")
                    {
                        this.Invoke((MethodInvoker)async delegate
                        {
                            await LoadAndShowLastMessage(conversationId, uc);
                        });
                    }
                });

            // Lưu vào list để quản lý
            _lastMsgSubscriptions.Add(sub);
        }

        // Hàm con để tải trọn vẹn object Message và hiển thị
        private async Task LoadAndShowLastMessage(string conversationId, UcMessUser uc)
        {
            try
            {
                var res = await _client.GetAsync($"Conversations/{conversationId}/LastMessage");
                if (res.Body != "null")
                {
                    var msg = res.ResultAs<Models.Message>();
                    uc.SetLastMessage(msg);
                }
            }
            catch { }
        }

        private void f_Message_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Hủy tất cả các listener LastMessage
            foreach (var sub in _lastMsgSubscriptions)
            {
                sub.Dispose();
            }
            _lastMsgSubscriptions.Clear();

            // Hủy listener tin nhắn chat chính
            _messageSubscription?.Dispose();

        }
    }
}



        
       