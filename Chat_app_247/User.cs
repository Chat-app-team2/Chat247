using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_app_247
{
    public class User
    {
        // tên đăng nhập 
        public string Username { get; set; }
        // mật khẩu 
        public string Password { get; set; }
        // Email 
        public string Email { get; set; }
        // ngày tạo tài khoản 
        public string CreatedAt { get; set; }
        public User()
        {
            // Tự động ghi thời gian khi tạo user
            CreatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
