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

namespace Chat_app_247
{
    public partial class Quen_Mat_Khau : Form
    {
        // khởi tạo cấu hinh kết nối 
        IFirebaseConfig config = new FirebaseConfig
        {   // mã bảo mật (database secret)  : xác thực bạn có quyền truy cập và database
            AuthSecret = "CZRPuSxymhdWGkfrb1lC9dW6t7WNSlk2bn3UbGSO",
            // đường dẫn gốc (url) đến reatime database
            BasePath = "https://projectchatapp-fcb8a-default-rtdb.asia-southeast1.firebasedatabase.app/"
        };
        // khởi tạo  đối tượng khách hàng
        IFirebaseClient client;
        public Quen_Mat_Khau()
        {
            InitializeComponent();
        }

        private void Quen_Mat_Khau_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(config);
                if (client == null)
                    MessageBox.Show("Không thể kết nối Firebase. Vui lòng kiểm tra cấu hình.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kết nối Firebase: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // Nút Reset (Đặt lại mật khẩu)
        private async void btnReset_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtnewpassword.Text;
            string confirm = txtconfirmpassword.Text;
            //1. Kiểm tra đầu vào
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Vui lòng nhập email.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirm))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới và xác nhận.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtnewpassword.Focus();
                return;
            }
            if (password != confirm)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp.", "Lỗi mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtnewpassword.Focus();
                return;
            }
            if (password.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải ít nhất 6 ký tự.", "Mật khẩu yếu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtnewpassword.Focus();
                return;
            }
            // 2. Tạo key an toàn cho email vì Firebase không cho dấu '.'
            string safeemail = email.Replace(".", "_");
            try
            {
                FirebaseResponse getRes = await client.GetAsync("Users/" + safeemail);
                if (getRes == null || getRes.Body == "null")
                {
                    MessageBox.Show("Email chưa được đăng ký.", "Không tìm thấy", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                User user = getRes.ResultAs<User>();
                if (user == null)
                {

                    MessageBox.Show("Không đọc được dữ liệu người dùng. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // 4. Cập nhật mật khẩu (lưu ý: plain-text — tuỳ bạn hash nếu muốn)
                user.Password = password;
                // 5. Ghi lại lên Firebase (ghi đè node Users/safeEmail)
                SetResponse setRes = await client.SetAsync("Users/" + safeemail, user);
                // 6. Kiểm tra kết quả (an toàn: chỉ kiểm response != null)
                if (setRes != null)
                {
                    MessageBox.Show("Đặt lại mật khẩu thành công! Vui lòng đăng nhập bằng mật khẩu mới.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    Dang_nhap login = new Dang_nhap();
                    login.Show();

                }
                else
                {
                    MessageBox.Show("Không thể cập nhật mật khẩu. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thao tác với Firebase: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Quay lại form đăng nhập
            this.Hide();
            Dang_nhap login = new Dang_nhap();
            login.Show();
        }
    }
}
    

