using System;
using System.IO;
using System.Windows.Forms;

namespace SurveyTool.ActionPlan
{
    class UserRating : IAction
    {
        private string mDirectory;
        private string mUser;

        public string RatingFile { get; private set; }
        public string[] RatingVideos { get; private set; }

        public UserRating(string user, string directory, string[] ratingVideos)
        {
            RatingFile = Path.Combine(directory, $"{user}.txt");
            RatingVideos = ratingVideos;
            mDirectory = directory;
            mUser = user;
        }

        public bool AlreadyRated => File.Exists(RatingFile);

        public override string ToString()
        {
            return "Rate user " + Path.GetDirectoryName(mDirectory);
        }

        public void SaveRating(int q1, int q2, int q3, int q4)
        {
            try {
                FileStream file = File.OpenWrite(RatingFile);
                StreamWriter output = new StreamWriter(file);

                output.WriteLine($"type: user");
                output.WriteLine($"observer: {mUser}");
                output.WriteLine($"directory: {mDirectory}");
                output.WriteLine($"videos: {string.Join("  ", RatingVideos)}");
                output.WriteLine($"answers: {q1},{q2},{q3},{q4}");
                output.Close();
                file.Close();
            } catch (Exception ex) {
                MessageBox.Show($"Could not save results file {RatingFile}: {ex.Message}");
            }
        }
    }
}
