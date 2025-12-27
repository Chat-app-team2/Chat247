using Chat_app_247.Class;
using Chat_app_247.Services;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Chat_app_247.Forms
{
    public partial class uc_SentRequest : UserControl
    {
        private User FriendUser;
        private string useridMain;
        public uc_SentRequest(string userid_main)
        {
            InitializeComponent();
            useridMain = userid_main;
        }
        public async void SetData(string userid)
        {
            var fireclient = new CreateObjectConnectDatabase();
            IFirebaseClient firebaseclient = fireclient.InitializeFirebase();
            FirebaseResponse f_response = await firebaseclient.GetAsync($"Users/{userid}");
            var userData = f_response.ResultAs<User>();
            FriendUser = userData;
            Name_Label.Text = FriendUser.DisplayName;
            await Task.Delay(5000);
            if (!string.IsNullOrEmpty(FriendUser.ProfilePictureUrl))
            {
                try
                {
                    Avartar_Picture.LoadAsync(FriendUser.ProfilePictureUrl);
                }
                catch (Exception ex)
                {
                    Avartar_Picture.Image = null;
                }
            }
        }

        private async void DeleteRequest_button_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteRequest_button.Enabled = false;
                DeleteRequest_button.Text = "Đang Xử Lý";
                string friend_id = FriendUser.UserId;

                bool success = await DeleteRequest(useridMain, friend_id);

                if (success)
                {
                    MessageBox.Show("Đã xóa lời mời kết bạn từ bản thân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Parent?.Controls.Remove(this);
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi khi xóa lời mời!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
            finally
            {
                DeleteRequest_button.Enabled = true;
                DeleteRequest_button.Text = "Xóa Lời Mời";
            }
        }
        private async Task<bool> DeleteRequest(string currentUserId, string friendUserId)
        {
            // Lấy current user
            var fireclient = new CreateObjectConnectDatabase();
            IFirebaseClient firebaseclient = fireclient.InitializeFirebase();
            FirebaseResponse f_response = await firebaseclient.GetAsync($"Users/{currentUserId}");
            var currentUserData = f_response.ResultAs<User>();

            // Lấy friend user
            var fireclient_f = new CreateObjectConnectDatabase();
            IFirebaseClient firebaseclient_f = fireclient_f.InitializeFirebase();
            FirebaseResponse f_response_f = await firebaseclient_f.GetAsync($"Users/{friendUserId}");
            var friendUserData = f_response_f.ResultAs<User>();

            // Kiểm tra và khởi tạo các List nếu chúng bị null
            if (currentUserData.FriendRequestSentIds == null)
            {
                currentUserData.FriendRequestSentIds = new List<string>();
            }
            if (friendUserData.FriendRequestReceivedIds == null)
            {
                friendUserData.FriendRequestReceivedIds = new List<string>();
            }

            // Xử lý xóa lời mời từ mình và xóa lời kết bạn đã gửi tới bạn bè
            currentUserData.FriendRequestSentIds?.Remove(friendUserId);
            friendUserData.FriendRequestReceivedIds?.Remove(currentUserId);
            // Update len Firebase
            await firebaseclient.SetAsync($"Users/{currentUserId}", currentUserData);
            await firebaseclient_f.SetAsync($"Users/{friendUserId}", friendUserData);

            return true;
        }

        private void Full_button_Click(object sender, EventArgs e)
        {
            if (FriendUser == null)
            {
                MessageBox.Show("Không có thông tin người dùng!",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string gioiTinhText = string.IsNullOrWhiteSpace(FriendUser.Gender)
                                    ? "Chưa cập nhật"
                                    : FriendUser.Gender;

            string ngaySinhText = FriendUser.DateOfBirth.HasValue
                                    ? FriendUser.DateOfBirth.Value.ToString("dd/MM/yyyy")
                                    : "Chưa cập nhật";

            string bioText = string.IsNullOrWhiteSpace(FriendUser.Bio)
                                ? "Chưa có giới thiệu"
                                : FriendUser.Bio;

            Form xemthem = new Xemthem(FriendUser.ProfilePictureUrl,
                                        FriendUser.DisplayName ?? "Chưa đặt tên",
                                        FriendUser.Email,
                                        ngaySinhText,
                                        gioiTinhText,
                                        bioText);
            xemthem.ShowDialog();
        }
    }
}
