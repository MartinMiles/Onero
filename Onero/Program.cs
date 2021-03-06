﻿using System;
using System.Windows.Forms;
using System.Xml;
using Onero.Collections;
using Onero.Dialogs;
using Onero.Helper.ErrorHandling;
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

            // TODO: Support console run, passing profile parameter (an / or maybe configuraion or optional)

            try
            {
                var settings = new LoaderSettings { Profile = Profiles.Current };
                Application.Run(new MainForm(settings));
            }
            catch (XmlException e)
            {
                MessageBox.Show(CONFIGURATION_FAILED);
                new ErrorManager(Profiles.Current).Fix(e, CONFIGURATION_FAILED);
            }
#if DEBUG
#else       
            catch (Exception e)
            {
                MessageBox.Show(GENERAL_EXCEPTION);
                new ErrorManager(Profiles.Current).Fix(e, GENERAL_EXCEPTION);
            }
#endif
        }
    }
}