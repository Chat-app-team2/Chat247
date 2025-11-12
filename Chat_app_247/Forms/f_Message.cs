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
    public partial class f_Message : Form
    {
        public f_Message()
        {
            InitializeComponent();
            LoadFirend();
        }
        private void LoadFirend()
        {
            List<string> Names = new List<string>
            {
                "Bui anh van",
                "Bui anh van",
                "Bui anh van",
                "Bui anh van",
                "Bui anh van",
                "Bui anh van",
                "Bui anh van",
                "Bui anh van",
                "Bui anh van",
                "Bui anh van",
                "Bui anh van",
            };
            Message_panel.Controls.Clear();
            foreach (string name in Names)
            {
                Forms.UcMessUser messUser = new Forms.UcMessUser();
                messUser.Name = name;
                messUser.Dock = DockStyle.Top;
                Message_panel.Controls.Add(messUser);
            }
        }
    }
}
