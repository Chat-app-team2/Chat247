using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;

namespace Chat_app_247.Forms
{
    public partial class VoiceMessageUC : UserControl
    {
        private WaveOutEvent outputDevice; //WaveInEvent → thu âm
        private AudioFileReader audioFile; // WaveFileWriter → ghi ra file WAV
        private System.Windows.Forms.Timer progressTimer;
        public string SenderName
        {
            get => lbName.Text;
            set => lbName.Text = value;
        }
        public VoiceMessageUC()
        {
            InitializeComponent();
            progressTimer = new System.Windows.Forms.Timer();
            progressTimer.Interval = 100; // cập nhật mỗi 0.1s
            progressTimer.Tick += ProgressTimer_Tick;
        }
        private void ProgressTimer_Tick(object sender, EventArgs e)
        {
            if (audioFile == null || outputDevice == null) return;

            double current = audioFile.CurrentTime.TotalSeconds;
            double total = audioFile.TotalTime.TotalSeconds;

            if (total > 0)
            {
                int progress = (int)((current / total) * 100);
                progressBarAudio.Value = Math.Min(progress, 100);
            }

            // Khi phát xong
            if (outputDevice.PlaybackState == PlaybackState.Stopped)
            {
                progressBarAudio.Value = 0;
                progressTimer.Stop();
                ResetAudioPosition();
            }
        }
        public void LoadAudio(string path)
        {
            if (audioFile != null)
            {
                audioFile.Dispose();
                audioFile = null;
            }

            try
            {
                audioFile = new AudioFileReader(path);
                lblDuration.Text = audioFile.TotalTime.ToString(@"mm\:ss");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi tạo AudioFile: {ex.Message}");
                audioFile = null;
                lblDuration.Text = "00:00";
            }
        }

        private void btnPlayPause_Click(object sender, EventArgs e)
        {
            if (outputDevice == null)
            {
                outputDevice = new WaveOutEvent();
                outputDevice.Init(audioFile);
            }

            if (outputDevice.PlaybackState == PlaybackState.Playing)
            {
                outputDevice.Pause();
                progressTimer.Stop();
            }
            else
            {
                outputDevice.Play();
                progressTimer.Start();
            }
        }
        private void ResetAudioPosition()
        {
            if (audioFile != null)
            {
                audioFile.Position = 0; // Quay về đầu file
                progressBarAudio.Value = 0;
            }
        }
    }
}
