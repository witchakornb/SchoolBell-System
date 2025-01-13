namespace SchoolBellSystem
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button btnAddPeriod;
        private System.Windows.Forms.Button btnRemovePeriod;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.TextBox txtStartTime;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.Button btnSelectSound;
        private System.Windows.Forms.Button btnPlaySound;
        private System.Windows.Forms.ListBox lstPeriods;
        private System.Windows.Forms.Label lblBellSound;
        private System.Windows.Forms.Timer bellTimer;
        private System.Windows.Forms.Label lblCurrentTime;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.btnAddPeriod = new System.Windows.Forms.Button();
            this.btnRemovePeriod = new System.Windows.Forms.Button();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.txtStartTime = new System.Windows.Forms.TextBox();
            this.lblDuration = new System.Windows.Forms.Label();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.btnSelectSound = new System.Windows.Forms.Button();
            this.btnPlaySound = new System.Windows.Forms.Button();
            this.lstPeriods = new System.Windows.Forms.ListBox();
            this.lblBellSound = new System.Windows.Forms.Label();
            this.bellTimer = new System.Windows.Forms.Timer(this.components);
            this.lblCurrentTime = new System.Windows.Forms.Label();

            // 
            // btnAddPeriod
            // 
            this.btnAddPeriod.Location = new System.Drawing.Point(10, 10);
            this.btnAddPeriod.Name = "btnAddPeriod";
            this.btnAddPeriod.Size = new System.Drawing.Size(120, 30);
            this.btnAddPeriod.Text = "Add Period";
            this.btnAddPeriod.UseVisualStyleBackColor = true;
            this.btnAddPeriod.Click += new System.EventHandler(this.btnAddPeriod_Click);

            // 
            // btnRemovePeriod
            // 
            this.btnRemovePeriod.Location = new System.Drawing.Point(10, 50);
            this.btnRemovePeriod.Name = "btnRemovePeriod";
            this.btnRemovePeriod.Size = new System.Drawing.Size(120, 30);
            this.btnRemovePeriod.Text = "Remove Period";
            this.btnRemovePeriod.UseVisualStyleBackColor = true;
            this.btnRemovePeriod.Click += new System.EventHandler(this.btnRemovePeriod_Click);

            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(10, 100);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(112, 13);
            this.lblStartTime.Text = "Start Time (HH:mm):";

            // 
            // txtStartTime
            // 
            this.txtStartTime.Location = new System.Drawing.Point(130, 97);
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.Size = new System.Drawing.Size(60, 20);
            this.txtStartTime.Text = "08:00";

            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(10, 140);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(74, 13);
            this.lblDuration.Text = "Duration (min):";

            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(130, 137);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(60, 20);
            this.txtDuration.Text = "50";

            // 
            // btnSelectSound
            // 
            this.btnSelectSound.Location = new System.Drawing.Point(10, 180);
            this.btnSelectSound.Name = "btnSelectSound";
            this.btnSelectSound.Size = new System.Drawing.Size(120, 30);
            this.btnSelectSound.Text = "Select Sound";
            this.btnSelectSound.UseVisualStyleBackColor = true;
            this.btnSelectSound.Click += new System.EventHandler(this.btnSelectSound_Click);

            // 
            // btnPlaySound
            // 
            this.btnPlaySound.Location = new System.Drawing.Point(10, 220);
            this.btnPlaySound.Name = "btnPlaySound";
            this.btnPlaySound.Size = new System.Drawing.Size(120, 30);
            this.btnPlaySound.Text = "Play Sound";
            this.btnPlaySound.UseVisualStyleBackColor = true;
            this.btnPlaySound.Click += new System.EventHandler(this.btnPlaySound_Click);

            // 
            // lstPeriods
            // 
            this.lstPeriods.FormattingEnabled = true;
            this.lstPeriods.Location = new System.Drawing.Point(200, 10);
            this.lstPeriods.Name = "lstPeriods";
            this.lstPeriods.Size = new System.Drawing.Size(220, 238);

            // 
            // lblBellSound
            // 
            this.lblBellSound.AutoSize = true;
            this.lblBellSound.Location = new System.Drawing.Point(10, 270);
            this.lblBellSound.Name = "lblBellSound";
            this.lblBellSound.Size = new System.Drawing.Size(116, 13);
            this.lblBellSound.Text = "Bell Sound: Not Selected";

            // 
            // bellTimer
            // 
            this.bellTimer.Interval = 1000; // 1 วินาที
            this.bellTimer.Tick += new System.EventHandler(this.bellTimer_Tick);

            // 
            // lblCurrentTime
            // 
            this.lblCurrentTime.AutoSize = true;
            this.lblCurrentTime.Location = new System.Drawing.Point(10, 310);
            this.lblCurrentTime.Name = "lblCurrentTime";
            this.lblCurrentTime.Size = new System.Drawing.Size(110, 13);
            this.lblCurrentTime.Text = "Current Time: --:--:--";

            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(440, 340);
            this.Controls.Add(this.btnAddPeriod);
            this.Controls.Add(this.btnRemovePeriod);
            this.Controls.Add(this.lblStartTime);
            this.Controls.Add(this.txtStartTime);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.txtDuration);
            this.Controls.Add(this.btnSelectSound);
            this.Controls.Add(this.btnPlaySound);
            this.Controls.Add(this.lstPeriods);
            this.Controls.Add(this.lblBellSound);
            this.Controls.Add(this.lblCurrentTime);
            this.Name = "MainForm";
            this.Text = "School Bell System";
        }
    }
}