namespace Chat_app_247.Forms
{
    partial class UcMessUser
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Button_Chat = new Guna.UI2.WinForms.Guna2Button();
            Avt_pic = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            Status_panel = new Guna.UI2.WinForms.Guna2Panel();
            lblName = new Label();
            guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            Last_Message = new Label();
            ((System.ComponentModel.ISupportInitialize)Avt_pic).BeginInit();
            guna2Panel2.SuspendLayout();
            SuspendLayout();
            // 
            // Button_Chat
            // 
            Button_Chat.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Button_Chat.BorderRadius = 8;
            Button_Chat.CustomizableEdges = customizableEdges1;
            Button_Chat.DisabledState.BorderColor = Color.DarkGray;
            Button_Chat.DisabledState.CustomBorderColor = Color.DarkGray;
            Button_Chat.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            Button_Chat.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            Button_Chat.FillColor = Color.FromArgb(104, 33, 122);
            Button_Chat.Font = new Font("Segoe UI Semibold", 9.857143F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Button_Chat.ForeColor = Color.White;
            Button_Chat.Location = new Point(442, 16);
            Button_Chat.Name = "Button_Chat";
            Button_Chat.ShadowDecoration.CustomizableEdges = customizableEdges2;
            Button_Chat.Size = new Size(122, 56);
            Button_Chat.TabIndex = 7;
            Button_Chat.Text = "Chat";
            // 
            // Avt_pic
            // 
            Avt_pic.Image = Properties.Resources.Logo_Real;
            Avt_pic.ImageRotate = 0F;
            Avt_pic.InitialImage = null;
            Avt_pic.Location = new Point(30, 15);
            Avt_pic.Margin = new Padding(4, 4, 4, 4);
            Avt_pic.Name = "Avt_pic";
            Avt_pic.ShadowDecoration.CustomizableEdges = customizableEdges3;
            Avt_pic.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            Avt_pic.Size = new Size(60, 60);
            Avt_pic.SizeMode = PictureBoxSizeMode.Zoom;
            Avt_pic.TabIndex = 11;
            Avt_pic.TabStop = false;
            // 
            // Status_panel
            // 
            Status_panel.BorderRadius = 5;
            Status_panel.CustomizableEdges = customizableEdges4;
            Status_panel.FillColor = Color.LimeGreen;
            Status_panel.Location = new Point(98, 64);
            Status_panel.Name = "Status_panel";
            Status_panel.RightToLeft = RightToLeft.Yes;
            Status_panel.ShadowDecoration.CustomizableEdges = customizableEdges5;
            Status_panel.Size = new Size(10, 10);
            Status_panel.TabIndex = 10;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI Semibold", 11.1428576F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName.ForeColor = Color.FromArgb(30, 30, 30);
            lblName.Location = new Point(117, 15);
            lblName.MaximumSize = new Size(500, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(86, 37);
            lblName.TabIndex = 9;
            lblName.Text = "label1";
            // 
            // guna2Panel2
            // 
            guna2Panel2.BackColor = Color.WhiteSmoke;
            guna2Panel2.BorderColor = Color.Blue;
            guna2Panel2.BorderRadius = 8;
            guna2Panel2.BorderThickness = 2;
            guna2Panel2.Controls.Add(Last_Message);
            guna2Panel2.Controls.Add(Avt_pic);
            guna2Panel2.Controls.Add(Button_Chat);
            guna2Panel2.Controls.Add(Status_panel);
            guna2Panel2.Controls.Add(lblName);
            guna2Panel2.CustomizableEdges = customizableEdges6;
            guna2Panel2.Dock = DockStyle.Fill;
            guna2Panel2.ForeColor = Color.WhiteSmoke;
            guna2Panel2.Location = new Point(0, 0);
            guna2Panel2.Margin = new Padding(4, 4, 4, 4);
            guna2Panel2.Name = "guna2Panel2";
            guna2Panel2.ShadowDecoration.CustomizableEdges = customizableEdges7;
            guna2Panel2.Size = new Size(588, 116);
            guna2Panel2.TabIndex = 12;
            // 
            // Last_Message
            // 
            Last_Message.AutoSize = true;
            Last_Message.Font = new Font("Segoe UI Semibold", 11.1428576F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Last_Message.ForeColor = Color.FromArgb(30, 30, 30);
            Last_Message.Location = new Point(117, 64);
            Last_Message.MaximumSize = new Size(500, 0);
            Last_Message.Name = "Last_Message";
            Last_Message.Size = new Size(180, 37);
            Last_Message.TabIndex = 12;
            Last_Message.Text = "Last Message";
            // 
            // UcMessUser
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(guna2Panel2);
            Margin = new Padding(4, 4, 4, 4);
            Name = "UcMessUser";
            Size = new Size(588, 116);
            ((System.ComponentModel.ISupportInitialize)Avt_pic).EndInit();
            guna2Panel2.ResumeLayout(false);
            guna2Panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button Button_Chat;
        private Guna.UI2.WinForms.Guna2CirclePictureBox Avt_pic;
        private Guna.UI2.WinForms.Guna2Panel Status_panel;
        private Label lblName;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Label Last_Message;
    }
}
