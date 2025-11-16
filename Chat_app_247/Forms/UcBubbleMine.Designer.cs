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
            pnlBubble.BorderRadius = 22;
            pnlBubble.Controls.Add(lblText);
            pnlBubble.CustomizableEdges = customizableEdges3;
            pnlBubble.FillColor = Color.FromArgb(0, 120, 212);
            pnlBubble.Location = new Point(2, 27);
            pnlBubble.Margin = new Padding(2);
            pnlBubble.Name = "pnlBubble";
            pnlBubble.Padding = new Padding(8, 5, 8, 5);
            pnlBubble.ShadowDecoration.CustomizableEdges = customizableEdges4;
            pnlBubble.Size = new Size(330, 47);
            pnlBubble.TabIndex = 0;
            // 
            // lblText
            // 
            lblText.AutoSize = true;
            lblText.BorderColor = Color.FromArgb(192, 192, 255);
            lblText.CustomizableEdges = customizableEdges1;
            lblText.DefaultText = "";
            lblText.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            lblText.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            lblText.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            lblText.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            lblText.FillColor = Color.FromArgb(0, 120, 212);
            lblText.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            lblText.Font = new Font("Segoe UI", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblText.ForeColor = Color.Black;
            lblText.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            lblText.Location = new Point(11, 9);
            lblText.Margin = new Padding(3, 4, 3, 4);
            lblText.MaximumSize = new Size(303, 0);
            lblText.Name = "lblText";
            lblText.PlaceholderText = "";
            lblText.ReadOnly = true;
            lblText.SelectedText = "";
            lblText.ShadowDecoration.CustomizableEdges = customizableEdges2;
            lblText.Size = new Size(303, 29);
            lblText.TabIndex = 1;
            // 
            // lb_name
            // 
            lb_name.AutoSize = true;
            lb_name.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lb_name.ForeColor = SystemColors.ActiveCaption;
            lb_name.Location = new Point(276, 0);
            lb_name.Name = "lb_name";
            lb_name.Size = new Size(56, 23);
            lb_name.TabIndex = 1;
            lb_name.Text = "Name";
            // 
            // pic_avt
            // 
            pic_avt.ImageRotate = 0F;
            pic_avt.Location = new Point(337, 27);
            pic_avt.Name = "pic_avt";
            pic_avt.ShadowDecoration.CustomizableEdges = customizableEdges5;
            pic_avt.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            pic_avt.Size = new Size(40, 40);
            pic_avt.SizeMode = PictureBoxSizeMode.Zoom;
            pic_avt.TabIndex = 2;
            pic_avt.TabStop = false;
            // 
            // UcBubbleMine
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.Transparent;
            Controls.Add(pic_avt);
            Controls.Add(lb_name);
            Controls.Add(pnlBubble);
            Margin = new Padding(43, 1, 0, 5);
            Name = "UcBubbleMine";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(380, 76);
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
