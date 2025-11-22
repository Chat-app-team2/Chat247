using Chat_app_247.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Chat_app_247.Forms
{
    public partial class UcMessUser : UserControl
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private User _friendUser; // Biến lưu thông tin người bạn này
        // ==== THÊM CHO NHÓM ====
        private bool _isGroup = false;
        private string _conversationId;
        private string _groupName;
        private string _groupImageUrl;

        // Thêm sự kiện OnChatClicked
        public event EventHandler<User> OnChatClicked;
        // Sự kiện cho chat nhóm 
        public event Action<string, string, string> OnGroupChatClicked;
        public UcMessUser()
        {
            InitializeComponent();
            this.AutoSize = false;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
        }
        public async void SetData(User friend)
        {
            _isGroup = false;          // đây là item bạn bè
            _friendUser = friend;

            lblName.Text = _friendUser.DisplayName ?? "(Không có tên)";
            Status_panel.FillColor = _friendUser.IsOnline ? Color.LimeGreen : Color.Gray;

            if (!string.IsNullOrEmpty(_friendUser.ProfilePictureUrl))
            {
                try
                {
                    byte[] bytes = await httpClient.GetByteArrayAsync(_friendUser.ProfilePictureUrl);

                    using (MemoryStream ms = new MemoryStream(bytes))
                    {
                        Avt_pic.Image = Image.FromStream(ms);
                    }
                }
                catch
                {
                    Avt_pic.Image = null; // Hoặc ảnh mặc định
                }
            }
            else
            {
                Avt_pic.Image = null;
            }
        }

        public async void SetGroupData(string conversationId, string groupName, string groupImageUrl)
        {
            _isGroup = true;
            _conversationId = conversationId;
            _groupName = groupName;
            _groupImageUrl = groupImageUrl;
            _friendUser = null;        // không dùng User trong mode group

            lblName.Text = groupName;
            // nhóm không có online/offline -> để xám
            Status_panel.FillColor = Color.Gray;

            if (!string.IsNullOrEmpty(groupImageUrl))
            {
                try
                {
                    byte[] bytes = await httpClient.GetByteArrayAsync(groupImageUrl);
                    using (MemoryStream ms = new MemoryStream(bytes))
                    {
                        Avt_pic.Image = Image.FromStream(ms);
                    }
                }
                catch
                {
                    Avt_pic.Image = null;
                }
            }
            else
            {
                Avt_pic.Image = null; // hoặc icon mặc định cho group
            }
        }
        private void Button_Chat_Click(object sender, EventArgs e)
        {
            if (_isGroup)
            {
                // Item này là NHÓM
                OnGroupChatClicked?.Invoke(_conversationId, _groupName, _groupImageUrl);
            }
            else if (_friendUser != null)
            {
                // Item này là BẠN 1-1
                OnChatClicked?.Invoke(this, _friendUser);
            }
        }
    }
}
