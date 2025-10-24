using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Configuration;
namespace Chat_app_247
{
    public partial class Dang_nhap : Form
    {   // khởi tạo cấu hinh kết nối 
        IFirebaseConfig config = new FirebaseConfig
        {   // mã bảo mật (database secret)  : xác thực bạn có quyền truy cập và database
            AuthSecret = "CZRPuSxymhdWGkfrb1lC9dW6t7WNSlk2bn3UbGSO",
            // đường dẫn gốc (url) đến reatime database
            BasePath = "https://projectchatapp-fcb8a-default-rtdb.asia-southeast1.firebasedatabase.app/"
        };
        // khởi tạo  đối tượng khách hàng
        IFirebaseClient client;
        public Dang_nhap()
        {
            InitializeComponent();
        }
        private void lblSubtitle_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }

        private void Dang_nhap_Load(object sender, EventArgs e)
        {   // kiểm tra form kết nối với firebase thành công hay chưa 
            try
            {
                client = new FireSharp.FirebaseClient(config);
                if (client != null)
                {
                    MessageBox.Show("kết nối thành công !");
                }
            }
            catch
            {
                MessageBox.Show("kết nối firebase thất bại !");
            }
            // Khi form load, kiểm tra xem có lưu tài khoản không
            txtEmail.Text = Properties.Settings.Default.Email;
            txtPassword.Text = Properties.Settings.Default.Password;
            chkRemember.Checked = Properties.Settings.Default.RememberMe;

        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {

            string email = txtEmail.Text;
            string password = txtPassword.Text;
            // kiểm tra dữ liệu đầu vào 
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ email !");
                txtEmail.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ mật khẩu !");
                txtPassword.Focus();
                return;
            }
            // Lấy toàn bộ danh sách user từ Firebase
            FirebaseResponse res = await client.GetAsync("Users");
            Dictionary<string, User> allUsers = res.ResultAs<Dictionary<string, User>>();

            if (allUsers == null)
            {
                MessageBox.Show("Không có tài khoản nào trong hệ thống!");
                return;
            }

            // Tìm user có email trùng khớp
            var matchedUser = allUsers.Values.FirstOrDefault(u => u.Email == email);
            if (matchedUser == null)
            {
                MessageBox.Show("Email này chưa được đăng ký!");
                return;
            }
            // Kiểm tra mật khẩu
            if (matchedUser.Password == password)
            {
                MessageBox.Show("Đăng nhập thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // chưa có form chat bao giờ có thì thay 
                // Ẩn form login, mở form chính
                this.Hide();
                // ChatForm chat = new ChatForm(matchedUser.Username);
                // chat.Show();
                if (chkRemember.Checked)
                {
                    Properties.Settings.Default.Email = email;
                    Properties.Settings.Default.Password = password;
                    Properties.Settings.Default.RememberMe = true;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    // Xóa thông tin nếu không chọn
                    Properties.Settings.Default.Email = "";
                    Properties.Settings.Default.Password = "";
                    Properties.Settings.Default.RememberMe = false;
                    Properties.Settings.Default.Save();
                }
            }
            else
            {
                MessageBox.Show("Sai mật khẩu! Vui lòng thử lại.");
            }
        }
        // chức năng  đăng kí 

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Dang_ki signup = new Dang_ki();
            signup.Show();
        }
        // chức năng quên mật khẩu 
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Quen_Mat_Khau qmk = new Quen_Mat_Khau();
            qmk.Show();
        }
    }
}
