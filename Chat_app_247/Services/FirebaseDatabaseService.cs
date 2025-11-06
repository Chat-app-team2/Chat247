using Chat_app_247.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Chat_app_247.Services
{
    internal class FirebaseDatabaseService
    {
        // khởi tạo Httpclient để gửi các yêu cầu  HTTP đến firebase 
        private readonly HttpClient _http = new();

        public async Task PutAsync<T>(string path, T data, string idToken)
        {
            // tạo url đến firebase database với token xác thực 
            var url = $"{FirebaseConfigFile.DatabaseURL.TrimEnd('/')}/{path}.json?auth={idToken}";
           // chuyển đổi dữ liệu thành json 
            var json = JsonSerializer.Serialize(data);
            // gửi yêu cầu put để ghi dữ liệu vào datbase 
            var res = await _http.PutAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
            // kiểm tra  kết quả trả về -> nếu không thành công thì ném ra lỗi 
            if (!res.IsSuccessStatusCode)
                throw new Exception("Không thể ghi dữ liệu người dùng.");
        }
    }
}
