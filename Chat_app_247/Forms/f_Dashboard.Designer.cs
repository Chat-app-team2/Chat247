namespace Chat_app_247
{
    partial class f_Dashboard
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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Panel_menu = new Panel();
            sub_Setting_panel = new Panel();
            Logout_button = new FontAwesome.Sharp.IconButton();
            Security_button = new FontAwesome.Sharp.IconButton();
            Information_button = new FontAwesome.Sharp.IconButton();
            Setting_button = new FontAwesome.Sharp.IconButton();
            Invite_button = new FontAwesome.Sharp.IconButton();
            Message_button = new FontAwesome.Sharp.IconButton();
            List_Friends_button = new FontAwesome.Sharp.IconButton();
            Introduction_button = new FontAwesome.Sharp.IconButton();
            panel_logo = new Panel();
            Logo_picture = new PictureBox();
            panel1 = new Panel();
            Avartar_Picture = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            Icon_Status = new FontAwesome.Sharp.IconPictureBox();
            Bell_button = new FontAwesome.Sharp.IconButton();
            Label_Name = new Label();
            Label_Small_Form = new Label();
            Icon_Small_Form = new FontAwesome.Sharp.IconPictureBox();
            Small_Form_panel = new Panel();
            helloToolStripMenuItem = new ToolStripMenuItem();
            List_Thong_Bao = new ContextMenuStrip(components);
            Panel_menu.SuspendLayout();
            sub_Setting_panel.SuspendLayout();
            panel_logo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Logo_picture).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Avartar_Picture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Icon_Status).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Icon_Small_Form).BeginInit();
            List_Thong_Bao.SuspendLayout();
            SuspendLayout();
            // 
            // Panel_menu
            // 
            Panel_menu.BackColor = Color.FromArgb(31, 30, 68);
            Panel_menu.Controls.Add(sub_Setting_panel);
            Panel_menu.Controls.Add(Setting_button);
            Panel_menu.Controls.Add(Invite_button);
            Panel_menu.Controls.Add(Message_button);
            Panel_menu.Controls.Add(List_Friends_button);
            Panel_menu.Controls.Add(Introduction_button);
            Panel_menu.Controls.Add(panel_logo);
            Panel_menu.Dock = DockStyle.Left;
            Panel_menu.Location = new Point(0, 0);
            Panel_menu.Margin = new Padding(4);
            Panel_menu.Name = "Panel_menu";
            Panel_menu.Size = new Size(375, 1066);
            Panel_menu.TabIndex = 0;
            // 
            // sub_Setting_panel
            // 
            sub_Setting_panel.BackColor = Color.FromArgb(39, 39, 58);
            sub_Setting_panel.BorderStyle = BorderStyle.FixedSingle;
            sub_Setting_panel.Controls.Add(Logout_button);
            sub_Setting_panel.Controls.Add(Security_button);
            sub_Setting_panel.Controls.Add(Information_button);
            sub_Setting_panel.Dock = DockStyle.Top;
            sub_Setting_panel.Location = new Point(0, 714);
            sub_Setting_panel.Margin = new Padding(4);
            sub_Setting_panel.Name = "sub_Setting_panel";
            sub_Setting_panel.Size = new Size(375, 334);
            sub_Setting_panel.TabIndex = 6;
            // 
            // Logout_button
            // 
            Logout_button.Dock = DockStyle.Top;
            Logout_button.FlatAppearance.BorderSize = 0;
            Logout_button.FlatStyle = FlatStyle.Flat;
            Logout_button.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Logout_button.ForeColor = Color.Gainsboro;
            Logout_button.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
            Logout_button.IconColor = Color.White;
            Logout_button.IconFont = FontAwesome.Sharp.IconFont.Auto;
            Logout_button.ImageAlign = ContentAlignment.MiddleLeft;
            Logout_button.Location = new Point(0, 210);
            Logout_button.Margin = new Padding(4);
            Logout_button.Name = "Logout_button";
            Logout_button.Padding = new Padding(30, 0, 0, 0);
            Logout_button.Size = new Size(373, 105);
            Logout_button.TabIndex = 8;
            Logout_button.Text = "Đăng xuất";
            Logout_button.TextAlign = ContentAlignment.MiddleLeft;
            Logout_button.TextImageRelation = TextImageRelation.ImageBeforeText;
            Logout_button.UseVisualStyleBackColor = false;
            Logout_button.Click += Logout_button_Click;
            // 
            // Security_button
            // 
            Security_button.Dock = DockStyle.Top;
            Security_button.FlatAppearance.BorderSize = 0;
            Security_button.FlatStyle = FlatStyle.Flat;
            Security_button.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Security_button.ForeColor = Color.Gainsboro;
            Security_button.IconChar = FontAwesome.Sharp.IconChar.ShieldBlank;
            Security_button.IconColor = Color.White;
            Security_button.IconFont = FontAwesome.Sharp.IconFont.Auto;
            Security_button.ImageAlign = ContentAlignment.MiddleLeft;
            Security_button.Location = new Point(0, 105);
            Security_button.Margin = new Padding(4);
            Security_button.Name = "Security_button";
            Security_button.Padding = new Padding(30, 0, 0, 0);
            Security_button.Size = new Size(373, 105);
            Security_button.TabIndex = 7;
            Security_button.Text = "Bảo Mật";
            Security_button.TextAlign = ContentAlignment.MiddleLeft;
            Security_button.TextImageRelation = TextImageRelation.ImageBeforeText;
            Security_button.UseVisualStyleBackColor = false;
            Security_button.Click += Security_button_Click;
            // 
            // Information_button
            // 
            Information_button.Dock = DockStyle.Top;
            Information_button.FlatAppearance.BorderSize = 0;
            Information_button.FlatStyle = FlatStyle.Flat;
            Information_button.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Information_button.ForeColor = Color.Gainsboro;
            Information_button.IconChar = FontAwesome.Sharp.IconChar.Info;
            Information_button.IconColor = Color.White;
            Information_button.IconFont = FontAwesome.Sharp.IconFont.Auto;
            Information_button.ImageAlign = ContentAlignment.MiddleLeft;
            Information_button.Location = new Point(0, 0);
            Information_button.Margin = new Padding(4);
            Information_button.Name = "Information_button";
            Information_button.Padding = new Padding(30, 0, 0, 0);
            Information_button.Size = new Size(373, 105);
            Information_button.TabIndex = 6;
            Information_button.Text = "Thông Tin Cá Nhân";
            Information_button.TextAlign = ContentAlignment.MiddleLeft;
            Information_button.TextImageRelation = TextImageRelation.ImageBeforeText;
            Information_button.UseVisualStyleBackColor = false;
            Information_button.Click += Information_button_Click;
            // 
            // Setting_button
            // 
            Setting_button.Dock = DockStyle.Top;
            Setting_button.FlatAppearance.BorderSize = 0;
            Setting_button.FlatStyle = FlatStyle.Flat;
            Setting_button.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Setting_button.ForeColor = Color.Gainsboro;
            Setting_button.IconChar = FontAwesome.Sharp.IconChar.Cog;
            Setting_button.IconColor = Color.White;
            Setting_button.IconFont = FontAwesome.Sharp.IconFont.Auto;
            Setting_button.ImageAlign = ContentAlignment.MiddleLeft;
            Setting_button.Location = new Point(0, 609);
            Setting_button.Margin = new Padding(4);
            Setting_button.Name = "Setting_button";
            Setting_button.Padding = new Padding(15, 0, 0, 0);
            Setting_button.Size = new Size(375, 105);
            Setting_button.TabIndex = 5;
            Setting_button.Text = "Setting";
            Setting_button.TextAlign = ContentAlignment.MiddleLeft;
            Setting_button.TextImageRelation = TextImageRelation.ImageBeforeText;
            Setting_button.UseVisualStyleBackColor = false;
            Setting_button.Click += Setting_button_Click;
            // 
            // Invite_button
            // 
            Invite_button.Dock = DockStyle.Top;
            Invite_button.FlatAppearance.BorderSize = 0;
            Invite_button.FlatStyle = FlatStyle.Flat;
            Invite_button.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Invite_button.ForeColor = Color.Gainsboro;
            Invite_button.IconChar = FontAwesome.Sharp.IconChar.Inbox;
            Invite_button.IconColor = Color.White;
            Invite_button.IconFont = FontAwesome.Sharp.IconFont.Auto;
            Invite_button.ImageAlign = ContentAlignment.MiddleLeft;
            Invite_button.Location = new Point(0, 504);
            Invite_button.Margin = new Padding(4);
            Invite_button.Name = "Invite_button";
            Invite_button.Padding = new Padding(15, 0, 0, 0);
            Invite_button.Size = new Size(375, 105);
            Invite_button.TabIndex = 4;
            Invite_button.Text = "Lời Mời Kết Bạn";
            Invite_button.TextAlign = ContentAlignment.MiddleLeft;
            Invite_button.TextImageRelation = TextImageRelation.ImageBeforeText;
            Invite_button.UseVisualStyleBackColor = false;
            Invite_button.Click += Invite_button_Click;
            // 
            // Message_button
            // 
            Message_button.Dock = DockStyle.Top;
            Message_button.FlatAppearance.BorderSize = 0;
            Message_button.FlatStyle = FlatStyle.Flat;
            Message_button.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Message_button.ForeColor = Color.Gainsboro;
            Message_button.IconChar = FontAwesome.Sharp.IconChar.Message;
            Message_button.IconColor = Color.White;
            Message_button.IconFont = FontAwesome.Sharp.IconFont.Auto;
            Message_button.ImageAlign = ContentAlignment.MiddleLeft;
            Message_button.Location = new Point(0, 399);
            Message_button.Margin = new Padding(4);
            Message_button.Name = "Message_button";
            Message_button.Padding = new Padding(15, 0, 0, 0);
            Message_button.Size = new Size(375, 105);
            Message_button.TabIndex = 3;
            Message_button.Text = "Message";
            Message_button.TextAlign = ContentAlignment.MiddleLeft;
            Message_button.TextImageRelation = TextImageRelation.ImageBeforeText;
            Message_button.UseVisualStyleBackColor = false;
            Message_button.Click += Message_button_Click;
            // 
            // List_Friends_button
            // 
            List_Friends_button.Dock = DockStyle.Top;
            List_Friends_button.FlatAppearance.BorderSize = 0;
            List_Friends_button.FlatStyle = FlatStyle.Flat;
            List_Friends_button.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            List_Friends_button.ForeColor = Color.Gainsboro;
            List_Friends_button.IconChar = FontAwesome.Sharp.IconChar.UserFriends;
            List_Friends_button.IconColor = Color.White;
            List_Friends_button.IconFont = FontAwesome.Sharp.IconFont.Auto;
            List_Friends_button.ImageAlign = ContentAlignment.MiddleLeft;
            List_Friends_button.Location = new Point(0, 294);
            List_Friends_button.Margin = new Padding(4);
            List_Friends_button.Name = "List_Friends_button";
            List_Friends_button.Padding = new Padding(15, 0, 0, 0);
            List_Friends_button.Size = new Size(375, 105);
            List_Friends_button.TabIndex = 2;
            List_Friends_button.Text = "Danh Sách Bạn bè";
            List_Friends_button.TextAlign = ContentAlignment.MiddleLeft;
            List_Friends_button.TextImageRelation = TextImageRelation.ImageBeforeText;
            List_Friends_button.UseVisualStyleBackColor = false;
            List_Friends_button.Click += List_Friends_button_Click;
            // 
            // Introduction_button
            // 
            Introduction_button.Dock = DockStyle.Top;
            Introduction_button.FlatAppearance.BorderSize = 0;
            Introduction_button.FlatStyle = FlatStyle.Flat;
            Introduction_button.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Introduction_button.ForeColor = Color.Gainsboro;
            Introduction_button.IconChar = FontAwesome.Sharp.IconChar.HandPaper;
            Introduction_button.IconColor = Color.White;
            Introduction_button.IconFont = FontAwesome.Sharp.IconFont.Auto;
            Introduction_button.ImageAlign = ContentAlignment.MiddleLeft;
            Introduction_button.Location = new Point(0, 189);
            Introduction_button.Margin = new Padding(4);
            Introduction_button.Name = "Introduction_button";
            Introduction_button.Padding = new Padding(15, 0, 0, 0);
            Introduction_button.Size = new Size(375, 105);
            Introduction_button.TabIndex = 1;
            Introduction_button.Text = "Lời Giới Thiệu";
            Introduction_button.TextAlign = ContentAlignment.MiddleLeft;
            Introduction_button.TextImageRelation = TextImageRelation.ImageBeforeText;
            Introduction_button.UseVisualStyleBackColor = false;
            Introduction_button.Click += Introduction_button_Click;
            // 
            // panel_logo
            // 
            panel_logo.BackColor = Color.FromArgb(39, 39, 58);
            panel_logo.Controls.Add(Logo_picture);
            panel_logo.Dock = DockStyle.Top;
            panel_logo.Location = new Point(0, 0);
            panel_logo.Margin = new Padding(4);
            panel_logo.Name = "panel_logo";
            panel_logo.Size = new Size(375, 189);
            panel_logo.TabIndex = 0;
            // 
            // Logo_picture
            // 
            Logo_picture.Image = Properties.Resources.Logo_Real;
            Logo_picture.Location = new Point(-315, -94);
            Logo_picture.Margin = new Padding(4);
            Logo_picture.Name = "Logo_picture";
            Logo_picture.Size = new Size(976, 356);
            Logo_picture.SizeMode = PictureBoxSizeMode.Zoom;
            Logo_picture.TabIndex = 0;
            Logo_picture.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(37, 36, 80);
            panel1.Controls.Add(Avartar_Picture);
            panel1.Controls.Add(Icon_Status);
            panel1.Controls.Add(Bell_button);
            panel1.Controls.Add(Label_Name);
            panel1.Controls.Add(Label_Small_Form);
            panel1.Controls.Add(Icon_Small_Form);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(375, 0);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1383, 117);
            panel1.TabIndex = 1;
            // 
            // Avartar_Picture
            // 
            Avartar_Picture.ImageRotate = 0F;
            Avartar_Picture.InitialImage = Properties.Resources.Logo_Real;
            Avartar_Picture.Location = new Point(1047, 16);
            Avartar_Picture.Margin = new Padding(4);
            Avartar_Picture.Name = "Avartar_Picture";
            Avartar_Picture.ShadowDecoration.CustomizableEdges = customizableEdges1;
            Avartar_Picture.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            Avartar_Picture.Size = new Size(75, 75);
            Avartar_Picture.SizeMode = PictureBoxSizeMode.Zoom;
            Avartar_Picture.TabIndex = 6;
            Avartar_Picture.TabStop = false;
            // 
            // Icon_Status
            // 
            Icon_Status.BackColor = Color.FromArgb(37, 36, 80);
            Icon_Status.ForeColor = Color.Chartreuse;
            Icon_Status.IconChar = FontAwesome.Sharp.IconChar.Circle;
            Icon_Status.IconColor = Color.Chartreuse;
            Icon_Status.IconFont = FontAwesome.Sharp.IconFont.Solid;
            Icon_Status.IconSize = 20;
            Icon_Status.Location = new Point(1148, 68);
            Icon_Status.Margin = new Padding(4);
            Icon_Status.Name = "Icon_Status";
            Icon_Status.Size = new Size(20, 20);
            Icon_Status.TabIndex = 5;
            Icon_Status.TabStop = false;
            // 
            // Bell_button
            // 
            Bell_button.FlatAppearance.BorderSize = 0;
            Bell_button.FlatStyle = FlatStyle.Flat;
            Bell_button.IconChar = FontAwesome.Sharp.IconChar.Bell;
            Bell_button.IconColor = SystemColors.ButtonHighlight;
            Bell_button.IconFont = FontAwesome.Sharp.IconFont.Solid;
            Bell_button.IconSize = 30;
            Bell_button.Location = new Point(970, 20);
            Bell_button.Margin = new Padding(4);
            Bell_button.Name = "Bell_button";
            Bell_button.Size = new Size(64, 72);
            Bell_button.TabIndex = 4;
            Bell_button.UseVisualStyleBackColor = true;
            Bell_button.Click += Bell_button_Click;
            // 
            // Label_Name
            // 
            Label_Name.AutoSize = true;
            Label_Name.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Label_Name.Location = new Point(1142, 16);
            Label_Name.Margin = new Padding(4, 0, 4, 0);
            Label_Name.Name = "Label_Name";
            Label_Name.Size = new Size(91, 38);
            Label_Name.TabIndex = 2;
            Label_Name.Text = "Name";
            // 
            // Label_Small_Form
            // 
            Label_Small_Form.AutoSize = true;
            Label_Small_Form.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Label_Small_Form.Location = new Point(99, 45);
            Label_Small_Form.Margin = new Padding(4, 0, 4, 0);
            Label_Small_Form.Name = "Label_Small_Form";
            Label_Small_Form.Size = new Size(84, 36);
            Label_Small_Form.TabIndex = 1;
            Label_Small_Form.Text = "Home";
            // 
            // Icon_Small_Form
            // 
            Icon_Small_Form.BackColor = Color.FromArgb(37, 36, 81);
            Icon_Small_Form.ForeColor = Color.MediumPurple;
            Icon_Small_Form.IconChar = FontAwesome.Sharp.IconChar.HomeUser;
            Icon_Small_Form.IconColor = Color.MediumPurple;
            Icon_Small_Form.IconFont = FontAwesome.Sharp.IconFont.Auto;
            Icon_Small_Form.IconSize = 60;
            Icon_Small_Form.Location = new Point(33, 34);
            Icon_Small_Form.Margin = new Padding(4);
            Icon_Small_Form.Name = "Icon_Small_Form";
            Icon_Small_Form.Size = new Size(62, 60);
            Icon_Small_Form.TabIndex = 0;
            Icon_Small_Form.TabStop = false;
            // 
            // Small_Form_panel
            // 
            Small_Form_panel.BackColor = Color.FromArgb(192, 192, 255);
            Small_Form_panel.Dock = DockStyle.Fill;
            Small_Form_panel.Location = new Point(375, 117);
            Small_Form_panel.Margin = new Padding(4);
            Small_Form_panel.Name = "Small_Form_panel";
            Small_Form_panel.Size = new Size(1383, 949);
            Small_Form_panel.TabIndex = 2;
            // 
            // helloToolStripMenuItem
            // 
            helloToolStripMenuItem.Name = "helloToolStripMenuItem";
            helloToolStripMenuItem.Size = new Size(131, 36);
            helloToolStripMenuItem.Text = "hello";
            // 
            // List_Thong_Bao
            // 
            List_Thong_Bao.ImageScalingSize = new Size(20, 20);
            List_Thong_Bao.Items.AddRange(new ToolStripItem[] { helloToolStripMenuItem });
            List_Thong_Bao.Name = "List_Thong_Bao";
            List_Thong_Bao.Size = new Size(132, 40);
            // 
            // f_Dashboard
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 36, 81);
            ClientSize = new Size(1758, 1066);
            Controls.Add(Small_Form_panel);
            Controls.Add(panel1);
            Controls.Add(Panel_menu);
            ForeColor = Color.Gainsboro;
            Margin = new Padding(4);
            Name = "f_Dashboard";
            Text = "Chat 247";
            FormClosing += f_Dashboard_FormClosing;
            Load += f_Dashboard_Load;
            Panel_menu.ResumeLayout(false);
            sub_Setting_panel.ResumeLayout(false);
            panel_logo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Logo_picture).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Avartar_Picture).EndInit();
            ((System.ComponentModel.ISupportInitialize)Icon_Status).EndInit();
            ((System.ComponentModel.ISupportInitialize)Icon_Small_Form).EndInit();
            List_Thong_Bao.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel Panel_menu;
        private Panel panel_logo;
        private Panel sub_Setting_panel;
        private FontAwesome.Sharp.IconButton Introduction_button;
        private FontAwesome.Sharp.IconButton Security_button;
        private FontAwesome.Sharp.IconButton Information_button;
        private FontAwesome.Sharp.IconButton Setting_button;
        private FontAwesome.Sharp.IconButton Invite_button;
        private FontAwesome.Sharp.IconButton Message_button;
        private FontAwesome.Sharp.IconButton List_Friends_button;
        private FontAwesome.Sharp.IconButton Logout_button;
        private Panel panel1;
        private Label Label_Small_Form;
        private FontAwesome.Sharp.IconPictureBox Icon_Small_Form;
        private Panel Small_Form_panel;
        private Label Label_Name;
        private FontAwesome.Sharp.IconButton Bell_button;
        private FontAwesome.Sharp.IconPictureBox Icon_Status;
        private ToolStripMenuItem helloToolStripMenuItem;
        private ContextMenuStrip List_Thong_Bao;
        private PictureBox Logo_picture;
        private Guna.UI2.WinForms.Guna2CirclePictureBox Avartar_Picture;
    }
}