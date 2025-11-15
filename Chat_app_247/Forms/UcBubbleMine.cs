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
    public partial class UcBubbleMine : UserControl
    {
        public UcBubbleMine()
        {
            InitializeComponent();
        }
        public void SetText(string text)
        {
            lblText.Text = text;
        }
        public string GetText()
        {
            return lblText.Text;
        }
    }
}
