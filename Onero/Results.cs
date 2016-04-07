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

        public static void WriteCSV(List<Result> NewResults, LoaderSettings settings)
        {
            var output = new List<string>();

            if (NewResults.Any())
            {
                output.Add($"{"Page URL"},{"Addons"},{"Status"},{"Addons overall"},{"Page status"},{"Time to load (ms)"}");
            }

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
                Directory.CreateDirectory(settings.Profile.OutputDirectory);
            }

            File.WriteAllLines($"{settings.Profile.OutputDirectory}\\{RESULTS_FILENAME}", output);
        }
    }
}
