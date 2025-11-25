using Chat_app_247.Services;
using FireSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chat_app_247.Models;


namespace Chat_app_247.Forms
{

    public partial class UcBubbleMine : UserControl
    {

        public UcBubbleMine()
        {
            InitializeComponent();
        }
        public void SetMessage(Models.Message msg, string avt, string name)
        {
            lb_name.Text = name;
            if (!string.IsNullOrEmpty(avt)) pic_avt.LoadAsync(avt);

            // Xóa các control cũ trong bubble
            pnlBubble.Controls.Clear();

            if (msg.MessageType == "Text")
            {
                string decryptedText = Chat_app_247.Services.EncryptionService.Decrypt(msg.Content);
                lblText.Text = decryptedText;
                lblText.Visible = true;
                pnlBubble.Controls.Add(lblText); 
                pnlBubble.MaximumSize = new Size(450, 500);
                lblText.MaximumSize = new Size(400, 400);
            }
            else if (msg.MessageType == "Image")
            {
                // Tạo PictureBox động
                PictureBox pb = new PictureBox();
                pb.LoadAsync(msg.FileUrl);
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.Size = new Size(200, 200); // Kích thước preview ảnh
                pb.Cursor = Cursors.Hand;
                pb.Click += (s, e) => { Process.Start(new ProcessStartInfo(msg.FileUrl) { UseShellExecute = true }); };

                pnlBubble.Controls.Add(pb);
                pnlBubble.AutoSize = true;
            }
            else if (msg.MessageType == "File")
            {
                // Tạo LinkLabel cho file
                LinkLabel lnk = new LinkLabel();
                lnk.Text = $"📄 {msg.FileName}";
                lnk.AutoSize = true;
                lnk.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                lnk.LinkColor = Color.White; 
                lnk.LinkClicked += (s, e) => {
                    try { Process.Start(new ProcessStartInfo(msg.FileUrl) { UseShellExecute = true }); }
                    catch { MessageBox.Show("Không thể mở link tải."); }
                };

                pnlBubble.Controls.Add(lnk);
                pnlBubble.AutoSize = true;
            }

            FixRightAlignment();
        }

        private void FixRightAlignment()
        {
            this.RightToLeft = RightToLeft.No;
            pic_avt.Left = this.Width - pic_avt.Width - 10;
            pnlBubble.Left = pic_avt.Left - pnlBubble.Width - 10;
            lb_name.Left = pnlBubble.Right - lb_name.Width;
        }

        public string GetText()
        {
            return lblText.Text;
        }
    }
}
