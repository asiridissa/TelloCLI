namespace TelloControl
{
    partial class Voice
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
            console = new RichTextBox();
            siLK = new Button();
            enUS = new Button();
            SuspendLayout();
            // 
            // console
            // 
            console.Location = new Point(134, 2);
            console.Name = "console";
            console.Size = new Size(666, 447);
            console.TabIndex = 0;
            console.Text = "";
            // 
            // siLK
            // 
            siLK.Location = new Point(26, 12);
            siLK.Name = "siLK";
            siLK.Size = new Size(75, 23);
            siLK.TabIndex = 1;
            siLK.Text = "si-LK";
            siLK.UseVisualStyleBackColor = true;
            siLK.Click += siLK_Click;
            // 
            // enUS
            // 
            enUS.Location = new Point(26, 51);
            enUS.Name = "enUS";
            enUS.Size = new Size(75, 23);
            enUS.TabIndex = 2;
            enUS.Text = "en-US";
            enUS.UseVisualStyleBackColor = true;
            enUS.Click += enUS_Click;
            // 
            // Voice
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(enUS);
            Controls.Add(siLK);
            Controls.Add(console);
            Name = "Voice";
            Text = "Voice";
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox console;
        private Button siLK;
        private Button enUS;
    }
}