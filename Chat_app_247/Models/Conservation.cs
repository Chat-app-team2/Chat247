using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_app_247.Models
{
    public class Conversation
    {
        // ID định danh duy nhất cho cuộc trò chuyện
        public string ConversationId { get; set; }

        // Cờ để xác định đây là chat nhóm hay chat 1-1
        public bool IsGroupChat { get; set; }

        // Tên của nhóm chat (null nếu là chat 1-1)
        public string GroupName { get; set; }

        // URL ảnh đại diện của nhóm (null nếu là chat 1-1)
        public string GroupImageUrl { get; set; }

        // Danh sách ID của tất cả thành viên trong cuộc trò chuyện
        public List<string> ParticipantIds { get; set; }

        // ID của người tạo/quản trị nhóm
        public List<string> AdminIds { get; set; }

        // Nội dung tin nhắn cuối cùng (dùng để hiển thị preview ngoài danh sách chat)
        public Message LastMessage { get; set; }

        // Key: UserId, Value: luôn là true. Dùng Dictionary cho phép thêm/xóa nhanh hơn List.
        public Dictionary<string, bool> TypingIndicator { get; set; }
    }
}
