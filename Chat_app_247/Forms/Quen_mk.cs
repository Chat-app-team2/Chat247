using Chat_app_247.Config;
using Firebase.Auth;
using Firebase.Auth.Providers;
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
    public partial class Quen_mk : Form
    {
        private FirebaseAuthClient F_Auth_Client;
        private string UserEmail;
        public Quen_mk()
        {
            InitializeComponent();
        }
        // Setup() để tạo đối tượng Client
        public void Setup()
        {
            var config = new FirebaseAuthConfig
            {
                ApiKey = FirebaseConfigFile.WebApi,
                Providers = new FirebaseAuthProvider[]
                {
                        new EmailProvider()
                },
                AuthDomain = FirebaseConfigFile.AuthDomain,
            };
            F_Auth_Client = new FirebaseAuthClient(config);
        }
        private async void btnSend_Click(object sender, EventArgs e)
        {
            // Kiểm tra email hợp lệ
            UserEmail = txtEmail.Text;
            if (string.IsNullOrEmpty(UserEmail))
            {
                MessageBox.Show("Vui lòng nhập email hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            try
            {
                // tạo client
                Setup();
                btnSend.Enabled = false;
                btnSend.Font = new Font("Segoe UI", 8, FontStyle.Bold);
                btnSend.Text = "Đang gửi tới email của bạn...";
                btnSend.ForeColor = Color.Black;
                // Gửi link thay đổi mật khẩu
                await F_Auth_Client.ResetEmailPasswordAsync(UserEmail);
                MessageBox.Show("Nếu email tồn tại trong hệ thống, link reset mật khẩu đã được gửi đến email của bạn! Vui lòng kiểm tra hộp thư", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi! Không thể gửi tới mail của bạn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSend.Enabled = true;
                btnSend.Text = "Gửi link đổi mật khẩu";
                btnSend.ForeColor = Color.White;
                btnSend.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            }
        }
        // chức năng khi ấn vào nút hủy 
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();// đóng form hiện tại
        }
    }
}
