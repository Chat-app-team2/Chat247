using Chat_app_247.Services;
using FireSharp.Interfaces;
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
        public void SetMessage(string text, string avt, string name)
        {
            pnlBubble.MaximumSize = new Size(450, 500); // ← Thêm chiều cao tối đa
            lblText.MaximumSize = new Size(400, 400);   // ← Thêm chiều cao tối đa

            lblText.Text = text;
            lb_name.Text = name;
            if (!string.IsNullOrEmpty(avt))
            {
                pic_avt.LoadAsync(avt);
            }
            FixRightAlignment();
        }
        private void FixRightAlignment()
        {
            // Reset RightToLeft
            this.RightToLeft = RightToLeft.No;
            if (lblText != null)
            {
                lblText.RightToLeft = RightToLeft.No;
                lblText.TextAlign = ContentAlignment.TopLeft;
            }

            // Đặt avatar ở góc phải
            pic_avt.Left = this.Width - pic_avt.Width - 10;

            // Bubble bên trái avatar
            pnlBubble.Left = pic_avt.Left - pnlBubble.Width - 10;

            // Tên căn phải với bubble
            lb_name.Left = pnlBubble.Right - lb_name.Width;
        }

        public string GetText()
        {
            return lblText.Text;
        }
    }
}
