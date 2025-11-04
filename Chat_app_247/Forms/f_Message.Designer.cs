namespace Chat_app_247
{
    partial class f_Message
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
            Message_panel = new Panel();
            Message_send_panel = new Panel();
            SuspendLayout();
            // 
            // Message_panel
            // 
            Message_panel.BorderStyle = BorderStyle.FixedSingle;
            Message_panel.Dock = DockStyle.Left;
            Message_panel.Location = new Point(0, 0);
            Message_panel.Name = "Message_panel";
            Message_panel.Size = new Size(257, 450);
            Message_panel.TabIndex = 0;
            // 
            // Message_send_panel
            // 
            Message_send_panel.BorderStyle = BorderStyle.Fixed3D;
            Message_send_panel.Dock = DockStyle.Fill;
            Message_send_panel.Location = new Point(257, 0);
            Message_send_panel.Name = "Message_send_panel";
            Message_send_panel.Size = new Size(543, 450);
            Message_send_panel.TabIndex = 1;
            // 
            // f_Message
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Message_send_panel);
            Controls.Add(Message_panel);
            Name = "f_Message";
            Text = "Message";
            ResumeLayout(false);
        }

        #endregion

        private Panel Message_panel;
        private Panel Message_send_panel;
    }
}