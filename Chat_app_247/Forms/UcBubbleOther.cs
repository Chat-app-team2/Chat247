using Chat_app_247.Services;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


namespace Chat_app_247.Forms
{
    public partial class UcBubbleOther : UserControl
    {

       
        public UcBubbleOther()
        {
            InitializeComponent();
           
        }
        public void SetMessage(string text, string avt, string name)
        {
            lblText.Text = text;
            lb_name.Text = name;
            if (!string.IsNullOrEmpty(avt))
            {
                pic_avt.LoadAsync(avt);
            }
        }

        public string GetText()
        {
            return lblText.Text;
        }
     

    }
}
