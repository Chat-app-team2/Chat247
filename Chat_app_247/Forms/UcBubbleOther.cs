using Chat_app_247.Services;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MessageModel = Chat_app_247.Models.Message;

namespace Chat_app_247.Forms
{
    public partial class UcBubbleOther : UserControl
    {

        // ID phòng chat (có thể là 1-1 hoặc nhóm)
        public string ChatId { get; set; }

        // ID của message
        public string MessageId { get; set; }

        // ID user hiện tại (người đang dùng app)
        public string CurrentUserId { get; set; }

        private IFirebaseClient _client;
        private ReactionService _reactionService;
        public UcBubbleOther()
        {
            InitializeComponent();
            lblText.ContextMenuStrip = contextEmoji;
            contextEmoji.ItemClicked += contextEmoji_ItemClicked;
        }
        public void SetMessage(string text, string avt, string name)
        {
            lblText.Text = text;
            lb_name.Text = name;
            if (!string.IsNullOrEmpty(avt))
            {
                pic_avt.LoadAsync(avt);
            }
        }

        public string GetText()
        {
            return lblText.Text;
        }
        // Bind đầy đủ dữ liệu message
        public void BindMessage(
            MessageModel msg,
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

            // hiển thị reaction nếu message đã có
            UpdateReactionsUI(msg.Reactions);
        }
        // Hiển thị reaction dưới bubble bằng icon + số lượng
        public void UpdateReactionsUI(Dictionary<string, List<string>> reactions)
        {
            // Xóa icon cũ
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

                // map key -> ảnh trong Resources
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

        private async void contextEmoji_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // Lấy key (like, haha, huhu, heart) từ Tag
            string reactionKey = e.ClickedItem.Tag as string ?? e.ClickedItem.Text;

            if (_reactionService == null ||
                string.IsNullOrEmpty(ChatId) ||
                string.IsNullOrEmpty(MessageId) ||
                string.IsNullOrEmpty(CurrentUserId))
                return;

            // Toggle reaction trên Firebase
            await _reactionService.ToggleReactionAsync(ChatId, MessageId, reactionKey, CurrentUserId);

            // Lấy lại message để cập nhật UI
            FirebaseResponse res =
                await _client.GetAsync($"Conversations/{ChatId}/Messages/{MessageId}");
            var msg = res.ResultAs<MessageModel>();

            if (msg != null)
                UpdateReactionsUI(msg.Reactions);
        }

    }
}
