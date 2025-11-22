using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chat_app_247.Models;      // User, Conversation
using Chat_app_247.Services;    // FirebaseDatabaseService
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using Chat_app_247.Class;   
using System.Linq;         
namespace Chat_app_247.Forms
{
    public partial class UC_TaoNhom : UserControl
    {

      
        private string _avatarLocalPath = "";

        // từ FirebaseAuthService 
        public string CurrentUserId { get; set; }
        public string IdToken { get; set; }

        private readonly FirebaseDatabaseService _dbService = new FirebaseDatabaseService();
        private readonly CloudinaryService _cloudService = new CloudinaryService();
        private List<User> _friends = new List<User>();
        // Event báo cho form cha khi tạo nhóm thành công
        public event Action<string, string, string> GroupCreated;
        public UC_TaoNhom()
        {
            InitializeComponent();
            btnChonAnh.Click += btnChonAnh_Click;
            btnTaoNhom.Click += btnTaoNhom_Click;
            lstTatCaUser.DoubleClick += lstTatCaUser_DoubleClick;
            lstThanhVienChon.DoubleClick += lstThanhVienChon_DoubleClick;
        }
        // Xử lý nút Chọn ảnh
        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.png;*.jpg;*.jpeg;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _avatarLocalPath = ofd.FileName;
                    picAvatarNhom.Image = Image.FromFile(_avatarLocalPath);
                    picAvatarNhom.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }
        // Nhận danh sách bạn bè từ form cha và hiển thị lên lstTatCaUser
        public void LoadFriends(List<User> friends)
        {
            _friends = friends ?? new List<User>();

            lstTatCaUser.Items.Clear();
            foreach (var u in _friends)
            {
                lstTatCaUser.Items.Add(u);   // User.ToString() sẽ hiển thị DisplayName
            }
        }
        // Xử lý nút Tạo nhóm
        private async void btnTaoNhom_Click(object sender, EventArgs e)
        {
            string tenNhom = txtTenNhom.Text.Trim();

            if (string.IsNullOrEmpty(tenNhom))
            {
                MessageBox.Show("Vui lòng nhập tên nhóm.");
                return;
            }

            if (lstThanhVienChon.Items.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất 1 thành viên.");
                return;
            }

            if (string.IsNullOrEmpty(CurrentUserId))
            {
                MessageBox.Show("Chưa có CurrentUserId. Hãy set thuộc tính này khi khởi tạo UC_TaoNhom.");
                return;
            }

            // 1. Lấy danh sách uid thành viên
            var participantIds = lstThanhVienChon.Items
                .Cast<User>()                // Chat_app_247.Models.User
                .Select(u => u.UserId)
                .ToList();

            // 2. Upload ảnh nhóm lên Cloudinary (nếu người dùng chọn ảnh)
            string groupImageUrl = null;
            if (!string.IsNullOrEmpty(_avatarLocalPath))
            {
                groupImageUrl = _cloudService.UploadImage(_avatarLocalPath);
                if (groupImageUrl == null)
                {
                    MessageBox.Show("Upload ảnh nhóm thất bại. Bạn có thể thử lại hoặc tạo nhóm không có ảnh.");
                }
            }

            try
            {
                string conversationId = await _dbService.CreateGroupConversationAsync(
                    tenNhom,
                    participantIds,
                    CurrentUserId,
                    IdToken,
                    groupImageUrl);

                MessageBox.Show("Tạo nhóm thành công!");

                // Gọi event báo cho form cha biết để mở màn chat nhóm
                GroupCreated?.Invoke(conversationId, tenNhom, groupImageUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo nhóm: " + ex.Message);
            }

        }
        // Double-click bạn bè bên trái để thêm vào danh sách thành viên
        private void lstTatCaUser_DoubleClick(object sender, EventArgs e)
        {
            if (lstTatCaUser.SelectedItem is User u)
            {
                // tránh trùng
                bool exists = lstThanhVienChon.Items.Cast<User>().Any(x => x.UserId == u.UserId);
                if (!exists)
                {
                    lstThanhVienChon.Items.Add(u);
                }
            }
        }
        // Double-click thành viên bên phải để bỏ ra
        private void lstThanhVienChon_DoubleClick(object sender, EventArgs e)
        {
            if (lstThanhVienChon.SelectedItem != null)
            {
                lstThanhVienChon.Items.Remove(lstThanhVienChon.SelectedItem);
            }
        }
    }
}
