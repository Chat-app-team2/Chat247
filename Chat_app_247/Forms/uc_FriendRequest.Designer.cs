namespace Chat_app_247.Forms
{
    partial class uc_FriendRequest
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
            uc_Request_Panel = new Guna.UI2.WinForms.Guna2Panel();
            Full_button = new Guna.UI2.WinForms.Guna2Button();
            Refuse_button = new Guna.UI2.WinForms.Guna2Button();
            Accept_button = new Guna.UI2.WinForms.Guna2Button();
            Name_Label = new Guna.UI2.WinForms.Guna2HtmlLabel();
            Avartar_Picture = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            uc_Request_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Avartar_Picture).BeginInit();
            SuspendLayout();
            // 
            // uc_Request_Panel
            // 
            uc_Request_Panel.BackColor = Color.WhiteSmoke;
            uc_Request_Panel.BorderColor = SystemColors.Highlight;
            uc_Request_Panel.BorderRadius = 9;
            uc_Request_Panel.BorderThickness = 4;
            uc_Request_Panel.Controls.Add(Full_button);
            uc_Request_Panel.Controls.Add(Refuse_button);
            uc_Request_Panel.Controls.Add(Accept_button);
            uc_Request_Panel.Controls.Add(Name_Label);
            uc_Request_Panel.Controls.Add(Avartar_Picture);
            uc_Request_Panel.CustomizableEdges = customizableEdges8;
            uc_Request_Panel.Dock = DockStyle.Fill;
            uc_Request_Panel.Location = new Point(0, 0);
            uc_Request_Panel.Name = "uc_Request_Panel";
            uc_Request_Panel.ShadowDecoration.CustomizableEdges = customizableEdges9;
            uc_Request_Panel.Size = new Size(818, 127);
            uc_Request_Panel.TabIndex = 0;
            // 
            // Full_button
            // 
            Full_button.BackColor = Color.Transparent;
            Full_button.BorderRadius = 10;
            Full_button.Cursor = Cursors.Hand;
            Full_button.CustomizableEdges = customizableEdges1;
            Full_button.DisabledState.BorderColor = Color.DarkGray;
            Full_button.DisabledState.CustomBorderColor = Color.DarkGray;
            Full_button.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            Full_button.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            Full_button.FillColor = SystemColors.MenuBar;
            Full_button.Font = new Font("Segoe UI", 9.857143F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Full_button.ForeColor = Color.Black;
            Full_button.Location = new Point(607, 32);
            Full_button.Margin = new Padding(2);
            Full_button.Name = "Full_button";
            Full_button.ShadowDecoration.CustomizableEdges = customizableEdges2;
            Full_button.ShadowDecoration.Enabled = true;
            Full_button.Size = new Size(82, 56);
            Full_button.TabIndex = 16;
            Full_button.Text = "Xem Thêm";
            Full_button.Click += Full_button_Click;
            // 
            // Refuse_button
            // 
            Refuse_button.BackColor = Color.Transparent;
            Refuse_button.BorderRadius = 10;
            Refuse_button.Cursor = Cursors.Hand;
            Refuse_button.CustomizableEdges = customizableEdges3;
            Refuse_button.DisabledState.BorderColor = Color.DarkGray;
            Refuse_button.DisabledState.CustomBorderColor = Color.DarkGray;
            Refuse_button.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            Refuse_button.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            Refuse_button.FillColor = Color.FromArgb(231, 76, 80);
            Refuse_button.Font = new Font("Segoe UI", 9.857143F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Refuse_button.ForeColor = Color.Black;
            Refuse_button.Location = new Point(449, 32);
            Refuse_button.Margin = new Padding(2);
            Refuse_button.Name = "Refuse_button";
            Refuse_button.ShadowDecoration.CustomizableEdges = customizableEdges4;
            Refuse_button.ShadowDecoration.Enabled = true;
            Refuse_button.Size = new Size(122, 56);
            Refuse_button.TabIndex = 15;
            Refuse_button.Text = "Từ Chối";
            Refuse_button.Click += Refuse_button_Click;
            // 
            // Accept_button
            // 
            Accept_button.BackColor = Color.Transparent;
            Accept_button.BorderRadius = 10;
            Accept_button.Cursor = Cursors.Hand;
            Accept_button.CustomizableEdges = customizableEdges5;
            Accept_button.DisabledState.BorderColor = Color.DarkGray;
            Accept_button.DisabledState.CustomBorderColor = Color.DarkGray;
            Accept_button.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            Accept_button.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            Accept_button.FillColor = Color.FromArgb(26, 188, 156);
            Accept_button.Font = new Font("Segoe UI", 9.857143F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Accept_button.ForeColor = Color.Black;
            Accept_button.Location = new Point(305, 31);
            Accept_button.Margin = new Padding(2);
            Accept_button.Name = "Accept_button";
            Accept_button.ShadowDecoration.CustomizableEdges = customizableEdges6;
            Accept_button.ShadowDecoration.Enabled = true;
            Accept_button.Size = new Size(122, 56);
            Accept_button.TabIndex = 14;
            Accept_button.Text = "Chấp Nhận";
            Accept_button.Click += Accept_button_Click;
            // 
            // Name_Label
            // 
            Name_Label.BackColor = Color.Transparent;
            Name_Label.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name_Label.ForeColor = SystemColors.Desktop;
            Name_Label.Location = new Point(98, 41);
            Name_Label.Name = "Name_Label";
            Name_Label.Size = new Size(75, 33);
            Name_Label.TabIndex = 1;
            Name_Label.Text = "Name";
            // 
            // Avartar_Picture
            // 
            Avartar_Picture.FillColor = Color.Black;
            Avartar_Picture.ImageRotate = 0F;
            Avartar_Picture.InitialImage = Properties.Resources.Logo_Real;
            Avartar_Picture.Location = new Point(22, 27);
            Avartar_Picture.Name = "Avartar_Picture";
            Avartar_Picture.ShadowDecoration.CustomizableEdges = customizableEdges7;
            Avartar_Picture.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            Avartar_Picture.Size = new Size(60, 60);
            Avartar_Picture.SizeMode = PictureBoxSizeMode.Zoom;
            Avartar_Picture.TabIndex = 0;
            Avartar_Picture.TabStop = false;
            // 
            // uc_FriendRequest
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(uc_Request_Panel);
            Name = "uc_FriendRequest";
            Size = new Size(818, 127);
            uc_Request_Panel.ResumeLayout(false);
            uc_Request_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Avartar_Picture).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel uc_Request_Panel;
        private Guna.UI2.WinForms.Guna2HtmlLabel Name_Label;
        private Guna.UI2.WinForms.Guna2CirclePictureBox Avartar_Picture;
        private Guna.UI2.WinForms.Guna2Button Full_button;
        private Guna.UI2.WinForms.Guna2Button Refuse_button;
        private Guna.UI2.WinForms.Guna2Button Accept_button;
    }
}
