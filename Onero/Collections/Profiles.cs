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
        public const string SETTINGS_DIRECTORY = "Settings";

        public static IProfile Current => EnabledOrDefault(Read());

        public static List<Profile> Read()
        {
            // TODO: Why is this called so multiple times? Refactor that!

            var profiles = new List<Profile>();

            if (!Directory.Exists(SETTINGS_DIRECTORY))
            {
                Directory.CreateDirectory(SETTINGS_DIRECTORY);
            }

            var profileDirectories = Directory.GetDirectories(SETTINGS_DIRECTORY);

            if (profileDirectories.Length == 0)
            {
                var defaultDirectory = $"{SETTINGS_DIRECTORY}\\{DEFAULT_PROFILE_NAME}";

                Directory.CreateDirectory(defaultDirectory);
                profileDirectories = new[] {defaultDirectory};
            }

            foreach (string profileDirectory in profileDirectories)
            {
                var currentDirectory = new DirectoryInfo(profileDirectory);
                string settingsFile = $"{profileDirectory}\\{PROFILE_SETTINGS_FILENAME}";

                if (!File.Exists(settingsFile))
                {
                    string profileName = profileDirectory.Split('\\')[1];
                    CreateSettingsFile(profileName, settingsFile);
                }

                profiles.Add(new Profile(currentDirectory.Name, settingsFile));
            }

            return profiles;
        }

        private static void CreateSettingsFile(string profileName, string settingsFile)
        {
            var profile = new Profile(profileName);
            profile.Save(settingsFile);
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
