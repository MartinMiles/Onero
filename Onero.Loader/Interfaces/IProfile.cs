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
    }
}
