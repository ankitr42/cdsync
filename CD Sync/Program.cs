using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using CD_Sync_Portable.Properties;

namespace CD_Sync_Portable
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                Environment.CurrentDirectory = AppSettingsManager.AppInstallationDirectory;
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Application.Run(new WndMain(args));
            }
            catch(Exception ex)
            {
                Environment.CurrentDirectory = Path.GetDirectoryName(Application.ExecutablePath);

                StreamWriter errLog = new StreamWriter("errLog.log", true, System.Text.Encoding.UTF8);
                errLog.WriteLine("============================================================================================");
                errLog.WriteLine(String.Format("An exception occured in CD Sync Portable on {0} at {1}", DateTime.Now.ToLongDateString(), DateTime.Now.ToShortTimeString()));
                errLog.WriteLine();
                errLog.WriteLine();
                errLog.WriteLine("The following information about the environment is available:");
                errLog.WriteLine();
                errLog.WriteLine("Command line: " + Environment.CommandLine);
                errLog.WriteLine("Present working directory: " + Environment.CurrentDirectory);
                errLog.WriteLine("Operating system: " + Environment.OSVersion.VersionString);
                errLog.WriteLine();
                errLog.WriteLine();
                errLog.WriteLine("The following information about the exception is available:");
                errLog.WriteLine();
                errLog.WriteLine(ex.ToString());
                errLog.WriteLine("============================================================================================");
                errLog.WriteLine();
                errLog.WriteLine();
                errLog.Close();

                MessageBox.Show(Resources.msgUnhandledExceptionOccured, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}