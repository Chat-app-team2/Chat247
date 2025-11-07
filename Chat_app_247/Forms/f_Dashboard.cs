using Chat_app_247.Class;
using Chat_app_247.Config;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using Chat_app_247.Services;
namespace Chat_app_247
{

    public partial class f_Dashboard : Form
    {
        // cho User hiện tại và FirebaseClient
        private User currentUser;
        private IFirebaseClient firebaseClient;
        private string userId = "";
        // CurrentBtn để lưu trữ nút hiện tại được chọn
        // LeftBorderBtn để tạo viền bên trái cho nút hiện tại
        private IconButton CurrentBtn;
        private Panel LeftBorderBtn;

        public f_Dashboard(Firebase.Auth.User user, string idToken)
        {
            InitializeComponent();
            sub_Setting_panel.Visible = false;
            // Mục đích để khởi tạo LeftBorderBtn
            LeftBorderBtn = new Panel();
            LeftBorderBtn.Size = new Size(7, 60);
            Panel_menu.Controls.Add(LeftBorderBtn);

            userId = user.Uid;
            // Gán thông tin người dùng hiện tại
            InitializeFirebase();
            // Tạo đối tượng User từ thông tin Firebase Auth
            LoadUserDataFromDatabase(user);
        }
        // Mục đích hàm f_Dashboard_FormClosing để cập nhật trạng thái ngoại tuyến khi đóng form Dashboard
        private async void f_Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất và đóng ứng dụng không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (firebaseClient != null && currentUser != null)
                {
                    // Cập nhật trạng thái ngoại tuyến của người dùng và thời gian lần hoạt động cuối cùng
                    bool isOnline = false;
                    var updates = new Dictionary<string, object>
                    {
                        { "IsOnline", isOnline },
                        { "LastSeenTimestamp", DateTimeOffset.UtcNow.ToUnixTimeSeconds() }
                    };
                    await firebaseClient.UpdateAsync($"Users/{userId}", updates);
                }
                Application.Exit(); // Đóng ứng dụng
            }
            else
            {
                e.Cancel = true; // Hủy đóng form nếu người dùng chọn "No"
            }
        }
        // Mục đích hàm InitializeFirebase để khởi tạo kết nối FirebaseDatabase
        private void InitializeFirebase()
        {
            var fireclient = new CreateObjectConnectDatabase();
            firebaseClient = fireclient.InitializeFirebase();
        }
        // Mục đích hàm LoadUserDataFromDatabase để tải dữ liệu người dùng từ Firebase Realtime Database
        private async void LoadUserDataFromDatabase(Firebase.Auth.User user)
        {
            try
            {
                if (firebaseClient != null)
                {
                    // Lấy dữ liệu người dùng từ Firebase Realtime Database tại UID cụ thể
                    FirebaseResponse response = await firebaseClient.GetAsync($"Users/{userId}");
                    // Gán dữ liệu người dùng vào đối tượng UserData
                    var userData = response.ResultAs<User>();
                    currentUser = userData;
                    // Cập nhật trạng thái trực tuyến của người dùng và thời gian lần hoạt động cuối cùng
                    bool isOnline = true;
                    var updates = new Dictionary<string, object>
                    {
                        { "IsOnline", isOnline },
                        { "LastSeenTimestamp", DateTimeOffset.UtcNow.ToUnixTimeSeconds() }
                    };

                    await firebaseClient.UpdateAsync($"Users/{userId}", updates);
                    // Cập nhật dữ liệu người dùng lên giao diện Dashboard
                    UpDateDataToDashBoard(currentUser);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xuất hiện lỗi ở trong f_Dashboard");
            }
        }
        // Mục đích hàm UpDateDataToDashBoard để cập nhật dữ liệu người dùng lên giao diện Dashboard
        private void UpDateDataToDashBoard(User user)
        {
            Label_Name.Text = user.DisplayName;
            // Tải ảnh đại diện từ URL (nếu có)
            if (!string.IsNullOrEmpty(user.ProfilePictureUrl))
            {
                try
                {
                    System.Net.WebRequest request = System.Net.WebRequest.Create(user.ProfilePictureUrl);
                    System.Net.WebResponse response = request.GetResponse();
                    System.IO.Stream responseStream = response.GetResponseStream();
                    Bitmap bitmap = new Bitmap(responseStream);
                    Avartar_Picture.Image = bitmap;
                    responseStream.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xuất hiện lỗi ở trong f_Dashboard");
                }
            }
        }
        // Mục đích hàm HideSubSetting để ẩn sub menu Setting
        private void HideSubSetting()
        {
            if (sub_Setting_panel.Visible == true)
                sub_Setting_panel.Visible = false;
        }
        // Mục đích hàm ShowSubSetting để hiển thị sub menu Setting
        private void ShowSubSetting(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                HideSubSetting();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        // Khởi tạo 1 cái form nhỏ để mở trong panel Small_Form_panel
        private Form active_form = null;
        // Mục đích hàm OpenSmallForm để mở form nhỏ trong panel Small_Form_panel
        private void OpenSmallForm(Form SmallForm)
        {
            // Đóng form hiện tại nếu có
            if (active_form != null)
                active_form.Close();
            // Mở form nhỏ trong panel Small_Form_panel
            active_form = SmallForm;
            SmallForm.TopLevel = false;
            SmallForm.FormBorderStyle = FormBorderStyle.None;
            SmallForm.Dock = DockStyle.Fill;
            Small_Form_panel.Controls.Add(SmallForm);
            // Đặt Tag để theo dõi form hiện tại
            Small_Form_panel.Tag = SmallForm;
            // Hiển thị form nhỏ
            SmallForm.BringToFront();
            SmallForm.Show();
            // Cập nhật tiêu đề của form nhỏ
            Label_Small_Form.Text = SmallForm.Text;
        }
        // Mục đích struct RGBColors để lưu trữ các màu sắc sử dụng trong ứng dụng
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
            public static Color color7 = Color.FromArgb(0, 150, 136);
            public static Color color8 = Color.FromArgb(255, 140, 0);
            public static Color color9 = Color.FromArgb(106, 90, 205);
        }
        // Mục đích hàm ActivateButton để kích hoạt nút hiện tại và thay đổi giao diện của nó
        private void ActivateButton(object senderBtn, Color color)
        {
            // Ẩn nút hiện tại nếu có
            DisableButton();
            // Kích hoạt nút mới
            if (senderBtn != null)
            {
                //Button
                CurrentBtn = (IconButton)senderBtn;     // Chuyển đổi kiểu senderBtn sang IconButton và gán cho CurrentBtn
                CurrentBtn.BackColor = Color.FromArgb(37, 36, 81);  // Thay đổi màu nền của nút hiện tại
                CurrentBtn.ForeColor = color;   // Thay đổi màu chữ của nút hiện tại
                CurrentBtn.TextAlign = ContentAlignment.MiddleCenter;   // Căn giữa chữ trong nút hiện tại
                CurrentBtn.IconColor = color;   // Thay đổi màu biểu tượng của nút hiện tại
                CurrentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;   // Đặt vị trí chữ trước biểu tượng trong nút hiện tại
                CurrentBtn.ImageAlign = ContentAlignment.MiddleRight;   // Căn phải biểu tượng trong nút hiện tại
                //Left border button
                LeftBorderBtn.BackColor = color;    // Thay đổi màu nền của viền bên trái
                Point buttonScreenLocation = CurrentBtn.PointToScreen(Point.Empty);     // Lấy vị trí
                Point buttonMenuLocation = Panel_menu.PointToClient(buttonScreenLocation);  // Chuyển đổi vị trí sang tọa độ của Panel_menu
                LeftBorderBtn.Location = new Point(0, buttonMenuLocation.Y);    // Đặt vị trí của viền bên trái
                LeftBorderBtn.Visible = true;   // Hiển thị viền bên trái
                LeftBorderBtn.BringToFront();   // Đưa viền bên trái lên trên cùng
                //Icon Current Small Form
                Icon_Small_Form.IconChar = CurrentBtn.IconChar; // Thay đổi biểu tượng của form nhỏ
                Icon_Small_Form.IconColor = color;  // Thay đổi màu biểu tượng của form nhỏ
            }
        }
        // Mục đích hàm DisableButton để vô hiệu hóa nút hiện tại và khôi phục giao diện ban đầu của nó
        private void DisableButton()
        {
            // Vô hiệu hóa nút hiện tại
            if (CurrentBtn != null)
            {
                CurrentBtn.BackColor = Color.FromArgb(31, 30, 68);  // Khôi phục màu nền ban đầu của nút hiện tại
                CurrentBtn.ForeColor = Color.Gainsboro; // Khôi phục màu chữ ban đầu của nút hiện tại
                CurrentBtn.TextAlign = ContentAlignment.MiddleLeft; // Khôi phục căn lề chữ ban đầu của nút hiện tại
                CurrentBtn.IconColor = Color.Gainsboro; // Khôi phục màu biểu tượng ban đầu của nút hiện tại
                CurrentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;   // Khôi phục vị trí biểu tượng trước chữ ban đầu của nút hiện tại
                CurrentBtn.ImageAlign = ContentAlignment.MiddleLeft;    // Khôi phục căn lề biểu tượng ban đầu của nút hiện tại
            }
        }
        // Sự kiện khi nhấn nút Introduction_button
        private void Introduction_button_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            f_Introduction f_intro = new f_Introduction();
            f_intro.Text = "Lời Giới Thiệu";
            OpenSmallForm(f_intro);
        }

        // Sự kiện khi nhấn nút List_Friends_button
        private void List_Friends_button_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            f_Friends f_listFriends = new f_Friends();
            f_listFriends.Text = "Danh Sách Bạn Bè";
            OpenSmallForm(f_listFriends);
        }

        // Sự kiện khi nhấn nút Message_button
        private void Message_button_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            f_Message f_message = new f_Message();
            f_message.Text = "Tin Nhắn";
            OpenSmallForm(f_message);
        }

        // Sự kiện khi nhấn nút Invite_button
        private void Invite_button_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            f_Invite f_invite = new f_Invite(firebaseClient, userId);
            f_invite.Text = "Lời Mời Kết Bạn";
            OpenSmallForm(f_invite);
        }

        // Sự kiện khi nhấn nút Setting_button
        private void Setting_button_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
            Label_Small_Form.Text = "Cài Đặt";
            ShowSubSetting(sub_Setting_panel);
        }

        // Sự kiện khi nhấn nút Information_button
        private void Information_button_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);
            f_Information f_info = new f_Information();
            f_info.Text = "Thông Tin Cá Nhân";
            OpenSmallForm(f_info);
        }

        // Sự kiện khi nhấn nút Security_button
        private void Security_button_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color7);
            f_Security f_security = new f_Security();
            f_security.Text = "Bảo Mật";
            OpenSmallForm(f_security);
        }

        // Sự kiện khi nhấn nút Logout_button (Đăng xuất)
        private void Logout_button_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color8);
            Label_Small_Form.Text = "Đăng Xuất";
        }

        // Sự kiện khi nhấn nút Bell_button (Xử lý thông báo)
        private void Bell_button_Click(object sender, EventArgs e)
        {
            List_Thong_Bao.Show(Bell_button, new Point(0, Bell_button.Height));
        }
    }
}
