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
    public partial class dang_ki : Form
    {
        public dang_ki()
        {
            InitializeComponent();
        }

        private void dang_ki_Load(object sender, EventArgs e)
        {

        }

        private void linkdang_nhap_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Dang_nhap dang_nhap = new Dang_nhap();
            dang_nhap.Show();
        }
    }
}
