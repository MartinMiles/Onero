using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Onero.Loader;
using Onero.Loader.Results;

namespace Onero
{
    public static class Results
    {
        private const string RESULTS_FILENAME = "results.csv";

        // TODO: Split writer IO functionality and producing results (single resp)
        // TODO: Global exception happens when folder path does not exist, for example being set to drive E:\ whereas machine has only C:\ available
        public static void WriteCSV(List<Result> NewResults, LoaderSettings settings)
        {
            var output = new List<string>();

            if (NewResults.Any())
            {
                output.Add($"{"Page URL"},{"Addons"},{"Status"},{"Addons overall"},{"Page status"},{"Time to load (ms)"}");
            }

            // TODO: Support other actions in the result - not only rules and forms
            foreach (var url in NewResults)
            {
                output.Add($"{url.Url},{""},{""},{(url.IsSuccessful ? "Successful" : "Failed")},{url.PageResult},{url.PageLoadTime}");

                foreach (var newResultCode in url.RuleResults.Where(r => settings.Profile.VerboseMode || r.Value != ResultCode.Successful))
                {
                    output.Add($"{""},{"Rule: " + newResultCode.Key.Name},{newResultCode.Value},{""}");
                }

                foreach (var newResultCode in url.FormResults.Where(r => settings.Profile.VerboseMode || r.Value != ResultCode.Successful))
                {
                    output.Add($"{""},{"Form: " + newResultCode.Key.Name},{newResultCode.Value},{""}");
                }
            }

            if (!Directory.Exists(settings.Profile.OutputDirectory))
            {
                try
                {
                    // TODO: May not be created when disk drive does not exist, ie. system does not have drive E:\ -STILL DOES NOT WORK - pages go red, probably need to set it earlier
                    Directory.CreateDirectory(settings.Profile.OutputDirectory);
                }
                catch (Exception e)
                {
                    var currectFolderRelativeDirectory = $"{Environment.CurrentDirectory.TrimEnd('\\')}Results\\{settings.Profile.Name}";
                    settings.Profile.OutputDirectory = currectFolderRelativeDirectory;
                }
            }

            File.WriteAllLines($"{settings.Profile.OutputDirectory}\\{RESULTS_FILENAME}", output);
        }
    }
}
