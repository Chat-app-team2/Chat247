namespace Chat_app_247.Forms
{
    partial class uc_NotificationRequestRefuse
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            uc_Notifi_refuse_Panel = new Guna.UI2.WinForms.Guna2Panel();
            Bell_button = new FontAwesome.Sharp.IconButton();
            Label_text_accept = new Guna.UI2.WinForms.Guna2HtmlLabel();
            Name_Label = new Guna.UI2.WinForms.Guna2HtmlLabel();
            Avartar_Picture = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            uc_Notifi_refuse_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Avartar_Picture).BeginInit();
            SuspendLayout();
            // 
            // uc_Notifi_refuse_Panel
            // 
            uc_Notifi_refuse_Panel.BackColor = Color.WhiteSmoke;
            uc_Notifi_refuse_Panel.BorderColor = SystemColors.Highlight;
            uc_Notifi_refuse_Panel.BorderRadius = 9;
            uc_Notifi_refuse_Panel.BorderThickness = 4;
            uc_Notifi_refuse_Panel.Controls.Add(Bell_button);
            uc_Notifi_refuse_Panel.Controls.Add(Label_text_accept);
            uc_Notifi_refuse_Panel.Controls.Add(Name_Label);
            uc_Notifi_refuse_Panel.Controls.Add(Avartar_Picture);
            uc_Notifi_refuse_Panel.CustomizableEdges = customizableEdges2;
            uc_Notifi_refuse_Panel.Dock = DockStyle.Fill;
            uc_Notifi_refuse_Panel.Location = new Point(0, 0);
            uc_Notifi_refuse_Panel.Name = "uc_Notifi_refuse_Panel";
            uc_Notifi_refuse_Panel.ShadowDecoration.CustomizableEdges = customizableEdges3;
            uc_Notifi_refuse_Panel.Size = new Size(745, 120);
            uc_Notifi_refuse_Panel.TabIndex = 3;
            // 
            // Bell_button
            // 
            Bell_button.FlatAppearance.BorderSize = 0;
            Bell_button.FlatStyle = FlatStyle.Flat;
            Bell_button.IconChar = FontAwesome.Sharp.IconChar.X;
            Bell_button.IconColor = Color.Red;
            Bell_button.IconFont = FontAwesome.Sharp.IconFont.Solid;
            Bell_button.IconSize = 40;
            Bell_button.Location = new Point(650, 20);
            Bell_button.Name = "Bell_button";
            Bell_button.Size = new Size(56, 82);
            Bell_button.TabIndex = 18;
            Bell_button.UseVisualStyleBackColor = true;
            // 
            // Label_text_accept
            // 
            Label_text_accept.BackColor = Color.Transparent;
            Label_text_accept.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Label_text_accept.ForeColor = Color.Red;
            Label_text_accept.Location = new Point(332, 42);
            Label_text_accept.Name = "Label_text_accept";
            Label_text_accept.Size = new Size(282, 33);
            Label_text_accept.TabIndex = 17;
            Label_text_accept.Text = "Đã từ chối lời mời kết bạn";
            // 
            // Name_Label
            // 
            Name_Label.BackColor = Color.Transparent;
            Name_Label.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Name_Label.ForeColor = SystemColors.Desktop;
            Name_Label.Location = new Point(96, 42);
            Name_Label.Name = "Name_Label";
            Name_Label.Size = new Size(79, 33);
            Name_Label.TabIndex = 1;
            Name_Label.Text = "Name";
            // 
            // Avartar_Picture
            // 
            Avartar_Picture.FillColor = Color.Black;
            Avartar_Picture.ImageRotate = 0F;
            Avartar_Picture.Location = new Point(26, 29);
            Avartar_Picture.Name = "Avartar_Picture";
            Avartar_Picture.ShadowDecoration.CustomizableEdges = customizableEdges1;
            Avartar_Picture.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            Avartar_Picture.Size = new Size(60, 60);
            Avartar_Picture.TabIndex = 0;
            Avartar_Picture.TabStop = false;
            // 
            // uc_NotificationRequestRefuse
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(uc_Notifi_refuse_Panel);
            Name = "uc_NotificationRequestRefuse";
            Size = new Size(745, 120);
            uc_Notifi_refuse_Panel.ResumeLayout(false);
            uc_Notifi_refuse_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Avartar_Picture).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel uc_Notifi_refuse_Panel;
        private FontAwesome.Sharp.IconButton Bell_button;
        private Guna.UI2.WinForms.Guna2HtmlLabel Label_text_accept;
        private Guna.UI2.WinForms.Guna2HtmlLabel Name_Label;
        private Guna.UI2.WinForms.Guna2CirclePictureBox Avartar_Picture;
    }
}
