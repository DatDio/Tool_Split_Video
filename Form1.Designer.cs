namespace Tool_Render_Video
{
	partial class Form1
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.btnInput = new System.Windows.Forms.Button();
			this.btnOutput = new System.Windows.Forms.Button();
			this.btnStart = new System.Windows.Forms.Button();
			this.btnStop = new System.Windows.Forms.Button();
			this.cbbScript = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.label7 = new System.Windows.Forms.Label();
			this.lblthreadRunning = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtNumberThread = new System.Windows.Forms.NumericUpDown();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.label4 = new System.Windows.Forms.Label();
			this.lblTimeRunning = new System.Windows.Forms.Label();
			this.rtbAddLogs = new System.Windows.Forms.RichTextBox();
			this.lblFail = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.lblSuccess = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.txtTimeVideoSplited = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtNumberThread)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtTimeVideoSplited)).BeginInit();
			this.SuspendLayout();
			// 
			// btnInput
			// 
			this.btnInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnInput.Image = ((System.Drawing.Image)(resources.GetObject("btnInput.Image")));
			this.btnInput.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnInput.Location = new System.Drawing.Point(398, 44);
			this.btnInput.Name = "btnInput";
			this.btnInput.Size = new System.Drawing.Size(131, 47);
			this.btnInput.TabIndex = 0;
			this.btnInput.Text = "Input";
			this.btnInput.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnInput.UseVisualStyleBackColor = true;
			this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
			// 
			// btnOutput
			// 
			this.btnOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnOutput.Image = ((System.Drawing.Image)(resources.GetObject("btnOutput.Image")));
			this.btnOutput.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnOutput.Location = new System.Drawing.Point(398, 121);
			this.btnOutput.Name = "btnOutput";
			this.btnOutput.Size = new System.Drawing.Size(131, 47);
			this.btnOutput.TabIndex = 1;
			this.btnOutput.Text = "Output";
			this.btnOutput.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnOutput.UseVisualStyleBackColor = true;
			this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
			// 
			// btnStart
			// 
			this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnStart.Image = ((System.Drawing.Image)(resources.GetObject("btnStart.Image")));
			this.btnStart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnStart.Location = new System.Drawing.Point(398, 203);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(131, 47);
			this.btnStart.TabIndex = 2;
			this.btnStart.Text = "Start";
			this.btnStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// btnStop
			// 
			this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnStop.Image = ((System.Drawing.Image)(resources.GetObject("btnStop.Image")));
			this.btnStop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnStop.Location = new System.Drawing.Point(398, 283);
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new System.Drawing.Size(131, 47);
			this.btnStop.TabIndex = 3;
			this.btnStop.Text = "Stop";
			this.btnStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnStop.UseVisualStyleBackColor = true;
			this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
			// 
			// cbbScript
			// 
			this.cbbScript.FormattingEnabled = true;
			this.cbbScript.Items.AddRange(new object[] {
            "Render Anime Có Mockup",
            "Render Video Lồng Lên Video Sóng Funny",
            "Render Video Lồng Lên Video Sóng Pet"});
			this.cbbScript.Location = new System.Drawing.Point(39, 12);
			this.cbbScript.Name = "cbbScript";
			this.cbbScript.Size = new System.Drawing.Size(270, 21);
			this.cbbScript.TabIndex = 4;
			this.cbbScript.Visible = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(36, 60);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(0, 13);
			this.label1.TabIndex = 5;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(95, 61);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(0, 13);
			this.label2.TabIndex = 6;
			// 
			// panel3
			// 
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel3.Controls.Add(this.label7);
			this.panel3.Controls.Add(this.lblthreadRunning);
			this.panel3.Controls.Add(this.label3);
			this.panel3.Controls.Add(this.txtNumberThread);
			this.panel3.Location = new System.Drawing.Point(25, 105);
			this.panel3.Margin = new System.Windows.Forms.Padding(2);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(270, 49);
			this.panel3.TabIndex = 8;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(121, 18);
			this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(12, 13);
			this.label7.TabIndex = 5;
			this.label7.Text = "/";
			// 
			// lblthreadRunning
			// 
			this.lblthreadRunning.AutoSize = true;
			this.lblthreadRunning.Location = new System.Drawing.Point(96, 18);
			this.lblthreadRunning.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblthreadRunning.Name = "lblthreadRunning";
			this.lblthreadRunning.Size = new System.Drawing.Size(13, 13);
			this.lblthreadRunning.TabIndex = 4;
			this.lblthreadRunning.Text = "0";
			// 
			// label3
			// 
			this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
			this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label3.Location = new System.Drawing.Point(2, 7);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(129, 32);
			this.label3.TabIndex = 3;
			this.label3.Text = "Số Luồng :";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtNumberThread
			// 
			this.txtNumberThread.Location = new System.Drawing.Point(140, 14);
			this.txtNumberThread.Margin = new System.Windows.Forms.Padding(2);
			this.txtNumberThread.Name = "txtNumberThread";
			this.txtNumberThread.Size = new System.Drawing.Size(66, 20);
			this.txtNumberThread.TabIndex = 2;
			// 
			// timer1
			// 
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.ForeColor = System.Drawing.Color.DarkRed;
			this.label4.Location = new System.Drawing.Point(110, 365);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(49, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "Thất bại:";
			// 
			// lblTimeRunning
			// 
			this.lblTimeRunning.AutoSize = true;
			this.lblTimeRunning.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.lblTimeRunning.Location = new System.Drawing.Point(277, 365);
			this.lblTimeRunning.Name = "lblTimeRunning";
			this.lblTimeRunning.Size = new System.Drawing.Size(13, 13);
			this.lblTimeRunning.TabIndex = 10;
			this.lblTimeRunning.Text = "0";
			// 
			// rtbAddLogs
			// 
			this.rtbAddLogs.Location = new System.Drawing.Point(25, 188);
			this.rtbAddLogs.Name = "rtbAddLogs";
			this.rtbAddLogs.Size = new System.Drawing.Size(270, 142);
			this.rtbAddLogs.TabIndex = 11;
			this.rtbAddLogs.Text = "";
			// 
			// lblFail
			// 
			this.lblFail.AutoSize = true;
			this.lblFail.ForeColor = System.Drawing.Color.DarkRed;
			this.lblFail.Location = new System.Drawing.Point(160, 366);
			this.lblFail.Name = "lblFail";
			this.lblFail.Size = new System.Drawing.Size(13, 13);
			this.lblFail.TabIndex = 13;
			this.lblFail.Text = "0";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(196, 365);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(80, 13);
			this.label6.TabIndex = 12;
			this.label6.Text = "Thời gian chạy:";
			// 
			// lblSuccess
			// 
			this.lblSuccess.AutoSize = true;
			this.lblSuccess.ForeColor = System.Drawing.Color.Green;
			this.lblSuccess.Location = new System.Drawing.Point(89, 365);
			this.lblSuccess.Name = "lblSuccess";
			this.lblSuccess.Size = new System.Drawing.Size(13, 13);
			this.lblSuccess.TabIndex = 15;
			this.lblSuccess.Text = "0";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.ForeColor = System.Drawing.Color.Green;
			this.label9.Location = new System.Drawing.Point(22, 364);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(68, 13);
			this.label9.TabIndex = 14;
			this.label9.Text = "Thành công:";
			// 
			// txtTimeVideoSplited
			// 
			this.txtTimeVideoSplited.Location = new System.Drawing.Point(150, 53);
			this.txtTimeVideoSplited.Name = "txtTimeVideoSplited";
			this.txtTimeVideoSplited.Size = new System.Drawing.Size(87, 20);
			this.txtTimeVideoSplited.TabIndex = 16;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(28, 55);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(110, 13);
			this.label5.TabIndex = 17;
			this.label5.Text = "Thời Gian Chia Video:";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(240, 56);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(12, 13);
			this.label8.TabIndex = 18;
			this.label8.Text = "s";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Gainsboro;
			this.ClientSize = new System.Drawing.Size(564, 409);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtTimeVideoSplited);
			this.Controls.Add(this.lblSuccess);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.lblFail);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.rtbAddLogs);
			this.Controls.Add(this.lblTimeRunning);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cbbScript);
			this.Controls.Add(this.btnStop);
			this.Controls.Add(this.btnStart);
			this.Controls.Add(this.btnOutput);
			this.Controls.Add(this.btnInput);
			this.Name = "Form1";
			this.Text = "Tool Split Video By Dio";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtNumberThread)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtTimeVideoSplited)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnInput;
		private System.Windows.Forms.Button btnOutput;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.ComboBox cbbScript;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label lblthreadRunning;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown txtNumberThread;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lblTimeRunning;
		private System.Windows.Forms.RichTextBox rtbAddLogs;
		private System.Windows.Forms.Label lblFail;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label lblSuccess;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.NumericUpDown txtTimeVideoSplited;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label8;
	}
}

