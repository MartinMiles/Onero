using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Onero.Loader.Interfaces;

namespace Onero.Collections
{
    public class Profiles
    {
        public const string DEFAULT_PROFILE_NAME = "Default";
        public const string PROFILE_SETTINGS_FILENAME = "Settings.xml";

        public static string SettingsDirectory
        {
            get { return string.Format("{0}Settings", PathPrefix); }
        }

        private static string PathPrefix
        {
            get
            {
                string prefix = String.Empty;

                #if (DEBUG)
                    prefix = "..\\..\\";
                #endif

                return prefix;
            }
        }

        public static IProfile Current
        {
            get { return Read().First(p => p.Enabled); }
        }

        public static List<Profile> Read()
        {
            var profiles = new List<Profile>();

            var profileDirectories = Directory.GetDirectories(SettingsDirectory);

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
                var directory = string.Format("{0}\\{1}", SettingsDirectory, profile.Name);

                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                var filename = string.Format("{0}\\{1}", directory, PROFILE_SETTINGS_FILENAME);
                profile.Save(filename);
            }
        }
    }
}
