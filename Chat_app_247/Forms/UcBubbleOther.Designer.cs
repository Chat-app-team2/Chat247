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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            contextEmoji = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripMenuItem();
            pic_avt = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            lb_name = new Label();
            flpReactions = new FlowLayoutPanel();
            lblText = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2Panel1.SuspendLayout();
            contextEmoji.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pic_avt).BeginInit();
            SuspendLayout();
            // 
            // guna2Panel1
            // 
            guna2Panel1.AutoRoundedCorners = true;
            guna2Panel1.AutoSize = true;
            guna2Panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            guna2Panel1.BorderRadius = 35;
            guna2Panel1.ContextMenuStrip = contextEmoji;
            guna2Panel1.Controls.Add(lblText);
            guna2Panel1.CustomizableEdges = customizableEdges1;
            guna2Panel1.FillColor = Color.White;
            guna2Panel1.Location = new Point(62, 46);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.Padding = new Padding(12, 8, 12, 8);
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Panel1.Size = new Size(445, 72);
            guna2Panel1.TabIndex = 0;
            // 
            // contextEmoji
            // 
            contextEmoji.Font = new Font("Segoe UI Emoji", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            contextEmoji.ImageScalingSize = new Size(28, 28);
            contextEmoji.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, toolStripMenuItem2, toolStripMenuItem3, toolStripMenuItem4 });
            contextEmoji.Name = "contextEmoji";
            contextEmoji.RenderStyle.ArrowColor = Color.FromArgb(151, 143, 255);
            contextEmoji.RenderStyle.BorderColor = Color.Gainsboro;
            contextEmoji.RenderStyle.ColorTable = null;
            contextEmoji.RenderStyle.RoundedEdges = true;
            contextEmoji.RenderStyle.SelectionArrowColor = Color.White;
            contextEmoji.RenderStyle.SelectionBackColor = Color.FromArgb(100, 88, 255);
            contextEmoji.RenderStyle.SelectionForeColor = Color.White;
            contextEmoji.RenderStyle.SeparatorColor = Color.Gainsboro;
            contextEmoji.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            contextEmoji.Size = new Size(114, 140);
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(113, 34);
            toolStripMenuItem1.Tag = "like";
            toolStripMenuItem1.Text = "👍";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(113, 34);
            toolStripMenuItem2.Tag = "heart";
            toolStripMenuItem2.Text = "❤️";
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(113, 34);
            toolStripMenuItem3.Tag = "haha";
            toolStripMenuItem3.Text = "😂";
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(113, 34);
            toolStripMenuItem4.Tag = "huhu";
            toolStripMenuItem4.Text = "😮";
            // 
            // pic_avt
            // 
            pic_avt.Image = Properties.Resources.Logo_Real;
            pic_avt.ImageRotate = 0F;
            pic_avt.Location = new Point(0, 51);
            pic_avt.Margin = new Padding(4);
            pic_avt.Name = "pic_avt";
            pic_avt.ShadowDecoration.CustomizableEdges = customizableEdges3;
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
            // flpReactions
            // 
            flpReactions.AutoSize = true;
            flpReactions.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpReactions.Location = new Point(441, 133);
            flpReactions.Name = "flpReactions";
            flpReactions.Size = new Size(0, 0);
            flpReactions.TabIndex = 5;
            // 
            // lblText
            // 
            lblText.BackColor = Color.Transparent;
            lblText.Location = new Point(94, 29);
            lblText.Name = "lblText";
            lblText.Size = new Size(336, 32);
            lblText.TabIndex = 0;
            lblText.Text = "guna2HtmlLabel1..................................";
            // 
            // UcBubbleOther
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.Transparent;
            Controls.Add(flpReactions);
            Controls.Add(lb_name);
            Controls.Add(pic_avt);
            Controls.Add(guna2Panel1);
            Margin = new Padding(0, 2, 64, 8);
            Name = "UcBubbleOther";
            Size = new Size(510, 136);
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            contextEmoji.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pic_avt).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pic_avt;
        private Label lb_name;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip contextEmoji;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private FlowLayoutPanel flpReactions;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblText;
    }
}
