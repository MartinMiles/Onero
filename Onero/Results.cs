﻿using System;
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
                output.Add(string.Format("{0},{1},{2},{3},{4},{5}", "Page URL", "Addons", "Status", "Addons overall", "Page status", "Time to load (ms)"));
            }

            foreach (var url in NewResults)
            {
                output.Add(string.Format("{0},{1},{2},{3},{4},{5}", url.Url, String.Empty, String.Empty, url.IsSuccessful ? "Successful" : "Failed", url.PageResult, url.PageLoadTime));

                foreach (var newResultCode in url.RuleResults.Where(r => settings.Profile.VerboseMode || r.Value != ResultCode.Successful))
                {
                    output.Add(string.Format("{0},{1},{2},{3}", String.Empty, "Rule: " + newResultCode.Key.Name, newResultCode.Value, String.Empty));
                }

                foreach (var newResultCode in url.FormResults.Where(r => settings.Profile.VerboseMode || r.Value != ResultCode.Successful))
                {
                    output.Add(string.Format("{0},{1},{2},{3}", String.Empty, "Form: " + newResultCode.Key.Name, newResultCode.Value, String.Empty));
                }
            }

            if (!Directory.Exists(settings.Profile.OutputDirectory))
            {
                Directory.CreateDirectory(settings.Profile.OutputDirectory);
            }

            File.WriteAllLines(string.Format("{0}\\{1}", settings.Profile.OutputDirectory, RESULTS_FILENAME), output);
        }
    }
}
