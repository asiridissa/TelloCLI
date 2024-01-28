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
            txtCommand.Size = new Size(500, 23);
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
            txtPilot.Size = new Size(500, 23);
            txtPilot.TabIndex = 3;
            txtPilot.Text = "Pilot Test";
            // 
            // btnTakeOff
            // 
            btnTakeOff.Location = new Point(216, 84);
            btnTakeOff.Name = "btnTakeOff";
            btnTakeOff.Size = new Size(75, 51);
            btnTakeOff.TabIndex = 4;
            btnTakeOff.Text = "Take Off";
            btnTakeOff.UseVisualStyleBackColor = true;
            btnTakeOff.Click += btnTakeOff_Click;
            // 
            // btnRecord
            // 
            btnRecord.Location = new Point(309, 84);
            btnRecord.Name = "btnRecord";
            btnRecord.Size = new Size(116, 51);
            btnRecord.TabIndex = 5;
            btnRecord.Text = "Record";
            btnRecord.UseVisualStyleBackColor = true;
            btnRecord.Click += btnRecord_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(454, 84);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(116, 51);
            btnStop.TabIndex = 6;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // txtLog
            // 
            txtLog.Location = new Point(106, 151);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.Size = new Size(570, 216);
            txtLog.TabIndex = 7;
            // 
            // btnLand
            // 
            btnLand.Location = new Point(601, 84);
            btnLand.Name = "btnLand";
            btnLand.Size = new Size(75, 51);
            btnLand.TabIndex = 8;
            btnLand.Text = "Land";
            btnLand.UseVisualStyleBackColor = true;
            btnLand.Click += btnLand_Click;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(106, 84);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(75, 51);
            btnConnect.TabIndex = 9;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // Record
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnConnect);
            Controls.Add(btnLand);
            Controls.Add(txtLog);
            Controls.Add(btnStop);
            Controls.Add(btnRecord);
            Controls.Add(btnTakeOff);
            Controls.Add(txtPilot);
            Controls.Add(label2);
            Controls.Add(txtCommand);
            Controls.Add(label1);
            Name = "Record";
            Text = "Record";
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
    }
}