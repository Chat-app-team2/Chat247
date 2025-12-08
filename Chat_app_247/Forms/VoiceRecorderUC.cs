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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Cloud.Speech.V1;

namespace Chat_app_247.Forms
{
    public partial class VoiceRecorderUC : UserControl
    {
        private WaveInEvent waveSource;
        private WaveFileWriter waveFile;
        private string outputPath = "voice_record.wav";
        private System.Windows.Forms.Timer timer;
        private int seconds = 0;
        private bool isSttMode = false;
        private Guna.UI2.WinForms.Guna2Button currentProcessingButton;

        public string _CurrentUserId { get; set; }
        public string _CurrentConversationId { get; set; }
        public IFirebaseClient _IFirebaseClient { get; set; }

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
            if (isSttMode && waveSource != null) return;
            isSttMode = false;
            HandleRecording(btnRecord);
        }
        private void btn_voice_text_Click(object sender, EventArgs e)
        {
            if (!isSttMode && waveSource != null) return;
            isSttMode = true;
            HandleRecording(btn_voice_text);
        }

        private void HandleRecording(Guna.UI2.WinForms.Guna2Button btn)
        {
            if (waveSource == null)
            {
                StartRecording(btn);
            }
            else
            {
                StopRecording(btn);
            }
        }

        private void StartRecording(Guna.UI2.WinForms.Guna2Button btn)
        {
            try
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

                // Tạo file mới (ghi đè file cũ)
                waveFile = new WaveFileWriter(outputPath, waveSource.WaveFormat);

                waveSource.StartRecording();
                timer.Start();

                // UI
                lblStatus.Text = isSttMode ? "Đang thu giọng..." : "Đang ghi âm...";
                lblStatus.Font = new Font(lblStatus.Font, FontStyle.Italic);
                lblStatus.ForeColor = Color.Black;
                btn.Text = "⏹";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi mic: " + ex.Message);
            }
        }
       private async void StopRecording(Guna.UI2.WinForms.Guna2Button btn)
        {
            timer.Stop();

            try 
            {
                if (waveSource != null)
                {
                    waveSource.StopRecording();
                    waveSource.Dispose();
                    waveSource = null;
                }

                if (waveFile != null)
                {
                    waveFile.Dispose(); 
                    waveFile = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi dừng ghi: " + ex.Message);
                return;
            }

            // Trả lại giao diện
            btn.Text = "🎤";
            lblStatus.Text = "Đang xử lý...";

            await Task.Delay(200);

            if (isSttMode)
            {
                await ProcessSpeechToText();
            }
            else
            {
                await ProcessVoiceMessage();
            }
        }

        private async void OnRecordingStopped(object? sender, StoppedEventArgs e)
        {
            timer.Stop();

            if (waveSource != null)
            {
                waveSource.Dispose();
                waveSource = null;
            }
            if (waveFile != null)
            {
                waveFile.Dispose();
                waveFile = null;
            }

            if (currentProcessingButton != null)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    currentProcessingButton.Text = "🎤";
                }));
            }

            if (e.Exception != null)
            {
                MessageBox.Show("Lỗi ghi âm: " + e.Exception.Message);
                return;
            }

            if (isSttMode)
            {
                await ProcessSpeechToText();
            }
            else
            {
                await ProcessVoiceMessage();
            }
        }

        private async Task ProcessVoiceMessage()
        {
            try
            {
                if (!File.Exists(outputPath) || new FileInfo(outputPath).Length == 0)
                {
                    lblStatus.Text = "Lỗi file ghi âm";
                    return;
                }

                var cloudianryService = new CloudinaryService();
                string voiceUrl = cloudianryService.UploadFile(outputPath);
                if (!string.IsNullOrEmpty(voiceUrl))
                {
                    if (!string.IsNullOrEmpty(_CurrentUserId) && !string.IsNullOrEmpty(_CurrentConversationId) && _IFirebaseClient != null)
                    {
                        await SaveVoiceToFirebase(voiceUrl);
                        OnRecordCompleted?.Invoke(outputPath);
                        lblStatus.Text = "Đã gửi Voice!";
                    }
                    else
                    {
                        MessageBox.Show("Thiếu thông tin người dùng/cuộc trò chuyện.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi upload: " + ex.Message);
            }
        }

        private async Task ProcessSpeechToText()
        {
            try
            {
                if (!File.Exists(outputPath) || new FileInfo(outputPath).Length < 100) 
                {
                    lblStatus.Text = "File lỗi/quá ngắn";
                    return;
                }
                string basePath = Application.StartupPath;
                string jsonPath = Path.Combine(basePath, "gen-lang-client-0459749173-072b46e05118.json");

                if (!File.Exists(jsonPath))
                {
                    MessageBox.Show("Không tìm thấy file cấu hình Google tại: " + jsonPath);
                    return;
                }

                // Cấu hình Google Credentials
                var builder = new SpeechClientBuilder
                {
                    CredentialsPath = jsonPath
                };
                var client = await builder.BuildAsync();

                byte[] audioBytes = File.ReadAllBytes(outputPath);

                var response = await client.RecognizeAsync(new RecognitionConfig()
                {
                    Encoding = RecognitionConfig.Types.AudioEncoding.Linear16,
                    SampleRateHertz = 44100,
                    LanguageCode = "vi-VN",
                }, RecognitionAudio.FromBytes(audioBytes)); 

                StringBuilder resultText = new StringBuilder();
                foreach (var result in response.Results)
                {
                    foreach (var alternative in result.Alternatives)
                    {
                        resultText.Append(alternative.Transcript + " ");
                    }
                }

                string finalMessage = resultText.ToString().Trim();

                if (string.IsNullOrEmpty(finalMessage))
                {
                    // Update UI trên luồng chính
                    this.Invoke(new MethodInvoker(delegate { lblStatus.Text = "Không nghe rõ..."; }));
                    return;
                }

                // Lưu tin nhắn
                if (!string.IsNullOrEmpty(_CurrentUserId) && !string.IsNullOrEmpty(_CurrentConversationId))
                {
                    await SaveTextToFirebase(finalMessage);

                    this.Invoke(new MethodInvoker(delegate {
                        lblStatus.Text = "Đã gửi Text!";
                        MessageBox.Show("Nội dung: " + finalMessage, "Đã gửi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Speech-to-Text: " + ex.Message);
                this.Invoke(new MethodInvoker(delegate { lblStatus.Text = "Lỗi dịch"; }));
            }
        }

        private async Task SaveTextToFirebase(string textContent)
        {
            try
            {
                var textMessage = new Chat_app_247.Models.Message
                {
                    SenderId = _CurrentUserId,
                    Timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                    MessageType = "Text",
                    Content = textContent,
                    ReadBy = new Dictionary<string, long>()
                };

                using (var realtimeClient = new Firebase.Database.FirebaseClient(FirebaseConfigFile.DatabaseURL))
                {
                    await realtimeClient
                        .Child("Conversations")
                        .Child(_CurrentConversationId)
                        .Child("Messages")
                        .PostAsync(textMessage);
                }

                var lastMsgPath = $"Conversations/{_CurrentConversationId}/LastMessage";
                await _IFirebaseClient.SetAsync(lastMsgPath, textMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi lưu Firebase (Text): {ex.Message}");
            }
        }

        private async Task SaveVoiceToFirebase(string voiceUrl)
        {
            try
            {
                var fileInfo = new FileInfo(outputPath);
                int duration = GetAudioDuration(outputPath);

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

                var lastMsgPath = $"Conversations/{_CurrentConversationId}/LastMessage";
                await _IFirebaseClient.SetAsync(lastMsgPath, voiceMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi lưu Firebase (Voice): {ex.Message}");
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