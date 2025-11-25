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
    public partial class AddFriendsGroup : Form
    {
        private static readonly HttpClient _http = new HttpClient();
        private ImageList imageListAll = new ImageList();
        private ImageList imageListSelected = new ImageList();

        public IFirebaseClient FirebaseClient { get; set; }
        public string CurrentUserId { get; set; }
        public List<string> ExistingMemberIds { get; set; } = new List<string>();
        public List<string> SelectedUserIds { get; private set; } = new List<string>();

        public AddFriendsGroup()
        {
            InitializeComponent();
        }
        public async Task LoadFriendsAsync()
        {
            if (FirebaseClient == null || string.IsNullOrEmpty(CurrentUserId)) return;

            try
            {
                imageListAll.Images.Clear();
                imageListSelected.Images.Clear();
                lstTatCaUser.Items.Clear();
                lstThanhVienChon.Items.Clear();

                // Lấy bạn bè
                FirebaseResponse friendRes = await FirebaseClient.GetAsync($"Users/{CurrentUserId}/FriendIds");
                var friendIds = friendRes.ResultAs<List<string>>();
                if (friendIds == null) return;

                foreach (var friendId in friendIds)
                {
                    FirebaseResponse userRes = await FirebaseClient.GetAsync($"Users/{friendId}");
                    var user = userRes.ResultAs<User>();
                    if (user != null)
                    {
                        // Load avatar
                        int imgIndex = -1;
                        if (!string.IsNullOrEmpty(user.ProfilePictureUrl))
                        {
                            try
                            {
                                var bytes = await _http.GetByteArrayAsync(user.ProfilePictureUrl);
                                using (var ms = new MemoryStream(bytes))
                                {
                                    var img = Image.FromStream(ms);
                                    imageListAll.Images.Add(friendId, img);
                                    imgIndex = imageListAll.Images.IndexOfKey(friendId);
                                }
                            }
                            catch { }
                        }

                        // Tạo item
                        var item = new ListViewItem(user.DisplayName);
                        item.Tag = friendId;
                        if (imgIndex >= 0) item.ImageIndex = imgIndex;
                        lstTatCaUser.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void LstTatCaUser_DoubleClick(object sender, EventArgs e)
        {
            if (lstTatCaUser.SelectedItems.Count == 0) return;

            var item = lstTatCaUser.SelectedItems[0];
            string friendId = item.Tag as string;

            if (ExistingMemberIds.Contains(friendId))
            {
                MessageBox.Show("Đã có trong nhóm!");
                return;
            }

            // Copy sang list đã chọn
            bool exists = lstThanhVienChon.Items.Cast<ListViewItem>().Any(x => x.Tag as string == friendId);
            if (!exists)
            {
                int imgIndex = -1;
                if (item.ImageIndex >= 0)
                {
                    var img = imageListAll.Images[item.ImageIndex];
                    imageListSelected.Images.Add(friendId, img);
                    imgIndex = imageListSelected.Images.Count - 1;
                }

                var newItem = new ListViewItem(item.Text);
                newItem.Tag = friendId;
                if (imgIndex >= 0) newItem.ImageIndex = imgIndex;
                lstThanhVienChon.Items.Add(newItem);
            }
        }

        private void LstThanhVienChon_DoubleClick(object sender, EventArgs e)
        {
            if (lstThanhVienChon.SelectedItems.Count == 0) return;
            lstThanhVienChon.Items.Remove(lstThanhVienChon.SelectedItems[0]);
        }

        private void btnThêm_Click(object sender, EventArgs e)
        {
            SelectedUserIds = lstThanhVienChon.Items.Cast<ListViewItem>()
                .Select(item => item.Tag as string).Where(id => !string.IsNullOrEmpty(id)).ToList();

            if (SelectedUserIds.Count == 0)
            {
                MessageBox.Show("Chọn ít nhất 1 thành viên!");
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
