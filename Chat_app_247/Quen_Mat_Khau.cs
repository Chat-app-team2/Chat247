using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
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
    public partial class Quen_Mat_Khau : Form
    {
        public Quen_Mat_Khau()
        {
            InitializeComponent();
        }

        private void Quen_Mat_Khau_Load(object sender, EventArgs e)
        {
           

        }

        // Nút Reset (Đặt lại mật khẩu)
        private async void btnReset_Click(object sender, EventArgs e)
        {
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Quay lại form đăng nhập
            this.Hide();
            Dang_nhap login = new Dang_nhap();
            login.Show();
        }
    }
}
    

