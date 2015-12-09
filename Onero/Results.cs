using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Onero.Crawler;
using Onero.Crawler.Results;

namespace Onero
{
    public static class Results
    {
        private const string RESULTS_FILENAME = "results.csv";

        public static void WriteCSV(List<Result> NewResults, CrawlerSettings settings)
        {
            var output = new List<string>();

            if (NewResults.Any())
            {
                output.Add(string.Format("{0},{1},{2},{3},{4},{5}", "Page URL", "Addons", "Status", "Addons status", "Page Status", "Time to load (ms)"));
            }

            foreach (var url in NewResults)
            {
                output.Add(string.Format("{0},{1},{2},{3},{4},{5}", url.Url, String.Empty, String.Empty, url.IsSuccessful, url.PageResult, url.PageLoadTime));

                foreach (var newResultCode in url.RuleResults.Where(r => settings.Verbose || r.Value != ResultCode.Successfull))
                {
                    output.Add(string.Format("{0},{1},{2},{3}", String.Empty, "Rule: " + newResultCode.Key.Name, newResultCode.Value, String.Empty));
                }

                foreach (var newResultCode in url.FormResults.Where(r => settings.Verbose || r.Value != ResultCode.Successfull))
                {
                    output.Add(string.Format("{0},{1},{2},{3}", String.Empty, "Form: " + newResultCode.Key.Name, newResultCode.Value, String.Empty));
                }
            }

            File.WriteAllLines(string.Format("{0}{1}", settings.OutputPath, RESULTS_FILENAME), output);
        }
    }
}
