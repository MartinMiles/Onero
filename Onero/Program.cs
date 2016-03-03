using System;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml;
using Onero.Collections;
using Onero.Dialogs;
using Onero.Loader;

namespace Onero
{
    static class Program
    {
        private const string CONFIGURATION_FAILED = "Error while processing configuration file";
        private const string GENERAL_EXCEPTION = "An error has occured. Sorry for inconvenience";

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                var settings = new LoaderSettings { Profile = Profiles.Current };
                Application.Run(new MainForm(settings));
            }
            catch (XmlException)
            {
                MessageBox.Show(CONFIGURATION_FAILED);
            }
            //catch (Exception)
            //{
            //    MessageBox.Show(GENERAL_EXCEPTION);
            //}
        }
    }
}
