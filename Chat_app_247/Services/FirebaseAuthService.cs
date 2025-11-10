using Chat_app_247.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Chat_app_247.Services
{
    // Lớp dịch vụ (service) dùng để làm việc với Firebase Authentication
    internal class FirebaseAuthService
    {
        // Khởi tạo đối tượng HttpClient để gửi các yêu cầu HTTP
        private readonly HttpClient _http = new();
        // Cấu hình JsonSerializer cho phép không phân biệt hoa thường tên thuộc tính
        private static JsonSerializerOptions Opt => new() { PropertyNameCaseInsensitive = true };
        // Định nghĩa record chứa dữ liệu phản hồi khi đăng ký tài khoản thành công
        public record SignUpRes(string idToken, string email, string refreshToken, string localId);

        public async Task<SignUpRes> SignUpAsync(string email, string password)
        {
            // URL API Firebase Authentication cho việc đăng ký tài khoản
            var url = $"https://identitytoolkit.googleapis.com/v1/accounts:signUp?key={FirebaseConfigFile.WebApi}";
            // Dữ liệu gửi đi (payload)
            var payload = new { email, password, returnSecureToken = true };
            // Gửi yêu cầu POST với payload dưới dạng JSON
            var res = await _http.PostAsJsonAsync(url, payload);
            // Đọc nội dung phản hồi dưới dạng chuỗi
            var body = await res.Content.ReadAsStringAsync();
            // Nếu có lỗi, kiểm tra xem lỗi có phải do email đã tồn tại không
            if (!res.IsSuccessStatusCode)
                throw new Exception(body.Contains("EMAIL_EXISTS") ? "Email đã tồn tại!" : "Đăng ký thất bại.");
            // Giải mã JSON thành đối tượng SignUpRes và trả về
            return JsonSerializer.Deserialize<SignUpRes>(body, Opt)!;
        }

        public async Task SendVerifyEmailAsync(string idToken)
        {   // URL API Firebase Authentication để gửi email xác minh
            var url = $"https://identitytoolkit.googleapis.com/v1/accounts:sendOobCode?key={FirebaseConfigFile.WebApi}";
            // dữ liệu gửi đi 
            var payload = new { requestType = "VERIFY_EMAIL", idToken };
            // Gửi yêu cầu POST với payload JSON
            await _http.PostAsJsonAsync(url, payload);
        }

        // =================== BỔ SUNG CHO MÀN BẢO MẬT ===================

        private record SignInRes(string idToken, string refreshToken, string localId, string email, string displayName);

        /// B1: Đăng nhập lại (re-auth) bằng email + mật khẩu hiện tại để lấy idToken
       
        private async Task<SignInRes> SignInAsync(string email, string currentPassword)
        {
            var url = $"https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key={FirebaseConfigFile.WebApi}";
            var payload = new { email, password = currentPassword, returnSecureToken = true };

            var res = await _http.PostAsJsonAsync(url, payload);
            var body = await res.Content.ReadAsStringAsync();
            if (!res.IsSuccessStatusCode)
                throw new Exception(ExtractFirebaseError(body)); 

            return JsonSerializer.Deserialize<SignInRes>(body, Opt)!;
        }

      
        /// B2: Cập nhật displayName và/hoặc password mới bằng accounts:update
    
        private async Task<bool> UpdateAccountAsync(string idToken, string? newDisplayName, string? newPassword)
        {
            var url = $"https://identitytoolkit.googleapis.com/v1/accounts:update?key={FirebaseConfigFile.WebApi}";

            // Xây payload động: chỉ gửi field có giá trị
            var payload = new Dictionary<string, object>
            {
                ["idToken"] = idToken,
                ["returnSecureToken"] = true
            };
            if (!string.IsNullOrWhiteSpace(newDisplayName)) payload["displayName"] = newDisplayName;
            if (!string.IsNullOrWhiteSpace(newPassword)) payload["password"] = newPassword;

            var res = await _http.PostAsJsonAsync(url, payload);
            var body = await res.Content.ReadAsStringAsync();
            if (!res.IsSuccessStatusCode)
                throw new Exception(ExtractFirebaseError(body)); 

            return true;
        }

        /// API public cho UI: đổi tên + mật khẩu (trả true/false)
 
        public async Task<bool> UpdateProfileAndPasswordAsync(
            string email,
            string newDisplayName,
            string currentPassword,
            string newPassword)
        {
            try
            {
                // B1: re-auth để xác minh mật khẩu hiện tại đúng
                var signIn = await SignInAsync(email, currentPassword);

                // B2: gọi accounts:update
                await UpdateAccountAsync(signIn.idToken, newDisplayName, newPassword);
                return true;
            }
            catch (Exception ex)
            {
                // Log ra Output nếu cần, UI sẽ hiển thị "Cập nhật thất bại..."
                System.Diagnostics.Debug.WriteLine("UpdateProfileAndPasswordAsync error: " + ex.Message);
                return false;
            }
        }

        // Helper trích mã lỗi Firebase cho dễ đọc
        private static string ExtractFirebaseError(string body)
        {
            try
            {
                using var doc = JsonDocument.Parse(body);
                var msg = doc.RootElement.GetProperty("error").GetProperty("message").GetString();
                return msg ?? body;
            }
            catch
            {
                return body;
            }
        }
    }
}

