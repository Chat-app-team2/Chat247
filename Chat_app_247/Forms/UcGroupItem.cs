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
    public partial class UcGroupItem : UserControl
    {
        private Color _defaultColor = Color.White;
        private Color _hoverColor = Color.FromArgb(245, 245, 255);
        private string _conversationId;
        private string _groupName;
        private string _groupImageUrl;

        // Event để form ngoài bắt được khi bấm Chat
        public event Action<string, string, string> OnGroupChatClicked;
        // tham số: conversationId, groupName, groupImageUrl
        public UcGroupItem()
        {
            InitializeComponent();
            pnlContainer.FillColor = _defaultColor;

            pnlContainer.MouseEnter += (s, e) => pnlContainer.FillColor = _hoverColor;
            pnlContainer.MouseLeave += (s, e) => pnlContainer.FillColor = _defaultColor;
            btnChat.Click += BtnChat_Click;
        }
        private void BtnChat_Click(object sender, EventArgs e)
        {
            OnGroupChatClicked?.Invoke(_conversationId, _groupName, _groupImageUrl);
        }

        public async void SetData(string conversationId, string groupName, string groupImageUrl)
        {
            _conversationId = conversationId;
            _groupName = groupName;
            _groupImageUrl = groupImageUrl;

            lblName.Text = groupName;

            if (!string.IsNullOrEmpty(groupImageUrl))
            {
                try
                {
                    using (var http = new HttpClient())
                    {
                        var data = await http.GetByteArrayAsync(groupImageUrl);
                        using (var ms = new MemoryStream(data))
                        {
                            picAvatar.Image = Image.FromStream(ms);
                            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                    }
                }
                catch
                {
                    picAvatar.Image = null;
                }
            }
            else
            {
                picAvatar.Image = null;
            }
        }
    }
}
