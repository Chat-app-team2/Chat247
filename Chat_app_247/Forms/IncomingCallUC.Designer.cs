namespace Chat_app_247.Forms
{
    partial class IncomingCallUC
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            picAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            lblCallerName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblStatus = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnAccept = new Guna.UI2.WinForms.Guna2Button();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            SuspendLayout();
            // 
            // picAvatar
            // 
            picAvatar.ImageRotate = 0F;
            picAvatar.Location = new Point(147, 25);
            picAvatar.Name = "picAvatar";
            picAvatar.ShadowDecoration.CustomizableEdges = customizableEdges1;
            picAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            picAvatar.Size = new Size(219, 200);
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picAvatar.TabIndex = 0;
            picAvatar.TabStop = false;
            // 
            // lblCallerName
            // 
            lblCallerName.BackColor = Color.Transparent;
            lblCallerName.Font = new Font("Segoe UI", 9.857143F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCallerName.ForeColor = SystemColors.ButtonHighlight;
            lblCallerName.Location = new Point(90, 272);
            lblCallerName.Name = "lblCallerName";
            lblCallerName.Size = new Size(61, 33);
            lblCallerName.TabIndex = 1;
            lblCallerName.Text = "None";
            // 
            // lblStatus
            // 
            lblStatus.BackColor = Color.Transparent;
            lblStatus.ForeColor = SystemColors.ButtonHighlight;
            lblStatus.Location = new Point(90, 331);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(54, 32);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "None";
            // 
            // btnAccept
            // 
            btnAccept.BorderRadius = 15;
            btnAccept.Cursor = Cursors.Hand;
            btnAccept.CustomizableEdges = customizableEdges2;
            btnAccept.DisabledState.BorderColor = Color.DarkGray;
            btnAccept.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAccept.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAccept.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAccept.FillColor = Color.DarkGreen;
            btnAccept.Font = new Font("Segoe UI", 21.8571434F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAccept.ForeColor = Color.White;
            btnAccept.Location = new Point(34, 481);
            btnAccept.Name = "btnAccept";
            btnAccept.ShadowDecoration.CustomizableEdges = customizableEdges3;
            btnAccept.Size = new Size(170, 87);
            btnAccept.TabIndex = 19;
            btnAccept.Text = "📞";
            btnAccept.Click += btnAccept_Click;
            // 
            // guna2Button1
            // 
            guna2Button1.BorderRadius = 15;
            guna2Button1.Cursor = Cursors.Hand;
            guna2Button1.CustomizableEdges = customizableEdges4;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.FillColor = Color.Red;
            guna2Button1.Font = new Font("Segoe UI", 21.8571434F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2Button1.ForeColor = Color.White;
            guna2Button1.Location = new Point(324, 481);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges5;
            guna2Button1.Size = new Size(170, 87);
            guna2Button1.TabIndex = 20;
            guna2Button1.Text = "✆";
            guna2Button1.Click += guna2Button1_Click;
            // 
            // IncomingCallUC
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(35, 39, 42);
            Controls.Add(guna2Button1);
            Controls.Add(btnAccept);
            Controls.Add(lblStatus);
            Controls.Add(lblCallerName);
            Controls.Add(picAvatar);
            Name = "IncomingCallUC";
            Size = new Size(539, 600);
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2CirclePictureBox picAvatar;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCallerName;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblStatus;
        private Guna.UI2.WinForms.Guna2Button btnAccept;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}
