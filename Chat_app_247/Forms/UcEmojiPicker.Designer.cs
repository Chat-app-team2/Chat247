namespace Chat_app_247.Forms
{
    partial class UcEmojiPicker
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
            flpEmoji = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // flpEmoji
            // 
            flpEmoji.AutoScroll = true;
            flpEmoji.Dock = DockStyle.Fill;
            flpEmoji.Font = new Font("Segoe UI Emoji", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            flpEmoji.Location = new Point(0, 0);
            flpEmoji.Margin = new Padding(2);
            flpEmoji.Name = "flpEmoji";
            flpEmoji.Size = new Size(346, 59);
            flpEmoji.TabIndex = 0;
            // 
            // UcEmojiPicker
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flpEmoji);
            Margin = new Padding(2);
            Name = "UcEmojiPicker";
            Size = new Size(346, 59);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flpEmoji;
    }
}
