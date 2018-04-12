using SurveyTool.ActionPlan;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using WMPLib;

namespace SurveyTool
{
    public partial class FrmRate : Form
    {
        private Plan mActionPlan;
        private int mIndex;
        private string mVideoFile;
        private bool mUpdating;
        private bool mTrial;
        private bool mWaitForVideoToFinish;

        public FrmRate(Plan actionPlan, bool waitForVideoToFinish)
        {
            InitializeComponent();

            mActionPlan = actionPlan;
            mIndex = -1;
            mUpdating = false;

            mWaitForVideoToFinish = waitForVideoToFinish;

            wmp.uiMode = "none";
            wmp.PlayStateChange += Wmp_PlayStateChange;
        }


        private void Wmp_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == (int)WMPPlayState.wmppsStopped) {
                wmp.Ctlcontrols.currentPosition = wmp.currentMedia.duration/2;
                wmp.Ctlcontrols.play();
                wmp.Ctlcontrols.pause();
            }
        }

        private void lnkReplay_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PlayVideo();
        }

        private void PlayVideo()
        {
            if (mVideoFile != null) {
                wmp.URL = mVideoFile;
                wmp.Ctlcontrols.play();
            }
        }

        private void CheckAdvance()
        {
            bool done = false;

            if (mTrial) {
                done = pbTRQ1.Visible && pbTRQ2.Visible && pbTRQ3.Visible && pbTRQ4.Visible;
            } else {
                done = pbURQ1.Visible && pbURQ2.Visible && pbURQ3.Visible && pbURQ4.Visible;
            }

            if (done) {
                if (ckAuto.Checked) {
                    AdvanceTrial();
                } else {
                    lnkNext.Visible = true;
                }
            }
        }

        private void AdvanceTrial(int increment = 1)
        {
            // Save the current action:
            if ((mIndex >= 0) && (increment == 1)) {
                if (mTrial) {
                    TrialRating tr = mActionPlan.Actions[mIndex] as TrialRating;
                    var q1 = rbTRQ1A1.Checked ? 1 :
                        rbTRQ1A2.Checked ? 2 :
                        rbTRQ1A3.Checked ? 3 : -1;
                    var q2 = rbTRQ2A1.Checked ? 1 :
                        rbTRQ2A2.Checked ? 2 : -1;
                    var q3 = rbTRQ3A1.Checked ? 1 :
                        rbTRQ3A2.Checked ? 2 :
                        rbTRQ3A3.Checked ? 3 : -1;
                    var q4 = rbTRQ4A1.Checked ? 1 :
                        rbTRQ4A2.Checked ? 2 :
                        rbTRQ4A3.Checked ? 3 : -1;
                    tr.SaveRating(q1, q2, q3, q4);
                } else {
                    UserRating ur = mActionPlan.Actions[mIndex] as UserRating;
                    var q1 = rbURQ1A1.Checked ? 1 :
                        rbURQ1A2.Checked ? 2 :
                        rbURQ1A3.Checked ? 3 :
                        rbURQ1A4.Checked ? 4 :
                        rbURQ1A5.Checked ? 5 : -1;
                    var q2 = rbURQ2A1.Checked ? 1 :
                        rbURQ2A2.Checked ? 2 : -1;
                    var q3 = rbURQ3A1.Checked ? 1 :
                        rbURQ3A2.Checked ? 2 : -1;
                    var q4 = rbURQ4A1.Checked ? 1 :
                        rbURQ4A2.Checked ? 2 :
                        rbURQ4A3.Checked ? 3 :
                        rbURQ4A4.Checked ? 4 : -1;
                    ur.SaveRating(q1, q2, q3, q4);
                }
            }

            // Advance to the next question
            mIndex += increment;
            if (mIndex < 0) {
                return;
            }
            if (mIndex >= mActionPlan.Actions.Count) {
                // Hooray we're done!
                MessageBox.Show("Hooray, all done! Thank you!!!", "Survey done!");
                Close();
                return;
            }

            // Reset the questionaire status:
            mUpdating = true; // don't trigger events
            Thread.Sleep(150);
            rbTRQ1A1.Checked = false;
            rbTRQ1A2.Checked = false;
            rbTRQ1A3.Checked = false;
            rbTRQ2A1.Checked = false;
            rbTRQ2A2.Checked = false;
            rbTRQ3A1.Checked = false;
            rbTRQ3A2.Checked = false;
            rbTRQ3A3.Checked = false;
            rbTRQ4A1.Checked = false;
            rbTRQ4A2.Checked = false;
            rbTRQ4A3.Checked = false;
            rbURQ1A1.Checked = false;
            rbURQ1A2.Checked = false;
            rbURQ1A3.Checked = false;
            rbURQ1A4.Checked = false;
            rbURQ1A5.Checked = false;
            rbURQ2A1.Checked = false;
            rbURQ2A2.Checked = false;
            rbURQ3A1.Checked = false;
            rbURQ3A2.Checked = false;
            rbURQ4A1.Checked = false;
            rbURQ4A2.Checked = false;
            rbURQ4A3.Checked = false;
            rbURQ4A4.Checked = false;
            pbTRQ1.Visible = false;
            pbTRQ2.Visible = false;
            pbTRQ3.Visible = false;
            pbTRQ4.Visible = false;
            pbURQ1.Visible = false;
            pbURQ2.Visible = false;
            pbURQ3.Visible = false;
            pbURQ4.Visible = false;
            lnkNext.Visible = false;
            lnkBack.Visible = mIndex > 0;
            lblTrial.Text = $"Trial {mIndex + 1} / {mActionPlan.Actions.Count}";
            mUpdating = false; // trigger events now

            if (mActionPlan.Actions[mIndex] is TrialRating) {
                TrialRating current = mActionPlan.Actions[mIndex] as TrialRating;
                lblExperiment.Text = "Trial rating";

                // Play video:
                mTrial = true;
                mVideoFile = current.RatingVideo;
                PlayVideo();
            } else {
                mTrial = false;
                UserRating current = mActionPlan.Actions[mIndex] as UserRating;
                lblExperiment.Text = "Overall user rating (showing 1st trial)";
                var video = current.RatingVideos.FirstOrDefault();
                if (video != null) {
                    mVideoFile = video;
                    PlayVideo();
                }
            }

            gbTRQ1.Visible = gbTRQ2.Visible = gbTRQ3.Visible = gbTRQ4.Visible = mTrial;
            gbURQ1.Visible = gbURQ2.Visible = gbURQ3.Visible = gbURQ4.Visible = !mTrial;

            pnlInternal.Enabled = !mWaitForVideoToFinish;
        }

        private void lnkNext_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AdvanceTrial();
        }

        private void FrmRate_Shown(object sender, System.EventArgs e)
        {
            AdvanceTrial();
        }

        private void lnkBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AdvanceTrial(-1);
        }

        private void hndTRQ1(object sender, System.EventArgs e)
        {
            if (!mUpdating)
            {
                pbTRQ1.Visible = true;
                CheckAdvance();
            }
        }

        private void hndTRQ2(object sender, System.EventArgs e)
        {
            if (!mUpdating)
            {
                pbTRQ2.Visible = true;
                CheckAdvance();
            }
        }

        private void hndTRQ3(object sender, System.EventArgs e)
        {
            if (!mUpdating)
            {
                pbTRQ3.Visible = true;
                CheckAdvance();
            }
        }

        private void hndTRQ4(object sender, System.EventArgs e)
        {
            if (!mUpdating)
            {
                pbTRQ4.Visible = true;
                CheckAdvance();
            }
        }

        private void hndURQ1(object sender, System.EventArgs e)
        {
            if (!mUpdating)
            {
                pbURQ1.Visible = true;
                CheckAdvance();
            }
        }

        private void hndURQ2(object sender, System.EventArgs e)
        {
            if (!mUpdating)
            {
                pbURQ2.Visible = true;
                CheckAdvance();
            }
        }

        private void hndURQ3(object sender, System.EventArgs e)
        {
            if (!mUpdating)
            {
                pbURQ3.Visible = true;
                CheckAdvance();
            }
        }

        private void hndURQ4(object sender, System.EventArgs e)
        {
            if (!mUpdating)
            {
                pbURQ4.Visible = true;
                CheckAdvance();
            }
        }

        private void hndPlayStateChanged(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 8)
            {
                pnlInternal.Enabled = true;
            }
        }
    }
}
