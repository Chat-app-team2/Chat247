using Chat_app_247.Config;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Auth.Repository;
using FireSharp.Config;
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
using Firebase.Auth.Repository;
namespace Chat_app_247
{
    public partial class Dang_nhap : Form
    {
        public Dang_nhap()
        {
            InitializeComponent();
        }
        // ấn vào link fogot password 
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();// ẩn form hiện tại 
            Quen_mk quen_mk = new Quen_mk();// tạo đối tượng form mới quên mật khẩu 
            quen_mk.ShowDialog();// show form quên mật khẩu 

            this.Show();// hiện lại form đăng nhập
        }
        // chức năng khi ấn vào sign up
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide(); // ẩn form hiện tại 
            dang_ki dang_ki = new dang_ki();// tạo đối tượng form đăng kí mới 
            dang_ki.ShowDialog();// show form đăng kí 
            this.Show();// hiện lại form đăng nhập
        }
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ email và mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                btnLogin.Enabled = false;
                btnLogin.Text = "Đang đăng nhập...";

                // Sử dụng FirebaseAuthConfig và EmailProvider để đăng nhập
                var config = new FirebaseAuthConfig
                {
                    ApiKey = FirebaseConfigFile.WebApi,
                    Providers = new FirebaseAuthProvider[]
                    {
                        new EmailProvider()
                    },
                    AuthDomain = FirebaseConfigFile.AuthDomain,
                    // Lưu token đăng nhập
                    UserRepository = new FileUserRepository("FirebaseAuth"),
                };
              
                // Tạo FirebaseAuthClient và đăng nhập
                var authProvider = new FirebaseAuthClient(config);
                var authResult = await authProvider.SignInWithEmailAndPasswordAsync(email, password);
                var idToken = await authResult.User.GetIdTokenAsync();

                if (authResult != null || authResult.User != null)
                {
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Sau khi đăng nhập thành công, chuyển sang form chính
                    var user = authResult.User;
                    this.Hide();
                    f_Dashboard dashboard = new f_Dashboard(user, idToken, authProvider);
                    dashboard.ShowDialog();
                    this.Close();
                }
            }
            catch (FirebaseAuthException ex)
            {
                MessageBox.Show($"Lỗi đăng nhập: Tài khoản và mật khẩu không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLogin.Enabled = true;
                btnLogin.Text = "Đăng nhập";
            }
        }

        private async void Dang_nhap_Load(object sender, EventArgs e)
        {
            // Kiểm tra nếu có saved token, tự động đăng nhập
            await CheckAutoLogin();
        }
        private async Task CheckAutoLogin()
        {
            try
            {
                var config = new FirebaseAuthConfig
                {
                    ApiKey = FirebaseConfigFile.WebApi,
                    Providers = new FirebaseAuthProvider[]
                    {
                new EmailProvider()
                    },
                    AuthDomain = FirebaseConfigFile.AuthDomain,
                    // Lưu token đăng nhập
                    UserRepository = new FileUserRepository("FirebaseAuth"),
                };

                var authProvider = new FirebaseAuthClient(config);

                // Kiểm tra xem có user đã đăng nhập từ trước không
                if (authProvider.User != null)
                {
                    // Có auto-login token, chuyển thẳng đến dashboard
                    var user = authProvider.User;
                    var idToken = await user.GetIdTokenAsync();

                    this.Hide();
                    f_Dashboard dashboard = new f_Dashboard(user, idToken, authProvider);
                    dashboard.ShowDialog(); 
                    this.Close(); 
                }
            }
            catch (Exception ex)
            {
                // Nếu auto-login fail, hiển thị form đăng nhập bình thường
                
            }
        }
    }
}
