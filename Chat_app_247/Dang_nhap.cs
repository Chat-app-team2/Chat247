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
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Configuration;
namespace Chat_app_247
{
    public partial class Dang_nhap : Form
    {   
        public Dang_nhap()
        {
            InitializeComponent();
        }
        private void lblSubtitle_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }

        private void Dang_nhap_Load(object sender, EventArgs e)
        {  

        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {

            
        }
        // chức năng  đăng kí 

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Dang_ki signup = new Dang_ki();
            signup.Show();
        }
        // chức năng quên mật khẩu 
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Quen_Mat_Khau qmk = new Quen_Mat_Khau();
            qmk.Show();
        }
    }
}
