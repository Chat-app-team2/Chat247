using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat_app_247.Forms
{
    public partial class FriendItem : UserControl
    {
        public FriendItem()
        {
            InitializeComponent();
        }

        // chức năng khi ấn vào button 3 chấm 
        private void btnMore_Click(object sender, EventArgs e)
        {
            // hiện lên cửa sổ menu cho phép xem thông tin  và xóa bạn 
            menuMore.Show(btnMore, new Point(0, btnMore.Height));
        }
        // thiết lập method sửa tên
        public void setname(string name)
        {
            lblName.Text= name;
        }
    }
}
