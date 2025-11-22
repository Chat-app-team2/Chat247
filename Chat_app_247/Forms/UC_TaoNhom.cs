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


        private static readonly HttpClient _http = new HttpClient();

        private string _avatarLocalPath = "";

        // từ FirebaseAuthService 
        public string CurrentUserId { get; set; }
        public string IdToken { get; set; }

        private readonly FirebaseDatabaseService _dbService = new FirebaseDatabaseService();
        private readonly CloudinaryService _cloudService = new CloudinaryService();
        private List<User> _friends = new List<User>();

        // ImageList cho 2 ListView
        private readonly ImageList _imageListTatCa = new ImageList();
        private readonly ImageList _imageListThanhVien = new ImageList();

        // Event báo cho form cha khi tạo nhóm thành công
        public event Action<string, string, string> GroupCreated;
        public UC_TaoNhom()
        {
            InitializeComponent();
            btnChonAnh.Click += btnChonAnh_Click;
            btnTaoNhom.Click += btnTaoNhom_Click;

            // ===== CẤU HÌNH IMAGELIST =====
            _imageListTatCa.ImageSize = new Size(32, 32);
            _imageListTatCa.ColorDepth = ColorDepth.Depth32Bit;
            // gắn sự kiện double-click
            lstTatCaUser.DoubleClick += lstTatCaUser_DoubleClick;

            _imageListThanhVien.ImageSize = new Size(32, 32);
            _imageListThanhVien.ColorDepth = ColorDepth.Depth32Bit;
            // gắn sự kiện double-click
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
        public async void LoadFriends(List<User> friends)
        {
            _friends = friends ?? new List<User>();

            lstTatCaUser.Items.Clear();
            _imageListTatCa.Images.Clear();

            foreach (var u in _friends)
            {
                int imgIndex = -1;

                // Tải avatar nếu có
                if (!string.IsNullOrEmpty(u.ProfilePictureUrl))
                {
                    try
                    {
                        var bytes = await _http.GetByteArrayAsync(u.ProfilePictureUrl);
                        using (var ms = new MemoryStream(bytes))
                        {
                            var avatar = Image.FromStream(ms);
                            _imageListTatCa.Images.Add(avatar);
                            imgIndex = _imageListTatCa.Images.Count - 1;
                        }
                    }
                    catch
                    {
                        // bỏ qua lỗi ảnh
                    }
                }

                var item = new ListViewItem(u.DisplayName ?? "(Không tên)");
                item.Tag = u;                // lưu cả User để dùng sau
                if (imgIndex >= 0)
                    item.ImageIndex = imgIndex;

                lstTatCaUser.Items.Add(item);
            }

            if (lstTatCaUser.Columns.Count > 0)
                lstTatCaUser.Columns[0].Width = -2;   // auto fit
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

            // 1. Lấy danh sách uid thành viên từ ListView bên phải
            var participantIds = lstThanhVienChon.Items
                .Cast<ListViewItem>()
                .Select(it => (it.Tag as User)?.UserId)
                .Where(id => !string.IsNullOrEmpty(id))
                .ToList();

            // Đảm bảo chủ nhóm (CurrentUserId) có trong danh sách
            if (!participantIds.Contains(CurrentUserId))
                participantIds.Add(CurrentUserId);

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
            if (lstTatCaUser.SelectedItems.Count == 0) return;

            var item = lstTatCaUser.SelectedItems[0];
            if (item.Tag is User u)
            {
                // tránh trùng
                bool exists = lstThanhVienChon.Items.Cast<ListViewItem>()
                    .Any(x => x.Tag is User u2 && u2.UserId == u.UserId);

                if (exists) return;

                int imgIndex = -1;
                if (item.ImageIndex >= 0)
                {
                    // copy avatar sang ImageList bên phải
                    var img = _imageListTatCa.Images[item.ImageIndex];
                    _imageListThanhVien.Images.Add(img);
                    imgIndex = _imageListThanhVien.Images.Count - 1;
                }

                var newItem = new ListViewItem(item.Text);
                newItem.Tag = u;
                if (imgIndex >= 0)
                    newItem.ImageIndex = imgIndex;

                lstThanhVienChon.Items.Add(newItem);

                if (lstThanhVienChon.Columns.Count > 0)
                    lstThanhVienChon.Columns[0].Width = -2;
            }
        }
        // Double-click thành viên bên phải để bỏ ra
        private void lstThanhVienChon_DoubleClick(object sender, EventArgs e)
        {
            if (lstThanhVienChon.SelectedItems.Count == 0) return;
            lstThanhVienChon.Items.Remove(lstThanhVienChon.SelectedItems[0]);
        }
    }
}
