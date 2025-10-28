namespace Chat_app_247.Forms
{
    partial class uc_SentRequest
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            uc_Sent_Panel = new Guna.UI2.WinForms.Guna2Panel();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            DeleteRequest_button = new Guna.UI2.WinForms.Guna2Button();
            Name_Label = new Guna.UI2.WinForms.Guna2HtmlLabel();
            Avartar_Picture = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            uc_Sent_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Avartar_Picture).BeginInit();
            SuspendLayout();
            // 
            // uc_Sent_Panel
            // 
            uc_Sent_Panel.BackColor = Color.FromArgb(44, 62, 80);
            uc_Sent_Panel.BorderColor = SystemColors.AppWorkspace;
            uc_Sent_Panel.BorderRadius = 2;
            uc_Sent_Panel.BorderThickness = 2;
            uc_Sent_Panel.Controls.Add(guna2Button1);
            uc_Sent_Panel.Controls.Add(DeleteRequest_button);
            uc_Sent_Panel.Controls.Add(Name_Label);
            uc_Sent_Panel.Controls.Add(Avartar_Picture);
            uc_Sent_Panel.CustomizableEdges = customizableEdges6;
            uc_Sent_Panel.Dock = DockStyle.Fill;
            uc_Sent_Panel.Location = new Point(0, 0);
            uc_Sent_Panel.Name = "uc_Sent_Panel";
            uc_Sent_Panel.ShadowDecoration.CustomizableEdges = customizableEdges7;
            uc_Sent_Panel.Size = new Size(821, 123);
            uc_Sent_Panel.TabIndex = 1;
            // 
            // guna2Button1
            // 
            guna2Button1.BackColor = Color.Transparent;
            guna2Button1.BorderRadius = 10;
            guna2Button1.Cursor = Cursors.Hand;
            guna2Button1.CustomizableEdges = customizableEdges1;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.FillColor = SystemColors.MenuBar;
            guna2Button1.Font = new Font("Segoe UI", 9.857143F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2Button1.ForeColor = Color.DimGray;
            guna2Button1.Location = new Point(598, 31);
            guna2Button1.Margin = new Padding(2);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Button1.ShadowDecoration.Enabled = true;
            guna2Button1.Size = new Size(82, 56);
            guna2Button1.TabIndex = 16;
            guna2Button1.Text = "Xem Thêm";
            // 
            // DeleteRequest_button
            // 
            DeleteRequest_button.BackColor = Color.Transparent;
            DeleteRequest_button.BorderRadius = 10;
            DeleteRequest_button.Cursor = Cursors.Hand;
            DeleteRequest_button.CustomizableEdges = customizableEdges3;
            DeleteRequest_button.DisabledState.BorderColor = Color.DarkGray;
            DeleteRequest_button.DisabledState.CustomBorderColor = Color.DarkGray;
            DeleteRequest_button.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            DeleteRequest_button.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            DeleteRequest_button.FillColor = Color.FromArgb(231, 76, 80);
            DeleteRequest_button.Font = new Font("Segoe UI", 9.857143F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DeleteRequest_button.ForeColor = Color.White;
            DeleteRequest_button.Location = new Point(409, 31);
            DeleteRequest_button.Margin = new Padding(2);
            DeleteRequest_button.Name = "DeleteRequest_button";
            DeleteRequest_button.ShadowDecoration.CustomizableEdges = customizableEdges4;
            DeleteRequest_button.ShadowDecoration.Enabled = true;
            DeleteRequest_button.Size = new Size(150, 56);
            DeleteRequest_button.TabIndex = 15;
            DeleteRequest_button.Text = "Xóa Lời Mời";
            // 
            // Name_Label
            // 
            Name_Label.BackColor = Color.Transparent;
            Name_Label.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name_Label.ForeColor = SystemColors.Info;
            Name_Label.Location = new Point(98, 41);
            Name_Label.Name = "Name_Label";
            Name_Label.Size = new Size(75, 33);
            Name_Label.TabIndex = 1;
            Name_Label.Text = "Name";
            // 
            // Avartar_Picture
            // 
            Avartar_Picture.ImageRotate = 0F;
            Avartar_Picture.Location = new Point(22, 27);
            Avartar_Picture.Name = "Avartar_Picture";
            Avartar_Picture.ShadowDecoration.CustomizableEdges = customizableEdges5;
            Avartar_Picture.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            Avartar_Picture.Size = new Size(60, 60);
            Avartar_Picture.TabIndex = 0;
            Avartar_Picture.TabStop = false;
            // 
            // uc_SentRequest
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(uc_Sent_Panel);
            Name = "uc_SentRequest";
            Size = new Size(821, 123);
            uc_Sent_Panel.ResumeLayout(false);
            uc_Sent_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Avartar_Picture).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel uc_Sent_Panel;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button DeleteRequest_button;
        private Guna.UI2.WinForms.Guna2HtmlLabel Name_Label;
        private Guna.UI2.WinForms.Guna2CirclePictureBox Avartar_Picture;
    }
}
