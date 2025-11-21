namespace Chat_app_247.Forms
{
    partial class UcBubbleMine
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
            pnlBubble = new Guna.UI2.WinForms.Guna2Panel();
            lblText = new Guna.UI2.WinForms.Guna2TextBox();
            lb_name = new Label();
            pic_avt = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            pnlBubble.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pic_avt).BeginInit();
            SuspendLayout();
            // 
            // pnlBubble
            // 
            pnlBubble.AutoRoundedCorners = true;
            pnlBubble.AutoSize = true;
            pnlBubble.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pnlBubble.BorderRadius = 43;
            pnlBubble.Controls.Add(lblText);
            pnlBubble.CustomizableEdges = customizableEdges3;
            pnlBubble.FillColor = Color.PowderBlue;
            pnlBubble.Location = new Point(3, 40);
            pnlBubble.Name = "pnlBubble";
            pnlBubble.Padding = new Padding(12, 8, 12, 8);
            pnlBubble.ShadowDecoration.CustomizableEdges = customizableEdges4;
            pnlBubble.Size = new Size(501, 89);
            pnlBubble.TabIndex = 0;
            // 
            // lblText
            // 
            lblText.AutoSize = true;
            lblText.BackColor = Color.Transparent;
            lblText.BorderColor = Color.FromArgb(0, 120, 212);
            lblText.CustomizableEdges = customizableEdges1;
            lblText.DefaultText = "";
            lblText.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            lblText.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            lblText.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            lblText.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            lblText.FillColor = Color.PowderBlue;
            lblText.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            lblText.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblText.ForeColor = Color.Black;
            lblText.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            lblText.Location = new Point(20, 16);
            lblText.Margin = new Padding(4, 8, 4, 8);
            lblText.Name = "lblText";
            lblText.PlaceholderText = "";
            lblText.ReadOnly = true;
            lblText.SelectedText = "";
            lblText.ShadowDecoration.CustomizableEdges = customizableEdges2;
            lblText.Size = new Size(465, 57);
            lblText.TabIndex = 1;
            // 
            // lb_name
            // 
            lb_name.AutoSize = true;
            lb_name.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lb_name.ForeColor = Color.Black;
            lb_name.Location = new Point(416, 0);
            lb_name.Margin = new Padding(4, 0, 4, 0);
            lb_name.Name = "lb_name";
            lb_name.Size = new Size(78, 32);
            lb_name.TabIndex = 1;
            lb_name.Text = "Name";
            // 
            // pic_avt
            // 
            pic_avt.ImageRotate = 0F;
            pic_avt.Location = new Point(512, 51);
            pic_avt.Margin = new Padding(4, 4, 4, 4);
            pic_avt.Name = "pic_avt";
            pic_avt.ShadowDecoration.CustomizableEdges = customizableEdges5;
            pic_avt.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            pic_avt.Size = new Size(60, 60);
            pic_avt.SizeMode = PictureBoxSizeMode.Zoom;
            pic_avt.TabIndex = 2;
            pic_avt.TabStop = false;
            // 
            // UcBubbleMine
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.Transparent;
            Controls.Add(pic_avt);
            Controls.Add(lb_name);
            Controls.Add(pnlBubble);
            Margin = new Padding(64, 2, 0, 8);
            Name = "UcBubbleMine";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(576, 132);
            pnlBubble.ResumeLayout(false);
            pnlBubble.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pic_avt).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlBubble;
        private Label lb_name;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pic_avt;
        private Guna.UI2.WinForms.Guna2TextBox lblText;
    }
}
