using Chat_app_247.Class;
using Chat_app_247.Forms;
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
namespace Chat_app_247
{
    public partial class f_Invite : Form
    {
        private User currentUser;

        private IFirebaseClient _firebaseClient;

        private string _userId;
        public f_Invite(IFirebaseClient firebaseClient, string userid)
        {
            InitializeComponent();
            _firebaseClient = firebaseClient;
            _userId = userid;
            // Hiện ra các bạn bè đã gửi lời mời kết bạn
            LoadInviteList(firebaseClient, userid);
            // Hiện ra các lời mời mà bạn đã gửi
            LoadSentRequestList(firebaseClient, userid);
            // Hiện ra thông báo sau khi được chấp nhận hoặc từ chối kết bạn
            LoadNotifyList(firebaseClient, userid);
        }
        // Lấy FriendRequestReceivedIds trong User
        private async Task<List<string>> GetFriendReceivedIDList(IFirebaseClient firebaseClient, string userid)
        {
            try
            {
                var database = await firebaseClient.GetAsync($"Users/{userid}");
                var userdata = database.ResultAs<User>();
                currentUser = userdata;
                if (currentUser?.FriendRequestReceivedIds == null)
                {
                    return new List<string>();
                }

                return currentUser.FriendRequestReceivedIds.ToList();
            }
            catch (Exception ex)
            {
                return new List<string>();
            }
        }

        // Lấy FriendRequestSentIds trong User
        private async Task<List<string>> GetFriendRequestSentIdsList(IFirebaseClient firebaseClient, string userid)
        {
            try
            {
                var database = await firebaseClient.GetAsync($"Users/{userid}");
                var userdata = database.ResultAs<User>();
                currentUser = userdata;
                if (currentUser?.FriendRequestSentIds == null)
                {
                    return new List<string>();
                }

                return currentUser.FriendRequestSentIds.ToList();
            }
            catch (Exception ex)
            {
                return new List<string>();
            }
        }

        // Lấy FriendRequestReceivedIds và load ra
        private async void LoadInviteList(IFirebaseClient firebaseClient, string userid)
        {
            List<string> FriendID = await GetFriendReceivedIDList(firebaseClient, userid);

            Received_Panel.Controls.Clear();
            if (FriendID.Count > 0)
                foreach (var id in FriendID)
                {
                    Forms.uc_FriendRequest friendRequestControl = new Forms.uc_FriendRequest(currentUser.UserId);
                    friendRequestControl.SetData(id);
                    friendRequestControl.Dock = DockStyle.Top;
                    Received_Panel.Controls.Add(friendRequestControl);
                }
        }

        // Lấy FriendRequestSentIds và load ra
        private async void LoadSentRequestList(IFirebaseClient firebaseClient, string userid)
        {
            List<string> sentRequestIDs = await GetFriendRequestSentIdsList(firebaseClient, userid);

            Sent_Panel.Controls.Clear();
            if (sentRequestIDs.Count > 0)
                foreach (var id in sentRequestIDs)
                {
                    Forms.uc_SentRequest sentRequestControl = new Forms.uc_SentRequest(currentUser.UserId);
                    sentRequestControl.SetData(id);
                    sentRequestControl.Dock = DockStyle.Top;
                    Sent_Panel.Controls.Add(sentRequestControl);
                }
        }
        // Lấy NotifyList trong User 
        private async void LoadNotifyList(IFirebaseClient firebaseClient, string userid)
        {
            try
            {
                var database = await firebaseClient.GetAsync($"Users/{userid}");
                var userdata = database.ResultAs<User>();
                currentUser = userdata;
                Dictionary<string, bool> notifyNames = currentUser?.Notifications ?? new Dictionary<string, bool>();
                Notification_Panel.Controls.Clear();
                foreach (var name in notifyNames)
                {
                    if (name.Value == true) // Chấp nhận
                    {
                        Forms.uc_NotificationRequestAcp notifyControl = new Forms.uc_NotificationRequestAcp();
                        notifyControl.SetData(name.Key);
                        notifyControl.Dock = DockStyle.Top;
                        Notification_Panel.Controls.Add(notifyControl);
                    }
                    else // Từ chối
                    {
                        Forms.uc_NotificationRequestRefuse notifyControl = new Forms.uc_NotificationRequestRefuse();
                        notifyControl.SetData(name.Key);
                        notifyControl.Dock = DockStyle.Top;
                        Notification_Panel.Controls.Add(notifyControl);
                    }
                }
                if (currentUser.Notifications != null)
                {
                    currentUser.Notifications.Clear();
                    await firebaseClient.SetAsync($"Users/{userid}", currentUser);
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu cần
            }
        }

        private void f_Invite_Load(object sender, EventArgs e)
        {

        }

        private async void btn_tim_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            if (string.IsNullOrWhiteSpace(searchText))
            {
                panel_addfriend.Controls.Clear();
                MessageBox.Show("Vui lòng nhập tên hoặc email để tìm kiếm.");
                return;
            }
            try
            {
                FirebaseResponse response = await _firebaseClient.GetAsync("Users");
                var allUsers = response.ResultAs<Dictionary<string, User>>();
                if (allUsers == null)
                {
                    MessageBox.Show("Không tìm thấy người dùng nào.");
                    return;
                }
                var results = allUsers.Values
                    .Where(u => u != null &&
                                u.UserId != _userId && // Bỏ qua chính mình
                                (
                                    (u.DisplayName != null && u.DisplayName.ToLower().Contains(searchText)) ||
                                    (u.Email != null && u.Email.ToLower().Contains(searchText))
                                ))
                    .ToList();
                DisplaySearchResults(results);

                if (results.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy người dùng nào.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
            }
        }

        // Hàm trợ giúp để hiển thị kết quả
        private void DisplaySearchResults(List<User> users)
        {
            panel_addfriend.Controls.Clear();
            panel_addfriend.SuspendLayout();

            string currentUserId = _userId;

            foreach (var user in users)
            {
                addfriend userCard = new addfriend();
                userCard.SetData(user, currentUserId, _firebaseClient);

                userCard.Dock = DockStyle.Top;
                panel_addfriend.Controls.Add(userCard);
                userCard.BringToFront(); // Đảm bảo UC mới nhất ở trên cùng
            }

            panel_addfriend.ResumeLayout(); // Bật lại layout
        }

        private void uitab_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Khi chuyển tab thì tự động load lại dữ liệu
            if (uitab.SelectedTab == Received_tab) 
            {
               LoadInviteList(_firebaseClient, _userId);
            }
            else if (uitab.SelectedTab == Sent_tab) 
            {
                LoadSentRequestList(_firebaseClient, _userId);
            }
            else if (uitab.SelectedTab == Notification_tab) 
            {
                LoadNotifyList(_firebaseClient, _userId);
            }
        }
    }
}
