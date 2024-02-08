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
            lblTime = new Label();
            lblH = new Label();
            lblBattery = new Label();
            lblTemp = new Label();
            txtPilot = new TextBox();
            label2 = new Label();
            txtCommand = new TextBox();
            label1 = new Label();
            btnEmergency = new Button();
            btnStop = new Button();
            btnRecord = new Button();
            chkRecordStart = new CheckBox();
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
            console.Size = new Size(586, 462);
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
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.ForeColor = Color.DodgerBlue;
            lblTime.Location = new Point(786, 109);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(11, 15);
            lblTime.TabIndex = 31;
            lblTime.Text = "t";
            // 
            // lblH
            // 
            lblH.AutoSize = true;
            lblH.ForeColor = Color.DodgerBlue;
            lblH.Location = new Point(786, 73);
            lblH.Name = "lblH";
            lblH.Size = new Size(14, 15);
            lblH.TabIndex = 30;
            lblH.Text = "h";
            // 
            // lblBattery
            // 
            lblBattery.AutoSize = true;
            lblBattery.ForeColor = Color.Red;
            lblBattery.Location = new Point(784, 41);
            lblBattery.Name = "lblBattery";
            lblBattery.Size = new Size(17, 15);
            lblBattery.TabIndex = 29;
            lblBattery.Text = "%";
            // 
            // lblTemp
            // 
            lblTemp.AutoSize = true;
            lblTemp.ForeColor = Color.Red;
            lblTemp.Location = new Point(784, 12);
            lblTemp.Name = "lblTemp";
            lblTemp.Size = new Size(19, 15);
            lblTemp.TabIndex = 28;
            lblTemp.Text = "℃";
            // 
            // txtPilot
            // 
            txtPilot.Location = new Point(81, 489);
            txtPilot.Name = "txtPilot";
            txtPilot.Size = new Size(141, 23);
            txtPilot.TabIndex = 35;
            txtPilot.Text = "Test User 1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 494);
            label2.Name = "label2";
            label2.Size = new Size(30, 15);
            label2.TabIndex = 34;
            label2.Text = "User";
            // 
            // txtCommand
            // 
            txtCommand.Location = new Point(81, 518);
            txtCommand.Name = "txtCommand";
            txtCommand.Size = new Size(141, 23);
            txtCommand.TabIndex = 33;
            txtCommand.Text = "Left";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 521);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 32;
            label1.Text = "Command";
            // 
            // btnEmergency
            // 
            btnEmergency.BackColor = SystemColors.Info;
            btnEmergency.ForeColor = Color.Red;
            btnEmergency.Location = new Point(739, 147);
            btnEmergency.Name = "btnEmergency";
            btnEmergency.Size = new Size(75, 317);
            btnEmergency.TabIndex = 38;
            btnEmergency.Text = "Emergency Shut off !!!";
            btnEmergency.UseVisualStyleBackColor = false;
            btnEmergency.Click += btnEmergency_Click;
            // 
            // btnStop
            // 
            btnStop.BackColor = Color.FromArgb(255, 192, 192);
            btnStop.Location = new Point(604, 470);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(116, 95);
            btnStop.TabIndex = 37;
            btnStop.Text = "Stop Recording";
            btnStop.UseVisualStyleBackColor = false;
            btnStop.Click += btnStop_Click;
            // 
            // btnRecord
            // 
            btnRecord.BackColor = Color.FromArgb(192, 255, 192);
            btnRecord.Location = new Point(482, 476);
            btnRecord.Name = "btnRecord";
            btnRecord.Size = new Size(116, 51);
            btnRecord.TabIndex = 36;
            btnRecord.Text = "Record Start";
            btnRecord.UseVisualStyleBackColor = false;
            btnRecord.Click += btnRecord_Click;
            // 
            // chkRecordStart
            // 
            chkRecordStart.AutoSize = true;
            chkRecordStart.Location = new Point(248, 489);
            chkRecordStart.Name = "chkRecordStart";
            chkRecordStart.Size = new Size(218, 19);
            chkRecordStart.TabIndex = 39;
            chkRecordStart.TabStop = false;
            chkRecordStart.Text = "Recoirding starts with the command";
            chkRecordStart.UseVisualStyleBackColor = true;
            // 
            // Voice
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(826, 623);
            Controls.Add(chkRecordStart);
            Controls.Add(btnEmergency);
            Controls.Add(btnStop);
            Controls.Add(btnRecord);
            Controls.Add(txtPilot);
            Controls.Add(label2);
            Controls.Add(txtCommand);
            Controls.Add(label1);
            Controls.Add(lblTime);
            Controls.Add(lblH);
            Controls.Add(lblBattery);
            Controls.Add(lblTemp);
            Controls.Add(btnConnect);
            Controls.Add(btnTelemetry);
            Controls.Add(enUS);
            Controls.Add(siLK);
            Controls.Add(console);
            Name = "Voice";
            Text = "Voice";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox console;
        private Button siLK;
        private Button enUS;
        private Button btnTelemetry;
        private Button btnConnect;
        private Label lblTime;
        private Label lblH;
        private Label lblBattery;
        private Label lblTemp;
        private TextBox txtPilot;
        private Label label2;
        private TextBox txtCommand;
        private Label label1;
        private Button btnEmergency;
        private Button btnStop;
        private Button btnRecord;
        private CheckBox chkRecordStart;
    }
}