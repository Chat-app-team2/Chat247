using Chat_app_247.Services;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chat_app_247.Class;
namespace Chat_app_247.Forms
{
    public partial class uc_NotificationRequestRefuse : UserControl
    {
        private User FriendUser;
        public uc_NotificationRequestRefuse()
        {
            InitializeComponent();
        }
        public async void SetData(string userid)
        {
            var fireclient = new CreateObjectConnectDatabase();
            IFirebaseClient firebaseclient = fireclient.InitializeFirebase();
            FirebaseResponse f_response = await firebaseclient.GetAsync($"Users/{userid}");
            var userData = f_response.ResultAs<User>();
            FriendUser = userData;
            Name_Label.Text = FriendUser.DisplayName;
            if (!string.IsNullOrEmpty(FriendUser.ProfilePictureUrl))
            {
                try
                {
                    Avartar_Picture.LoadAsync(FriendUser.ProfilePictureUrl);
                }
                catch (Exception ex)
                {
                    Avartar_Picture.Image = null;
                }
            }
        }
    }
}
