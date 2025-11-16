using Chat_app_247.Services;
using FireSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessageModel = Chat_app_247.Models.Message;

namespace Chat_app_247.Forms
{
    
    public partial class UcBubbleMine : UserControl
    {
        // ---- các thông tin cần cho reaction ----
    public string ChatId { get; set; }          // ID phòng chat (conversationId)
        public string MessageId { get; set; }       // ID message (key trong Firebase)
        public string CurrentUserId { get; set; }   // user đang dùng app
        private IFirebaseClient _client;
        private ReactionService _reactionService;
        public UcBubbleMine()
        {
            InitializeComponent();
            lblText.ContextMenuStrip = guna2ContextMenuStrip1;
            // đăng ký sự kiện click emoji của context menu
            guna2ContextMenuStrip1.ItemClicked += guna2ContextMenuStrip1_ItemClicked;
        }
        public void SetMessage(string text, string avt, string name)
        {
            lblText.Text = text;
            lb_name.Text= name;
            if (!string.IsNullOrEmpty(avt))
            {
                pic_avt.LoadAsync(avt);
            }
        }

        public string GetText()
        {
            return lblText.Text;
        }
        //  Hàm bind đầy đủ dữ liệu message (giống bên Other)
        public void BindMessage(MessageModel msg,
                        string chatId,
                        string messageId,
                        string currentUserId,
                        IFirebaseClient client)
        {
            ChatId = chatId;
            MessageId = messageId;
            CurrentUserId = currentUserId;

            _client = client;
            _reactionService = new ReactionService(client);

            lblText.Text = msg.Content;

            // nếu message đã có reaction từ trước thì show luôn
            UpdateReactionsUI(msg.Reactions);
        }

        // Hiển thị tổng emoji dưới bubble
        public void UpdateReactionsUI(Dictionary<string, List<string>> reactions)
        { // Xóa icon cũ
            flpReactions.Controls.Clear();

            if (reactions == null || reactions.Count == 0)
                return;

            foreach (var kv in reactions)
            {
                string key = kv.Key;                 // "like", "haha", "huhu", "heart"
                int count = kv.Value?.Count ?? 0;
                if (count <= 0) continue;

                // Panel nhỏ chứa icon + số
                var p = new Panel
                {
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    Margin = new Padding(2, 0, 2, 0),
                    BackColor = Color.Transparent
                };

                var pic = new PictureBox
                {
                    Width = 16,
                    Height = 16,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BackColor = Color.Transparent
                };

                // Map key -> ảnh trong Resources
                switch (key)
                {
                    case "like":
                        pic.Image = Properties.Resources.like;
                        break;
                    case "haha":
                        pic.Image = Properties.Resources.haha;
                        break;
                    case "huhu":
                        pic.Image = Properties.Resources.huhu;
                        break;
                    case "heart":
                        pic.Image = Properties.Resources.heart;
                        break;
                    default:
                        continue;   // key lạ thì bỏ qua
                }

                var lbl = new Label
                {
                    AutoSize = true,
                    Text = count.ToString(),
                    ForeColor = Color.Gray,
                    BackColor = Color.Transparent,
                    Margin = new Padding(2, 2, 0, 0)
                };

                p.Controls.Add(pic);
                p.Controls.Add(lbl);

                flpReactions.Controls.Add(p);
            }
        }

        // chọn emoji trong menu
        private async void guna2ContextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        { // Lấy key từ Tag (like, haha, huhu, heart)
            string reactionKey = e.ClickedItem.Tag as string ?? e.ClickedItem.Text;

            if (_reactionService == null ||
                string.IsNullOrEmpty(ChatId) ||
                string.IsNullOrEmpty(MessageId) ||
                string.IsNullOrEmpty(CurrentUserId))
                return;

            // Ghi reaction vào Firebase
            await _reactionService.ToggleReactionAsync(ChatId, MessageId, reactionKey, CurrentUserId);

            // Lấy lại message để cập nhật icon
            var res = await _client.GetAsync($"Conversations/{ChatId}/Messages/{MessageId}");
            var msg = res.ResultAs<MessageModel>();

            if (msg != null)
                UpdateReactionsUI(msg.Reactions);
        }
    }
}
