using System;
using System.Windows.Forms;

namespace SurveyTool
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FrmStart start = new FrmStart();
            Application.Run(start);

            if (start.StartPlan) {
                FrmRate rate = new FrmRate(start.ActionPlan, start.WaitForVideoToFinishBeforeRating);
                Application.Run(rate);
            }
        }
    }
}
