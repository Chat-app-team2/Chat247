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
using FireSharp.Response;
using System.Net.Http;
using System.IO;

namespace Chat_app_247.Forms
{
    public partial class UC_ThongTinCaNhan : UserControl
    {
        private static readonly HttpClient _http = new HttpClient();

        // Firebase + UserId được truyền từ f_Message
        public IFirebaseClient FirebaseClient { get; set; }
        public string UserId { get; set; }

        // Sự kiện báo cho form ngoài khi bấm nút "Quay lại"
        public event Action OnCloseRequested;
        public UC_ThongTinCaNhan()
        {
            InitializeComponent();
        }
        public async Task LoadDataAsync()
        {
            if (FirebaseClient == null || string.IsNullOrEmpty(UserId))
                return;

            try
            {
                FirebaseResponse res = await FirebaseClient.GetAsync("Users/" + UserId);
                var user = res.ResultAs<User>();
                if (user == null) return;

                // Gán dữ liệu lên UI 
                lblTen.Text = user.DisplayName ?? "";
                lblTrangThai.Text = user.IsOnline ? "Đang hoạt động" : "Ngoại tuyến";
                lblEmail.Text = user.Email ?? "";
                lblNgaySinh.Text = user.DateOfBirth?.ToString("dd/MM/yyyy") ?? "";
                txtGioiThieu.Text = user.Bio ?? "";

                // Ảnh đại diện
                if (!string.IsNullOrEmpty(user.ProfilePictureUrl))
                {
                    try
                    {
                        var bytes = await _http.GetByteArrayAsync(user.ProfilePictureUrl);
                        using (var ms = new MemoryStream(bytes))
                        {
                            picAvatar.Image = Image.FromStream(ms);
                            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                    }
                    catch
                    {
                        picAvatar.Image = null;
                    }
                }
                else
                {
                    picAvatar.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin người dùng: " + ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            OnCloseRequested?.Invoke();
        }
    }
}
