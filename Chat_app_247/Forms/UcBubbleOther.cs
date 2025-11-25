using Chat_app_247.Services;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Chat_app_247.Models;


namespace Chat_app_247.Forms
{
    public partial class UcBubbleOther : UserControl
    {

       
        public UcBubbleOther()
        {
            InitializeComponent();
           
        }
        public void SetMessage(Models.Message msg, string avt, string name)
        {
            lb_name.Text = name;
            if (!string.IsNullOrEmpty(avt)) pic_avt.LoadAsync(avt);

            pnlBubble.Controls.Clear();

            if (msg.MessageType == "Text")
            {
                string decryptedText = Chat_app_247.Services.EncryptionService.Decrypt(msg.Content);
                lblText.Text = decryptedText;
                pnlBubble.Controls.Add(lblText);
                pnlBubble.MaximumSize = new Size(450, 500);
                lblText.MaximumSize = new Size(400, 400);
            }
            else if (msg.MessageType == "Image")
            {
                PictureBox pb = new PictureBox();
                pb.LoadAsync(msg.FileUrl);
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.Size = new Size(200, 200);
                pb.Cursor = Cursors.Hand;
                pb.Click += (s, e) => { Process.Start(new ProcessStartInfo(msg.FileUrl) { UseShellExecute = true }); };
                pnlBubble.Controls.Add(pb);
                pnlBubble.AutoSize = true;
            }
            else if (msg.MessageType == "File")
            {
                LinkLabel lnk = new LinkLabel();
                lnk.Text = $"📄 {msg.FileName}";
                lnk.AutoSize = true;
                lnk.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                lnk.LinkColor = Color.Blue;
                lnk.LinkClicked += (s, e) => {
                    try { Process.Start(new ProcessStartInfo(msg.FileUrl) { UseShellExecute = true }); }
                    catch { MessageBox.Show("Không thể mở link tải."); }
                };
                pnlBubble.Controls.Add(lnk);
                pnlBubble.AutoSize = true;
            }
        }

        public string GetText()
        {
            return lblText.Text;
        }
     

    }
}
