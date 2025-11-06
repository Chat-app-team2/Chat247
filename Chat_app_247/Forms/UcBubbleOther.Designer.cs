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
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            lblText = new Guna.UI2.WinForms.Guna2TextBox();
            guna2Panel1.SuspendLayout();
            SuspendLayout();
            // 
            // guna2Panel1
            // 
            guna2Panel1.AutoRoundedCorners = true;
            guna2Panel1.AutoSize = true;
            guna2Panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            guna2Panel1.BorderRadius = 34;
            guna2Panel1.Controls.Add(lblText);
            guna2Panel1.CustomizableEdges = customizableEdges3;
            guna2Panel1.FillColor = Color.White;
            guna2Panel1.Location = new Point(51, 47);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.Padding = new Padding(12, 8, 12, 8);
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Panel1.Size = new Size(489, 71);
            guna2Panel1.TabIndex = 0;
            // 
            // lblText
            // 
            lblText.AutoSize = true;
            lblText.CustomizableEdges = customizableEdges1;
            lblText.DefaultText = "";
            lblText.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            lblText.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            lblText.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            lblText.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            lblText.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            lblText.Font = new Font("Segoe UI", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblText.ForeColor = Color.Black;
            lblText.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            lblText.Location = new Point(17, 14);
            lblText.Margin = new Padding(5, 6, 5, 6);
            lblText.MaximumSize = new Size(455, 0);
            lblText.Name = "lblText";
            lblText.PlaceholderText = "";
            lblText.SelectedText = "";
            lblText.ShadowDecoration.CustomizableEdges = customizableEdges2;
            lblText.Size = new Size(455, 43);
            lblText.TabIndex = 0;
            // 
            // UcBubbleOther
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.Transparent;
            Controls.Add(guna2Panel1);
            Margin = new Padding(0, 2, 64, 8);
            Name = "UcBubbleOther";
            Size = new Size(543, 121);
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2TextBox lblText;
    }
}
