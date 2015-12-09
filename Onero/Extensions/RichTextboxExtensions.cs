using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Onero
{
    public static class RichTextBoxExtensions
    {
        public static void FillValuesWithColor(this RichTextBox environmentLinksItems, Dictionary<string, DisplayResult> UrlToProcess)
        {
            environmentLinksItems.Clear();

            foreach (KeyValuePair<string, DisplayResult> url in UrlToProcess)
            {
                AppendLine(environmentLinksItems, url.Key, url.Value);
            }
        }

        private static void AppendLine(this RichTextBox environmentLinksItems, string line, DisplayResult resultCode)
        {
            int length = line.Length + 1;
            environmentLinksItems.AppendText(string.Format("{0}\n", line));
            environmentLinksItems.SelectionStart = environmentLinksItems.Text.Length - length;
            environmentLinksItems.SelectionLength = environmentLinksItems.Text.Length;
            environmentLinksItems.SelectionColor = GetColor(resultCode);
        }

        public static void ReplaceLine(this RichTextBox environmentLinksItems, string line, DisplayResult resultCode)
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                int position = environmentLinksItems.Find(line);

                int length = line.Length + 1;
                environmentLinksItems.SelectionStart = position;
                environmentLinksItems.SelectionLength = length;
                environmentLinksItems.SelectionColor = GetColor(resultCode);
            }

        }

        private static Color GetColor(DisplayResult displayResult)
        {
            switch (displayResult)
            {
                case DisplayResult.Unprocessed: return Color.Black;
                case DisplayResult.Successful: return Color.Green;
                case DisplayResult.Failed: return Color.Red;
            }

            throw new ArgumentOutOfRangeException("DisplayResult: unknown value being passed");
        }

        public static string GetClickedString(this RichTextBox richTextBox1, MouseEventArgs ea)
        {
            int positionToSearch = richTextBox1.GetCharIndexFromPosition(ea.Location);

            var wordRegex = new Regex(@"[^\r\n]+");
            var words = wordRegex.Matches(richTextBox1.Text);
            if (words.Count < 1) return null;

            var currentWord = string.Empty;
            for (var i = words.Count - 1; i >= 0; i--)
            {
                if (words[i].Index <= positionToSearch)
                {
                    currentWord = words[i].Value;
                    break;
                }
            }

            return currentWord.Trim();
        }
    }
}
