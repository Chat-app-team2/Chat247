namespace Chat_app_247.Forms
{
    partial class UcGroupItem
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlContainer = new Guna.UI2.WinForms.Guna2Panel();
            picAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            lblName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblLastMessage = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnChat = new Guna.UI2.WinForms.Guna2Button();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            SuspendLayout();
            // 
            // pnlContainer
            // 
            pnlContainer.BackColor = Color.Transparent;
            pnlContainer.BorderColor = Color.Silver;
            pnlContainer.BorderRadius = 10;
            pnlContainer.BorderThickness = 1;
            pnlContainer.Controls.Add(guna2HtmlLabel1);
            pnlContainer.Controls.Add(btnChat);
            pnlContainer.Controls.Add(lblLastMessage);
            pnlContainer.Controls.Add(lblName);
            pnlContainer.Controls.Add(picAvatar);
            pnlContainer.CustomizableEdges = customizableEdges4;
            pnlContainer.Dock = DockStyle.Fill;
            pnlContainer.FillColor = Color.White;
            pnlContainer.Location = new Point(0, 0);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.ShadowDecoration.CustomizableEdges = customizableEdges5;
            pnlContainer.ShadowDecoration.Enabled = true;
            pnlContainer.Size = new Size(588, 116);
            pnlContainer.TabIndex = 0;
            // 
            // picAvatar
            // 
            picAvatar.FillColor = Color.LightGray;
            picAvatar.ImageRotate = 0F;
            picAvatar.Location = new Point(26, 16);
            picAvatar.Name = "picAvatar";
            picAvatar.ShadowDecoration.CustomizableEdges = customizableEdges3;
            picAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            picAvatar.Size = new Size(93, 84);
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picAvatar.TabIndex = 0;
            picAvatar.TabStop = false;
            // 
            // lblName
            // 
            lblName.BackColor = Color.Transparent;
            lblName.Font = new Font("Segoe UI", 9.857143F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName.ForeColor = Color.FromArgb(30, 30, 30);
            lblName.Location = new Point(174, 16);
            lblName.Name = "lblName";
            lblName.Size = new Size(111, 33);
            lblName.TabIndex = 1;
            lblName.Text = "Tên nhóm";
            // 
            // lblLastMessage
            // 
            lblLastMessage.BackColor = Color.Transparent;
            lblLastMessage.Font = new Font("Segoe UI", 9.857143F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblLastMessage.ForeColor = Color.Gray;
            lblLastMessage.Location = new Point(174, 55);
            lblLastMessage.Name = "lblLastMessage";
            lblLastMessage.Size = new Size(147, 33);
            lblLastMessage.TabIndex = 2;
            lblLastMessage.Text = "Last message...";
            // 
            // btnChat
            // 
            btnChat.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnChat.BorderRadius = 10;
            btnChat.CustomizableEdges = customizableEdges1;
            btnChat.DisabledState.BorderColor = Color.DarkGray;
            btnChat.DisabledState.CustomBorderColor = Color.DarkGray;
            btnChat.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnChat.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnChat.FillColor = Color.FromArgb(104, 33, 122);
            btnChat.Font = new Font("Segoe UI Semibold", 9.857143F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnChat.ForeColor = Color.White;
            btnChat.Location = new Point(432, 32);
            btnChat.Name = "btnChat";
            btnChat.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnChat.Size = new Size(122, 56);
            btnChat.TabIndex = 8;
            btnChat.Text = "Chat";
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.AutoSize = false;
            guna2HtmlLabel1.BackColor = Color.Red;
            guna2HtmlLabel1.Enabled = false;
            guna2HtmlLabel1.Location = new Point(546, 7);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(17, 27);
            guna2HtmlLabel1.TabIndex = 9;
            guna2HtmlLabel1.Text = "3";
            guna2HtmlLabel1.Visible = false;
            // 
            // UcGroupItem
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlContainer);
            Name = "UcGroupItem";
            Size = new Size(588, 116);
            pnlContainer.ResumeLayout(false);
            pnlContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlContainer;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblLastMessage;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblName;
        private Guna.UI2.WinForms.Guna2CirclePictureBox picAvatar;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2Button btnChat;
    }
}
