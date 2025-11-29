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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnRecord = new Guna.UI2.WinForms.Guna2Button();
            btnStop = new Guna.UI2.WinForms.Guna2Button();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblStatus = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblTimer = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            SuspendLayout();
            // 
            // btnRecord
            // 
            btnRecord.BorderRadius = 15;
            btnRecord.Cursor = Cursors.Hand;
            btnRecord.CustomizableEdges = customizableEdges1;
            btnRecord.DisabledState.BorderColor = Color.DarkGray;
            btnRecord.DisabledState.CustomBorderColor = Color.DarkGray;
            btnRecord.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnRecord.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnRecord.FillColor = Color.FromArgb(104, 33, 122);
            btnRecord.Font = new Font("Segoe UI", 21.8571434F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRecord.ForeColor = Color.White;
            btnRecord.Location = new Point(15, 16);
            btnRecord.Name = "btnRecord";
            btnRecord.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnRecord.Size = new Size(125, 87);
            btnRecord.TabIndex = 18;
            btnRecord.Text = "🎤";
            btnRecord.Click += btnRecord_Click;
            // 
            // btnStop
            // 
            btnStop.BorderRadius = 15;
            btnStop.Cursor = Cursors.Hand;
            btnStop.CustomizableEdges = customizableEdges3;
            btnStop.DisabledState.BorderColor = Color.DarkGray;
            btnStop.DisabledState.CustomBorderColor = Color.DarkGray;
            btnStop.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnStop.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnStop.FillColor = Color.FromArgb(104, 33, 122);
            btnStop.Font = new Font("Segoe UI", 21.8571434F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnStop.ForeColor = Color.White;
            btnStop.Location = new Point(453, 16);
            btnStop.Name = "btnStop";
            btnStop.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnStop.Size = new Size(125, 87);
            btnStop.TabIndex = 19;
            btnStop.Text = "⏹";
            btnStop.Click += btnStop_Click;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.Location = new Point(162, 16);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(119, 33);
            guna2HtmlLabel1.TabIndex = 20;
            guna2HtmlLabel1.Text = "Trạng thái:";
            // 
            // lblStatus
            // 
            lblStatus.BackColor = Color.Transparent;
            lblStatus.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.Location = new Point(300, 16);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(50, 30);
            lblStatus.TabIndex = 21;
            lblStatus.Text = "none";
            // 
            // lblTimer
            // 
            lblTimer.BackColor = Color.Transparent;
            lblTimer.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTimer.Location = new Point(300, 54);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(74, 39);
            lblTimer.TabIndex = 22;
            lblTimer.Text = "00:00";
            // 
            // guna2HtmlLabel4
            // 
            guna2HtmlLabel4.BackColor = Color.Transparent;
            guna2HtmlLabel4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel4.Location = new Point(162, 61);
            guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            guna2HtmlLabel4.Size = new Size(110, 33);
            guna2HtmlLabel4.TabIndex = 23;
            guna2HtmlLabel4.Text = "Thời gian:";
            // 
            // VoiceRecorderUC
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Bisque;
            Controls.Add(guna2HtmlLabel4);
            Controls.Add(lblTimer);
            Controls.Add(lblStatus);
            Controls.Add(guna2HtmlLabel1);
            Controls.Add(btnStop);
            Controls.Add(btnRecord);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            Name = "VoiceRecorderUC";
            Size = new Size(594, 115);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnRecord;
        private Guna.UI2.WinForms.Guna2Button btnStop;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblStatus;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTimer;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
    }
}
