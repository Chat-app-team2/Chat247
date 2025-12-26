using Chat_app_247.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat_app_247.Forms
{
    public partial class SecuritySettingsControl : UserControl
    {
        // Sự kiện bắn về Dashboard khi tên hiển thị được cập nhật thành công
        public event Action<string /*newDisplayName*/>? OnProfileUpdated;
        public SecuritySettingsControl()
        {
            InitializeComponent();
            // Ẩn ký tự ở các ô mật khẩu ngay từ đầu (an toàn mặc định)
            txtCurrentPassword.UseSystemPasswordChar = true;
            txtNewPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // Gắn các event handler cho control trong UI
            cbShowPassword.CheckedChanged += cbShowPassword_CheckedChanged;
            btnSave.Click += btnSave_Click;
        }
        // Dùng để prefill dữ liệu từ Dashboard
        public void LoadUser(string email, string displayName)
        {
            txtEmail.Text = email;
            txtname.Text = displayName;
        }
        // Xử lý khi bấm nút Lưu thay đổi
        private async void btnSave_Click(object sender, EventArgs e)
        {
            // Reset trạng thái thông báo
            lblStatus.Text = "";
            lblStatus.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.ForeColor = System.Drawing.Color.IndianRed;
            // 1) Kiểm tra dữ liệu đầu vào phía client (trước khi gọi API)
            string? error = ValidateInputs();
            if (error != null)
            {
                lblStatus.Text = error;
                return;
            }

            // 2) Khoá nút để tránh bấm liên tục trong lúc gọi API
            btnSave.Enabled = false;

            try
            {
                // FirebaseAuthService: lớp service bạn đã viết để làm việc với Firebase Auth
                var auth = new FirebaseAuthService(); // mock
                 // Gọi API đổi tên + đổi mật khẩu:
                 // - Bước 1 (trong service): re-auth (signInWithPassword) để xác minh mật khẩu hiện tại
                 // - Bước 2 (trong service): accounts:update để đổi displayName/password
                bool ok = await auth.UpdateProfileAndPasswordAsync(
                    email: txtEmail.Text.Trim(),
                    newDisplayName: txtname.Text.Trim(),
                    currentPassword: txtCurrentPassword.Text,
                    newPassword: txtNewPassword.Text
                );

                if (!ok)
                {
                    lblStatus.Text = "Cập nhật thất bại. Kiểm tra mật khẩu hiện tại hoặc thử lại.";
                    return;
                }

                lblStatus.ForeColor = System.Drawing.Color.ForestGreen;
                lblStatus.Text = "Cập nhật thành công.";
                MessageBox.Show("Mật khẩu đã được thay đổi thành công.",
                "Thành công",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                // Báo cho Dashboard cập nhật tên hiển thị ở góc trên (nếu có)
                OnProfileUpdated?.Invoke(txtname.Text.Trim());

                // Xoá các ô mật khẩu để tránh lưu vết
                txtCurrentPassword.Clear();
                txtNewPassword.Clear();
                txtConfirmPassword.Clear();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Lỗi hệ thống: " + ex.Message;
            }
            finally
            {
                btnSave.Enabled = true;
            } 

        }
        // Validate đầu vào ở client
        private string? ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtname.Text))
                return "Tên không được để trống.";

            if (string.IsNullOrWhiteSpace(txtCurrentPassword.Text))
                return "Vui lòng nhập mật khẩu hiện tại.";

            if (string.IsNullOrWhiteSpace(txtNewPassword.Text) || string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
                return "Vui lòng nhập mật khẩu mới và xác nhận.";

            if (txtNewPassword.Text.Length < 8)
                return "Mật khẩu mới tối thiểu 8 ký tự.";

            // ít nhất 1 chữ hoa, 1 chữ thường, 1 số
            var strong = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$");
            if (!strong.IsMatch(txtNewPassword.Text))
                return "Mật khẩu mới cần gồm chữ hoa, chữ thường và số.";

            if (txtNewPassword.Text != txtConfirmPassword.Text)
                return "Xác nhận mật khẩu không khớp.";

            if (txtNewPassword.Text == txtCurrentPassword.Text)
                return "Mật khẩu mới không được trùng mật khẩu hiện tại.";

            return null; // OK
        }
        // Toggle hiện/ẩn mật khẩu khi người dùng tick "Hiện mật khẩu"
        private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            // Nếu show = true → UseSystemPasswordChar = false (hiện chữ)
            // Nếu show = false → UseSystemPasswordChar = true (ẩn chữ)
            bool show = cbShowPassword.Checked;
            txtCurrentPassword.UseSystemPasswordChar = !show;
            txtNewPassword.UseSystemPasswordChar = !show;
            txtConfirmPassword.UseSystemPasswordChar = !show;

        }
    }
}
