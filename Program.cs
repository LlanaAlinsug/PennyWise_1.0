using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PennyWise
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Welcome());
            }
            catch (Exception ex)
            {
                // Handle the exception here - display an error message
                MessageBox.Show($"An error occurred: {ex.Message}\nPlease restart & report bug to PennyWise developers.",
                                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Define public static variables for ID reference
        public static int MASTER_UserID;
        public static int MASTER_LoginID;

        // Define public static variables for notif limit
        public static int PlannerNotifLimit;

        // Define public static variables for scheme percentage
        public static float NeedsPercentage = 0.5f;
        public static float WantsPercentage = 0.3f;
        public static float FundsPercentage = 0.2f;

        // Define public static variable for amount update dependency
        // Assures that Needs, Wants, and Funds are calculated upon scheme customization
        public static bool P_SchemeCustomizeUpdate = false;

        // Define public static variables for closing the form
        public static bool ApplicationExit = true;

        // Define public static variables for limiting filter forms to 1 open only
        public static int IE_DateFilterFormLimit = 0;
        public static int IE_SourceFilterFormLimit = 0;
    }
}
