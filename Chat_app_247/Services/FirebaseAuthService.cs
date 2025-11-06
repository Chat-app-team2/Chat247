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
    }
}

