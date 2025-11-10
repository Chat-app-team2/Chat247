using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_app_247.Class
{
    public class User
    {
        // ID người dùng, sẽ lấy từ Firebase Authentication UID
        public string UserId { get; set; }

        // Email dùng để đăng nhập
        public string Email { get; set; }

        // Tên hiển thị trong ứng dụng
        public string DisplayName { get; set; }

        // URL đến ảnh đại diện, lưu trên Firebase Storage
        public string ProfilePictureUrl { get; set; }

        // giới tính của người dùng
        public string Gender { get; set; }
        // ngày sinh của người dùng
        public DateTime? DateOfBirth { get; set; }
        // Tiểu sử hoặc mô tả ngắn về người dùng
        public string Bio { get; set; }
      
        // Trạng thái trực tuyến của người dùng
        public bool IsOnline { get; set; }

        // Timestamp của lần hoạt động cuối cùng
        public long LastSeenTimestamp { get; set; }

        // Danh sách ID của những người đã là bạn bè
        public List<string> FriendIds { get; set; }

        // Danh sách ID của những người đã gửi lời mời kết bạn cho mình
        public List<string> FriendRequestReceivedIds { get; set; }

        // Danh sách ID của những người mình đã gửi lời mời kết bạn
        public List<string> FriendRequestSentIds { get; set; }
    }
}
