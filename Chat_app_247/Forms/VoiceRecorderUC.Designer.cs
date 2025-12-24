namespace Chat_app_247.Forms
{
    partial class VoiceRecorderUC
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
            btnRecord = new Guna.UI2.WinForms.Guna2Button();
            btn_voice_text = new Guna.UI2.WinForms.Guna2Button();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblStatus = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblTimer = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // btnRecord
            // 
            btnRecord.BorderRadius = 15;
            btnRecord.Cursor = Cursors.Hand;
            btnRecord.CustomizableEdges = customizableEdges5;
            btnRecord.DisabledState.BorderColor = Color.DarkGray;
            btnRecord.DisabledState.CustomBorderColor = Color.DarkGray;
            btnRecord.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnRecord.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnRecord.FillColor = Color.FromArgb(104, 33, 122);
            btnRecord.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRecord.ForeColor = Color.White;
            btnRecord.Location = new Point(26, 43);
            btnRecord.Name = "btnRecord";
            btnRecord.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnRecord.Size = new Size(86, 54);
            btnRecord.TabIndex = 18;
            btnRecord.Text = "🎤";
            btnRecord.Click += btnRecord_Click;
            // 
            // btn_voice_text
            // 
            btn_voice_text.BorderRadius = 15;
            btn_voice_text.Cursor = Cursors.Hand;
            btn_voice_text.CustomizableEdges = customizableEdges7;
            btn_voice_text.DisabledState.BorderColor = Color.DarkGray;
            btn_voice_text.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_voice_text.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_voice_text.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_voice_text.FillColor = Color.FromArgb(104, 33, 122);
            btn_voice_text.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_voice_text.ForeColor = Color.White;
            btn_voice_text.Location = new Point(445, 45);
            btn_voice_text.Name = "btn_voice_text";
            btn_voice_text.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btn_voice_text.Size = new Size(86, 54);
            btn_voice_text.TabIndex = 19;
            btn_voice_text.Text = "🎤";
            btn_voice_text.Click += btn_voice_text_Click;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.Location = new Point(144, 19);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(166, 47);
            guna2HtmlLabel1.TabIndex = 20;
            guna2HtmlLabel1.Text = "Trạng thái:";
            // 
            // lblStatus
            // 
            lblStatus.BackColor = Color.Transparent;
            lblStatus.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.Location = new Point(321, 15);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(69, 40);
            lblStatus.TabIndex = 21;
            lblStatus.Text = "none";
            // 
            // lblTimer
            // 
            lblTimer.BackColor = Color.Transparent;
            lblTimer.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTimer.Location = new Point(316, 62);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(101, 53);
            lblTimer.TabIndex = 22;
            lblTimer.Text = "00:00";
            // 
            // guna2HtmlLabel4
            // 
            guna2HtmlLabel4.BackColor = Color.Transparent;
            guna2HtmlLabel4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel4.Location = new Point(144, 62);
            guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            guna2HtmlLabel4.Size = new Size(153, 47);
            guna2HtmlLabel4.TabIndex = 23;
            guna2HtmlLabel4.Text = "Thời gian:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(33, 1);
            label1.Name = "label1";
            label1.Size = new Size(79, 36);
            label1.TabIndex = 24;
            label1.Text = "Voice";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(424, 6);
            label2.Name = "label2";
            label2.Size = new Size(170, 36);
            label2.TabIndex = 25;
            label2.Text = "Voice -> text";
            // 
            // VoiceRecorderUC
            // 
            AutoScaleDimensions = new SizeF(13F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Bisque;
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(guna2HtmlLabel4);
            Controls.Add(lblTimer);
            Controls.Add(lblStatus);
            Controls.Add(guna2HtmlLabel1);
            Controls.Add(btn_voice_text);
            Controls.Add(btnRecord);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            Name = "VoiceRecorderUC";
            Size = new Size(594, 115);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnRecord;
        private Guna.UI2.WinForms.Guna2Button btn_voice_text;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblStatus;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTimer;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Label label1;
        private Label label2;
    }
}
