using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
namespace Chat_app_247
{
    public partial class Dang_ki : Form
    {   // khởi tạo cấu hinh kết nối 
        IFirebaseConfig config = new FirebaseConfig
        {
            // mã bảo mật (database secret)  : xác thực bạn có quyền truy cập và database 
            AuthSecret = "CZRPuSxymhdWGkfrb1lC9dW6t7WNSlk2bn3UbGSO",
            // đường dẫn gốc (url) đến reatime database 
            BasePath = "https://projectchatapp-fcb8a-default-rtdb.asia-southeast1.firebasedatabase.app/"
        };
        // khởi tạo  đối tượng khách hàng 
        IFirebaseClient client;
        public Dang_ki()
        {
            InitializeComponent();
        }

        private void Dang_ki_Load(object sender, EventArgs e)
        {
            try
            {
                // tạo kết nối trực tiếp đến firebase dựa trên cấu hình đã khởi tạo (config) 
                client = new FireSharp.FirebaseClient(config);
                // kiểm tra có kết nối thành công hay không 
                if (client != null)
                    MessageBox.Show("kết nối firebase thành công !");
            }
            catch
            {
                MessageBox.Show("không thể kết nối firebase ! ");
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            // truy xuất các thuộc tính từ form 
            string username = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirm = txtConfirmPassword.Text.Trim();
            // kiểm tra dữ liệu nhập vào 
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirm))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            // kiểm tra confirm password và password có giông nhau không 
            if (password != confirm)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!");
                return;
            }
   
            string safeEmail = email.Replace(".", "_"); // Firebase không cho dấu chấm trong key
             // kiểm tra tài khoàn đã tồn tại chưa 
            FirebaseResponse res = await client.GetAsync("Users/" + safeEmail);
            User existingUser = res.ResultAs<User>();

            if (existingUser != null)
            {
                MessageBox.Show("Email đã được sử dụng!");
                return;
            }

            // tạo user mới 
            User newUser = new User()
            {
                Username = username,
                Email = email,
                Password = password,

            };
            // ghi vào firebase 
            SetResponse response = await client.SetAsync("Users/" + safeEmail, newUser);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show("Đăng ký thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide(); // ẩn form đăng kí hiện tại 
                Dang_nhap login = new Dang_nhap(); // tạo form đăng nhập mới 
                login.Show(); // hiển thị form đăng nhập 
            }
            else
            {
                MessageBox.Show("Lỗi khi đăng ký, vui lòng thử lại!");
            }
        }

        private void linkdang_nhap_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide(); // ẩn form đăng kí hiện tại 
            Dang_nhap login = new Dang_nhap();// tạo form đăng nhập mới 
            login.Show(); // hiển thị form đăng nhập 
        }
    }
}
