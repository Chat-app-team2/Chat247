using Chat_app_247.Class;
using Chat_app_247.Services;
using FireSharp;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Text;
using System.Windows.Forms;

namespace Chat_app_247.Forms
{
    public partial class UcMessUser : UserControl
    {
        private User FriendUser;
        private string _friendId;
        public UcMessUser()
        {
            InitializeComponent();
            this.AutoSize = false;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
        }
        public async void SetData(string friendId)
        {
            _friendId = friendId;

            var fireclient = new CreateObjectConnectDatabase();
            IFirebaseClient firebaseclient = fireclient.InitializeFirebase();

            FirebaseResponse f_response = await firebaseclient.GetAsync($"Users/{friendId}");
            FriendUser = f_response.ResultAs<User>();

            if (FriendUser != null)
            {
                // hiển thị tên ở item
                lblName.Text = FriendUser.DisplayName;
                
               
            }
            else
            {
                lblName.Text = "Không tìm thấy người dùng";
            }

        }
        // nút xem thêm 
        private void btn_xemthem_Click(object sender, EventArgs e)
        {
            if (FriendUser == null)
            {
                MessageBox.Show("Không có thông tin người dùng!",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ------ Xử lý hiển thị giới tính ------
            string gioiTinhText = string.IsNullOrWhiteSpace(FriendUser.Gender)
                             ? "Chưa cập nhật"
                             : FriendUser.Gender;

            // ------ Xử lý ngày sinh ------
            string ngaySinhText;
            if (FriendUser.DateOfBirth is DateTime dob)
                ngaySinhText = dob.ToString("dd/MM/yyyy");
            else
                ngaySinhText = string.IsNullOrEmpty(FriendUser.DateOfBirth?.ToString())
                               ? "Chưa cập nhật"
                               : FriendUser.DateOfBirth.ToString();

            // ------ Ghép chuỗi thông tin ------
            var sb = new StringBuilder();
            sb.AppendLine("Thông tin người dùng:\n");
            sb.AppendLine($"Họ tên: {FriendUser.DisplayName ?? "Chưa đặt tên"}");
            sb.AppendLine($"Email: {FriendUser.Email ?? "Chưa có email"}");
            sb.AppendLine($"Giới tính: {gioiTinhText}");
            sb.AppendLine($"Ngày sinh: {ngaySinhText}");
            sb.AppendLine($"Giới thiệu: {FriendUser.Bio ?? "Chưa có giới thiệu"}");

            MessageBox.Show(sb.ToString(),
                            "Thông tin người dùng",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }
    }
}
