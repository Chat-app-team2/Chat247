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
            this.Close();// đóng form hiện tại
        }
    }
}
