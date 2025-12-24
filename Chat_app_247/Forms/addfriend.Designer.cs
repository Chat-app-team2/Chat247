namespace Chat_app_247.Forms
{
    partial class addfriend
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
            uc_Request_Panel = new Guna.UI2.WinForms.Guna2Panel();
            guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            Name_Label = new Guna.UI2.WinForms.Guna2HtmlLabel();
            Avartar_Picture = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            uc_Request_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Avartar_Picture).BeginInit();
            SuspendLayout();
            // 
            // uc_Request_Panel
            // 
            uc_Request_Panel.BackColor = Color.Transparent;
            uc_Request_Panel.BorderColor = SystemColors.Highlight;
            uc_Request_Panel.BorderRadius = 9;
            uc_Request_Panel.BorderThickness = 4;
            uc_Request_Panel.Controls.Add(guna2Button2);
            uc_Request_Panel.Controls.Add(guna2Button1);
            uc_Request_Panel.Controls.Add(Name_Label);
            uc_Request_Panel.Controls.Add(Avartar_Picture);
            uc_Request_Panel.CustomizableEdges = customizableEdges6;
            uc_Request_Panel.Dock = DockStyle.Fill;
            uc_Request_Panel.Location = new Point(0, 0);
            uc_Request_Panel.Margin = new Padding(4, 4, 4, 4);
            uc_Request_Panel.Name = "uc_Request_Panel";
            uc_Request_Panel.ShadowDecoration.CustomizableEdges = customizableEdges7;
            uc_Request_Panel.Size = new Size(1222, 150);
            uc_Request_Panel.TabIndex = 1;
            uc_Request_Panel.Paint += uc_Request_Panel_Paint;
            // 
            // guna2Button2
            // 
            guna2Button2.BackColor = Color.Transparent;
            guna2Button2.BorderRadius = 10;
            guna2Button2.Cursor = Cursors.Hand;
            guna2Button2.CustomizableEdges = customizableEdges1;
            guna2Button2.DisabledState.BorderColor = Color.DarkGray;
            guna2Button2.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button2.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button2.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button2.FillColor = Color.FromArgb(104, 33, 122);
            guna2Button2.Font = new Font("Segoe UI", 9.857143F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2Button2.ForeColor = Color.White;
            guna2Button2.Location = new Point(910, 40);
            guna2Button2.Name = "guna2Button2";
            guna2Button2.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Button2.ShadowDecoration.Enabled = true;
            guna2Button2.Size = new Size(123, 84);
            guna2Button2.TabIndex = 17;
            guna2Button2.Text = "Thêm Bạn";
            guna2Button2.Click += guna2Button2_Click_1;
            // 
            // guna2Button1
            // 
            guna2Button1.BackColor = Color.Transparent;
            guna2Button1.BorderRadius = 10;
            guna2Button1.Cursor = Cursors.Hand;
            guna2Button1.CustomizableEdges = customizableEdges3;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.FillColor = SystemColors.MenuBar;
            guna2Button1.Font = new Font("Segoe UI", 9.857143F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2Button1.ForeColor = Color.Black;
            guna2Button1.Location = new Point(738, 40);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Button1.ShadowDecoration.Enabled = true;
            guna2Button1.Size = new Size(123, 84);
            guna2Button1.TabIndex = 16;
            guna2Button1.Text = "Xem Thêm";
            guna2Button1.Click += guna2Button1_Click;
            // 
            // Name_Label
            // 
            Name_Label.BackColor = Color.Transparent;
            Name_Label.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name_Label.ForeColor = Color.Black;
            Name_Label.Location = new Point(147, 56);
            Name_Label.Margin = new Padding(4, 4, 4, 4);
            Name_Label.Name = "Name_Label";
            Name_Label.Size = new Size(105, 46);
            Name_Label.TabIndex = 1;
            Name_Label.Text = "Name";
            // 
            // Avartar_Picture
            // 
            Avartar_Picture.Image = Properties.Resources.Logo_Real;
            Avartar_Picture.ImageRotate = 0F;
            Avartar_Picture.Location = new Point(33, 30);
            Avartar_Picture.Margin = new Padding(4, 4, 4, 4);
            Avartar_Picture.Name = "Avartar_Picture";
            Avartar_Picture.ShadowDecoration.CustomizableEdges = customizableEdges5;
            Avartar_Picture.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            Avartar_Picture.Size = new Size(90, 90);
            Avartar_Picture.SizeMode = PictureBoxSizeMode.Zoom;
            Avartar_Picture.TabIndex = 0;
            Avartar_Picture.TabStop = false;
            // 
            // addfriend
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(uc_Request_Panel);
            Name = "addfriend";
            Size = new Size(1222, 150);
            uc_Request_Panel.ResumeLayout(false);
            uc_Request_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Avartar_Picture).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel uc_Request_Panel;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2HtmlLabel Name_Label;
        private Guna.UI2.WinForms.Guna2CirclePictureBox Avartar_Picture;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
    }
}
