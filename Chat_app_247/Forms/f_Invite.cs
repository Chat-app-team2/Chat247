using Chat_app_247.Class;
using Firebase;
using FireSharp;
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
using Chat_app_247.Services;
namespace Chat_app_247
{
    public partial class f_Invite : Form
    {
        private User currentUser;
        public f_Invite(IFirebaseClient firebaseClient,string userid)
        {
            InitializeComponent();
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
            List<string>  FriendID = await GetFriendReceivedIDList(firebaseClient, userid);

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
            List<string> sentRequestNames = await GetFriendRequestSentIdsList(firebaseClient, userid);

            Sent_Panel.Controls.Clear();
            if (sentRequestNames.Count > 0)
            foreach (var name in sentRequestNames)
            {
                Forms.uc_SentRequest sentRequestControl = new Forms.uc_SentRequest();
                sentRequestControl.SetName(name);
                sentRequestControl.Dock = DockStyle.Top;
                Sent_Panel.Controls.Add(sentRequestControl);
            }
        }
        private void LoadNotifyList(IFirebaseClient firebaseClient, string userid)
        {
            List<string> notifyNames = new List<string>
            {
                "Pham Thi I",
                "Tran Van J",
                "Nguyen Thi K"
            };
            Notification_Panel.Controls.Clear();
            foreach (var name in notifyNames)
            {
                Forms.uc_NotificationRequestAcp notifyControl = new Forms.uc_NotificationRequestAcp();
                Forms.uc_NotificationRequestRefuse refuseControl = new Forms.uc_NotificationRequestRefuse();
                notifyControl.SetName(name);
                notifyControl.Dock = DockStyle.Top;
                Notification_Panel.Controls.Add(notifyControl);

                refuseControl.SetName(name);
                refuseControl.Dock = DockStyle.Top;
                Notification_Panel.Controls.Add(refuseControl);
            }
        }
    }
}
