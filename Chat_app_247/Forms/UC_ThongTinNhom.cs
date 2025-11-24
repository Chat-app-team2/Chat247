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
        public string CurrentUserId { get; set; }

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
                                // Lấy avatar của user (nếu có) 
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

                                string displayName = user.DisplayName;

                                // THÊM KÝ HIỆU ADMIN - kiểm tra uid có trong AdminIds không
                                if (conv.AdminIds != null && conv.AdminIds.Contains(uid))
                                {
                                    displayName += " - ADMIN";
                                }

                                // Tạo item cho ListView - DÙNG displayName ĐÃ ĐƯỢC CHỈNH SỬA
                                var item = new ListViewItem(displayName);

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
        private async void XoaThanhVienKhoiNhom()
        {
            if (lvMembers.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn thành viên để xóa!", "Thông báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (FirebaseClient == null || string.IsNullOrEmpty(ConversationId) || string.IsNullOrEmpty(CurrentUserId))
            {
                MessageBox.Show("Lỗi kết nối!", "Thông báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Lấy thông tin conversation hiện tại
                FirebaseResponse res = await FirebaseClient.GetAsync("Conversations/" + ConversationId);
                var conv = res.ResultAs<Conversation>();
                if (conv == null || conv.ParticipantIds == null) return;

                // KIỂM TRA QUYỀN ADMIN
                if (conv.AdminIds == null || !conv.AdminIds.Contains(CurrentUserId))
                {
                    MessageBox.Show("Chỉ quản trị viên mới có quyền xóa thành viên!", "Không có quyền",
                                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy index của item được chọn
                int selectedIndex = lvMembers.SelectedIndices[0];

                // Kiểm tra index hợp lệ
                if (selectedIndex >= 0 && selectedIndex < conv.ParticipantIds.Count)
                {
                    // Lấy UID của thành viên được chọn
                    string selectedUid = conv.ParticipantIds[selectedIndex];

                    // KHÔNG CHO PHÉP TỰ XÓA CHÍNH MÌNH
                    if (selectedUid == CurrentUserId)
                    {
                        MessageBox.Show("Bạn không thể xóa chính mình khỏi nhóm!", "Thông báo",
                                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Hiển thị hộp thoại xác nhận
                    var result = MessageBox.Show($"Bạn có chắc muốn xóa thành viên này khỏi nhóm?",
                                               "Xác nhận xóa",
                                               MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Xóa UID khỏi danh sách participant
                        conv.ParticipantIds.RemoveAt(selectedIndex);

                        // Cập nhật lên Firebase
                        await FirebaseClient.SetAsync("Conversations/" + ConversationId, conv);

                        // Cập nhật lại giao diện
                        await LoadDataAsync();

                        MessageBox.Show("Đã xóa thành viên khỏi nhóm!", "Thành công",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa thành viên: " + ex.Message, "Lỗi",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            OnCloseRequested?.Invoke();
        }

        private void btnXoaTV_Click(object sender, EventArgs e)
        {
            XoaThanhVienKhoiNhom();
        }
        private async void RoiKhoiNhom()
        {
            if (FirebaseClient == null || string.IsNullOrEmpty(ConversationId) || string.IsNullOrEmpty(CurrentUserId))
            {
                MessageBox.Show("Lỗi kết nối!", "Thông báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Lấy thông tin conversation hiện tại
                FirebaseResponse res = await FirebaseClient.GetAsync("Conversations/" + ConversationId);
                var conv = res.ResultAs<Conversation>();
                if (conv == null || conv.ParticipantIds == null) return;

                // KIỂM TRA NẾU LÀ ADMIN - KHÔNG CHO RỜI NHÓM
                if (conv.AdminIds != null && conv.AdminIds.Contains(CurrentUserId))
                {
                    MessageBox.Show("Quản trị viên không thể rời nhóm!", "Không thể rời nhóm",
                                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // HIỂN THỊ HỘP THOẠI XÁC NHẬN
                var result = MessageBox.Show($"Bạn có chắc muốn rời khỏi nhóm '{conv.GroupName}'?",
                                           "Xác nhận rời nhóm",
                                           MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // XÓA USER HIỆN TẠI KHỎI DANH SÁCH THÀNH VIÊN
                    conv.ParticipantIds.Remove(CurrentUserId);

                    // CẬP NHẬT LÊN FIREBASE
                    await FirebaseClient.SetAsync("Conversations/" + ConversationId, conv);

                    MessageBox.Show("Đã rời khỏi nhóm thành công!", "Thành công",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // ĐÓNG LUÔN THÔNG TIN NHÓM, QUAY VỀ MÀN HÌNH CHÍNH
                    OnCloseRequested?.Invoke();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi rời nhóm: " + ex.Message, "Lỗi",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRoiNhom_Click(object sender, EventArgs e)
        {
            RoiKhoiNhom();
        }
    }
}
