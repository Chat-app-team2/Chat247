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

        // Thêm sự kiện OnChatClicked
        public event EventHandler<User> OnChatClicked;
        public UcMessUser()
        {
            InitializeComponent();
            this.AutoSize = false;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
        }
        public async void SetData(User friend)
        {
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
        }

        private void Button_Chat_Click(object sender, EventArgs e)
        {
            if (_friendUser != null)
            {
                // Gửi thông tin của _friendUser về cho f_Message
                OnChatClicked?.Invoke(this, _friendUser);
            }
        }
    }
}
