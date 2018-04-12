using System;
using System.IO;
using System.Windows.Forms;

namespace SurveyTool.ActionPlan
{
    class TrialRating: IAction
    {
        private string mUser;
        public string RatingFile { get; private set; }
        public string RatingVideo { get; private set; }

        public TrialRating(string user, string ratingVideo)
        {
            RatingFile = ratingVideo + $"-{user}.txt";
            RatingVideo = ratingVideo;
            mUser = user;
        }

        public bool AlreadyRated => File.Exists(RatingFile);

        public override string ToString()
        {
            return "Rate trial " + RatingVideo;
        }

        public void SaveRating(int q1, int q2, int q3, int q4)
        {
            try {
                FileStream file = File.OpenWrite(RatingFile);
                StreamWriter output = new StreamWriter(file);

                output.WriteLine($"type: trial");
                output.WriteLine($"observer: {mUser}");
                output.WriteLine($"video: {RatingVideo}");
                output.WriteLine($"answers: {q1},{q2},{q3},{q4}");
                output.Close();
                file.Close();
            } catch (Exception ex) {
                MessageBox.Show($"Could not save results file {RatingFile}: {ex.Message}");
            }
        }
    }
}
