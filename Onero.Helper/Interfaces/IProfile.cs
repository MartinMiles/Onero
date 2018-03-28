using Onero.Helper.Browsers;

namespace Onero.Helper.Interfaces
{
    public interface IProfile
    {
        string Name { get; set; }

        bool Enabled { get; set; }

        int Timeout { get; set; }

        int Width { get; set; }

        int Height { get; set; }

        bool CreateScreenshots { get; set; }

        bool VerboseMode { get; set; }

        bool CreateErrorLog { get; set; }

        bool SendErrorsAndStats { get; set; }

        SupportedBrowser Browser { get; set; }

        string OutputDirectory { get; set; }

        bool FindAllBrokenLinks { get; set; }

        bool FindAllBrokenImages { get; set; }

        bool FindAllBrokenScripts { get; set; }

        bool FindAllBrokenStyles { get; set; }
    }
}
