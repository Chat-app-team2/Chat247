using Chat_app_247.Class;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat_app_247.Forms
{
    public partial class addfriend : UserControl

    {
        private User FriendUser;
        private string useridMain;
        private User _targetUser;
        private string _currentUserId;
        private IFirebaseClient _client;
        public addfriend()
        {
            InitializeComponent();
        }

        public async void SetData(User targetUser, string currentUserId, IFirebaseClient client)
        {
            _targetUser = targetUser;
            _currentUserId = currentUserId;
            _client = client;

            // Hiển thị dữ liệu lên UC
            Name_Label.Text = _targetUser.DisplayName;

            // Tải ảnh đại diện (nếu có)
            if (!string.IsNullOrEmpty(_targetUser.ProfilePictureUrl))
            {
                try
                {
                    using (WebClient wc = new WebClient())
                    {
                        byte[] bytes = await wc.DownloadDataTaskAsync(new Uri(_targetUser.ProfilePictureUrl));
                        using (MemoryStream ms = new MemoryStream(bytes))
                        {
                            Avartar_Picture.Image = Image.FromStream(ms);
                        }
                    }
                }
                catch (Exception)
                {
                    Avartar_Picture.Image = null; // hoặc ảnh default
                }
            }

            // Kiểm tra trạng thái: đã gửi, đã là bạn, hay chưa có gì
            await CheckFriendshipStatus();
        }

        // Kiểm tra xem đã gửi lời mời hay đã là bạn chưa
        private async Task CheckFriendshipStatus()
        {
            if (_client == null || _targetUser == null || _currentUserId == null) return;

            FirebaseResponse res = await _client.GetAsync($"Users/{_currentUserId}");
            var currentUser = res.ResultAs<User>();

            if (currentUser == null) return;

            // 1. Đã là bạn
            if (currentUser.FriendIds != null && currentUser.FriendIds.Contains(_targetUser.UserId))
            {
                guna2Button2.Text = "Bạn Bè";
                guna2Button2.Enabled = false;
            }
            // 2. Đã gửi lời mời
            else if (currentUser.FriendRequestSentIds != null && currentUser.FriendRequestSentIds.Contains(_targetUser.UserId))
            {
                guna2Button2.Text = "Đã Gửi";
                guna2Button2.Enabled = false;
            }
            // 3. Đang nhận lời mời từ họ
            else if (currentUser.FriendRequestReceivedIds != null && currentUser.FriendRequestReceivedIds.Contains(_targetUser.UserId))
            {
                guna2Button2.Text = "Chấp Nhận";
                guna2Button2.Enabled = true;
            }
            // 4. Chưa có gì
            else
            {
                guna2Button2.Text = "Thêm Bạn";
                guna2Button2.Enabled = true;
            }
        }


        private async void guna2Button2_Click_1(object sender, EventArgs e)
        {
            if (_client == null || _targetUser == null || _currentUserId == null)
            {
                MessageBox.Show("Lỗi: Dữ liệu người dùng không hợp lệ.");
                return;
            }

            guna2Button2.Enabled = false;
            guna2Button2.Text = "Đang Gửi...";

            try
            {
                // Lấy danh sách FriendRequestSentIds HIỆN TẠI
                var sentListRes = await _client.GetAsync($"Users/{_currentUserId}/FriendRequestSentIds");
                var sentList = sentListRes.ResultAs<List<string>>() ?? new List<string>();

                // Thêm ID người nhận vào danh sách (nếu chưa có)
                if (!sentList.Contains(_targetUser.UserId))
                {
                    sentList.Add(_targetUser.UserId);
                }

                // GHI ĐÈ (SetAsync) danh sách đó lên Firebase.
                await _client.SetAsync($"Users/{_currentUserId}/FriendRequestSentIds", sentList);

                // Lấy danh sách FriendRequestReceivedIds HIỆN TẠI
                var receivedListRes = await _client.GetAsync($"Users/{_targetUser.UserId}/FriendRequestReceivedIds");
                var receivedList = receivedListRes.ResultAs<List<string>>() ?? new List<string>();

                // Thêm ID người gửi vào danh sách (nếu chưa có)
                if (!receivedList.Contains(_currentUserId))
                {
                    receivedList.Add(_currentUserId);
                }

                // GHI ĐÈ (SetAsync) danh sách đó lên Firebase
                await _client.SetAsync($"Users/{_targetUser.UserId}/FriendRequestReceivedIds", receivedList);

                guna2Button2.Text = "Đã Gửi";
                MessageBox.Show("Đã gửi lời mời kết bạn!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gửi lời mời thất bại: " + ex.Message);
                await CheckFriendshipStatus(); // Reset lại trạng thái nút nếu lỗi
            }
        }

        private void uc_Request_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (FriendUser != null)
            {
                string userInfo = $"Thông tin người dùng:\n\n" +
                                    $"Tên hiển thị: {FriendUser.DisplayName ?? "Chưa đặt tên"}\n" +
                                    $"Email: {FriendUser.Email ?? "Chưa có email"}\n";
                MessageBox.Show(userInfo, "Thông tin người dùng", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
