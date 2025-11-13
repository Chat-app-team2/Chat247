using Chat_app_247.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Firebase;
using FireSharp;
using FireSharp.Interfaces;
using Chat_app_247.Class;
using FireSharp.Response;

namespace Chat_app_247
{
    public partial class f_Friends : Form
    {
        private readonly IFirebaseClient _firebaseClient;

        private readonly string _userId = "";

        public f_Friends(IFirebaseClient firebaseClient, string userId)
        {
            InitializeComponent();
            _firebaseClient = firebaseClient;
            _userId = userId;
            // Render sau khi form đã show (khi đó có kích thước thật)
            this.Shown += (s, e) => LoadFriends();
        }

        private void flpFriends_Paint(object sender, PaintEventArgs e)
        {

        }
        private async void LoadFriends()
        {
            if (_firebaseClient == null || string.IsNullOrEmpty(_userId)) return;

            // Xóa danh sách cũ trước khi tải
            friendsPanel.Controls.Clear();

            try
            {
                FirebaseResponse res = await _firebaseClient.GetAsync($"Users/{_userId}/FriendIds");

                if (res.Body == "null")
                {
                    return;
                }

                var friendIds = res.ResultAs<List<string>>();
                if (friendIds == null || friendIds.Count == 0)
                {
                    return;
                }


                friendsPanel.SuspendLayout();

                foreach (var friendId in friendIds)
                {
                    // Lấy thông tin của từng người bạn
                    FirebaseResponse friendRes = await _firebaseClient.GetAsync($"Users/{friendId}");
                    var friendUser = friendRes.ResultAs<User>();

                    if (friendUser != null)
                    {
                        FriendItem friendItem = new FriendItem();

                        friendItem.Dock = DockStyle.Top;

                        // SetData
                        friendItem.SetData(friendUser, _userId, _firebaseClient);

                        friendsPanel.Controls.Add(friendItem);
                        friendItem.BringToFront();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách bạn bè: " + ex.Message);
            }
            finally
            {
                friendsPanel.ResumeLayout();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void friendsPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void f_Friends_Load(object sender, EventArgs e)
        {

        }
    }
}

