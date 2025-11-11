using Chat_app_247.Class;
using Chat_app_247.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Net.Http;

namespace Chat_app_247
{
    public partial class dang_ki : Form
    {
        public dang_ki()
        {
            InitializeComponent();
        }

        private void dang_ki_Load(object sender, EventArgs e)
        {

        }
        // chức năng  khi ấn vào  chữ đăng nhập ngay 
        private void linkdang_nhap_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();// đóng form hiện tại
        }
        // Xử lý khi bấm nút Sign Up
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var name = txtUsername.Text.Trim();   // Lấy tên hiển thị, cắt khoảng trắng đầu/cuối
            var email = txtEmail.Text.Trim();    // Lấy email, cắt khoảng trắng
            var password = txtPassword.Text;    // Lấy mật khẩu
            var confirm = txtConfirmPassword.Text;  // Lấy mật khẩu xác nhận

            // Validate cơ bản
            if (string.IsNullOrWhiteSpace(name)) { MessageBox.Show("Vui lòng nhập tên hiển thị."); return; }
            // Nếu tên trống → thông báo và dừng
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@")) { MessageBox.Show("Email không hợp lệ."); return; }
            // Email trống hoặc không chứa '@' → báo lỗi (kiểm tra đơn giản)
            if (password.Length < 6) { MessageBox.Show("Mật khẩu phải ≥ 6 ký tự."); return; }
            // Mật khẩu ít hơn 6 ký tự → báo lỗi
            if (password != confirm) { MessageBox.Show("Mật khẩu xác nhận không khớp."); return; }
            // Xác nhận mật khẩu không trùng → báo lỗi

            btnLogin.Enabled = false;  // Vô hiệu nút để tránh bấm liên tục
            btnLogin.Text = "Signing up..."; // Đổi nhãn nút để báo đang xử lý


            try
            {
                await RegisterAsync(name, email, password); // Gọi luồng đăng ký bất đồng bộ

                MessageBox.Show("Đăng ký thành công! Vui lòng kiểm tra email để xác minh.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Thông báo thành công và nhắc kiểm tra email xác minh

                this.DialogResult = DialogResult.OK;   // đóng form đăng ký và trả về OK cho form gọi
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Đăng ký thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Nếu có lỗi, hiển thị thông điệp (đã được MapAuthError chuyển hóa nếu từ Firebase)
            }
            finally
            {
                btnLogin.Enabled = true;  // Bật lại nút
                btnLogin.Text = "Sign Up";// Trả nhãn nút về mặc định
            }
        }
        // ==== Fields dùng chung cho form ====
        private static readonly HttpClient _http = new HttpClient();
        // HttpClient dùng chung (static) để tái sử dụng kết nối, tốt cho hiệu năng
        private static readonly JsonSerializerOptions _json = new() { PropertyNameCaseInsensitive = true };
        // Tùy chọn JSON: không phân biệt hoa/thường tên thuộc tính khi deserialize
        // Response model cho Firebase Auth signUp
        private record SignUpResponse(string IdToken, string Email, string RefreshToken, string LocalId);
        // Record để ánh xạ body phản hồi của Firebase: token, email, refresh token, UID

        // ==== Đăng ký tài khoản (gọi từ nút Sign Up) ====
        private async Task RegisterAsync(string name, string email, string password)
        {
            // 1) Tạo tài khoản Firebase Auth (signUp)
            var signUp = await SignUpAsync(email, password);

            // 2) Ghi hồ sơ người dùng vào Realtime Database (PUT /Users/{uid})
            var newUser = new User
            {
                UserId = signUp.LocalId,
                Email = email,
                DisplayName = name,
                ProfilePictureUrl = "",
                IsOnline = true,
                LastSeenTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                FriendIds = new List<string>(),
                FriendRequestReceivedIds = new List<string>(),
                FriendRequestSentIds = new List<string>()
            };

            await PutUserAsync(signUp.LocalId, newUser, signUp.IdToken);
            // Ghi hồ sơ này vào Realtime Database tại /Users/{uid}.json, kèm auth={IdToken}

            // 3) Gửi email xác minh (optional nhưng nên có)
            _ = SendVerifyEmailAsync(signUp.IdToken);
            // Gửi email xác minh. Dùng "fire-and-forget" (không await) để không chặn luồng.
        }

