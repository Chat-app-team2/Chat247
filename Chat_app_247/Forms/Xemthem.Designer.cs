namespace Chat_app_247.Forms
{
    partial class Xemthem
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            avt_pic = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txt_bio = new RichTextBox();
            txt_name = new TextBox();
            txt_email = new TextBox();
            txt_gender = new TextBox();
            txt_date = new TextBox();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)avt_pic).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // avt_pic
            // 
            avt_pic.Image = Properties.Resources.Logo_Real;
            avt_pic.ImageRotate = 0F;
            avt_pic.Location = new Point(136, 59);
            avt_pic.Name = "avt_pic";
            avt_pic.ShadowDecoration.CustomizableEdges = customizableEdges2;
            avt_pic.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            avt_pic.Size = new Size(120, 120);
            avt_pic.SizeMode = PictureBoxSizeMode.Zoom;
            avt_pic.TabIndex = 0;
            avt_pic.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(22, 200);
            label1.Name = "label1";
            label1.Size = new Size(97, 28);
            label1.TabIndex = 1;
            label1.Text = "Tên user:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(22, 252);
            label2.Name = "label2";
            label2.Size = new Size(69, 28);
            label2.TabIndex = 2;
            label2.Text = "Email:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.Location = new Point(22, 298);
            label3.Name = "label3";
            label3.Size = new Size(100, 28);
            label3.TabIndex = 3;
            label3.Text = "Giới tính:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.Location = new Point(18, 350);
            label4.Name = "label4";
            label4.Size = new Size(112, 28);
            label4.TabIndex = 4;
            label4.Text = "Ngày sinh:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.Location = new Point(22, 396);
            label5.Name = "label5";
            label5.Size = new Size(48, 28);
            label5.TabIndex = 5;
            label5.Text = "Bio:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(80, 16);
            label6.Name = "label6";
            label6.Size = new Size(251, 31);
            label6.TabIndex = 6;
            label6.Text = "Thông tin người dùng";
            // 
            // txt_bio
            // 
            txt_bio.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_bio.Location = new Point(22, 430);
            txt_bio.Name = "txt_bio";
            txt_bio.ReadOnly = true;
            txt_bio.Size = new Size(363, 120);
            txt_bio.TabIndex = 7;
            txt_bio.Text = "";
            // 
            // txt_name
            // 
            txt_name.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txt_name.Location = new Point(137, 203);
            txt_name.Name = "txt_name";
            txt_name.ReadOnly = true;
            txt_name.Size = new Size(248, 28);
            txt_name.TabIndex = 8;
            // 
            // txt_email
            // 
            txt_email.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txt_email.Location = new Point(136, 256);
            txt_email.Name = "txt_email";
            txt_email.ReadOnly = true;
            txt_email.Size = new Size(248, 28);
            txt_email.TabIndex = 9;
            // 
            // txt_gender
            // 
            txt_gender.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txt_gender.Location = new Point(136, 302);
            txt_gender.Name = "txt_gender";
            txt_gender.ReadOnly = true;
            txt_gender.Size = new Size(248, 28);
            txt_gender.TabIndex = 10;
            // 
            // txt_date
            // 
            txt_date.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txt_date.Location = new Point(136, 354);
            txt_date.Name = "txt_date";
            txt_date.ReadOnly = true;
            txt_date.Size = new Size(248, 28);
            txt_date.TabIndex = 11;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.GradientInactiveCaption;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(txt_date);
            panel1.Controls.Add(txt_gender);
            panel1.Controls.Add(txt_email);
            panel1.Controls.Add(txt_name);
            panel1.Controls.Add(txt_bio);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(avt_pic);
            panel1.Location = new Point(15, 18);
            panel1.Name = "panel1";
            panel1.Size = new Size(407, 573);
            panel1.TabIndex = 12;
            // 
            // Xemthem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(440, 607);
            Controls.Add(panel1);
            Name = "Xemthem";
            Text = "Xemthem";
            ((System.ComponentModel.ISupportInitialize)avt_pic).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2CirclePictureBox avt_pic;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private RichTextBox txt_bio;
        private TextBox txt_name;
        private TextBox txt_email;
        private TextBox txt_gender;
        private TextBox txt_date;
        private Panel panel1;
    }
}