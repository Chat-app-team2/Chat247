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
using System.Diagnostics;
using System.Threading.Tasks;

namespace Chat_app_247
{
    public partial class f_Friends : Form
    {
        private readonly IFirebaseClient _firebaseClient;

        private readonly string _userId = "";

        private Dictionary<string, FriendItem> _friendItemMap = new Dictionary<string, FriendItem>();
        private List<string> _currentFriendIds = new List<string>();
        private List<Task> _listenerTasks = new List<Task>();   // Quản lý các listener
        public f_Friends(IFirebaseClient firebaseClient, string userId)
        {
            InitializeComponent();
            _firebaseClient = firebaseClient;
            _userId = userId;
            this.Shown += (s, e) => LoadFriends();
        }

        private void flpFriends_Paint(object sender, PaintEventArgs e)
        {

        }
        private async void LoadFriends()
        {
            if (_firebaseClient == null || string.IsNullOrEmpty(_userId)) return;

            // Xóa sạch map, list và panel
            _friendItemMap.Clear();
            _currentFriendIds.Clear();
            friendsPanel.Controls.Clear();

            try
            {
                FirebaseResponse res = await _firebaseClient.GetAsync($"Users/{_userId}/FriendIds");

                var friendIds = res.ResultAs<List<string>>();

                if (friendIds == null || friendIds.Count == 0)
                {
                    return;
                }

                _currentFriendIds = friendIds;

                friendsPanel.SuspendLayout();

                foreach (var friendId in _currentFriendIds)
                {
                    FirebaseResponse friendRes = await _firebaseClient.GetAsync($"Users/{friendId}");
                    var friendUser = friendRes.ResultAs<User>();

                    if (friendUser != null)
                    {
                        FriendItem friendItem = new FriendItem();
                        friendItem.Dock = DockStyle.Top;
                        friendItem.SetData(friendUser, _userId, _firebaseClient); // Gọi SetData

                        friendsPanel.Controls.Add(friendItem);
                        friendItem.BringToFront();

                        _friendItemMap[friendId] = friendItem;
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
                // Bắt đầu lắng nghe TẤT CẢ bạn bè
                StartAllListeners();
            }
        }

        // Lắng nghe tập trung
        private void StartAllListeners()
        {
            if (_firebaseClient == null) return;

            // Hủy các listener cũ nếu có

            _listenerTasks.Clear();

            foreach (string friendId in _currentFriendIds)
            {
                // Chạy mỗi listener trên một Task riêng
                var listenerTask = Task.Run(async () =>
                {
                    try
                    {
                        // Lắng nghe vĩnh viễn
                        await _firebaseClient.OnAsync($"Users/{friendId}/IsOnline", (sender, args, context) =>
                        {
                            if (bool.TryParse(args.Data, out bool isOnline))
                            {
                                // Tìm FriendItem tương ứng trong Map
                                if (_friendItemMap.TryGetValue(friendId, out FriendItem friendItem))
                                {
                                    // Cập nhật UI an toàn
                                    if (friendItem.IsHandleCreated && !friendItem.IsDisposed)
                                    {
                                        friendItem.BeginInvoke(new Action(() =>
                                        {
                                            friendItem.UpdateStatus(isOnline);
                                        }));
                                    }
                                }
                            }
                        });
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"Lỗi listener cho {friendId}: {ex.Message}");
                    }
                });
                _listenerTasks.Add(listenerTask);
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

