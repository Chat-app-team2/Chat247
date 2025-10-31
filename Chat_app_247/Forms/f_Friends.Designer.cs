namespace Chat_app_247
{
    partial class f_Friends
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            cardFriends = new Guna.UI2.WinForms.Guna2Panel();
            guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            friendsPanel = new Guna.UI2.WinForms.Guna2Panel();
            cardFriends.SuspendLayout();
            guna2CustomGradientPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // cardFriends
            // 
            cardFriends.BackColor = Color.Transparent;
            cardFriends.BorderRadius = 12;
            cardFriends.Controls.Add(friendsPanel);
            cardFriends.Controls.Add(guna2CustomGradientPanel1);
            cardFriends.CustomizableEdges = customizableEdges15;
            cardFriends.Dock = DockStyle.Fill;
            cardFriends.FillColor = Color.White;
            cardFriends.Location = new Point(0, 0);
            cardFriends.Name = "cardFriends";
            cardFriends.ShadowDecoration.CustomizableEdges = customizableEdges16;
            cardFriends.ShadowDecoration.Enabled = true;
            cardFriends.Size = new Size(1654, 802);
            cardFriends.TabIndex = 3;
            // 
            // guna2CustomGradientPanel1
            // 
            guna2CustomGradientPanel1.Controls.Add(txtSearch);
            guna2CustomGradientPanel1.CustomizableEdges = customizableEdges13;
            guna2CustomGradientPanel1.Dock = DockStyle.Top;
            guna2CustomGradientPanel1.Location = new Point(0, 0);
            guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            guna2CustomGradientPanel1.ShadowDecoration.CustomizableEdges = customizableEdges14;
            guna2CustomGradientPanel1.Size = new Size(1654, 50);
            guna2CustomGradientPanel1.TabIndex = 0;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.White;
            txtSearch.CustomizableEdges = customizableEdges11;
            txtSearch.DefaultText = "";
            txtSearch.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtSearch.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtSearch.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtSearch.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtSearch.Dock = DockStyle.Top;
            txtSearch.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearch.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtSearch.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearch.IconLeft = Properties.Resources.Screenshot_2025_10_29_233643;
            txtSearch.Location = new Point(0, 0);
            txtSearch.Margin = new Padding(5, 6, 5, 6);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Tìm kiếm bạn bè ...";
            txtSearch.SelectedText = "";
            txtSearch.ShadowDecoration.CustomizableEdges = customizableEdges12;
            txtSearch.Size = new Size(1654, 44);
            txtSearch.TabIndex = 1;
            // 
            // friendsPanel
            // 
            friendsPanel.AutoScroll = true;
            friendsPanel.CustomizableEdges = customizableEdges9;
            friendsPanel.Dock = DockStyle.Fill;
            friendsPanel.Location = new Point(0, 50);
            friendsPanel.Name = "friendsPanel";
            friendsPanel.ShadowDecoration.CustomizableEdges = customizableEdges10;
            friendsPanel.Size = new Size(1654, 752);
            friendsPanel.TabIndex = 1;
            // 
            // f_Friends
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1654, 802);
            Controls.Add(cardFriends);
            Name = "f_Friends";
            Text = "Friends";
            cardFriends.ResumeLayout(false);
            guna2CustomGradientPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel cardFriends;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2Panel friendsPanel;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
    }
}