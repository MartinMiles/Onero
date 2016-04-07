using System.Collections.Generic;
using System.IO;
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

        public IEnumerable<DataExtractItem> DataExtractors { get; set; }

        public IEnumerable<Broken.Broken> BrokenLinks { get; set; }

        public IEnumerable<Broken.Broken> BrokenImages { get; set; }

        public IEnumerable<Broken.Broken> BrokenScripts { get; set; }

        public IEnumerable<Broken.Broken> BrokenStyles { get; set; }

        public IEnumerable<Rule> Rules { get; set; }

        public IEnumerable<WebForm> Forms { get; set; }

        #endregion

        //public void Init()
        //{
        //    Rules = new CollectionOf<Rule>(CurrentProfileName).Read<Rule>().Where(r => r.Enabled);
        //    Forms = new CollectionOf<Form>(CurrentProfileName).Read<WebForm>().Where(f => f.Enabled);
        //    BrokenLinks = new CollectionOf<BrokenLink>(CurrentProfileName).Read<BrokenLink>().Where(f => f.Enabled);
        //    BrokenImages = new CollectionOf<BrokenImage>(CurrentProfileName).Read<BrokenImage>().Where(f => f.Enabled);
        //    BrokenScripts = new CollectionOf<BrokenScript>(CurrentProfileName).Read<BrokenScript>().Where(f => f.Enabled);
        //    BrokenStyles = new CollectionOf<BrokenStyle>(CurrentProfileName).Read<BrokenStyle>().Where(f => f.Enabled);
        //}
    }
}
