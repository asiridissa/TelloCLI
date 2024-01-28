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
            btnTelemetry = new Button();
            btnConnect = new Button();
            SuspendLayout();
            // 
            // console
            // 
            console.BackColor = Color.Black;
            console.DetectUrls = false;
            console.ForeColor = Color.Lime;
            console.Location = new Point(134, 2);
            console.Name = "console";
            console.ReadOnly = true;
            console.Size = new Size(666, 462);
            console.TabIndex = 0;
            console.TabStop = false;
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
            // btnTelemetry
            // 
            btnTelemetry.Location = new Point(26, 90);
            btnTelemetry.Name = "btnTelemetry";
            btnTelemetry.Size = new Size(75, 23);
            btnTelemetry.TabIndex = 4;
            btnTelemetry.Text = "Log Toggle";
            btnTelemetry.UseVisualStyleBackColor = true;
            btnTelemetry.Click += btnTelemetry_Click;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(26, 131);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(75, 23);
            btnConnect.TabIndex = 5;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // Voice
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(826, 623);
            Controls.Add(btnConnect);
            Controls.Add(btnTelemetry);
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
        private Button btnTelemetry;
        private Button btnConnect;
    }
}