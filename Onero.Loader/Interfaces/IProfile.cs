namespace Onero.Loader.Interfaces
{
    public interface IProfile
    {
        string Name { get; set; }

        bool Enabled { get; set; }

        int Timeout { get; set; }

        bool CreateScreenshots { get; set; }

        bool VerboseMode { get; set; }

        bool CreateErrorLog { get; set; }

        Browser Browser { get; set; }

        string OutputDirectory { get; set; }

        // new settings for broken links verifier
        bool FindAllBrokenLinks { get; set; }

        bool FindAllBrokenImages { get; set; }

        bool FindAllBrokenScripts { get; set; }

        bool FindAllBrokenStyles { get; set; }
    }
}
