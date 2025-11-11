namespace Chat_app_247.Forms
{
    partial class FriendItem
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlBase = new Guna.UI2.WinForms.Guna2Panel();
            pnlDot = new Guna.UI2.WinForms.Guna2Panel();
            lblName = new Label();
            btnMore = new Guna.UI2.WinForms.Guna2Button();
            btnChat = new Guna.UI2.WinForms.Guna2Button();
            picAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            menuMore = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            pnlBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            menuMore.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBase
            // 
            pnlBase.BackColor = Color.Transparent;
            pnlBase.BorderRadius = 12;
            pnlBase.Controls.Add(pnlDot);
            pnlBase.Controls.Add(lblName);
            pnlBase.Controls.Add(btnMore);
            pnlBase.Controls.Add(btnChat);
            pnlBase.Controls.Add(picAvatar);
            pnlBase.CustomizableEdges = customizableEdges8;
            pnlBase.Dock = DockStyle.Fill;
            pnlBase.FillColor = Color.White;
            pnlBase.Location = new Point(0, 0);
            pnlBase.Margin = new Padding(0, 0, 0, 7);
            pnlBase.Name = "pnlBase";
            pnlBase.Padding = new Padding(7, 5, 7, 5);
            pnlBase.ShadowDecoration.CustomizableEdges = customizableEdges9;
            pnlBase.ShadowDecoration.Depth = 5;
            pnlBase.ShadowDecoration.Enabled = true;
            pnlBase.Size = new Size(533, 60);
            pnlBase.TabIndex = 0;
            // 
            // pnlDot
            // 
            pnlDot.BorderRadius = 5;
            pnlDot.CustomizableEdges = customizableEdges1;
            pnlDot.FillColor = Color.LimeGreen;
            pnlDot.Location = new Point(59, 43);
            pnlDot.Margin = new Padding(2, 2, 2, 2);
            pnlDot.Name = "pnlDot";
            pnlDot.RightToLeft = RightToLeft.Yes;
            pnlDot.ShadowDecoration.CustomizableEdges = customizableEdges2;
            pnlDot.Size = new Size(7, 7);
            pnlDot.TabIndex = 6;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI Semibold", 11.1428576F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName.ForeColor = Color.FromArgb(30, 30, 30);
            lblName.Location = new Point(83, 16);
            lblName.Margin = new Padding(2, 0, 2, 0);
            lblName.MaximumSize = new Size(333, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(61, 25);
            lblName.TabIndex = 1;
            lblName.Text = "label1";
            // 
            // btnMore
            // 
            btnMore.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMore.BorderRadius = 8;
            btnMore.Cursor = Cursors.Hand;
            btnMore.CustomizableEdges = customizableEdges3;
            btnMore.DisabledState.BorderColor = Color.DarkGray;
            btnMore.DisabledState.CustomBorderColor = Color.DarkGray;
            btnMore.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnMore.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnMore.FillColor = Color.Transparent;
            btnMore.Font = new Font("Segoe UI", 14.1428576F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMore.ForeColor = Color.Gray;
            btnMore.HoverState.FillColor = SystemColors.ButtonFace;
            btnMore.Image = Properties.Resources._3_cham;
            btnMore.ImageSize = new Size(30, 30);
            btnMore.Location = new Point(487, 13);
            btnMore.Margin = new Padding(2, 2, 2, 2);
            btnMore.Name = "btnMore";
            btnMore.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnMore.Size = new Size(38, 33);
            btnMore.TabIndex = 5;
            btnMore.Click += btnMore_Click;
            // 
            // btnChat
            // 
            btnChat.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnChat.BorderRadius = 8;
            btnChat.CustomizableEdges = customizableEdges5;
            btnChat.DisabledState.BorderColor = Color.DarkGray;
            btnChat.DisabledState.CustomBorderColor = Color.DarkGray;
            btnChat.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnChat.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnChat.FillColor = Color.FromArgb(104, 33, 122);
            btnChat.Font = new Font("Segoe UI Semibold", 9.857143F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnChat.ForeColor = Color.White;
            btnChat.Location = new Point(401, 13);
            btnChat.Margin = new Padding(2, 2, 2, 2);
            btnChat.Name = "btnChat";
            btnChat.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnChat.Size = new Size(81, 37);
            btnChat.TabIndex = 4;
            btnChat.Text = "Chat";
            // 
            // picAvatar
            // 
            picAvatar.Image = Properties.Resources.Logo_Real;
            picAvatar.ImageRotate = 0F;
            picAvatar.Location = new Point(10, 7);
            picAvatar.Margin = new Padding(2, 2, 2, 2);
            picAvatar.Name = "picAvatar";
            picAvatar.ShadowDecoration.CustomizableEdges = customizableEdges7;
            picAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            picAvatar.Size = new Size(47, 47);
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picAvatar.TabIndex = 0;
            picAvatar.TabStop = false;
            // 
            // menuMore
            // 
            menuMore.ImageScalingSize = new Size(28, 28);
            menuMore.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, toolStripMenuItem2 });
            menuMore.Name = "menuMore";
            menuMore.RenderStyle.ArrowColor = Color.FromArgb(151, 143, 255);
            menuMore.RenderStyle.BorderColor = Color.Gainsboro;
            menuMore.RenderStyle.ColorTable = null;
            menuMore.RenderStyle.RoundedEdges = true;
            menuMore.RenderStyle.SelectionArrowColor = Color.White;
            menuMore.RenderStyle.SelectionBackColor = Color.FromArgb(100, 88, 255);
            menuMore.RenderStyle.SelectionForeColor = Color.White;
            menuMore.RenderStyle.SeparatorColor = Color.Gainsboro;
            menuMore.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            menuMore.Size = new Size(177, 52);
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(176, 24);
            toolStripMenuItem1.Text = "Xem thông tin ";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(176, 24);
            toolStripMenuItem2.Text = "Xóa bạn";
            // 
            // FriendItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            Controls.Add(pnlBase);
            Margin = new Padding(2, 2, 2, 2);
            Name = "FriendItem";
            Size = new Size(533, 60);
            pnlBase.ResumeLayout(false);
            pnlBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            menuMore.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlBase;
        private Label lblName;
        private Guna.UI2.WinForms.Guna2CirclePictureBox picAvatar;
        private Guna.UI2.WinForms.Guna2Button btnChat;
        private Guna.UI2.WinForms.Guna2Button btnMore;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip menuMore;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private Guna.UI2.WinForms.Guna2Panel pnlDot;
    }
}
