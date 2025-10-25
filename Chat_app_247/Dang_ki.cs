using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
namespace Chat_app_247
{
    public partial class Dang_ki : Form
    { 
        public Dang_ki()
        {
            InitializeComponent();
        }

        private void Dang_ki_Load(object sender, EventArgs e)
        {
          
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
           
        }
        // ấn vào link đăng nhập 
        private void linkdang_nhap_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide(); // ẩn form đăng kí hiện tại 
            Dang_nhap login = new Dang_nhap();// tạo form đăng nhập mới 
            login.Show(); // hiển thị form đăng nhập 
        }
    }
}
