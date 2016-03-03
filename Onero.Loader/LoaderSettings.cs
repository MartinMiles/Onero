using System.Collections.Generic;
using System.IO;
using Onero.Loader.Broken;
using Onero.Loader.Interfaces;

namespace Onero.Loader
{
    public class LoaderSettings
    {
        #region Properties

        public IEnumerable<string> PagesToCrawl { get; set; }

        public IProfile Profile { get; set; }

        public void CleanOutputDirectory()
        {
            if (Directory.Exists(Profile.OutputDirectory))
            {
                Directory.Delete(Profile.OutputDirectory, true);
            }
        }

        public IEnumerable<Broken.Broken> BrokenLinks { get; set; }

        public IEnumerable<Broken.Broken> BrokenImages { get; set; }

        public IEnumerable<Rule> Rules { get; set; }

        public IEnumerable<WebForm> Forms { get; set; }

        #endregion
    }
}
