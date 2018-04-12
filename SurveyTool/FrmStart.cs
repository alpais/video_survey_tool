using SurveyTool.ActionPlan;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SurveyTool
{
    public partial class FrmStart : Form
    {
        private const string VIDEO_FILE_PATTERN = "*.MP4";
        public Plan ActionPlan { get; private set; }
        public bool StartPlan { get; private set; }
        public bool WaitForVideoToFinishBeforeRating { get; private set; }

        public FrmStart()
        {
            ActionPlan = null;
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, System.EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.SelectedPath = txtUser.Text;
            if (folderBrowser.ShowDialog() == DialogResult.OK) {
                txtLocation.Text = folderBrowser.SelectedPath;
            }
        }

        private void btnCreate_Click(object sender, System.EventArgs e)
        {
            try {
                // Reset state:
                txtActionPlan.Text = "";
                ActionPlan = null;
                btnStart.Enabled = false;

                // Compute new plan:
                string user = txtUser.Text.ToLower();
                string location = txtLocation.Text;

                if (string.IsNullOrWhiteSpace(user) || user.Any(Char.IsWhiteSpace)) {
                    throw new Exception("Person name cannot be empty or contain spaces.");
                }

                if (string.IsNullOrWhiteSpace(location) || !Directory.Exists(location)) {
                    throw new Exception("Video location cannot be empty and must exist.");
                }

                PlanType planType = PlanType.PerUser;
                if (rbTrial.Checked) {
                    planType = PlanType.PerTrialNo;
                } else if (rbRandom.Checked) {
                    planType = PlanType.Random;
                }

                if ((planType != PlanType.PerUser) && cbUserRating.Checked) {
                    throw new Exception("Plan type invalid: cannot include user ratings if plan is not per-user.");
                }

                ActionPlan = new Plan(user, location, planType, cbUserRating.Checked, VIDEO_FILE_PATTERN);
                txtActionPlan.Text = ActionPlan.ToString();
                btnStart.Enabled = true;

            } catch (Exception ex) {
                MessageBox.Show(this, ex.Message, "Cannot create action plan");
            }
        }

        private void rbTrial_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTrial.Checked) {
                cbUserRating.Checked = false;
            }
        }

        private void rbRandom_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRandom.Checked) {
                cbUserRating.Checked = false;
            }
        }

        private void FrmStart_Shown(object sender, EventArgs e)
        {
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            StartPlan = true;
            Close();
        }

        private void ckWaitForVideoToFinish_CheckedChanged(object sender, EventArgs e)
        {
            WaitForVideoToFinishBeforeRating = ckWaitForVideoToFinish.Checked;
        }
    }
}
