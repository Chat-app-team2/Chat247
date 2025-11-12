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

namespace Chat_app_247
{
    public partial class f_Friends : Form
    {
        private readonly IFirebaseClient _firebaseClient;

        private readonly string _userId = "";

        List<User> users = new List<User>();
        //Biến cấp lớp lưu toàn bộ danh sách mock (để còn lọc/tải lại).
        private List<string> _allFriends = new();
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

        // nạp dữ liệu tạm thời , tạo danh sách tạm thời 

        private void LoadFriends()
        {
            if (_firebaseClient != null)
            {

            }
            _allFriends = new List<string>
            {
                "Nguyen Van A","Tran Thi B","Le Van C","Pham Thi D",
                "Do Van E","Hoang Thi F","Vu Van G","Tran Thi H",
                "Bui Van I","Pham Thi K","Le Van L","Nguyen Thi M"
            };

            RenderFriends(_allFriends);
        }
        // hiển thị giao diện 
        private void RenderFriends(IEnumerable<string> names)
        {
            friendsPanel.SuspendLayout();
            friendsPanel.Controls.Clear();

            foreach (var name in names)
            {
                var item = new FriendItem();
                item.setname(name);        // gán tên vào label trong frienditem
                item.Dock = DockStyle.Top; // xếp dọc  từ trên xuống 
                friendsPanel.Controls.Add(item);
                item.BringToFront();       // đưa item mới lên trên cùng 
            }

            friendsPanel.ResumeLayout();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

