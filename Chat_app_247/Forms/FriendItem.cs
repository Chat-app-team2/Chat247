using Chat_app_247.Class;
using FireSharp.Interfaces;
using FireSharp.Response;
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
using System.IO;

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
            if (pic_avta != null && !string.IsNullOrEmpty(_targetUser.ProfilePictureUrl))
            {
                try
                {
                    using (WebClient wc = new WebClient())
                    {
                        byte[] bytes = await wc.DownloadDataTaskAsync(new Uri(_targetUser.ProfilePictureUrl));
                        using (MemoryStream ms = new MemoryStream(bytes))
                        {
                            pic_avta.Image = Image.FromStream(ms);
                        }
                    }
                }
                catch (Exception)
                {
                    pic_avta.Image = null;
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

        private async void Delete_Friend_button_Click(object sender, EventArgs e)
        {
            if (_client == null || _targetUser == null || string.IsNullOrEmpty(_currentUserId))
            {
                MessageBox.Show("Lỗi: Dữ liệu không hợp lệ.");
                return;
            }

            var confirm = MessageBox.Show($"Bạn có chắc muốn hủy kết bạn với {_targetUser.DisplayName ?? "người này"}?",
                                          "Xác nhận hủy kết bạn",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);

            if (confirm == DialogResult.No)
            {
                return;
            }

            this.Enabled = false;

            try
            {
                FirebaseResponse resCurrent = await _client.GetAsync($"Users/{_currentUserId}");
                var currentUserData = resCurrent.ResultAs<User>();
                FirebaseResponse resTarget = await _client.GetAsync($"Users/{_targetUser.UserId}");
                var targetUserData = resTarget.ResultAs<User>();

                if (currentUserData == null || targetUserData == null)
                {
                    throw new Exception("Không tìm thấy thông tin người dùng.");
                }

                var currentFriendIds = currentUserData.FriendIds ?? new List<string>();
                var targetFriendIds = targetUserData.FriendIds ?? new List<string>();

                currentFriendIds.Remove(_targetUser.UserId);
                targetFriendIds.Remove(_currentUserId);

                // Dùng UpdateAsync để chỉ cập nhật node "FriendIds"
                await _client.UpdateAsync($"Users/{_currentUserId}", new { FriendIds = currentFriendIds });
                await _client.UpdateAsync($"Users/{_targetUser.UserId}", new { FriendIds = targetFriendIds });

                MessageBox.Show("Đã hủy kết bạn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Tự xóa mình khỏi panel cha 
                if (this.Parent is Panel panel)
                {
                    panel.Controls.Remove(this);
                }
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hủy kết bạn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Enabled = true;
            }
        }

        private void pnlBase_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Full_button_Click(object sender, EventArgs e)
        {
            if (_targetUser == null)
            {
                MessageBox.Show("Không có thông tin người dùng!",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Giới tính 
            string gioiTinhText = string.IsNullOrWhiteSpace(_targetUser.Gender)
                                    ? "Chưa cập nhật"
                                    : _targetUser.Gender;

            // Ngày sinh
            string ngaySinhText = _targetUser.DateOfBirth.HasValue
                           ? _targetUser.DateOfBirth.Value.ToString("dd/MM/yyyy")
                           : "Chưa cập nhật";

            var sb = new StringBuilder();
            sb.AppendLine("Thông tin người dùng:\n");
            sb.AppendLine($"Họ tên: {_targetUser.DisplayName ?? "Chưa đặt tên"}");
            sb.AppendLine($"Email: {_targetUser.Email ?? "Chưa có email"}");
            sb.AppendLine($"Giới tính: {gioiTinhText}");
            sb.AppendLine($"Ngày sinh: {ngaySinhText}");
            sb.AppendLine($"Giới thiệu: {_targetUser.Bio ?? "Chưa có giới thiệu"}");

            MessageBox.Show(sb.ToString(),
                            "Thông tin người dùng",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }
    }
}