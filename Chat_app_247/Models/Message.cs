using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_app_247.Models
{
    public class Message
    {
        // ID định danh duy nhất cho tin nhắn
        public string MessageId { get; set; }

        // ID của người gửi
        public string SenderId { get; set; }

        // Thời gian gửi tin nhắn (dùng kiểu long - Unix Timestamp để dễ sắp xếp)
        public long Timestamp { get; set; }

        // Loại tin nhắn: Text, Image, File...
        public string MessageType { get; set; } // "Text", "Image", "File"

        // Nội dung tin nhắn (nếu là MessageType.Text)
        public string Content { get; set; }

        // URL của file đính kèm (nếu là Image hoặc File)
        public string FileUrl { get; set; }

        // Tên file gốc để hiển thị cho người nhận
        public string FileName { get; set; }

        // Key: UserId của người đã đọc, Value: Timestamp lúc đọc
        public Dictionary<string, long> ReadBy { get; set; }
        //  REACTIONS
        public Dictionary<string, List<string>> Reactions { get; set; }
    }
}
