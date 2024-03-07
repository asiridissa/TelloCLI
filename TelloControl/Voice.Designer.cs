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
            btnIncorrect = new Button();
            btnCorrect = new Button();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtIncorrect = new TextBox();
            label6 = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            label7 = new Label();
            textBox2 = new TextBox();
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
            console.Size = new Size(586, 478);
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
            txtPilot.Size = new Size(159, 23);
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
            // txtCommand
            // 
            txtCommand.Location = new Point(84, 51);
            txtCommand.Name = "txtCommand";
            txtCommand.Size = new Size(159, 23);
            txtCommand.TabIndex = 33;
            txtCommand.Text = "Left";
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
            btnEmergency.ForeColor = Color.Red;
            btnEmergency.Location = new Point(739, 147);
            btnEmergency.Name = "btnEmergency";
            btnEmergency.Size = new Size(75, 333);
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
            btnIncorrect.Location = new Point(15, 115);
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
            btnCorrect.Location = new Point(136, 117);
            btnCorrect.Name = "btnCorrect";
            btnCorrect.Size = new Size(107, 51);
            btnCorrect.TabIndex = 41;
            btnCorrect.Text = "Correct++";
            btnCorrect.UseVisualStyleBackColor = false;
            btnCorrect.Click += btnCorrect_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 38);
            label3.Name = "label3";
            label3.Size = new Size(100, 15);
            label3.TabIndex = 42;
            label3.Text = "Accuracy counter";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Green;
            label4.Location = new Point(121, 38);
            label4.Name = "label4";
            label4.Size = new Size(52, 15);
            label4.TabIndex = 43;
            label4.Text = "Correct: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.Red;
            label5.Location = new Point(121, 58);
            label5.Name = "label5";
            label5.Size = new Size(60, 15);
            label5.TabIndex = 44;
            label5.Text = "Incorrect: ";
            // 
            // txtIncorrect
            // 
            txtIncorrect.Location = new Point(15, 86);
            txtIncorrect.Name = "txtIncorrect";
            txtIncorrect.Size = new Size(228, 23);
            txtIncorrect.TabIndex = 45;
            txtIncorrect.TextChanged += txtIncorrect_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 68);
            label6.Name = "label6";
            label6.Size = new Size(67, 15);
            label6.TabIndex = 46;
            label6.Text = "Description";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnIncorrect);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(btnCorrect);
            groupBox1.Controls.Add(txtIncorrect);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Location = new Point(862, 20);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(262, 185);
            groupBox1.TabIndex = 47;
            groupBox1.TabStop = false;
            groupBox1.Text = "Accuracy";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBox2);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(txtPilot);
            groupBox2.Controls.Add(btnRecord);
            groupBox2.Controls.Add(btnStop);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(chkRecordStart);
            groupBox2.Controls.Add(txtCommand);
            groupBox2.Controls.Add(label2);
            groupBox2.Location = new Point(862, 211);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(262, 269);
            groupBox2.TabIndex = 48;
            groupBox2.TabStop = false;
            groupBox2.Text = "Log Recording";
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
            // textBox2
            // 
            textBox2.Location = new Point(15, 105);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(228, 23);
            textBox2.TabIndex = 42;
            textBox2.Text = "Normal";
            // 
            // Voice
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1144, 497);
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
            Load += Voice_Load;
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
        private TextBox txtCommand;
        private Label label1;
        private Button btnEmergency;
        private Button btnStop;
        private Button btnRecord;
        private CheckBox chkRecordStart;
        private Button btnIncorrect;
        private Button btnCorrect;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtIncorrect;
        private Label label6;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private TextBox textBox2;
        private Label label7;
    }
}