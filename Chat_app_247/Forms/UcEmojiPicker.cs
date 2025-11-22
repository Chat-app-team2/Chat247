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
    public partial class UcEmojiPicker : UserControl
    {
        // Sự kiện bắn ra emoji đã chọn
        public event Action<string> OnEmojiSelected;
        public UcEmojiPicker()
        {
            InitializeComponent();
            LoadEmojis();
        }

        private void LoadEmojis()
        {
            string[] emojis =
            {
                "😀","😁","😂","🤣","😊","😍","😎",
                "😢","😡","👍","🙏","❤","🎉"
            };

            flpEmoji.Controls.Clear();

            foreach (var emo in emojis)
            {
                var btn = new Button();
                btn.Text = emo;
                btn.Width = 50;
                btn.Height = 50;
                btn.Font = new Font("Segoe UI Emoji", 15, FontStyle.Bold);
                btn.BackColor = Color.White;
                btn.ForeColor = Color.Black;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Margin = new Padding(3);
                btn.TextAlign = ContentAlignment.MiddleCenter; 
                btn.Padding = new Padding(0);
                btn.Click += EmojiButton_Click;
                flpEmoji.Controls.Add(btn);
            }
        }

        private void EmojiButton_Click(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                // Gọi event ra ngoài form
                OnEmojiSelected?.Invoke(btn.Text);
            }
        }
    }
}
