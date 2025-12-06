using Chat_app_247.Config;
using Chat_app_247.Models;
using Chat_app_247.Services;
using Firebase.Database.Query;
using FireSharp.Interfaces;
using FireSharp.Response;
using NAudio.Wave;
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
    public partial class VoiceRecorderUC : UserControl
    {
        private WaveInEvent waveSource;
        private WaveFileWriter waveFile;
        private string outputPath = "voice_record.wav";
        private System.Windows.Forms.Timer timer;
        private int seconds = 0;

        public string _CurrentUserId { get; set; }
        public string _CurrentConversationId { get; set; }
        public IFirebaseClient _IFirebaseClient { get; set; }

        // sự kiện trả file ra ngoài cho Form Chat
        public Action<string> OnRecordCompleted;
        public VoiceRecorderUC()
        {
            InitializeComponent();
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; 
            timer.Tick += Timer_Tick;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            seconds++;
            lblTimer.Text = TimeSpan.FromSeconds(seconds).ToString(@"mm\:ss");
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            if (waveSource == null) 
            {
                StartRecording();
            }
            else // Dừng ghi âm
            {
                StopRecording();
            }
        }
        private void StartRecording()
        {
            seconds = 0;
            lblTimer.Text = "00:00";
            lblTimer.ForeColor = Color.Black;

            waveSource = new WaveInEvent();
            waveSource.WaveFormat = new WaveFormat(44100, 1);

            waveSource.DataAvailable += (s, a) =>
            {
                if (waveFile != null)
                {
                    waveFile.Write(a.Buffer, 0, a.BytesRecorded);
                }
            };

            waveFile = new WaveFileWriter(outputPath, waveSource.WaveFormat);

            waveSource.StartRecording();
            timer.Start();

            lblStatus.Text = "Đang ghi âm...";
            lblStatus.Font = new Font(lblStatus.Font, FontStyle.Italic);
            lblStatus.ForeColor = Color.Black;

            btnRecord.Text = "⏹";
            
        }
        private void StopRecording()
        {
            btnStop_Click(this, EventArgs.Empty);

            btnRecord.Text = "🎤";
        }

        private async void btnStop_Click(object sender, EventArgs e)
        {
            timer.Stop();

            waveSource.StopRecording();
            waveSource.Dispose();
            waveSource = null;

            waveFile.Dispose();
            waveFile = null;

            lblStatus.Text = "Đã ghi xong!";
            try
            {
                var cloudianryService = new CloudinaryService();
                string voiceUrl = cloudianryService.UploadFile(outputPath);
                if (!string.IsNullOrEmpty(voiceUrl))
                {
                    MessageBox.Show("Ghi âm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (!string.IsNullOrEmpty(_CurrentUserId) && !string.IsNullOrEmpty(_CurrentConversationId) && _IFirebaseClient != null)
                    {
                        await SaveVoiceToFirebase(voiceUrl);
                        OnRecordCompleted?.Invoke(outputPath);
                    }
                    else
                    {
                        MessageBox.Show("Không thể lưu tin nhắn âm thanh: Thiếu thông tin người dùng hoặc cuộc trò chuyện.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải lên âm thanh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private async Task SaveVoiceToFirebase(string voiceUrl)
        {
            try
            {
                // Lấy thông tin file
                var fileInfo = new FileInfo(outputPath);
                int duration = GetAudioDuration(outputPath);

                // Tạo message object
                var voiceMessage = new Chat_app_247.Models.Message
                {
                    SenderId = _CurrentUserId,
                    Timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                    MessageType = "Voice",
                    VoiceUrl = voiceUrl,
                    VoiceFileName = Path.GetFileName(outputPath),
                    VoiceDuration = duration,
                    FileSize = fileInfo.Length,
                    ReadBy = new Dictionary<string, long>()
                };

                using (var realtimeClient = new Firebase.Database.FirebaseClient(FirebaseConfigFile.DatabaseURL))
                {
                    await realtimeClient
                        .Child("Conversations")
                        .Child(_CurrentConversationId)
                        .Child("Messages")
                        .PostAsync(voiceMessage);
                }
                // Cập nhật LastMessage (dùng FireSharp cho cái này vẫn OK)
                var lastMsgPath = $"Conversations/{_CurrentConversationId}/LastMessage";
                await _IFirebaseClient.SetAsync(lastMsgPath, voiceMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi lưu Firebase: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetAudioDuration(string filePath)
        {
            try
            {
                using (var audioFile = new AudioFileReader(filePath))
                {
                    return (int)audioFile.TotalTime.TotalSeconds;
                }
            }
            catch
            {
                return 0;
            }
        }
    }
}
