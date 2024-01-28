namespace TelloControl
{
    partial class MainForm
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
            btnRecord = new Button();
            btnVoiceCommand = new Button();
            SuspendLayout();
            // 
            // btnRecord
            // 
            btnRecord.Location = new Point(12, 12);
            btnRecord.Name = "btnRecord";
            btnRecord.Size = new Size(124, 85);
            btnRecord.TabIndex = 0;
            btnRecord.Text = "Open Record Window";
            btnRecord.UseVisualStyleBackColor = true;
            btnRecord.Click += btnRecord_Click;
            // 
            // btnVoiceCommand
            // 
            btnVoiceCommand.Location = new Point(12, 103);
            btnVoiceCommand.Name = "btnVoiceCommand";
            btnVoiceCommand.Size = new Size(124, 85);
            btnVoiceCommand.TabIndex = 1;
            btnVoiceCommand.Text = "Open Voice Command Window";
            btnVoiceCommand.UseVisualStyleBackColor = true;
            btnVoiceCommand.Click += button1_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(149, 198);
            Controls.Add(btnVoiceCommand);
            Controls.Add(btnRecord);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
        }

        #endregion

        private Button btnRecord;
        private Button btnVoiceCommand;
    }
}