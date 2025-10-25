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
    public partial class Dang_nhap : Form
    {
        public Dang_nhap()
        {
            InitializeComponent();
        }
        // ấn vào link fogot password 
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();// ẩn form hiện tại 
            Quen_mk quen_mk = new Quen_mk();// tạo đối tượng form mới quên mật khẩu 
            quen_mk.Show();// show form quên mật khẩu 

        }
        // chức năng khi ấn vào sign up
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide(); // ẩn form hiện tại 
            dang_ki dang_ki = new dang_ki();// tạo đối tượng form đăng kí mới 
            dang_ki.Show();// show form đăng kí 
        }
    }
}
