namespace TelloControl
{
    partial class Record
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
            label1 = new Label();
            txtCommand = new TextBox();
            label2 = new Label();
            txtPilot = new TextBox();
            btnTakeOff = new Button();
            btnRecord = new Button();
            btnStop = new Button();
            txtLog = new TextBox();
            btnLand = new Button();
            btnConnect = new Button();
            btnLeft = new Button();
            btnRight = new Button();
            btnForward = new Button();
            btnBackward = new Button();
            btnDown = new Button();
            btnUp = new Button();
            btnCCW = new Button();
            btnCW = new Button();
            txtSpeed = new MaskedTextBox();
            label3 = new Label();
            txtDistanceAngle = new MaskedTextBox();
            label4 = new Label();
            lblTemp = new Label();
            lblBattery = new Label();
            btnEmergency = new Button();
            chkRecordStart = new CheckBox();
            lblH = new Label();
            lblTime = new Label();
            chkUseRC = new CheckBox();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            btnHover = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(106, 49);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 0;
            label1.Text = "Command";
            // 
            // txtCommand
            // 
            txtCommand.Location = new Point(176, 46);
            txtCommand.Name = "txtCommand";
            txtCommand.Size = new Size(141, 23);
            txtCommand.TabIndex = 1;
            txtCommand.Text = "Left";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(106, 22);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 2;
            label2.Text = "Pilot";
            // 
            // txtPilot
            // 
            txtPilot.Location = new Point(176, 17);
            txtPilot.Name = "txtPilot";
            txtPilot.Size = new Size(141, 23);
            txtPilot.TabIndex = 3;
            txtPilot.Text = "Pilot Test";
            // 
            // btnTakeOff
            // 
            btnTakeOff.Location = new Point(455, 18);
            btnTakeOff.Name = "btnTakeOff";
            btnTakeOff.Size = new Size(75, 51);
            btnTakeOff.TabIndex = 4;
            btnTakeOff.Text = "Take Off";
            btnTakeOff.UseVisualStyleBackColor = true;
            btnTakeOff.Click += btnTakeOff_Click;
            // 
            // btnRecord
            // 
            btnRecord.BackColor = Color.FromArgb(192, 255, 192);
            btnRecord.Location = new Point(355, 83);
            btnRecord.Name = "btnRecord";
            btnRecord.Size = new Size(116, 95);
            btnRecord.TabIndex = 5;
            btnRecord.Text = "Record Start";
            btnRecord.UseVisualStyleBackColor = false;
            btnRecord.Click += btnRecord_Click;
            // 
            // btnStop
            // 
            btnStop.BackColor = Color.FromArgb(255, 192, 192);
            btnStop.Location = new Point(511, 83);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(116, 95);
            btnStop.TabIndex = 6;
            btnStop.Text = "Stop Recording";
            btnStop.UseVisualStyleBackColor = false;
            btnStop.Click += btnStop_Click;
            // 
            // txtLog
            // 
            txtLog.Location = new Point(73, 489);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.Size = new Size(579, 302);
            txtLog.TabIndex = 7;
            // 
            // btnLand
            // 
            btnLand.Location = new Point(552, 18);
            btnLand.Name = "btnLand";
            btnLand.Size = new Size(75, 51);
            btnLand.TabIndex = 8;
            btnLand.Text = "Land";
            btnLand.UseVisualStyleBackColor = true;
            btnLand.Click += btnLand_Click;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(355, 18);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(75, 51);
            btnConnect.TabIndex = 9;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnLeft
            // 
            btnLeft.Location = new Point(9, 115);
            btnLeft.Name = "btnLeft";
            btnLeft.Size = new Size(64, 51);
            btnLeft.TabIndex = 10;
            btnLeft.Text = "Left";
            btnLeft.UseVisualStyleBackColor = true;
            btnLeft.Click += btnLeft_Click;
            // 
            // btnRight
            // 
            btnRight.Location = new Point(144, 115);
            btnRight.Name = "btnRight";
            btnRight.Size = new Size(64, 51);
            btnRight.TabIndex = 11;
            btnRight.Text = "Right";
            btnRight.UseVisualStyleBackColor = true;
            btnRight.Click += btnRight_Click;
            // 
            // btnForward
            // 
            btnForward.Location = new Point(79, 47);
            btnForward.Name = "btnForward";
            btnForward.Size = new Size(64, 51);
            btnForward.TabIndex = 12;
            btnForward.Text = "Forward";
            btnForward.UseVisualStyleBackColor = true;
            btnForward.Click += btnForward_Click;
            // 
            // btnBackward
            // 
            btnBackward.Location = new Point(72, 184);
            btnBackward.Name = "btnBackward";
            btnBackward.Size = new Size(71, 51);
            btnBackward.TabIndex = 13;
            btnBackward.Text = "Backward";
            btnBackward.UseVisualStyleBackColor = true;
            btnBackward.Click += btnBackward_Click;
            // 
            // btnDown
            // 
            btnDown.Location = new Point(439, 184);
            btnDown.Name = "btnDown";
            btnDown.Size = new Size(64, 51);
            btnDown.TabIndex = 15;
            btnDown.Text = "Down";
            btnDown.UseVisualStyleBackColor = true;
            btnDown.Click += btnDown_Click;
            // 
            // btnUp
            // 
            btnUp.Location = new Point(439, 47);
            btnUp.Name = "btnUp";
            btnUp.Size = new Size(64, 51);
            btnUp.TabIndex = 14;
            btnUp.Text = "Up";
            btnUp.UseVisualStyleBackColor = true;
            btnUp.Click += btnUp_Click;
            // 
            // btnCCW
            // 
            btnCCW.Location = new Point(504, 115);
            btnCCW.Name = "btnCCW";
            btnCCW.Size = new Size(64, 51);
            btnCCW.TabIndex = 17;
            btnCCW.Text = "CCW";
            btnCCW.UseVisualStyleBackColor = true;
            btnCCW.Click += btnCCW_Click;
            // 
            // btnCW
            // 
            btnCW.Location = new Point(369, 115);
            btnCW.Name = "btnCW";
            btnCW.Size = new Size(64, 51);
            btnCW.TabIndex = 16;
            btnCW.Text = "CW";
            btnCW.UseVisualStyleBackColor = true;
            btnCW.Click += btnCW_Click;
            // 
            // txtSpeed
            // 
            txtSpeed.Location = new Point(280, 104);
            txtSpeed.Mask = "000";
            txtSpeed.Name = "txtSpeed";
            txtSpeed.PromptChar = ' ';
            txtSpeed.Size = new Size(37, 23);
            txtSpeed.TabIndex = 18;
            txtSpeed.Text = "25";
            txtSpeed.ValidatingType = typeof(int);
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(234, 107);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 19;
            label3.Text = "Speed";
            // 
            // txtDistanceAngle
            // 
            txtDistanceAngle.Location = new Point(280, 75);
            txtDistanceAngle.Mask = "000";
            txtDistanceAngle.Name = "txtDistanceAngle";
            txtDistanceAngle.PromptChar = ' ';
            txtDistanceAngle.Size = new Size(37, 23);
            txtDistanceAngle.TabIndex = 20;
            txtDistanceAngle.Text = "15";
            txtDistanceAngle.ValidatingType = typeof(int);
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(121, 78);
            label4.Name = "label4";
            label4.Size = new Size(153, 15);
            label4.TabIndex = 21;
            label4.Text = "Distance cm / Angle degree";
            // 
            // lblTemp
            // 
            lblTemp.AutoSize = true;
            lblTemp.ForeColor = Color.Red;
            lblTemp.Location = new Point(6, 29);
            lblTemp.Name = "lblTemp";
            lblTemp.Size = new Size(19, 15);
            lblTemp.TabIndex = 22;
            lblTemp.Text = "℃";
            // 
            // lblBattery
            // 
            lblBattery.AutoSize = true;
            lblBattery.ForeColor = Color.Red;
            lblBattery.Location = new Point(6, 58);
            lblBattery.Name = "lblBattery";
            lblBattery.Size = new Size(17, 15);
            lblBattery.TabIndex = 23;
            lblBattery.Text = "%";
            // 
            // btnEmergency
            // 
            btnEmergency.BackColor = SystemColors.Info;
            btnEmergency.ForeColor = Color.Red;
            btnEmergency.Location = new Point(678, 192);
            btnEmergency.Name = "btnEmergency";
            btnEmergency.Size = new Size(75, 599);
            btnEmergency.TabIndex = 24;
            btnEmergency.Text = "Emergency Shut off !!!";
            btnEmergency.UseVisualStyleBackColor = false;
            btnEmergency.Click += btnEmergency_Click;
            // 
            // chkRecordStart
            // 
            chkRecordStart.AutoSize = true;
            chkRecordStart.Location = new Point(9, 22);
            chkRecordStart.Name = "chkRecordStart";
            chkRecordStart.Size = new Size(218, 19);
            chkRecordStart.TabIndex = 25;
            chkRecordStart.TabStop = false;
            chkRecordStart.Text = "Recoirding starts with the command";
            chkRecordStart.UseVisualStyleBackColor = true;
            // 
            // lblH
            // 
            lblH.AutoSize = true;
            lblH.ForeColor = Color.DodgerBlue;
            lblH.Location = new Point(8, 90);
            lblH.Name = "lblH";
            lblH.Size = new Size(14, 15);
            lblH.TabIndex = 26;
            lblH.Text = "h";
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.ForeColor = Color.DodgerBlue;
            lblTime.Location = new Point(8, 126);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(11, 15);
            lblTime.TabIndex = 27;
            lblTime.Text = "t";
            // 
            // chkUseRC
            // 
            chkUseRC.AutoSize = true;
            chkUseRC.Location = new Point(446, 22);
            chkUseRC.Name = "chkUseRC";
            chkUseRC.Size = new Size(127, 19);
            chkUseRC.TabIndex = 28;
            chkUseRC.TabStop = false;
            chkUseRC.Text = "Use 'rc' commands";
            chkUseRC.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblTime);
            groupBox1.Controls.Add(lblTemp);
            groupBox1.Controls.Add(lblBattery);
            groupBox1.Controls.Add(lblH);
            groupBox1.Location = new Point(656, 17);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(97, 160);
            groupBox1.TabIndex = 29;
            groupBox1.TabStop = false;
            groupBox1.Text = "Info";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnHover);
            groupBox2.Controls.Add(btnForward);
            groupBox2.Controls.Add(btnLeft);
            groupBox2.Controls.Add(chkUseRC);
            groupBox2.Controls.Add(chkRecordStart);
            groupBox2.Controls.Add(btnRight);
            groupBox2.Controls.Add(btnBackward);
            groupBox2.Controls.Add(btnUp);
            groupBox2.Controls.Add(btnDown);
            groupBox2.Controls.Add(btnCW);
            groupBox2.Controls.Add(btnCCW);
            groupBox2.Location = new Point(75, 184);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(577, 273);
            groupBox2.TabIndex = 30;
            groupBox2.TabStop = false;
            groupBox2.Text = "Controls";
            // 
            // btnHover
            // 
            btnHover.Location = new Point(260, 47);
            btnHover.Name = "btnHover";
            btnHover.Size = new Size(64, 51);
            btnHover.TabIndex = 26;
            btnHover.Text = "Hover";
            btnHover.UseVisualStyleBackColor = true;
            btnHover.Click += btnHover_Click;
            // 
            // Record
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(824, 805);
            Controls.Add(groupBox2);
            Controls.Add(btnStop);
            Controls.Add(groupBox1);
            Controls.Add(btnEmergency);
            Controls.Add(label4);
            Controls.Add(txtDistanceAngle);
            Controls.Add(label3);
            Controls.Add(txtSpeed);
            Controls.Add(btnConnect);
            Controls.Add(btnLand);
            Controls.Add(txtLog);
            Controls.Add(btnRecord);
            Controls.Add(btnTakeOff);
            Controls.Add(txtPilot);
            Controls.Add(label2);
            Controls.Add(txtCommand);
            Controls.Add(label1);
            Name = "Record";
            Text = "Record";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtCommand;
        private Label label2;
        private TextBox txtPilot;
        private Button btnTakeOff;
        private Button btnRecord;
        private Button btnStop;
        private TextBox txtLog;
        private Button btnLand;
        private Button btnConnect;
        private Button btnLeft;
        private Button btnRight;
        private Button btnForward;
        private Button btnBackward;
        private Button btnDown;
        private Button btnUp;
        private Button btnCCW;
        private Button btnCW;
        private MaskedTextBox txtSpeed;
        private Label label3;
        private MaskedTextBox txtDistanceAngle;
        private Label label4;
        private Label lblTemp;
        private Label lblBattery;
        private Button btnEmergency;
        private CheckBox chkRecordStart;
        private Label lblH;
        private Label lblTime;
        private CheckBox chkUseRC;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button btnHover;
    }
}