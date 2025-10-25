using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat_app_247
{
    public partial class Quen_mk : Form
    {
        public Quen_mk()
        {
            InitializeComponent();
        }
        // chức năng khi ấn vào nút hủy 
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide(); // ânr form hiện tại 
            Dang_nhap dang_nhap = new Dang_nhap();// khởi tạo đối tượng đăng nhập mới 
            dang_nhap.Show();// show form đăng nhập mới 
        }
    }
}
