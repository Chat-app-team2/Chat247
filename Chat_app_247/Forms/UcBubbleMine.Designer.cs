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
            pnlBubble = new Guna.UI2.WinForms.Guna2Panel();
            lblText = new Guna.UI2.WinForms.Guna2HtmlLabel();
            pnlBubble.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBubble
            // 
            pnlBubble.AutoRoundedCorners = true;
            pnlBubble.AutoSize = true;
            pnlBubble.BorderRadius = 30;
            pnlBubble.Controls.Add(lblText);
            pnlBubble.CustomizableEdges = customizableEdges3;
            pnlBubble.FillColor = Color.FromArgb(0, 120, 212);
            pnlBubble.Location = new Point(57, 54);
            pnlBubble.Name = "pnlBubble";
            pnlBubble.Padding = new Padding(12, 8, 12, 8);
            pnlBubble.ShadowDecoration.CustomizableEdges = customizableEdges4;
            pnlBubble.Size = new Size(344, 63);
            pnlBubble.TabIndex = 0;
            // 
            // lblText
            // 
            lblText.BackColor = Color.Transparent;
            lblText.Font = new Font("Segoe UI", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblText.ForeColor = Color.White;
            lblText.Location = new Point(30, 11);
            lblText.MaximumSize = new Size(420, 0);
            lblText.Name = "lblText";
            lblText.Size = new Size(184, 33);
            lblText.TabIndex = 0;
            lblText.Text = "guna2HtmlLabel1";
            // 
            // UcBubbleMine
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.Transparent;
            Controls.Add(pnlBubble);
            Margin = new Padding(64, 2, 0, 8);
            Name = "UcBubbleMine";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(404, 120);
            pnlBubble.ResumeLayout(false);
            pnlBubble.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlBubble;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblText;
    }
}
