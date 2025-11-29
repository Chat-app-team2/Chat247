namespace Chat_app_247.Forms
{
    partial class Caller
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            lblStatus = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblCallerName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            picAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            SuspendLayout();
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
            guna2Button1.Location = new Point(76, 349);
            guna2Button1.Margin = new Padding(2);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges5;
            guna2Button1.Size = new Size(113, 58);
            guna2Button1.TabIndex = 25;
            guna2Button1.Text = "✆";
            // 
            // lblStatus
            // 
            lblStatus.BackColor = Color.Transparent;
            lblStatus.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.ForeColor = Color.Black;
            lblStatus.Location = new Point(116, 235);
            lblStatus.Margin = new Padding(2);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(45, 25);
            lblStatus.TabIndex = 23;
            lblStatus.Text = "None";
            // 
            // lblCallerName
            // 
            lblCallerName.BackColor = Color.Transparent;
            lblCallerName.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblCallerName.ForeColor = Color.Black;
            lblCallerName.Location = new Point(120, 194);
            lblCallerName.Margin = new Padding(2);
            lblCallerName.Name = "lblCallerName";
            lblCallerName.Size = new Size(44, 25);
            lblCallerName.TabIndex = 22;
            lblCallerName.Text = "None";
            // 
            // picAvatar
            // 
            picAvatar.ImageRotate = 0F;
            picAvatar.Location = new Point(65, 25);
            picAvatar.Margin = new Padding(2);
            picAvatar.Name = "picAvatar";
            picAvatar.ShadowDecoration.CustomizableEdges = customizableEdges6;
            picAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            picAvatar.Size = new Size(145, 145);
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picAvatar.TabIndex = 21;
            picAvatar.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(40, 194);
            label1.Name = "label1";
            label1.Size = new Size(45, 25);
            label1.TabIndex = 26;
            label1.Text = "Tên:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 235);
            label2.Name = "label2";
            label2.Size = new Size(99, 25);
            label2.TabIndex = 27;
            label2.Text = "Trạng thái:";
            // 
            // Caller
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(278, 438);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(guna2Button1);
            Controls.Add(lblStatus);
            Controls.Add(lblCallerName);
            Controls.Add(picAvatar);
            Name = "Caller";
            Text = "Caller";
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblStatus;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCallerName;
        private Guna.UI2.WinForms.Guna2CirclePictureBox picAvatar;
        private Label label1;
        private Label label2;
    }
}