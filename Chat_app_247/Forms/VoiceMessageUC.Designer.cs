namespace Chat_app_247.Forms
{
    partial class VoiceMessageUC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnPlayPause = new Guna.UI2.WinForms.Guna2Button();
            progressBarAudio = new Guna.UI2.WinForms.Guna2ProgressBar();
            lblDuration = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lbName = new Label();
            SuspendLayout();
            // 
            // btnPlayPause
            // 
            btnPlayPause.BorderRadius = 15;
            btnPlayPause.Cursor = Cursors.Hand;
            btnPlayPause.CustomizableEdges = customizableEdges5;
            btnPlayPause.DisabledState.BorderColor = Color.DarkGray;
            btnPlayPause.DisabledState.CustomBorderColor = Color.DarkGray;
            btnPlayPause.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnPlayPause.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnPlayPause.FillColor = Color.FromArgb(104, 33, 122);
            btnPlayPause.Font = new Font("Segoe UI", 21.8571434F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPlayPause.ForeColor = Color.White;
            btnPlayPause.Location = new Point(14, 15);
            btnPlayPause.Margin = new Padding(2);
            btnPlayPause.Name = "btnPlayPause";
            btnPlayPause.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnPlayPause.Size = new Size(61, 57);
            btnPlayPause.TabIndex = 17;
            btnPlayPause.Text = "▶";
            btnPlayPause.Click += btnPlayPause_Click;
            // 
            // progressBarAudio
            // 
            progressBarAudio.CustomizableEdges = customizableEdges7;
            progressBarAudio.Location = new Point(79, 29);
            progressBarAudio.Margin = new Padding(2);
            progressBarAudio.Name = "progressBarAudio";
            progressBarAudio.ShadowDecoration.CustomizableEdges = customizableEdges8;
            progressBarAudio.Size = new Size(350, 35);
            progressBarAudio.TabIndex = 18;
            progressBarAudio.Text = "guna2ProgressBar1";
            progressBarAudio.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // lblDuration
            // 
            lblDuration.BackColor = Color.Transparent;
            lblDuration.Location = new Point(79, 3);
            lblDuration.Margin = new Padding(2);
            lblDuration.Name = "lblDuration";
            lblDuration.Size = new Size(38, 22);
            lblDuration.TabIndex = 19;
            lblDuration.Text = "00:00";
            // 
            // lbName
            // 
            lbName.AutoSize = true;
            lbName.Location = new Point(252, 5);
            lbName.Name = "lbName";
            lbName.Size = new Size(85, 20);
            lbName.TabIndex = 20;
            lbName.Text = "label_name";
            // 
            // VoiceMessageUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lbName);
            Controls.Add(lblDuration);
            Controls.Add(progressBarAudio);
            Controls.Add(btnPlayPause);
            Margin = new Padding(2);
            Name = "VoiceMessageUC";
            Size = new Size(440, 81);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnPlayPause;
        private Guna.UI2.WinForms.Guna2ProgressBar progressBarAudio;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDuration;
        private Label lbName;
    }
}
