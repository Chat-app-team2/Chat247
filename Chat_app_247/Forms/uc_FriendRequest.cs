using Chat_app_247.Services;
using Firebase;
using FireSharp;
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
using Chat_app_247.Class;
namespace Chat_app_247.Forms
{
    public partial class uc_FriendRequest : UserControl
    {
        private User FriendUser;
        private string useridMain;
        public uc_FriendRequest(string userid_main)
        {
            InitializeComponent();
            useridMain = userid_main;
        }
        // Set data cho UC
        public async void SetData(string userid)
        {
            var fireclient = new CreateObjectConnectDatabase();
            IFirebaseClient firebaseclient = fireclient.InitializeFirebase();
            FirebaseResponse f_response = await firebaseclient.GetAsync($"Users/{userid}");
            var userData = f_response.ResultAs<User>();
            FriendUser = userData;
            Name_Label.Text = FriendUser.DisplayName;
            if (!string.IsNullOrEmpty(FriendUser.ProfilePictureUrl))
            {
                try
                {
                    System.Net.WebRequest request = System.Net.WebRequest.Create(FriendUser.ProfilePictureUrl);
                    System.Net.WebResponse response = request.GetResponse();
                    System.IO.Stream responseStream = response.GetResponseStream();
                    Bitmap bitmap = new Bitmap(responseStream);
                    Avartar_Picture.Image = bitmap;
                    responseStream.Dispose();
                }
                catch (Exception ex)
                {
                    Avartar_Picture.Image = null;
                }
            }

        }
        // Xử lý Event Chấp nhận
        private async void Accept_button_Click(object sender, EventArgs e)
        {
            // Disable button để tránh click nhiều lần
            try
            {
                Accept_button.Enabled = false;
                Accept_button.Text = "Đang xử lý...";

                string friend_id = FriendUser.UserId;

                bool success = await AcceptFriendRequest(useridMain, friend_id);

                if (success)
                {
                    MessageBox.Show("Đã chấp nhận kết bạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Parent?.Controls.Remove(this);
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi khi kết bạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
            finally
            {
                Accept_button.Enabled = true;
                Accept_button.Text = "Chấp nhận";
            }
        }

        // Xử lý khi xảy ra Event Chấp Nhận thì ảnh hưởng gì tới database
        private async Task<bool> AcceptFriendRequest(string currentUserId, string friendUserId)
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

            // Cập nhật cho current user: xóa và thêm
            currentUserData.FriendRequestReceivedIds?.Remove(friendUserId);
            currentUserData.FriendIds.Add(friendUserId);

            // Cập nhật cho friend user: xóa và thêm
            friendUserData.FriendRequestSentIds?.Remove(currentUserId);
            friendUserData.FriendIds.Add(currentUserId);

            // Updata lên Firebase
            await firebaseclient.SetAsync($"Users/{currentUserId}", currentUserData);
            await firebaseclient_f.SetAsync($"Users/{friendUserId}", friendUserData);

            return true;
        }
        // Xử lý event Từ chối
        private async void Refuse_button_Click(object sender, EventArgs e)
        {
            try
            {
                Refuse_button.Enabled = false;
                Refuse_button.Text = "Đang xử lý...";

                string friend_id = FriendUser.UserId; 

                bool success = await RefuseFriendRequest(useridMain, friend_id);

                if (success)
                {
                    MessageBox.Show("Đã từ chối lời mời kết bạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Parent?.Controls.Remove(this);
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi khi từ chối!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
            finally
            {
                Refuse_button.Enabled = true;
                Refuse_button.Text = "Từ chối";
            }
        }

        // Xử lý khi xảy ra Event Từ chối thì ảnh hưởng gì tới database
        private async Task<bool> RefuseFriendRequest(string currentUserId, string friendUserId)
        {
            var fireclient = new CreateObjectConnectDatabase();
            IFirebaseClient firebaseclient = fireclient.InitializeFirebase();

            // Lấy current user
            FirebaseResponse currentResponse = await firebaseclient.GetAsync($"Users/{currentUserId}");
            var currentUserData = currentResponse.ResultAs<User>();

            // Lấy friend user
            FirebaseResponse friendResponse = await firebaseclient.GetAsync($"Users/{friendUserId}");
            var friendUserData = friendResponse.ResultAs<User>();

            // Current user: xóa khỏi danh sách nhận được
            currentUserData.FriendRequestReceivedIds.Remove(friendUserId);

            // Friend user: xóa khỏi danh sách đã gửi
            friendUserData.FriendRequestSentIds.Remove(currentUserId);

            // Update lên Firebase
            await firebaseclient.SetAsync($"Users/{currentUserId}", currentUserData);
            await firebaseclient.SetAsync($"Users/{friendUserId}", friendUserData);

            return true;
        }

        // Xử lý khi người dùng muốn xem thêm thông tin 
        private async void Full_button_Click(object sender, EventArgs e)
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
