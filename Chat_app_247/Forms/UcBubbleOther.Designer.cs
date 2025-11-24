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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlBubble = new Guna.UI2.WinForms.Guna2Panel();
            lblText = new Label();
            pic_avt = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            lb_name = new Label();
            pnlBubble.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pic_avt).BeginInit();
            SuspendLayout();
            // 
            // pnlBubble
            // 
            pnlBubble.AutoRoundedCorners = true;
            pnlBubble.AutoSize = true;
            pnlBubble.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pnlBubble.BorderRadius = 18;
            pnlBubble.Controls.Add(lblText);
            pnlBubble.CustomizableEdges = customizableEdges4;
            pnlBubble.FillColor = Color.White;
            pnlBubble.Location = new Point(50, 25);
            pnlBubble.Margin = new Padding(2);
            pnlBubble.Name = "pnlBubble";
            pnlBubble.Padding = new Padding(8, 5, 8, 5);
            pnlBubble.ShadowDecoration.CustomizableEdges = customizableEdges5;
            pnlBubble.Size = new Size(93, 38);
            pnlBubble.TabIndex = 0;
            // 
            // lblText
            // 
            lblText.AutoSize = true;
            lblText.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblText.ForeColor = Color.Black;
            lblText.Location = new Point(14, 5);
            lblText.Name = "lblText";
            lblText.Size = new Size(68, 28);
            lblText.TabIndex = 1;
            lblText.Text = "lblText";
            // 
            // pic_avt
            // 
            pic_avt.Image = Properties.Resources.Logo_Real;
            pic_avt.ImageRotate = 0F;
            pic_avt.Location = new Point(4, 25);
            pic_avt.Name = "pic_avt";
            pic_avt.ShadowDecoration.CustomizableEdges = customizableEdges6;
            pic_avt.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            pic_avt.Size = new Size(40, 40);
            pic_avt.SizeMode = PictureBoxSizeMode.Zoom;
            pic_avt.TabIndex = 3;
            pic_avt.TabStop = false;
            // 
            // lb_name
            // 
            lb_name.AutoSize = true;
            lb_name.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lb_name.ForeColor = SystemColors.ActiveCaptionText;
            lb_name.Location = new Point(53, -2);
            lb_name.Name = "lb_name";
            lb_name.Size = new Size(56, 23);
            lb_name.TabIndex = 4;
            lb_name.Text = "Name";
            // 
            // UcBubbleOther
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.Transparent;
            Controls.Add(lb_name);
            Controls.Add(pic_avt);
            Controls.Add(pnlBubble);
            Margin = new Padding(0, 1, 43, 5);
            Name = "UcBubbleOther";
            Size = new Size(145, 68);
            pnlBubble.ResumeLayout(false);
            pnlBubble.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pic_avt).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlBubble;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pic_avt;
        private Label lb_name;
        private Label lblText;
    }
}
