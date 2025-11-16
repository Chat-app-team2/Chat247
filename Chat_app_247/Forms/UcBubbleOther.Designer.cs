namespace Chat_app_247.Forms
{
    partial class UcBubbleOther
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            lblText = new Guna.UI2.WinForms.Guna2TextBox();
            pic_avt = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            lb_name = new Label();
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pic_avt).BeginInit();
            SuspendLayout();
            // 
            // guna2Panel1
            // 
            guna2Panel1.AutoRoundedCorners = true;
            guna2Panel1.AutoSize = true;
            guna2Panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            guna2Panel1.BorderRadius = 26;
            guna2Panel1.Controls.Add(lblText);
            guna2Panel1.CustomizableEdges = customizableEdges3;
            guna2Panel1.FillColor = Color.White;
            guna2Panel1.Location = new Point(62, 46);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.Padding = new Padding(12, 8, 12, 8);
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Panel1.Size = new Size(377, 55);
            guna2Panel1.TabIndex = 0;
            // 
            // lblText
            // 
            lblText.CustomizableEdges = customizableEdges1;
            lblText.DefaultText = "";
            lblText.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            lblText.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            lblText.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            lblText.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            lblText.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            lblText.Font = new Font("Segoe UI", 9F);
            lblText.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            lblText.Location = new Point(17, 5);
            lblText.Margin = new Padding(5, 6, 5, 6);
            lblText.Name = "lblText";
            lblText.PlaceholderForeColor = Color.Black;
            lblText.PlaceholderText = "";
            lblText.ReadOnly = true;
            lblText.SelectedText = "";
            lblText.ShadowDecoration.CustomizableEdges = customizableEdges2;
            lblText.Size = new Size(343, 36);
            lblText.TabIndex = 0;
            // 
            // pic_avt
            // 
            pic_avt.Image = Properties.Resources.Logo_Real;
            pic_avt.ImageRotate = 0F;
            pic_avt.Location = new Point(0, 51);
            pic_avt.Margin = new Padding(4);
            pic_avt.Name = "pic_avt";
            pic_avt.ShadowDecoration.CustomizableEdges = customizableEdges5;
            pic_avt.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            pic_avt.Size = new Size(60, 60);
            pic_avt.SizeMode = PictureBoxSizeMode.Zoom;
            pic_avt.TabIndex = 3;
            pic_avt.TabStop = false;
            // 
            // lb_name
            // 
            lb_name.AutoSize = true;
            lb_name.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lb_name.ForeColor = SystemColors.ActiveCaption;
            lb_name.Location = new Point(62, 8);
            lb_name.Margin = new Padding(4, 0, 4, 0);
            lb_name.Name = "lb_name";
            lb_name.Size = new Size(78, 32);
            lb_name.TabIndex = 4;
            lb_name.Text = "Name";
            // 
            // UcBubbleOther
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.Transparent;
            Controls.Add(lb_name);
            Controls.Add(pic_avt);
            Controls.Add(guna2Panel1);
            Margin = new Padding(0, 2, 64, 8);
            Name = "UcBubbleOther";
            Size = new Size(442, 115);
            guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pic_avt).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pic_avt;
        private Label lb_name;
        private Guna.UI2.WinForms.Guna2TextBox lblText;
    }
}
