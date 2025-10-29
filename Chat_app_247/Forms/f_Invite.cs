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
    public partial class f_Invite : Form
    {
        public f_Invite()
        {
            InitializeComponent();
            LoadInviteList();
            LoadSentRequestList();
            LoadNotifyList();
        }
        private void LoadInviteList()
        {
            List<string> inviteNames = new List<string>
            {
                "Nguyen Van A",
                "Tran Thi B",
                "Le Van C",
                "Pham Thi D",
                "Nguyen Van A",
                "Tran Thi B",
                "Le Van C",
                "Pham Thi D"
            };
            Received_Panel.Controls.Clear();
            foreach (var name in inviteNames)
            {
                Forms.uc_FriendRequest friendRequestControl = new Forms.uc_FriendRequest();
                friendRequestControl.SetName(name);
                friendRequestControl.Dock = DockStyle.Top;
                Received_Panel.Controls.Add(friendRequestControl);
            }
        }
        private void LoadSentRequestList()
        {
            List<string> sentRequestNames = new List<string>
            {
                "Le Thi E",
                "Hoang Van F",
                "Vu Thi G",
                "Do Van H"
            };
            Sent_Panel.Controls.Clear();
            foreach (var name in sentRequestNames)
            {
                Forms.uc_SentRequest sentRequestControl = new Forms.uc_SentRequest();
                sentRequestControl.SetName(name);
                sentRequestControl.Dock = DockStyle.Top;
                Sent_Panel.Controls.Add(sentRequestControl);
            }
        }
        private void LoadNotifyList()
        {
            List<string> notifyNames = new List<string>
            {
                "Pham Thi I",
                "Tran Van J",
                "Nguyen Thi K"
            };
            Notification_Panel.Controls.Clear();
            foreach (var name in notifyNames)
            {
                Forms.uc_NotificationRequestAcp notifyControl = new Forms.uc_NotificationRequestAcp();
                Forms.uc_NotificationRequestRefuse refuseControl = new Forms.uc_NotificationRequestRefuse();
                notifyControl.SetName(name);
                notifyControl.Dock = DockStyle.Top;
                Notification_Panel.Controls.Add(notifyControl);

                refuseControl.SetName(name);
                refuseControl.Dock = DockStyle.Top;
                Notification_Panel.Controls.Add(refuseControl);
            }
        }
    }
}
