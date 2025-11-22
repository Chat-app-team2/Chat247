using Chat_app_247.Models;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatUser = Chat_app_247.Class.User;

namespace Chat_app_247.Forms
{
    public partial class UC_ThongTinNhom : UserControl
    {
        private static readonly HttpClient _http = new HttpClient();

        public IFirebaseClient FirebaseClient { get; set; }
        public string ConversationId { get; set; }

        public event Action OnCloseRequested;

        public UC_ThongTinNhom()
        {
            InitializeComponent();
        }
        public async Task LoadDataAsync()
        {
            if (FirebaseClient == null || string.IsNullOrEmpty(ConversationId))
                return;

            try
            {
                // Lấy thông tin Conversation từ Firebase
                FirebaseResponse res = await FirebaseClient.GetAsync("Conversations/" + ConversationId);
                var conv = res.ResultAs<Conversation>();
                if (conv == null) return;

                // Gán tên nhóm, ảnh nhóm
                lblTenNhom.Text = conv.GroupName ?? "";

                int soLuong = conv.ParticipantIds?.Count ?? 0;
                lblSoThanhVien.Text = soLuong.ToString();

                if (!string.IsNullOrEmpty(conv.GroupImageUrl))
                {
                    try
                    {
                        var bytes = await _http.GetByteArrayAsync(conv.GroupImageUrl);
                        using (var ms = new MemoryStream(bytes))
                        {
                            picAvatarNhom.Image = Image.FromStream(ms);
                            picAvatarNhom.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                    }
                    catch
                    {
                        picAvatarNhom.Image = null;
                    }
                }
                else
                {
                    picAvatarNhom.Image = null;
                }

                // Xoá ảnh cũ và item cũ
                imageListMembers.Images.Clear();
                lvMembers.Items.Clear();

                if (conv.ParticipantIds != null)
                {
                    foreach (var uid in conv.ParticipantIds)
                    {
                        try
                        {
                            var userRes = await FirebaseClient.GetAsync("Users/" + uid);
                            var user = userRes.ResultAs<ChatUser>();
                            if (user != null)
                            {
                                // ----- Lấy avatar của user (nếu có) -----
                                int imgIndex = -1;
                                if (!string.IsNullOrEmpty(user.ProfilePictureUrl))
                                {
                                    try
                                    {
                                        var bytes = await _http.GetByteArrayAsync(user.ProfilePictureUrl);
                                        using (var ms = new MemoryStream(bytes))
                                        {
                                            var img = Image.FromStream(ms);
                                            // key theo uid để tránh trùng
                                            imageListMembers.Images.Add(uid, img);
                                            imgIndex = imageListMembers.Images.IndexOfKey(uid);
                                        }
                                    }
                                    catch
                                    {
                                        // có lỗi load ảnh thì bỏ qua, user vẫn hiện tên
                                    }
                                }

                                // ----- Tạo item cho ListView -----
                                var item = new ListViewItem(user.DisplayName);

                                if (imgIndex >= 0)
                                {
                                    item.ImageIndex = imgIndex;   // gắn avatar
                                }

                                lvMembers.Items.Add(item);
                            }
                        }
                        catch
                        {
                            // lỗi 1 user nào đó thì bỏ qua, load tiếp user khác
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin nhóm: " + ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            OnCloseRequested?.Invoke();
        }
    }
}
