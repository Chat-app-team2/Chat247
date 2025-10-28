namespace Chat_app_247
{
    partial class f_Invite
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
            guna2TabControl1 = new Guna.UI2.WinForms.Guna2TabControl();
            Received_tab = new TabPage();
            Received_Panel = new Guna.UI2.WinForms.Guna2ShadowPanel();
            Sent_tab = new TabPage();
            Sent_Panel = new Guna.UI2.WinForms.Guna2ShadowPanel();
            Notification_tab = new TabPage();
            Nofi_Panel = new Guna.UI2.WinForms.Guna2ShadowPanel();
            Notification_Panel = new Guna.UI2.WinForms.Guna2ShadowPanel();
            guna2TabControl1.SuspendLayout();
            Received_tab.SuspendLayout();
            Sent_tab.SuspendLayout();
            Notification_tab.SuspendLayout();
            Nofi_Panel.SuspendLayout();
            SuspendLayout();
            // 
            // guna2TabControl1
            // 
            guna2TabControl1.Alignment = TabAlignment.Left;
            guna2TabControl1.Controls.Add(Received_tab);
            guna2TabControl1.Controls.Add(Sent_tab);
            guna2TabControl1.Controls.Add(Notification_tab);
            guna2TabControl1.Dock = DockStyle.Fill;
            guna2TabControl1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            guna2TabControl1.ItemSize = new Size(180, 40);
            guna2TabControl1.Location = new Point(0, 0);
            guna2TabControl1.Name = "guna2TabControl1";
            guna2TabControl1.SelectedIndex = 0;
            guna2TabControl1.Size = new Size(1103, 535);
            guna2TabControl1.TabButtonHoverState.BorderColor = Color.Empty;
            guna2TabControl1.TabButtonHoverState.FillColor = Color.FromArgb(40, 52, 70);
            guna2TabControl1.TabButtonHoverState.Font = new Font("Segoe UI Semibold", 10F);
            guna2TabControl1.TabButtonHoverState.ForeColor = Color.White;
            guna2TabControl1.TabButtonHoverState.InnerColor = Color.FromArgb(40, 52, 70);
            guna2TabControl1.TabButtonIdleState.BorderColor = Color.Empty;
            guna2TabControl1.TabButtonIdleState.FillColor = Color.FromArgb(33, 42, 57);
            guna2TabControl1.TabButtonIdleState.Font = new Font("Segoe UI Semibold", 10F);
            guna2TabControl1.TabButtonIdleState.ForeColor = Color.FromArgb(156, 160, 167);
            guna2TabControl1.TabButtonIdleState.InnerColor = Color.FromArgb(33, 42, 57);
            guna2TabControl1.TabButtonSelectedState.BorderColor = Color.Empty;
            guna2TabControl1.TabButtonSelectedState.FillColor = Color.FromArgb(29, 37, 49);
            guna2TabControl1.TabButtonSelectedState.Font = new Font("Segoe UI Semibold", 10F);
            guna2TabControl1.TabButtonSelectedState.ForeColor = Color.White;
            guna2TabControl1.TabButtonSelectedState.InnerColor = Color.FromArgb(76, 132, 255);
            guna2TabControl1.TabButtonSize = new Size(180, 40);
            guna2TabControl1.TabIndex = 0;
            guna2TabControl1.TabMenuBackColor = Color.FromArgb(33, 42, 57);
            // 
            // Received_tab
            // 
            Received_tab.BorderStyle = BorderStyle.FixedSingle;
            Received_tab.Controls.Add(Received_Panel);
            Received_tab.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            Received_tab.Location = new Point(184, 4);
            Received_tab.Name = "Received_tab";
            Received_tab.Padding = new Padding(3);
            Received_tab.Size = new Size(915, 527);
            Received_tab.TabIndex = 0;
            Received_tab.Text = "Lời Mời Đến";
            Received_tab.UseVisualStyleBackColor = true;
            // 
            // Received_Panel
            // 
            Received_Panel.AutoScroll = true;
            Received_Panel.BackColor = Color.DimGray;
            Received_Panel.Dock = DockStyle.Fill;
            Received_Panel.FillColor = Color.LightCyan;
            Received_Panel.Location = new Point(3, 3);
            Received_Panel.Name = "Received_Panel";
            Received_Panel.ShadowColor = Color.Black;
            Received_Panel.Size = new Size(907, 519);
            Received_Panel.TabIndex = 3;
            // 
            // Sent_tab
            // 
            Sent_tab.BorderStyle = BorderStyle.FixedSingle;
            Sent_tab.Controls.Add(Sent_Panel);
            Sent_tab.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            Sent_tab.Location = new Point(184, 4);
            Sent_tab.Name = "Sent_tab";
            Sent_tab.Padding = new Padding(3);
            Sent_tab.Size = new Size(915, 527);
            Sent_tab.TabIndex = 1;
            Sent_tab.Text = "Lời Mời Đã Gửi";
            Sent_tab.UseVisualStyleBackColor = true;
            // 
            // Sent_Panel
            // 
            Sent_Panel.AutoScroll = true;
            Sent_Panel.BackColor = Color.DimGray;
            Sent_Panel.Dock = DockStyle.Fill;
            Sent_Panel.FillColor = Color.LightCyan;
            Sent_Panel.Location = new Point(3, 3);
            Sent_Panel.Name = "Sent_Panel";
            Sent_Panel.ShadowColor = Color.Black;
            Sent_Panel.Size = new Size(907, 519);
            Sent_Panel.TabIndex = 4;
            // 
            // Notification_tab
            // 
            Notification_tab.BorderStyle = BorderStyle.FixedSingle;
            Notification_tab.Controls.Add(Nofi_Panel);
            Notification_tab.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            Notification_tab.Location = new Point(184, 4);
            Notification_tab.Name = "Notification_tab";
            Notification_tab.Size = new Size(915, 527);
            Notification_tab.TabIndex = 2;
            Notification_tab.Text = "Thông Báo";
            Notification_tab.UseVisualStyleBackColor = true;
            // 
            // Nofi_Panel
            // 
            Nofi_Panel.BackColor = Color.Transparent;
            Nofi_Panel.Controls.Add(Notification_Panel);
            Nofi_Panel.Dock = DockStyle.Fill;
            Nofi_Panel.FillColor = Color.White;
            Nofi_Panel.Location = new Point(0, 0);
            Nofi_Panel.Name = "Nofi_Panel";
            Nofi_Panel.ShadowColor = Color.Black;
            Nofi_Panel.Size = new Size(913, 525);
            Nofi_Panel.TabIndex = 1;
            // 
            // Notification_Panel
            // 
            Notification_Panel.AutoScroll = true;
            Notification_Panel.BackColor = Color.DimGray;
            Notification_Panel.BorderStyle = BorderStyle.FixedSingle;
            Notification_Panel.Dock = DockStyle.Fill;
            Notification_Panel.FillColor = Color.LightCyan;
            Notification_Panel.Location = new Point(0, 0);
            Notification_Panel.Name = "Notification_Panel";
            Notification_Panel.ShadowColor = Color.Black;
            Notification_Panel.Size = new Size(913, 525);
            Notification_Panel.TabIndex = 2;
            // 
            // f_Invite
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1103, 535);
            Controls.Add(guna2TabControl1);
            Name = "f_Invite";
            Text = "Invited";
            guna2TabControl1.ResumeLayout(false);
            Received_tab.ResumeLayout(false);
            Sent_tab.ResumeLayout(false);
            Notification_tab.ResumeLayout(false);
            Nofi_Panel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2TabControl guna2TabControl1;
        private TabPage Received_tab;
        private TabPage Sent_tab;
        private TabPage Notification_tab;
        private Guna.UI2.WinForms.Guna2ShadowPanel Nofi_Panel;
        private Guna.UI2.WinForms.Guna2ShadowPanel Notification_Panel;
        private Guna.UI2.WinForms.Guna2ShadowPanel Received_Panel;
        private Guna.UI2.WinForms.Guna2ShadowPanel Sent_Panel;
    }
}