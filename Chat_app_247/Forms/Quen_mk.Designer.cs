namespace Chat_app_247
{
    partial class Quen_mk
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
            panel1 = new Panel();
            label4 = new Label();
            btnSend = new Guna.UI2.WinForms.Guna2Button();
            label1 = new Label();
            btnCancel = new Guna.UI2.WinForms.Guna2Button();
            txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            guna2PanelLeft = new Guna.UI2.WinForms.Guna2Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.MidnightBlue;
            panel1.Controls.Add(label4);
            panel1.Controls.Add(btnSend);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(txtEmail);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(467, 0);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(302, 434);
            panel1.TabIndex = 5;
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(4, 0);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(300, 55);
            label4.TabIndex = 32;
            label4.Text = "Quên Mật Khẩu";
            // 
            // btnSend
            // 
            btnSend.BackColor = Color.Transparent;
            btnSend.BorderRadius = 10;
            btnSend.Cursor = Cursors.Hand;
            btnSend.CustomizableEdges = customizableEdges1;
            btnSend.DisabledState.BorderColor = Color.DarkGray;
            btnSend.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSend.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSend.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSend.FillColor = Color.FromArgb(29, 155, 240);
            btnSend.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSend.ForeColor = Color.White;
            btnSend.Location = new Point(37, 219);
            btnSend.Margin = new Padding(2);
            btnSend.Name = "btnSend";
            btnSend.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnSend.ShadowDecoration.Enabled = true;
            btnSend.Size = new Size(240, 49);
            btnSend.TabIndex = 33;
            btnSend.Text = "Gửi link đổi mật khẩu";
            btnSend.Click += btnSend_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.LightGray;
            label1.Location = new Point(37, 69);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(255, 23);
            label1.TabIndex = 31;
            label1.Text = "Nhập email để đặt lại mật khẩu.";
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Transparent;
            btnCancel.BorderRadius = 10;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.CustomizableEdges = customizableEdges3;
            btnCancel.DisabledState.BorderColor = Color.DarkGray;
            btnCancel.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCancel.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCancel.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCancel.FillColor = Color.FromArgb(29, 155, 240);
            btnCancel.Font = new Font("Segoe UI", 9.857143F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(37, 294);
            btnCancel.Margin = new Padding(2);
            btnCancel.Name = "btnCancel";
            btnCancel.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnCancel.ShadowDecoration.Enabled = true;
            btnCancel.Size = new Size(240, 50);
            btnCancel.TabIndex = 15;
            btnCancel.Text = "Hủy";
            btnCancel.Click += btnCancel_Click;
            // 
            // txtEmail
            // 
            txtEmail.BorderColor = Color.FromArgb(90, 90, 90);
            txtEmail.BorderRadius = 10;
            txtEmail.Cursor = Cursors.IBeam;
            txtEmail.CustomizableEdges = customizableEdges5;
            txtEmail.DefaultText = "";
            txtEmail.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtEmail.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtEmail.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtEmail.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtEmail.FillColor = Color.FromArgb(20, 20, 25);
            txtEmail.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtEmail.Font = new Font("Segoe UI", 9F);
            txtEmail.ForeColor = Color.White;
            txtEmail.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtEmail.Location = new Point(37, 96);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Enter your email";
            txtEmail.SelectedText = "";
            txtEmail.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtEmail.Size = new Size(240, 49);
            txtEmail.TabIndex = 8;
            // 
            // guna2PanelLeft
            // 
            guna2PanelLeft.BackColor = Color.MidnightBlue;
            guna2PanelLeft.BackgroundImage = Properties.Resources.Screenshot_2025_10_23_2129451;
            guna2PanelLeft.CustomizableEdges = customizableEdges7;
            guna2PanelLeft.Dock = DockStyle.Left;
            guna2PanelLeft.Location = new Point(0, 0);
            guna2PanelLeft.Margin = new Padding(2);
            guna2PanelLeft.Name = "guna2PanelLeft";
            guna2PanelLeft.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2PanelLeft.Size = new Size(467, 434);
            guna2PanelLeft.TabIndex = 4;
            // 
            // Quen_mk
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(769, 434);
            Controls.Add(panel1);
            Controls.Add(guna2PanelLeft);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            Name = "Quen_mk";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quen_mk";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label4;
        private Label label1;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private Guna.UI2.WinForms.Guna2Panel guna2PanelLeft;
        private Guna.UI2.WinForms.Guna2Button btnSend;
    }
}