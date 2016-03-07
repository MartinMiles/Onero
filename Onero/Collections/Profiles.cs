using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using Onero.Loader.Interfaces;

namespace Onero.Collections
{
    public class Profiles
    {
        public const string DEFAULT_PROFILE_NAME = "Default";
        public const string PROFILE_SETTINGS_FILENAME = "Settings.xml";
        public const string SETTINGS_DIRECTORY = "Settings";

        //public static string SettingsDirectory
        //{
        //    get { return string.Format("{0}Settings", PathPrefix); }
        //}

        //private static string PathPrefix
        //{
        //    get
        //    {
        //        string prefix = String.Empty;

        //        #if (DEBUG)
        //            prefix = "..\\..\\";
        //        #endif

        //        return prefix;
        //    }
        //}

        public static IProfile Current
        {
            get { return EnabledOrDefault(Read()); }
        }

        public static List<Profile> Read()
        {
            var profiles = new List<Profile>();

            var profileDirectories = Directory.GetDirectories(SETTINGS_DIRECTORY);

            if (profileDirectories.Length > 0)
            {
                foreach (string profileDirectory in profileDirectories)
                {
                    var currentDirectory = new DirectoryInfo(profileDirectory);
                    string file = string.Format("{0}\\{1}", profileDirectory, PROFILE_SETTINGS_FILENAME);
                        profiles.Add(new Profile(currentDirectory.Name, file));
                }
            }
            else
            {
                // alert no default
            }

            return profiles;
        }

        public static void Save(IEnumerable<Profile> profiles)
        {
            foreach (Profile profile in profiles)
            {
                var directory = $"{SETTINGS_DIRECTORY}\\{profile.Name}";

                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                var filename = $"{directory}\\{PROFILE_SETTINGS_FILENAME}";
                profile.Save(filename);
            }
        }

        public static Profile EnabledOrDefault(IEnumerable<Profile> profiles)
        {
            var enabled = profiles.FirstOrDefault(p => p.Enabled);
            var _default = profiles.FirstOrDefault(p => p.Name == DEFAULT_PROFILE_NAME);

            if (enabled == null && _default == null)
            {
                throw new ArgumentException("There is no default setting profile. Unable to run.");
            }

            return enabled ?? _default;
        }
    }
}
