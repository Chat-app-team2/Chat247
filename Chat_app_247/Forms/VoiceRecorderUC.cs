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
    public partial class VoiceRecorderUC : UserControl
    {
        private WaveInEvent waveSource;
        private WaveFileWriter waveFile;
        private string outputPath = "voice_record.wav";
        private System.Windows.Forms.Timer timer;
        private int seconds = 0;

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

            seconds = 0;
            lblTimer.Text = "00:00";

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
            btnRecord.Enabled = false;
            btnStop.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer.Stop();

            waveSource.StopRecording();
            waveSource.Dispose();
            waveSource = null;

            waveFile.Dispose();
            waveFile = null;

            lblStatus.Text = "Đã ghi xong!";
            btnRecord.Enabled = true;
            btnStop.Enabled = false;

            // gửi file WAV cho Form Chat
            OnRecordCompleted?.Invoke(outputPath);
        }
    }
}
