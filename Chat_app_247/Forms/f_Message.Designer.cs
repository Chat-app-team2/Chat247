namespace Chat_app_247
{
    partial class f_Message
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Message_panel = new Panel();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            flpMessages = new FlowLayoutPanel();
            pnlComposer = new Guna.UI2.WinForms.Guna2Panel();
            txtInput = new Guna.UI2.WinForms.Guna2TextBox();
            btnAttach = new Guna.UI2.WinForms.Guna2Button();
            btnSend = new Guna.UI2.WinForms.Guna2Button();
            picAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            pnlStatusDot = new Guna.UI2.WinForms.Guna2Panel();
            guna2Panel1.SuspendLayout();
            pnlHeader.SuspendLayout();
            pnlComposer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            SuspendLayout();
            // 
            // Message_panel
            // 
            Message_panel.BorderStyle = BorderStyle.FixedSingle;
            Message_panel.Dock = DockStyle.Left;
            Message_panel.Location = new Point(0, 0);
            Message_panel.Margin = new Padding(4, 4, 4, 4);
            Message_panel.Name = "Message_panel";
            Message_panel.Size = new Size(384, 675);
            Message_panel.TabIndex = 0;
            // 
            // guna2Panel1
            // 
            guna2Panel1.Controls.Add(pnlHeader);
            guna2Panel1.Controls.Add(pnlComposer);
            guna2Panel1.Controls.Add(flpMessages);
            guna2Panel1.CustomizableEdges = customizableEdges14;
            guna2Panel1.Dock = DockStyle.Fill;
            guna2Panel1.FillColor = Color.White;
            guna2Panel1.Location = new Point(384, 0);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges15;
            guna2Panel1.Size = new Size(816, 675);
            guna2Panel1.TabIndex = 1;
            // 
            // pnlHeader
            // 
            pnlHeader.BorderRadius = 8;
            pnlHeader.Controls.Add(pnlStatusDot);
            pnlHeader.Controls.Add(picAvatar);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.CustomizableEdges = customizableEdges4;
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.FillColor = Color.White;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(16, 10, 16, 10);
            pnlHeader.ShadowDecoration.CustomizableEdges = customizableEdges5;
            pnlHeader.Size = new Size(816, 56);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 11.1428576F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(114, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(220, 38);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "guna2HtmlLabel1";
            // 
            // flpMessages
            // 
            flpMessages.AutoScroll = true;
            flpMessages.BackColor = Color.FromArgb(246, 246, 247);
            flpMessages.Dock = DockStyle.Fill;
            flpMessages.FlowDirection = FlowDirection.TopDown;
            flpMessages.Location = new Point(0, 0);
            flpMessages.Name = "flpMessages";
            flpMessages.Padding = new Padding(16);
            flpMessages.Size = new Size(816, 675);
            flpMessages.TabIndex = 1;
            flpMessages.WrapContents = false;
            // 
            // pnlComposer
            // 
            pnlComposer.Controls.Add(btnSend);
            pnlComposer.Controls.Add(btnAttach);
            pnlComposer.Controls.Add(txtInput);
            pnlComposer.CustomizableEdges = customizableEdges12;
            pnlComposer.Dock = DockStyle.Bottom;
            pnlComposer.FillColor = Color.White;
            pnlComposer.Location = new Point(0, 611);
            pnlComposer.Name = "pnlComposer";
            pnlComposer.Padding = new Padding(12);
            pnlComposer.ShadowDecoration.CustomizableEdges = customizableEdges13;
            pnlComposer.Size = new Size(816, 64);
            pnlComposer.TabIndex = 2;
            // 
            // txtInput
            // 
            txtInput.AutoRoundedCorners = true;
            txtInput.BorderRadius = 19;
            txtInput.CustomizableEdges = customizableEdges10;
            txtInput.DefaultText = "";
            txtInput.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtInput.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtInput.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtInput.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtInput.Dock = DockStyle.Fill;
            txtInput.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtInput.Font = new Font("Segoe UI", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtInput.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtInput.Location = new Point(12, 12);
            txtInput.Margin = new Padding(5, 6, 5, 6);
            txtInput.Name = "txtInput";
            txtInput.PlaceholderText = "Nhập tin nhắn...";
            txtInput.SelectedText = "";
            txtInput.ShadowDecoration.CustomizableEdges = customizableEdges11;
            txtInput.Size = new Size(792, 40);
            txtInput.TabIndex = 0;
            // 
            // btnAttach
            // 
            btnAttach.AutoRoundedCorners = true;
            btnAttach.CustomizableEdges = customizableEdges8;
            btnAttach.DisabledState.BorderColor = Color.DarkGray;
            btnAttach.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAttach.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAttach.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAttach.Dock = DockStyle.Right;
            btnAttach.FillColor = Color.FromArgb(128, 128, 255);
            btnAttach.Font = new Font("Segoe UI", 9F);
            btnAttach.ForeColor = Color.White;
            btnAttach.Location = new Point(760, 12);
            btnAttach.Name = "btnAttach";
            btnAttach.ShadowDecoration.CustomizableEdges = customizableEdges9;
            btnAttach.Size = new Size(44, 40);
            btnAttach.TabIndex = 1;
            btnAttach.Text = "📎";
            // 
            // btnSend
            // 
            btnSend.AutoRoundedCorners = true;
            btnSend.CustomizableEdges = customizableEdges6;
            btnSend.DisabledState.BorderColor = Color.DarkGray;
            btnSend.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSend.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSend.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSend.Dock = DockStyle.Right;
            btnSend.FillColor = Color.FromArgb(0, 120, 212);
            btnSend.Font = new Font("Segoe UI", 9F);
            btnSend.ForeColor = Color.White;
            btnSend.Location = new Point(688, 12);
            btnSend.Name = "btnSend";
            btnSend.ShadowDecoration.CustomizableEdges = customizableEdges7;
            btnSend.Size = new Size(72, 40);
            btnSend.TabIndex = 2;
            btnSend.Text = "Gửi";
            // 
            // picAvatar
            // 
            picAvatar.Dock = DockStyle.Left;
            picAvatar.Image = Properties.Resources.Logo_Real;
            picAvatar.ImageRotate = 0F;
            picAvatar.Location = new Point(16, 10);
            picAvatar.Name = "picAvatar";
            picAvatar.ShadowDecoration.CustomizableEdges = customizableEdges3;
            picAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            picAvatar.Size = new Size(40, 36);
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picAvatar.TabIndex = 1;
            picAvatar.TabStop = false;
            // 
            // pnlStatusDot
            // 
            pnlStatusDot.BorderColor = Color.White;
            pnlStatusDot.BorderRadius = 6;
            pnlStatusDot.BorderThickness = 2;
            pnlStatusDot.CustomizableEdges = customizableEdges1;
            pnlStatusDot.FillColor = Color.LimeGreen;
            pnlStatusDot.Location = new Point(61, 35);
            pnlStatusDot.Name = "pnlStatusDot";
            pnlStatusDot.ShadowDecoration.CustomizableEdges = customizableEdges2;
            pnlStatusDot.Size = new Size(12, 12);
            pnlStatusDot.TabIndex = 2;
            // 
            // f_Message
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 675);
            Controls.Add(guna2Panel1);
            Controls.Add(Message_panel);
            Margin = new Padding(4, 4, 4, 4);
            Name = "f_Message";
            Text = "Message";
            guna2Panel1.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlComposer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel Message_panel;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private FlowLayoutPanel flpMessages;
        private Guna.UI2.WinForms.Guna2Panel pnlComposer;
        private Guna.UI2.WinForms.Guna2TextBox txtInput;
        private Guna.UI2.WinForms.Guna2Button btnSend;
        private Guna.UI2.WinForms.Guna2Button btnAttach;
        private Guna.UI2.WinForms.Guna2CirclePictureBox picAvatar;
        private Guna.UI2.WinForms.Guna2Panel pnlStatusDot;
    }
}