        // ==== Gọi Firebase Auth: accounts:signUp ====
        private async Task<SignUpResponse> SignUpAsync(string email, string password)
        {
            var endpoint = $"https://identitytoolkit.googleapis.com/v1/accounts:signUp?key={FirebaseConfigFile.WebApi}";
            // Endpoint dịch vụ Identity Toolkit của Firebase, kèm API Key project
            var payload = new { email, password, returnSecureToken = true };
            // Payload yêu cầu: email, password; returnSecureToken yêu cầu trả về IdToken/RefreshToken

            var res = await _http.PostAsJsonAsync(endpoint, payload);
            // Gửi POST JSON tới endpoint
            var body = await res.Content.ReadAsStringAsync();
            // Đọc toàn bộ nội dung phản hồi dạng chuỗi (để map lỗi thủ công)


            if (!res.IsSuccessStatusCode)
                throw new Exception(MapAuthError(body));
            // Nếu HTTP status không 2xx → chuyển JSON lỗi sang thông điệp dễ hiểu rồi ném Exception

            return JsonSerializer.Deserialize<SignUpResponse>(body, _json)!;
            // Nếu thành công → deserialize body sang SignUpResponse và trả về
        }

        // ==== PUT user vào Realtime Database ====
        private async Task PutUserAsync(string uid, User user, string idToken)
        {
            var url = $"{FirebaseConfigFile.DatabaseURL.TrimEnd('/')}/Users/{uid}.json?auth={idToken}";
            // Tạo URL tới node người dùng theo UID. Thêm auth={IdToken} để xác thực.
            var json = JsonSerializer.Serialize(user);
            // Chuyển object User thành chuỗi JSON
            var res = await _http.PutAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
            // Gửi PUT lên Realtime Database (PUT sẽ ghi đè node /Users/{uid})
            if (!res.IsSuccessStatusCode)
                throw new Exception("Không thể lưu hồ sơ người dùng.");
            // Nếu thất bại, ném Exception để lớp gọi hiển thị lỗi
        }

        // ==== Gửi email xác minh ====
        private async Task SendVerifyEmailAsync(string idToken)
        {
            try
            {
                var endpoint = $"https://identitytoolkit.googleapis.com/v1/accounts:sendOobCode?key={FirebaseConfigFile.WebApi}";
                // Endpoint gửi mã thao tác "ngoài luồng" (OOB) — ở đây là VERIFY_EMAIL
                var payload = new { requestType = "VERIFY_EMAIL", idToken };
                // Loại yêu cầu: VERIFY_EMAIL, kèm IdToken của user
                await _http.PostAsJsonAsync(endpoint, payload);
                // Gửi yêu cầu. Không cần xử lý body ở đây.
            }
            catch { /* không chặn flow nếu gửi mail fail */ }
        }

        // ==== Map lỗi Firebase Auth → thông báo dễ hiểu ====
        private string MapAuthError(string json)
        {
            try
            {
                using var doc = JsonDocument.Parse(json);// Parse chuỗi JSON lỗi trả về
                var code = doc.RootElement.GetProperty("error").GetProperty("message").GetString();
                // Truy xuất mã lỗi trong error.message (ví dụ: EMAIL_EXISTS, WEAK_PASSWORD, ...)

                return code switch
                {
                    "EMAIL_EXISTS" => "Email đã tồn tại.", // Email đã có tài khoản
                    "OPERATION_NOT_ALLOWED" => "Phương thức đăng ký đang bị tắt trong Firebase.",
                    var s when s != null && s.Contains("WEAK_PASSWORD") => "Mật khẩu phải từ 6 ký tự trở lên.",
                    _ => $"Đăng ký thất bại: {code}"  // Một số biến thể chứa chữ WEAK_PASSWORD → báo mật khẩu yếu
                };
            }
            catch { return "Đăng ký thất bại."; }
            // Nếu JSON không đúng định dạng, trả thông báo chung
        }
    }
}
