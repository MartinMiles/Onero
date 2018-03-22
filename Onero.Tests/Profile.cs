using Onero.Loader;
using Onero.Loader.Interfaces;

namespace Onero.Tests
{
    public class Profile : IProfile
    {
        public string Name { get; set; }
        public bool Enabled { get; set; }
        public int Timeout { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool CreateScreenshots { get; set; }
        public bool VerboseMode { get; set; }
        public bool CreateErrorLog { get; set; }
        public Browser Browser { get; set; }
        public string OutputDirectory { get; set; }
        public bool FindAllBrokenLinks { get; set; }
        public bool FindAllBrokenImages { get; set; }
        public bool FindAllBrokenScripts { get; set; }
        public bool FindAllBrokenStyles { get; set; }
    }
}
