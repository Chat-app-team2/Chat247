using Chat_app_247.Class;
using FireSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat_app_247.Forms
{
    public partial class FriendItem : UserControl
    {
        private User _targetUser;
        private string _currentUserId;
        private IFirebaseClient _client;
        public FriendItem()
        {
            InitializeComponent();
        }

        public async void SetData(User targetUser, string currentUserId, IFirebaseClient client)
        {
            _targetUser = targetUser;
            _currentUserId = currentUserId;
            _client = client;

            //  Kiểm tra DisplayName null
            lblName.Text = _targetUser.DisplayName ?? "(Không có tên)";

            // Hiển thị trạng thái Online/Offline
            UpdateStatus(_targetUser.IsOnline);

            // Tải ảnh đại diện bất đồng bộ
            if (picAvatar != null && !string.IsNullOrEmpty(_targetUser.ProfilePictureUrl))
            {
                try
                {
                    using (WebClient wc = new WebClient())
                    {
                        byte[] bytes = await wc.DownloadDataTaskAsync(new Uri(_targetUser.ProfilePictureUrl));
                        using (MemoryStream ms = new MemoryStream(bytes))
                        {
                            picAvatar.Image = Image.FromStream(ms);
                        }
                    }
                }
                catch (Exception)
                {
                    picAvatar.Image = null;
                }
            }
        }

        public void UpdateStatus(bool isOnline)
        {
            if (pnlDot != null)
            {
                pnlDot.FillColor = isOnline ? Color.LimeGreen : Color.Gray;
            }
        }
    }
}
