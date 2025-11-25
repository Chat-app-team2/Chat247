namespace Chat_app_247.Forms
{
    partial class AddFriendsGroup
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            PanelAddFriend = new Panel();
            btnHuy = new Guna.UI2.WinForms.Guna2Button();
            btnThêm = new Guna.UI2.WinForms.Guna2Button();
            guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            lstThanhVienChon = new ListView();
            columnHeader2 = new ColumnHeader();
            guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            PanelLeft = new Guna.UI2.WinForms.Guna2Panel();
            lstTatCaUser = new ListView();
            columnHeader1 = new ColumnHeader();
            guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            label2 = new Label();
            PanelAddFriend.SuspendLayout();
            guna2Panel2.SuspendLayout();
            PanelLeft.SuspendLayout();
            SuspendLayout();
            // 
            // PanelAddFriend
            // 
            PanelAddFriend.BackColor = SystemColors.ScrollBar;
            PanelAddFriend.Controls.Add(btnHuy);
            PanelAddFriend.Controls.Add(btnThêm);
            PanelAddFriend.Controls.Add(guna2Panel2);
            PanelAddFriend.Controls.Add(PanelLeft);
            PanelAddFriend.Controls.Add(label2);
            PanelAddFriend.Dock = DockStyle.Fill;
            PanelAddFriend.Location = new Point(0, 0);
            PanelAddFriend.Name = "PanelAddFriend";
            PanelAddFriend.Size = new Size(597, 393);
            PanelAddFriend.TabIndex = 3;
            // 
            // btnHuy
            // 
            btnHuy.BorderRadius = 15;
            btnHuy.CustomizableEdges = customizableEdges1;
            btnHuy.DisabledState.BorderColor = Color.DarkGray;
            btnHuy.DisabledState.CustomBorderColor = Color.DarkGray;
            btnHuy.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnHuy.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnHuy.FillColor = Color.Thistle;
            btnHuy.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHuy.ForeColor = Color.White;
            btnHuy.Location = new Point(347, 292);
            btnHuy.Margin = new Padding(2);
            btnHuy.Name = "btnHuy";
            btnHuy.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnHuy.Size = new Size(192, 47);
            btnHuy.TabIndex = 13;
            btnHuy.Text = "Hủy";
            btnHuy.Click += btnHuy_Click;
            // 
            // btnThêm
            // 
            btnThêm.BorderRadius = 15;
            btnThêm.CustomizableEdges = customizableEdges3;
            btnThêm.DisabledState.BorderColor = Color.DarkGray;
            btnThêm.DisabledState.CustomBorderColor = Color.DarkGray;
            btnThêm.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnThêm.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnThêm.FillColor = Color.FromArgb(104, 33, 122);
            btnThêm.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThêm.ForeColor = Color.White;
            btnThêm.Location = new Point(64, 292);
            btnThêm.Margin = new Padding(2);
            btnThêm.Name = "btnThêm";
            btnThêm.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnThêm.Size = new Size(192, 47);
            btnThêm.TabIndex = 12;
            btnThêm.Text = "Thêm";
            btnThêm.Click += btnThêm_Click;
            // 
            // guna2Panel2
            // 
            guna2Panel2.BorderRadius = 30;
            guna2Panel2.Controls.Add(lstThanhVienChon);
            guna2Panel2.Controls.Add(guna2HtmlLabel4);
            guna2Panel2.CustomizableEdges = customizableEdges5;
            guna2Panel2.Location = new Point(291, 91);
            guna2Panel2.Margin = new Padding(2);
            guna2Panel2.Name = "guna2Panel2";
            guna2Panel2.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2Panel2.Size = new Size(277, 189);
            guna2Panel2.TabIndex = 11;
            // 
            // lstThanhVienChon
            // 
            lstThanhVienChon.BorderStyle = BorderStyle.FixedSingle;
            lstThanhVienChon.Columns.AddRange(new ColumnHeader[] { columnHeader2 });
            lstThanhVienChon.FullRowSelect = true;
            lstThanhVienChon.Location = new Point(5, 36);
            lstThanhVienChon.Margin = new Padding(2);
            lstThanhVienChon.MultiSelect = false;
            lstThanhVienChon.Name = "lstThanhVienChon";
            lstThanhVienChon.Size = new Size(272, 151);
            lstThanhVienChon.TabIndex = 12;
            lstThanhVienChon.UseCompatibleStateImageBehavior = false;
            lstThanhVienChon.View = View.Details;
            lstThanhVienChon.DoubleClick += LstThanhVienChon_DoubleClick;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Thành viên";
            columnHeader2.Width = 480;
            // 
            // guna2HtmlLabel4
            // 
            guna2HtmlLabel4.AutoSize = false;
            guna2HtmlLabel4.BackColor = Color.Transparent;
            guna2HtmlLabel4.Font = new Font("Segoe UI", 9.857143F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel4.Location = new Point(5, 4);
            guna2HtmlLabel4.Margin = new Padding(2);
            guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            guna2HtmlLabel4.Size = new Size(171, 28);
            guna2HtmlLabel4.TabIndex = 11;
            guna2HtmlLabel4.Text = "Thành viên đã chọn";
            // 
            // PanelLeft
            // 
            PanelLeft.BorderRadius = 30;
            PanelLeft.Controls.Add(lstTatCaUser);
            PanelLeft.Controls.Add(guna2HtmlLabel3);
            PanelLeft.CustomizableEdges = customizableEdges7;
            PanelLeft.Location = new Point(14, 91);
            PanelLeft.Margin = new Padding(2);
            PanelLeft.Name = "PanelLeft";
            PanelLeft.ShadowDecoration.CustomizableEdges = customizableEdges8;
            PanelLeft.Size = new Size(273, 189);
            PanelLeft.TabIndex = 10;
            // 
            // lstTatCaUser
            // 
            lstTatCaUser.BorderStyle = BorderStyle.FixedSingle;
            lstTatCaUser.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            lstTatCaUser.FullRowSelect = true;
            lstTatCaUser.Location = new Point(2, 36);
            lstTatCaUser.Margin = new Padding(2);
            lstTatCaUser.MultiSelect = false;
            lstTatCaUser.Name = "lstTatCaUser";
            lstTatCaUser.Size = new Size(269, 151);
            lstTatCaUser.TabIndex = 10;
            lstTatCaUser.UseCompatibleStateImageBehavior = false;
            lstTatCaUser.View = View.Details;
            lstTatCaUser.DoubleClick += LstTatCaUser_DoubleClick;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Bạn Bè";
            columnHeader1.Width = 480;
            // 
            // guna2HtmlLabel3
            // 
            guna2HtmlLabel3.AutoSize = false;
            guna2HtmlLabel3.BackColor = Color.Transparent;
            guna2HtmlLabel3.Font = new Font("Segoe UI", 9.857143F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel3.Location = new Point(2, 7);
            guna2HtmlLabel3.Margin = new Padding(2);
            guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            guna2HtmlLabel3.Size = new Size(193, 25);
            guna2HtmlLabel3.TabIndex = 8;
            guna2HtmlLabel3.Text = "Danh sách bạn bè";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(177, 31);
            label2.Name = "label2";
            label2.Size = new Size(232, 28);
            label2.TabIndex = 2;
            label2.Text = "Thêm thành viên nhóm";
            // 
            // AddFriendsGroup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(597, 393);
            Controls.Add(PanelAddFriend);
            Name = "AddFriendsGroup";
            Text = "AddFriendsGroup";
            PanelAddFriend.ResumeLayout(false);
            PanelAddFriend.PerformLayout();
            guna2Panel2.ResumeLayout(false);
            PanelLeft.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelAddFriend;
        private Guna.UI2.WinForms.Guna2Button btnHuy;
        private Guna.UI2.WinForms.Guna2Button btnThêm;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private ListView lstThanhVienChon;
        private ColumnHeader columnHeader2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2Panel PanelLeft;
        private ListView lstTatCaUser;
        private ColumnHeader columnHeader1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Label label2;
    }
}