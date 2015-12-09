using System.Collections.Generic;
using System.IO;

namespace Onero.Crawler
{
    public class CrawlerSettings
    {
        #region Properties

        public IEnumerable<string> PagesToCrawl { get; set; }

        public bool CreateScreenshots { get; set; }

        private string _outputPath;

        public string OutputPath
        {
            get { return _outputPath; }
            set
            {
                _outputPath = string.Format("{0}\\", value.TrimEnd('\\'));
                
                CleanOutputDirectory();
            }
        }

        public void CleanOutputDirectory()
        {
            if (Directory.Exists(_outputPath))
            {
                Directory.Delete(_outputPath, true);
            }

            Directory.CreateDirectory(_outputPath);

            var screnshotsDir = string.Format("{0}Screenshots", _outputPath);
            if (!Directory.Exists(screnshotsDir))
            {
                Directory.CreateDirectory(screnshotsDir);
            }
        }

        public IEnumerable<Rule> Rules { get; set; }
        public IEnumerable<WebForm> Forms { get; set; }

        public bool ShowFirefox { get; set; }
        public bool Verbose { get; set; }

        public int TimeOut { get; set; }

        #endregion
    }
}
