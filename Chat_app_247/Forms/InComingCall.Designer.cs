namespace Chat_app_247.Forms
{
    partial class InComingCall
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

        #region Windows Form Designer generated code

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
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            btnAccept = new Guna.UI2.WinForms.Guna2Button();
            lblStatus = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblCallerName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            picAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            SuspendLayout();
            // 
            // guna2Button1
            // 
            guna2Button1.BorderRadius = 15;
            guna2Button1.Cursor = Cursors.Hand;
            guna2Button1.CustomizableEdges = customizableEdges1;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.FillColor = Color.Red;
            guna2Button1.Font = new Font("Segoe UI", 21.8571434F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2Button1.ForeColor = Color.White;
            guna2Button1.Location = new Point(233, 353);
            guna2Button1.Margin = new Padding(2);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Button1.Size = new Size(113, 58);
            guna2Button1.TabIndex = 25;
            guna2Button1.Text = "✆";
            // 
            // btnAccept
            // 
            btnAccept.BorderRadius = 15;
            btnAccept.Cursor = Cursors.Hand;
            btnAccept.CustomizableEdges = customizableEdges3;
            btnAccept.DisabledState.BorderColor = Color.DarkGray;
            btnAccept.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAccept.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAccept.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAccept.FillColor = Color.DarkGreen;
            btnAccept.Font = new Font("Segoe UI", 21.8571434F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAccept.ForeColor = Color.White;
            btnAccept.Location = new Point(40, 353);
            btnAccept.Margin = new Padding(2);
            btnAccept.Name = "btnAccept";
            btnAccept.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnAccept.Size = new Size(113, 58);
            btnAccept.TabIndex = 24;
            btnAccept.Text = "📞";
            // 
            // lblStatus
            // 
            lblStatus.BackColor = Color.Transparent;
            lblStatus.ForeColor = Color.Black;
            lblStatus.Location = new Point(77, 253);
            lblStatus.Margin = new Padding(2);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(39, 22);
            lblStatus.TabIndex = 23;
            lblStatus.Text = "None";
            // 
            // lblCallerName
            // 
            lblCallerName.BackColor = Color.Transparent;
            lblCallerName.Font = new Font("Segoe UI", 9.857143F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCallerName.ForeColor = Color.Black;
            lblCallerName.Location = new Point(77, 213);
            lblCallerName.Margin = new Padding(2);
            lblCallerName.Name = "lblCallerName";
            lblCallerName.Size = new Size(45, 23);
            lblCallerName.TabIndex = 22;
            lblCallerName.Text = "None";
            // 
            // picAvatar
            // 
            picAvatar.ImageRotate = 0F;
            picAvatar.Location = new Point(115, 49);
            picAvatar.Margin = new Padding(2);
            picAvatar.Name = "picAvatar";
            picAvatar.ShadowDecoration.CustomizableEdges = customizableEdges5;
            picAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            picAvatar.Size = new Size(145, 145);
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picAvatar.TabIndex = 21;
            picAvatar.TabStop = false;
            // 
            // InComingCall
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 450);
            Controls.Add(guna2Button1);
            Controls.Add(btnAccept);
            Controls.Add(lblStatus);
            Controls.Add(lblCallerName);
            Controls.Add(picAvatar);
            Name = "InComingCall";
            Text = "InComingCall";
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button btnAccept;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblStatus;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCallerName;
        private Guna.UI2.WinForms.Guna2CirclePictureBox picAvatar;
    }
}