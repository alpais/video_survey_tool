namespace SurveyTool
{
    partial class FrmStart
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
            if (disposing && (components != null)) {
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
            this.lblUser = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.rbDirect = new System.Windows.Forms.RadioButton();
            this.rbTrial = new System.Windows.Forms.RadioButton();
            this.rbRandom = new System.Windows.Forms.RadioButton();
            this.cbUserRating = new System.Windows.Forms.CheckBox();
            this.txtActionPlan = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.ckWaitForVideoToFinish = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(13, 18);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(173, 13);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "Person doing the rating (first name):";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(13, 63);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(80, 13);
            this.lblLocation.TabIndex = 1;
            this.lblLocation.Text = "Video directory:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Action Plan:";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(14, 34);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(417, 20);
            this.txtUser.TabIndex = 3;
            this.txtUser.Text = "vlad";
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(14, 79);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(417, 20);
            this.txtLocation.TabIndex = 4;
            this.txtLocation.Text = "E:\\Videos";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(333, 105);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(98, 24);
            this.btnBrowse.TabIndex = 5;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // rbDirect
            // 
            this.rbDirect.AutoSize = true;
            this.rbDirect.Checked = true;
            this.rbDirect.Location = new System.Drawing.Point(28, 132);
            this.rbDirect.Name = "rbDirect";
            this.rbDirect.Size = new System.Drawing.Size(109, 17);
            this.rbDirect.TabIndex = 6;
            this.rbDirect.TabStop = true;
            this.rbDirect.Text = "Trial user ordering";
            this.rbDirect.UseVisualStyleBackColor = true;
            // 
            // rbTrial
            // 
            this.rbTrial.AutoSize = true;
            this.rbTrial.Location = new System.Drawing.Point(28, 155);
            this.rbTrial.Name = "rbTrial";
            this.rbTrial.Size = new System.Drawing.Size(124, 17);
            this.rbTrial.TabIndex = 8;
            this.rbTrial.Text = "Trial number ordering";
            this.rbTrial.UseVisualStyleBackColor = true;
            this.rbTrial.CheckedChanged += new System.EventHandler(this.rbTrial_CheckedChanged);
            // 
            // rbRandom
            // 
            this.rbRandom.AutoSize = true;
            this.rbRandom.Location = new System.Drawing.Point(28, 178);
            this.rbRandom.Name = "rbRandom";
            this.rbRandom.Size = new System.Drawing.Size(125, 17);
            this.rbRandom.TabIndex = 9;
            this.rbRandom.Text = "Random trial ordering";
            this.rbRandom.UseVisualStyleBackColor = true;
            this.rbRandom.CheckedChanged += new System.EventHandler(this.rbRandom_CheckedChanged);
            // 
            // cbUserRating
            // 
            this.cbUserRating.AutoSize = true;
            this.cbUserRating.Checked = true;
            this.cbUserRating.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbUserRating.Location = new System.Drawing.Point(28, 201);
            this.cbUserRating.Name = "cbUserRating";
            this.cbUserRating.Size = new System.Drawing.Size(128, 17);
            this.cbUserRating.TabIndex = 10;
            this.cbUserRating.Text = "User rating at the end";
            this.cbUserRating.UseVisualStyleBackColor = true;
            // 
            // txtActionPlan
            // 
            this.txtActionPlan.Location = new System.Drawing.Point(14, 258);
            this.txtActionPlan.Multiline = true;
            this.txtActionPlan.Name = "txtActionPlan";
            this.txtActionPlan.ReadOnly = true;
            this.txtActionPlan.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtActionPlan.Size = new System.Drawing.Size(416, 223);
            this.txtActionPlan.TabIndex = 11;
            this.txtActionPlan.WordWrap = false;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(333, 200);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(98, 23);
            this.btnCreate.TabIndex = 12;
            this.btnCreate.Text = "Create plan";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 242);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Action plan:";
            // 
            // btnStart
            // 
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(338, 487);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(98, 23);
            this.btnStart.TabIndex = 14;
            this.btnStart.Text = "Start rating";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // ckWaitForVideoToFinish
            // 
            this.ckWaitForVideoToFinish.AutoSize = true;
            this.ckWaitForVideoToFinish.Location = new System.Drawing.Point(14, 492);
            this.ckWaitForVideoToFinish.Name = "ckWaitForVideoToFinish";
            this.ckWaitForVideoToFinish.Size = new System.Drawing.Size(196, 17);
            this.ckWaitForVideoToFinish.TabIndex = 15;
            this.ckWaitForVideoToFinish.Text = "Watch the entire video before rating";
            this.ckWaitForVideoToFinish.UseVisualStyleBackColor = true;
            this.ckWaitForVideoToFinish.CheckedChanged += new System.EventHandler(this.ckWaitForVideoToFinish_CheckedChanged);
            // 
            // FrmStart
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(453, 522);
            this.Controls.Add(this.ckWaitForVideoToFinish);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.txtActionPlan);
            this.Controls.Add(this.cbUserRating);
            this.Controls.Add(this.rbRandom);
            this.Controls.Add(this.rbTrial);
            this.Controls.Add(this.rbDirect);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmStart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Survey start settings";
            this.Shown += new System.EventHandler(this.FrmStart_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.RadioButton rbDirect;
        private System.Windows.Forms.RadioButton rbTrial;
        private System.Windows.Forms.RadioButton rbRandom;
        private System.Windows.Forms.CheckBox cbUserRating;
        private System.Windows.Forms.TextBox txtActionPlan;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.CheckBox ckWaitForVideoToFinish;
    }
}