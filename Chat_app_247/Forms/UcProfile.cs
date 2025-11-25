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
using FireSharp.Interfaces;
using Chat_app_247.Services;
namespace Chat_app_247.Forms
{
    public partial class UcProfile : UserControl
    {
        // === Trường dùng nội bộ UC ===
        private IFirebaseClient _client;// client Firebase
        private string _uid; // UID người dùng hiện tại (truyền từ Dashboard)
        private User _current; // cache dữ liệu người dùng đang hiển thị 
        public UcProfile()
        {
            InitializeComponent();
            // khi hủy nạp lại dữ liệu từ DB , bỏ mọi thay đổi trên form 
            btnCancel.Click += async (_, __) => await LoadUserAsync();
            // nạp sẵn danh sách nếu combobox đang rỗng 
            if (cboGender != null && cboGender.Items.Count == 0)
                cboGender.Items.AddRange(new[] { "Nam", "Nữ", "Khác" });
        }
        // constructor runtime 
        public UcProfile(IFirebaseClient client, string uid) : this()
        {
            _client = client;
            _uid = uid;
            // khi load UC thì nạp dữ liệu người dùng
            this.Load += async (_, __) => await LoadUserAsync();
        }
        //  Hàm nạp dữ liệu từ Firebase → điền lên UI
        //    - Đọc node: Users/{_uid} (đồng bộ với những chỗ khác như f_Invite)
        //    - Nếu chưa có dữ liệu, tạo User rỗng với UserId = _uid
        private async Task LoadUserAsync()
        {
            // Nếu thiếu client/uid (VD: lỡ khởi tạo bằng constructor rỗng) → không làm gì
            if (_client == null || string.IsNullOrWhiteSpace(_uid)) return;
            // Lấy dữ liệu người dùng
            var res = await _client.GetAsync($"Users/{_uid}");
            _current = res.ResultAs<User>() ?? new User { UserId = _uid };

            // Điền dữ liệu lên các control

            txtFullName.Text = _current.DisplayName ?? "";
            txtEmail.Text = _current.Email ?? "";
            cboGender.Text = _current.Gender ?? "";
            dtpDob.Value = _current.DateOfBirth ?? DateTime.Today;
            txtinfor.Text = _current.Bio ?? "";
            // Ảnh đại diện (nếu có URL hợp lệ trong DB)
            if (!string.IsNullOrWhiteSpace(_current.ProfilePictureUrl))
            {
                try { Avatar_pic.Load(_current.ProfilePictureUrl); }
                catch { Avatar_pic.Image = null; }// Nếu URL lỗi, bỏ ảnh
            }
            else Avatar_pic.Image = null;// Chưa có URL → clear ảnh
            f_Dashboard.Instance.UpDateDataToDashBoard(_current);

        }
        // Nút Lưu:
        //    - Thu thập dữ liệu từ form
        //    - Tạo dictionary "updates" chỉ chứa các field cần cập nhật
        //    - UpdateAsync để KHÔNG ghi đè những mảng/field khác (friendIds, v.v.)
        //    - Sau khi lưu → thông báo + tải lại UI từ DB
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (_client == null || string.IsNullOrWhiteSpace(_uid)) return;
            // Nếu _current chưa có → tạo mới với UserId

            if (_current == null) _current = new User { UserId = _uid };

            // Lấy dữ liệu từ UI gán vào model
            _current.DisplayName = txtFullName.Text.Trim();
            _current.Email = txtEmail.Text.Trim();
            _current.Gender = cboGender.Text;
            _current.DateOfBirth = dtpDob.Value.Date;
            _current.Bio = txtinfor.Text.Trim();

            try
            {
                // Dùng UpdateAsync để chỉ cập nhật các field này, tránh ghi đè node khác
                var updates = new Dictionary<string, object>
                {
                    ["DisplayName"] = _current.DisplayName,
                    ["Email"] = _current.Email,
                    ["Gender"] = _current.Gender,
                    ["DateOfBirth"] = _current.DateOfBirth,// FireSharp sẽ serialize DateTime
                    ["Bio"] = _current.Bio

                };

                await _client.UpdateAsync($"Users/{_uid}", updates);

                MessageBox.Show("Đã lưu thông tin!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Tải lại từ DB để đảm bảo UI khớp dữ liệu đã lưu
                await LoadUserAsync();
            }
            catch (Exception ex)
            {
                // Nếu có lỗi (mạng, rules, URL…), hiển thị thông báo
                MessageBox.Show("Lưu thất bại: " + ex.Message);
            }
        }
        //  Nút Hủy:
        //    - Không lưu gì cả
        //    - Gọi lại LoadUserAsync để trả UI về dữ liệu gốc trên Firebase
        //    - Tạm khóa nút & đổi con trỏ để UX tốt hơn
        private async void btnCancel_Click(object sender, EventArgs e)
        {
            if (_client == null || string.IsNullOrWhiteSpace(_uid)) return;

            var old = Cursor;
            Cursor = Cursors.WaitCursor;
            btnCancel.Enabled = false;
            btnSave.Enabled = false;

            try
            {
                // khôi phục dữ liệu từ DB
                await LoadUserAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải lại dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = old;
                btnCancel.Enabled = true;
                btnSave.Enabled = true;
            }
        }
        private async void UpImage_button_Click(object sender, EventArgs e)
        {
            try
            {
                UpImage_button.Enabled = false;
                UpImage_button.Text = "Đang Tải Ảnh...";
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = dialog.FileName;
                    string imageURL = new CloudinaryService().UploadFile(filePath);
                    if (imageURL != null)
                    {
                        // Luu URL vao database
                        var updates = new Dictionary<string, object>
                    {
                        {"ProfilePictureUrl", imageURL}
                    };
                        await _client.UpdateAsync($"Users/{_uid}", updates);
                        // Hien thi anh URL tu cloudinary
                        await LoadUserAsync();
                        // Hien thi messagebox
                        MessageBox.Show("Chọn avatar mới thành công!");
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                UpImage_button.Enabled = true;
                UpImage_button.Text = "Tải ảnh...";
            }
        }
    }
}
