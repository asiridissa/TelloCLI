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
            label1 = new Label();
            btnEmergency = new Button();
            btnStop = new Button();
            btnRecord = new Button();
            chkRecordStart = new CheckBox();
            btnIncorrect = new Button();
            btnCorrect = new Button();
            label6 = new Label();
            groupBox1 = new GroupBox();
            btnIncorrect5 = new Button();
            btnIncorrect4 = new Button();
            btnIncorrect3 = new Button();
            btnIncorrect2 = new Button();
            btnIncorrect1 = new Button();
            cmbAccuracyNote = new ComboBox();
            groupBox2 = new GroupBox();
            cmbCommand = new ComboBox();
            cmbCondition = new ComboBox();
            label7 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
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
            console.Size = new Size(586, 665);
            console.TabIndex = 0;
            console.TabStop = false;
            console.Text = "";
            // 
            // siLK
            // 
            siLK.Location = new Point(26, 73);
            siLK.Name = "siLK";
            siLK.Size = new Size(75, 23);
            siLK.TabIndex = 1;
            siLK.Text = "si-LK";
            siLK.UseVisualStyleBackColor = true;
            siLK.Visible = false;
            siLK.Click += siLK_Click;
            // 
            // enUS
            // 
            enUS.Location = new Point(12, 102);
            enUS.Name = "enUS";
            enUS.Size = new Size(102, 74);
            enUS.TabIndex = 2;
            enUS.Text = "Start Voice Recognittion";
            enUS.UseVisualStyleBackColor = true;
            enUS.Click += enUS_Click;
            // 
            // btnTelemetry
            // 
            btnTelemetry.Location = new Point(26, 182);
            btnTelemetry.Name = "btnTelemetry";
            btnTelemetry.Size = new Size(75, 23);
            btnTelemetry.TabIndex = 4;
            btnTelemetry.Text = "Log Toggle";
            btnTelemetry.UseVisualStyleBackColor = true;
            btnTelemetry.Visible = false;
            btnTelemetry.Click += btnTelemetry_Click;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(12, 20);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(102, 47);
            btnConnect.TabIndex = 5;
            btnConnect.Text = "Connect to Drone";
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
            txtPilot.Location = new Point(84, 22);
            txtPilot.Name = "txtPilot";
            txtPilot.Size = new Size(168, 23);
            txtPilot.TabIndex = 35;
            txtPilot.Text = "Test User 1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 27);
            label2.Name = "label2";
            label2.Size = new Size(30, 15);
            label2.TabIndex = 34;
            label2.Text = "User";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 54);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 32;
            label1.Text = "Command";
            // 
            // btnEmergency
            // 
            btnEmergency.BackColor = SystemColors.Info;
            btnEmergency.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnEmergency.ForeColor = Color.Red;
            btnEmergency.Location = new Point(739, 147);
            btnEmergency.Name = "btnEmergency";
            btnEmergency.Size = new Size(102, 520);
            btnEmergency.TabIndex = 38;
            btnEmergency.Text = "Emergency Shut off !!!";
            btnEmergency.UseVisualStyleBackColor = false;
            btnEmergency.Click += btnEmergency_Click;
            // 
            // btnStop
            // 
            btnStop.BackColor = Color.FromArgb(255, 192, 192);
            btnStop.Location = new Point(136, 158);
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
            btnRecord.Location = new Point(12, 159);
            btnRecord.Name = "btnRecord";
            btnRecord.Size = new Size(116, 94);
            btnRecord.TabIndex = 36;
            btnRecord.Text = "Record Start";
            btnRecord.UseVisualStyleBackColor = false;
            btnRecord.Click += btnRecord_Click;
            // 
            // chkRecordStart
            // 
            chkRecordStart.AutoSize = true;
            chkRecordStart.Location = new Point(15, 134);
            chkRecordStart.Name = "chkRecordStart";
            chkRecordStart.Size = new Size(218, 19);
            chkRecordStart.TabIndex = 39;
            chkRecordStart.TabStop = false;
            chkRecordStart.Text = "Recoirding starts with the command";
            chkRecordStart.UseVisualStyleBackColor = true;
            // 
            // btnIncorrect
            // 
            btnIncorrect.BackColor = Color.FromArgb(255, 192, 192);
            btnIncorrect.Location = new Point(16, 71);
            btnIncorrect.Name = "btnIncorrect";
            btnIncorrect.Size = new Size(113, 53);
            btnIncorrect.TabIndex = 40;
            btnIncorrect.Text = "Incorrect++";
            btnIncorrect.UseVisualStyleBackColor = false;
            btnIncorrect.Click += btnIncorrect_Click;
            // 
            // btnCorrect
            // 
            btnCorrect.BackColor = Color.FromArgb(192, 255, 192);
            btnCorrect.Location = new Point(137, 73);
            btnCorrect.Name = "btnCorrect";
            btnCorrect.Size = new Size(107, 51);
            btnCorrect.TabIndex = 41;
            btnCorrect.Text = "Correct++";
            btnCorrect.UseVisualStyleBackColor = false;
            btnCorrect.Click += btnCorrect_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(16, 24);
            label6.Name = "label6";
            label6.Size = new Size(67, 15);
            label6.TabIndex = 46;
            label6.Text = "Description";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnIncorrect5);
            groupBox1.Controls.Add(btnIncorrect4);
            groupBox1.Controls.Add(btnIncorrect3);
            groupBox1.Controls.Add(btnIncorrect2);
            groupBox1.Controls.Add(btnIncorrect1);
            groupBox1.Controls.Add(cmbAccuracyNote);
            groupBox1.Controls.Add(btnIncorrect);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(btnCorrect);
            groupBox1.Location = new Point(862, 20);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(262, 343);
            groupBox1.TabIndex = 47;
            groupBox1.TabStop = false;
            groupBox1.Text = "Accuracy";
            // 
            // btnIncorrect5
            // 
            btnIncorrect5.BackColor = Color.FromArgb(255, 192, 192);
            btnIncorrect5.Location = new Point(6, 297);
            btnIncorrect5.Name = "btnIncorrect5";
            btnIncorrect5.Size = new Size(250, 37);
            btnIncorrect5.TabIndex = 53;
            btnIncorrect5.Text = "Drone behaviour mismatch the command";
            btnIncorrect5.UseVisualStyleBackColor = false;
            btnIncorrect5.Click += btnIncorrectQuick_Click;
            // 
            // btnIncorrect4
            // 
            btnIncorrect4.BackColor = Color.FromArgb(255, 192, 192);
            btnIncorrect4.Location = new Point(6, 257);
            btnIncorrect4.Name = "btnIncorrect4";
            btnIncorrect4.Size = new Size(250, 37);
            btnIncorrect4.TabIndex = 51;
            btnIncorrect4.Text = "Speech to text invalid result";
            btnIncorrect4.UseVisualStyleBackColor = false;
            btnIncorrect4.Click += btnIncorrectQuick_Click;
            // 
            // btnIncorrect3
            // 
            btnIncorrect3.BackColor = Color.FromArgb(255, 192, 192);
            btnIncorrect3.Location = new Point(6, 216);
            btnIncorrect3.Name = "btnIncorrect3";
            btnIncorrect3.Size = new Size(250, 37);
            btnIncorrect3.TabIndex = 50;
            btnIncorrect3.Text = "Speech to text previous voice input partially used";
            btnIncorrect3.UseCompatibleTextRendering = true;
            btnIncorrect3.UseVisualStyleBackColor = false;
            btnIncorrect3.Click += btnIncorrectQuick_Click;
            // 
            // btnIncorrect2
            // 
            btnIncorrect2.BackColor = Color.FromArgb(255, 192, 192);
            btnIncorrect2.Location = new Point(6, 175);
            btnIncorrect2.Name = "btnIncorrect2";
            btnIncorrect2.Size = new Size(250, 37);
            btnIncorrect2.TabIndex = 49;
            btnIncorrect2.Text = "Speech to text partial  result";
            btnIncorrect2.UseVisualStyleBackColor = false;
            btnIncorrect2.Click += btnIncorrectQuick_Click;
            // 
            // btnIncorrect1
            // 
            btnIncorrect1.BackColor = Color.FromArgb(255, 192, 192);
            btnIncorrect1.Location = new Point(6, 133);
            btnIncorrect1.Name = "btnIncorrect1";
            btnIncorrect1.Size = new Size(250, 37);
            btnIncorrect1.TabIndex = 48;
            btnIncorrect1.Text = "Speech to text no result";
            btnIncorrect1.UseVisualStyleBackColor = false;
            btnIncorrect1.Click += btnIncorrectQuick_Click;
            // 
            // cmbAccuracyNote
            // 
            cmbAccuracyNote.FormattingEnabled = true;
            cmbAccuracyNote.Items.AddRange(new object[] { "Speech to text no result", "Speech to text partial  result", "Speech to text previous voice input partially used", "Speech to text invalid result", "Drone behaviour mismatch the command" });
            cmbAccuracyNote.Location = new Point(15, 45);
            cmbAccuracyNote.Name = "cmbAccuracyNote";
            cmbAccuracyNote.Size = new Size(229, 23);
            cmbAccuracyNote.TabIndex = 47;
            cmbAccuracyNote.Tag = "invalid";
            cmbAccuracyNote.Text = "Speech to text invalid result";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cmbCommand);
            groupBox2.Controls.Add(cmbCondition);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(txtPilot);
            groupBox2.Controls.Add(btnRecord);
            groupBox2.Controls.Add(btnStop);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(chkRecordStart);
            groupBox2.Controls.Add(label2);
            groupBox2.Location = new Point(862, 398);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(262, 269);
            groupBox2.TabIndex = 48;
            groupBox2.TabStop = false;
            groupBox2.Text = "Log Recording";
            // 
            // cmbCommand
            // 
            cmbCommand.FormattingEnabled = true;
            cmbCommand.Items.AddRange(new object[] { "GO UP ", "GO UP Little", "GO UP Lot", "GO Down ", "GO Down Little", "GO Down Lot", "GO Left ", "GO Left Little", "GO Left Lot", "GO Right ", "GO Right Little", "GO Right Lot", "GO Forward ", "GO Forward Little", "GO Forward Lot", "GO Back ", "GO Back Little", "GO Back Lot", "Turn Left ", "Turn Left Little", "Turn Left Lot", "Turn Right ", "Turn Right Little", "Turn Right Lot", "Hover  ", "Emergency  ", "Takeoff  ", "Land  ", "Connect " });
            cmbCommand.Location = new Point(84, 51);
            cmbCommand.Name = "cmbCommand";
            cmbCommand.Size = new Size(168, 23);
            cmbCommand.TabIndex = 49;
            cmbCommand.Text = "Connect ";
            // 
            // cmbCondition
            // 
            cmbCondition.FormattingEnabled = true;
            cmbCondition.Items.AddRange(new object[] { "Normal", "Noisy", "Low Light", "Windy" });
            cmbCondition.Location = new Point(15, 105);
            cmbCondition.Name = "cmbCondition";
            cmbCondition.Size = new Size(237, 23);
            cmbCondition.TabIndex = 49;
            cmbCondition.Text = "Normal";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(15, 87);
            label7.Name = "label7";
            label7.Size = new Size(103, 15);
            label7.TabIndex = 41;
            label7.Text = "Control Condition";
            // 
            // Voice
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1144, 679);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnEmergency);
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
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
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
        private Label label1;
        private Button btnEmergency;
        private Button btnStop;
        private Button btnRecord;
        private CheckBox chkRecordStart;
        private Button btnIncorrect;
        private Button btnCorrect;
        private Label label6;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label7;
        private ComboBox cmbCondition;
        private ComboBox cmbCommand;
        private ComboBox cmbAccuracyNote;
        private Button btnIncorrect1;
        private Button btnIncorrect5;
        private Button btnIncorrect4;
        private Button btnIncorrect3;
        private Button btnIncorrect2;
    }
}