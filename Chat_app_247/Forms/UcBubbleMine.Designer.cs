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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlBubble = new Guna.UI2.WinForms.Guna2Panel();
            lblText = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lb_name = new Label();
            pic_avt = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            guna2ContextMenuStrip1 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripMenuItem();
            flpReactions = new FlowLayoutPanel();
            pnlBubble.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pic_avt).BeginInit();
            guna2ContextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBubble
            // 
            pnlBubble.AutoRoundedCorners = true;
            pnlBubble.AutoSize = true;
            pnlBubble.BorderRadius = 34;
            pnlBubble.ContextMenuStrip = guna2ContextMenuStrip1;
            pnlBubble.Controls.Add(lblText);
            pnlBubble.CustomizableEdges = customizableEdges1;
            pnlBubble.FillColor = Color.FromArgb(0, 120, 212);
            pnlBubble.Location = new Point(3, 40);
            pnlBubble.Name = "pnlBubble";
            pnlBubble.Padding = new Padding(12, 8, 12, 8);
            pnlBubble.ShadowDecoration.CustomizableEdges = customizableEdges2;
            pnlBubble.Size = new Size(495, 71);
            pnlBubble.TabIndex = 0;
            // 
            // lblText
            // 
            lblText.BackColor = Color.Transparent;
            lblText.Location = new Point(24, 11);
            lblText.Name = "lblText";
            lblText.Size = new Size(421, 32);
            lblText.TabIndex = 0;
            lblText.Text = "guna2HtmlLabel1...................................................";
            // 
            // lb_name
            // 
            lb_name.AutoSize = true;
            lb_name.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lb_name.ForeColor = SystemColors.ActiveCaption;
            lb_name.Location = new Point(414, 0);
            lb_name.Margin = new Padding(4, 0, 4, 0);
            lb_name.Name = "lb_name";
            lb_name.Size = new Size(78, 32);
            lb_name.TabIndex = 1;
            lb_name.Text = "Name";
            // 
            // pic_avt
            // 
            pic_avt.ImageRotate = 0F;
            pic_avt.Location = new Point(506, 40);
            pic_avt.Margin = new Padding(4);
            pic_avt.Name = "pic_avt";
            pic_avt.ShadowDecoration.CustomizableEdges = customizableEdges3;
            pic_avt.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            pic_avt.Size = new Size(60, 60);
            pic_avt.SizeMode = PictureBoxSizeMode.Zoom;
            pic_avt.TabIndex = 2;
            pic_avt.TabStop = false;
            // 
            // guna2ContextMenuStrip1
            // 
            guna2ContextMenuStrip1.Font = new Font("Segoe UI Emoji", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guna2ContextMenuStrip1.ImageScalingSize = new Size(28, 28);
            guna2ContextMenuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, toolStripMenuItem2, toolStripMenuItem3, toolStripMenuItem4 });
            guna2ContextMenuStrip1.Name = "contextEmoji";
            guna2ContextMenuStrip1.RenderStyle.ArrowColor = Color.FromArgb(151, 143, 255);
            guna2ContextMenuStrip1.RenderStyle.BorderColor = Color.Gainsboro;
            guna2ContextMenuStrip1.RenderStyle.ColorTable = null;
            guna2ContextMenuStrip1.RenderStyle.RoundedEdges = true;
            guna2ContextMenuStrip1.RenderStyle.SelectionArrowColor = Color.White;
            guna2ContextMenuStrip1.RenderStyle.SelectionBackColor = Color.FromArgb(100, 88, 255);
            guna2ContextMenuStrip1.RenderStyle.SelectionForeColor = Color.White;
            guna2ContextMenuStrip1.RenderStyle.SeparatorColor = Color.Gainsboro;
            guna2ContextMenuStrip1.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            guna2ContextMenuStrip1.Size = new Size(114, 140);
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
            // flpReactions
            // 
            flpReactions.AutoSize = true;
            flpReactions.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpReactions.Location = new Point(79, 120);
            flpReactions.Name = "flpReactions";
            flpReactions.Size = new Size(0, 0);
            flpReactions.TabIndex = 4;
            // 
            // UcBubbleMine
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.Transparent;
            Controls.Add(flpReactions);
            Controls.Add(pic_avt);
            Controls.Add(lb_name);
            Controls.Add(pnlBubble);
            Margin = new Padding(64, 2, 0, 8);
            Name = "UcBubbleMine";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(570, 123);
            pnlBubble.ResumeLayout(false);
            pnlBubble.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pic_avt).EndInit();
            guna2ContextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlBubble;
        private Label lb_name;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pic_avt;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip guna2ContextMenuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private FlowLayoutPanel flpReactions;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblText;
    }
}
